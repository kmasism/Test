using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui;
using UpgradeHelpers.Gui.Controls;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_Aircraft_Change
		: System.Windows.Forms.Form
	{

		//******************************************************************************************


		//===================
		// Private Type Defs
		//===================

		[Serializable]
		private struct MOD_Seller_Buyer_type
		{
			public int comp_id;
			public int contact_id;
			public string Contact_Type;
			public double percent;
			public string business_type;
			public static MOD_Seller_Buyer_type CreateInstance()
			{
				MOD_Seller_Buyer_type result = new MOD_Seller_Buyer_type();
				result.Contact_Type = String.Empty;
				result.business_type = String.Empty;
				return result;
			}
		}

		//==================
		// Public Variables
		//==================
		public string Trans_Type = ""; //Will contain the 2-chr transaction type, put here by the 'frm_Aircraft' form
		public int Journal_ID = 0; //Sent to the 'frm_Sold_Financial' form,
		public int Aircraft_ID = 0; //Sent to the 'frm_Sold_Financial' form,
		public bool Clear_Availability = false;
		public bool Clear_Base = false;
		public bool Clear_Contacts = false;
		public bool Clear_Specifications = false;
		public bool Aircraft_Settings = false;
		public string AvailListedDate = "";
		public bool AircraftUsed = false; // RTW - 3/31/2004 - NEW FLAG SET FROM SETTINGS FORM TO INDICATE IF AIRCRAFT IS NOW USED.
		public int ac_journ_id = 0; //aey 5/24/05  historical ac
		public int VS_journ_id = 0; // Tom 5/24/2010 to hold the journal ID for  verified sale record VS
		//===================
		// Private Variables
		//===================
		private bool PastNewToMarket = false; //   FLAG INDICATING IF THERE IS A PAST NEW TO MARKET TRANSACTION
		private string Seller_Fraction_Expires_Date = ""; // date the sellers fractions are set to expire
		private bool Been_Here = false;
		private string UI_Seller_Buyer = "";
		private bool Aircraft_Exclusive = false;
		private string Aircraft_Serial_Number = ""; // stores the full serial number of the current aircraft
		private string Aircraft_LifeCycle_Stage = ""; // stores stage of the current aircraft
		private string[] arr_Transmit_Fields = null; // array of field names to be sent to the transmit file
		private string Aircraft_Ownership_Type = ""; //W - Wholly Owned, S - Shared Ownership,
		private int gbl_ac_amod_id = 0; //From the Aircraft row
		private int MOD_Journal_ID = 0; //From the 'frm_Aircraft' form's history panel
		private string MOD_Trans_Type = "";
		private MOD_Seller_Buyer_type MOD_Seller = MOD_Seller_Buyer_type.CreateInstance();
		private MOD_Seller_Buyer_type MOD_Buyer = MOD_Seller_Buyer_type.CreateInstance();
		private string Transaction_Type = ""; //WSEUEU', WSEUDP', etc., generated in the 'Build_Transaction_Type'
		private bool cbo_Trans_Seller_Click_SKIP = false;
		private bool cbo_Trans_Buyer_Click_SKIP = false;

		private int Seller_Comp_ID = 0;
		private int Seller_Contact_ID = 0;
		private string Seller_Contact_Type = "";
		private string Seller_Company_Business_Type = "";
		private string Seller_Aircraft_Business_Type = "";
		private string Seller_Comp_Name = "";
		private string Seller_Percentage = "";

		private int Buyer_row = 0;

		private int Buyer_Comp_ID = 0;
		private int Buyer_Contact_ID = 0;
		private string Buyer_Contact_Type = "";
		private string Buyer_Percentage = "";
		private string Buyer_Company_Business_Type = "";
		private string Buyer_Primary_Business_Type = "";
		private string Buyer_Comp_Name = "";

		private int Registered_As_Owner_comp_id = 0;
		private int Registered_As_Owner_contact_id = 0;
		private int Registered_As_Buyer_comp_id = 0;
		private int Registered_As_Buyer_contact_id = 0;
		private int POC_Row = 0;
		private int Old_POC_comp_id = 0;
		private int New_POC_comp_id = 0;
		private bool Preserve_POC = false; //aey 9/2/04
		private string gPOC_Flag = ""; //aey 9/3/04
		private bool Prior_Availability = false;
		private int[] grid_Array_comp_id = null; //Holds the 'comp_id'
		private string[] grid_Array_comp_Bus_Type = null; //Holds the 'comp_Company_Business_Type'
		private int[] grid_Array_contact_id = null; //Holds the 'contact_id'
		private string[] grid_Array_contact_type = null; //Holds the 'contact_type'
		private string[] grid_Array_POC = null; //Holds the 'cref_primary_poc_flag'
		private string[] grid_Array_comp_name = null; //Holds the 'comp_name'
		private string[] grid_Array_fraction_expire_date = null; //Holds the 'fraction expiration date'
		private int EventCompID = 0;
		private int EventContactID = 0;

		private DialogResult SellFracTransPHtoPH = (DialogResult) 0;
		private DialogResult RespShareSale = (DialogResult) 0;
		private bool mvHasFocus = false;
		private bool bComingBackFromTransaction = false;

		private modGlobalVars.e_find_form_action_types tCompFind_ActionTypes = (modGlobalVars.e_find_form_action_types) 0;

		private int Found_Contact_Id = 0;
		private int Found_Company_Id = 0;
		public string Companies_Connected_List = "";

		private string Lessor_Comp_Name_1 = "";
		private string Lessee_Comp_Name_1 = "";
		public frm_Aircraft_Change()
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


		public void Find_Orphaned_Company(int journ_id)
		{

			string Query = "";
			ADORecordSetHelper ado_orp = new ADORecordSetHelper();
			string Query2 = "";


			try
			{


				if (journ_id > 0)
				{
					Query = " SELECT    dbo.Company.comp_id, dbo.Company.comp_journ_id ";
					Query = $"{Query} FROM     dbo.Company ";
					Query = $"{Query} INNER JOIN dbo.Journal ON dbo.Company.comp_journ_id = dbo.Journal.journ_id ";
					Query = $"{Query} INNER JOIN dbo.Journal_Category ON dbo.Journal.journ_subcategory_code = dbo.Journal_Category.jcat_subcategory_code ";
					Query = $"{Query} LEFT OUTER JOIN dbo.Aircraft_Reference ON dbo.Company.comp_id = dbo.Aircraft_Reference.cref_comp_id AND dbo.Company.comp_journ_id = dbo.Aircraft_Reference.cref_journ_id";
					Query = $"{Query} WHERE        (dbo.Company.comp_journ_id > 0) AND (dbo.Aircraft_Reference.cref_id IS NULL) ";
					Query = $"{Query} AND (dbo.Journal.journ_subcategory_code <> 'ACDOC') AND (dbo.Journal.journ_subcategory_code <> 'CNAME') ";
					Query = $"{Query} AND (dbo.Journal_Category.jcat_category_code = 'AH') ";
					Query = $"{Query}  And journ_id = {journ_id.ToString()}";

					ado_orp.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(ado_orp.BOF && ado_orp.EOF))
					{

						while(!ado_orp.EOF)
						{

							Query2 = $"DELETE FROM Company WHERE comp_id = {Convert.ToString(ado_orp["comp_id"])} and comp_journ_id = {journ_id.ToString()}";

							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query2;
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();

							ado_orp.MoveNext();
						};
					}

					ado_orp.Close();
					ado_orp = null;
				}
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Find_Orphaned_Company_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}


		}

		private void Refresh_Form_Controls()
		{
			Control Control_Obj = null;

			//UPGRADE_WARNING: (2065) Form property frm_Aircraft_Change.Controls has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
			foreach (Control Control_ObjIterator in ContainerHelper.Controls(this))
			{
				Control_Obj = Control_ObjIterator;
				if ((Control_Obj is Panel) || (Control_Obj is ListBox))
				{
					Control_Obj.Refresh();
				}
				//Control_Obj
				Control_Obj = default(Control);
			}

		}

		private bool CheckFractionalGrid()
		{
			// check to see if buy percent = sell percent
			bool result = false;
			DialogResult Ans = (DialogResult) 0;

			double BuyPct = 0;
			double SellPct = 0;

			int tempForEndVar = grd_Fractional.RowsCount - 1;
			for (int K = 1; K <= tempForEndVar; K++)
			{
				grd_Fractional.CurrentRowIndex = K;
				grd_Fractional.CurrentColumnIndex = 4;
				if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Seller")
				{
					grd_Fractional.CurrentColumnIndex = 3;
					SellPct += Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString());
				}
				else if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer"))
				{ 
					grd_Fractional.CurrentColumnIndex = 3;
					BuyPct += Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString());
				}

			}

			if (chk_Awaiting_Documentation.CheckState == CheckState.Unchecked)
			{
				result = true;

				if (Math.Abs(BuyPct) == Math.Abs(SellPct))
				{
					return true;
				}
				else
				{
					Ans = MessageBox.Show("Buy Percentages do not equal Sell Percentages, Continue?", "Buy/Sell Percentage Totals", MessageBoxButtons.YesNo);
					if (Ans == System.Windows.Forms.DialogResult.Yes)
					{
						result = true;
					}

				}
			}
			else
			{
				result = true;
			}

			return result;
		}

		private void CheckPermission()
		{
			//aey 9/27/04 make sure that the transaction is not interrupted by someone else


			string strOwner = modCommon.AircraftLocked(modAdminCommon.gbl_Aircraft_ID, MOD_Journal_ID);

			//If someone has this locked who is not "me" then say so and get out
			if (strOwner != "False" && strOwner != Convert.ToString(modAdminCommon.snp_User["user_id"]))
			{
				MessageBox.Show($"This Aircraft is locked into a transaction by {strOwner}.{Environment.NewLine}Transaction cancelled.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				this.Close();
			}
			else
			{
				//Lock the record
				modCommon.LockAircraft(modAdminCommon.gbl_Aircraft_ID, MOD_Journal_ID, Convert.ToString(modAdminCommon.snp_User["user_id"]));
			}
			return;


			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			modAdminCommon.Report_Error($"CheckPermission_Error: [{Information.Err().Description}] E#:{Information.Err().Number.ToString()} usr:{Convert.ToString(modAdminCommon.snp_User["user_id"])} lock:{strOwner}");


		}

		private bool CheckForNUTransaction(int inACID)
		{


			string Query = "SELECT journ_newac_flag ";
			Query = $"{Query}FROM Journal ";
			Query = $"{Query}WHERE journ_ac_id = {inACID.ToString()} ";
			Query = $"{Query}AND journ_newac_flag = 'Y'";

			return modAdminCommon.Exist(Query);

		}

		private int Get_Exclusive_Comp_id(string inQuery)
		{
			//aey 10/19/2004
			//called by transaction_save_fractional_sale

			int result = 0;
			ADORecordSetHelper Ado_Exclusive = new ADORecordSetHelper();

			try
			{

				Ado_Exclusive.Open(inQuery, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);
				if (Ado_Exclusive.EOF && Ado_Exclusive.BOF)
				{
					result = 0;
					Ado_Exclusive.Close();
					Ado_Exclusive = null;
					return result;
				}
				Ado_Exclusive.MoveFirst();
				result = Convert.ToInt32(Conversion.Val($"{Convert.ToString(Ado_Exclusive["cref_comp_id"])}"));
				Ado_Exclusive.Close();
				Ado_Exclusive = null;
			}
			catch (System.Exception excep)
			{

				result = 0;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("FS Sale", $"GetExclusive_error {Information.Err().Number.ToString()} {excep.Message}");
			}
			return result;
		}

		private void HideFractionalGrid()
		{

			string temp_name = "";
			pnl_Seller.Visible = true;
			pnl_Buyer.Visible = true;
			pnl_Fractional_Seller.Visible = false;
			pnl_Verify.Visible = true;
			cmdShowFractionalGrid.Visible = true;

			// If grd_Fractional.Cols < 4 Then grd_Fractional.Cols = 4
			int tempForEndVar = grd_Fractional.RowsCount - 1;
			for (int Row = 1; Row <= tempForEndVar; Row++)
			{
				grd_Fractional.CurrentRowIndex = Row;
				grd_Fractional.CurrentColumnIndex = 4;

				if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Seller" || grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessor")
				{
					modAircraftChange.Display_Seller_Info(lst_Seller, cbo_Trans_Seller, grid_Array_comp_id[Row], grid_Array_contact_id[Row], ref Seller_Contact_Type, ref Seller_Aircraft_Business_Type, ref Seller_Company_Business_Type, ref Seller_Comp_Name);
					grd_Fractional.CurrentRowIndex = Row;
					grd_Fractional.CurrentColumnIndex = 3;

					if (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L")
					{
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							lbl_Step_3.Text = $"STEP 3: Lessor ({Strings.FormatNumber(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString()), 3, TriState.False, TriState.False, TriState.True)})";
							Seller_Percentage = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.True);
						}
						else
						{
							lbl_Step_3.Text = "STEP 3: Lessor (0)";
							Seller_Percentage = "0";
						}
					}
					else
					{
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							lbl_Step_3.Text = $"STEP 3: Seller ({Strings.FormatNumber(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString()), 3, TriState.False, TriState.False, TriState.True)})";
							Seller_Percentage = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.True);
						}
						else
						{
							lbl_Step_3.Text = "STEP 3: Seller (0)";
							Seller_Percentage = "0";
						}
					}

					lbl_Step_3.Refresh();

					if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
					{
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							lbl_Step_4.Text = $"STEP 4:{Environment.NewLine}Buyer ({Strings.FormatNumber(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString()), 3, TriState.False, TriState.False, TriState.True)})";
							Buyer_Percentage = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.True);
						}
						else
						{
							lbl_Step_4.Text = $"STEP 4:{Environment.NewLine}Buyer (0)";
							Buyer_Percentage = "0";
						}

						lbl_Step_4.Refresh();

					}

				}
				else if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer" || grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessee")
				{ 

					temp_name = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString();


					modAircraftChange.Display_Buyer_Info(lst_Buyer, cbo_Trans_Buyer, grid_Array_comp_id[Row], grid_Array_contact_id[Row], ref Buyer_Company_Business_Type, ref Buyer_Comp_Name);

					grd_Fractional.CurrentRowIndex = Row;
					grd_Fractional.CurrentColumnIndex = 3;
					if (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L")
					{
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{
							lbl_Step_4.Text = $"STEP 4: Lessee ({Strings.FormatNumber(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString()), 3, TriState.False, TriState.False, TriState.True)})";
							Buyer_Percentage = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.True);
						}
						else
						{
							lbl_Step_4.Text = "STEP 4: Lessee (0)";
							Buyer_Percentage = "0";
						}
					}
					else
					{

						// added MSW 5/20/19
						if (Trans_Type.Substring(0, Math.Min(2, Trans_Type.Length)).ToUpper() == "SS")
						{
							lbl_Step_4.Text = $"STEP 4: {temp_name} ({Strings.FormatNumber(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString()), 3, TriState.False, TriState.False, TriState.True)})";
							Buyer_Percentage = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.True);
						}
						else if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
						{ 
							lbl_Step_4.Text = $"STEP 4: Seller ({Strings.FormatNumber(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString()), 3, TriState.False, TriState.False, TriState.True)})";
							Buyer_Percentage = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.True);
						}
						else
						{
							lbl_Step_4.Text = "STEP 4: Seller (0)";
							Buyer_Percentage = "0";
						}
					}

					lbl_Step_4.Refresh();

				} // found the seller
			}
			// rtw - change
			cmd_Commit_Transaction.Enabled = Transaction_OK();

		}

		private void ShowFractionalGrid()
		{

			pnl_Seller.Visible = false;
			pnl_Buyer.Visible = false;
			pnl_Fractional_Seller.Visible = true;
			pnl_Verify.Visible = false;
			cmd_Commit_Transaction.Enabled = false;
			grd_Fractional.Redraw = true;

		}

		//  each row in the grd_fractional' grid
		//UPGRADE_WARNING: (2050) MSComCtl2.MonthView Event cal_transaction_date.DateClick was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2050
		private void cal_transaction_date_DateClick(System.DateTime DateClicked)
		{

			string M = "";

			txt_transaction_date.Text = DateClicked.ToString("d");

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// IF not Valid transaction date
			//    Notify user and wait
			// ENDIF
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			if (!Information.IsDate(DateTime.Parse(txt_transaction_date.Text).ToString("d")))
			{
				M = "The transaction date entered is not a valid date. Please correct.";
				MessageBox.Show(M, "ILLEGAL DATE", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cal_transaction_date.SetDate(DateTime.Parse(txt_transaction_date.Text));
			}
			else if (((int) DateAndTime.DateDiff("d", DateTime.Parse(modAdminCommon.DateToday), DateTime.Parse(txt_transaction_date.Text), FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)) > 0)
			{ 
				M = "The transaction date must be equal to or earlier than TODAY";
				MessageBox.Show(M, "ILLEGAL DATE", MessageBoxButtons.OK, MessageBoxIcon.Error);
				cal_transaction_date.SetDate(DateTime.Parse(txt_transaction_date.Text));
			}

		}

		private void cal_transaction_date_Enter(Object eventSender, EventArgs eventArgs) => mvHasFocus = true;


		private void cbo_ac_asking_SelectionChangeCommitted(Object eventSender, EventArgs eventArgs)
		{

			txt_ac_asking_price.Visible = cbo_ac_asking.Text == "Price";

			if (cbo_ac_asking.Text != "Price")
			{
				txt_ac_asking_price.Text = "";
			}

		}


		private void cbo_Unknown_Country_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			Determine_Transaction_Type();

			modFillCompConControls.Check_If_Country_HasState(cbo_Unknown_State, cbo_Unknown_Country);

		}

		private void cbo_Unknown_State_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			Determine_Transaction_Type();

			modFillCompConControls.Select_Unknown_Country(cbo_Unknown_State, cbo_Unknown_Country);

		}

		private void chk_Lease_Take_Off_Market_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{
			// Remember that chk_LEase_Take_Off_Market is only checked if the user wants to
			// take the aircraft off market, not to say available after transaction
			if ((chk_Avail_Prior.CheckState == CheckState.Checked) && (chk_Lease_Take_Off_Market.CheckState == CheckState.Unchecked))
			{
				Trans_Type = "LA"; // Available, now Not Available
			}
			else if ((chk_Avail_Prior.CheckState == CheckState.Checked) && (chk_Lease_Take_Off_Market.CheckState == CheckState.Checked))
			{ 
				Trans_Type = "LO"; // Available - Sill Available
			}
			else if ((chk_Avail_Prior.CheckState == CheckState.Unchecked) && (chk_Lease_Take_Off_Market.CheckState == CheckState.Checked))
			{ 
				Trans_Type = "LT"; // Not Available, Stays not Available
			}
			else if ((chk_Avail_Prior.CheckState == CheckState.Unchecked) && (chk_Lease_Take_Off_Market.CheckState == CheckState.Unchecked))
			{ 
				Trans_Type = "LN"; // Not Available, Now Available
			}
			else
			{
				Trans_Type = "LS";
			}

			Update_grid_trans_types();

			if (!pnl_Fractional_Seller.Visible)
			{
				HideFractionalGrid();
			}

		}

		private void chk_Awaiting_Documentation_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (pnl_Fractional_Seller.Visible || chk_Awaiting_Documentation.CheckState == CheckState.Checked)
			{

				if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
				{

					fra_Awaiting_Documentation.Visible = true;
					cmd_Fractional_Buyer_OK.Visible = true;
					cmd_Fractional_Buyer_OK.Enabled = true;
					cmd_Fractional_Buyer_Cancel.Visible = true;
					cmd_Fractional_Buyer_Cancel.Enabled = true;

					cmd_Identify_Buyer.Enabled = false;

					modAircraftChange.Fill_cbo_Trans_Buyer(cbo_Trans_Buyer, 0, "", true);

				} // chk_Awaiting_Documentation.Value = vbChecked

			} //  pnl_Fractional_Seller.Visible Or chk_Awaiting_Documentation.Value = vbChecked

			if (fra_Awaiting_Documentation.Visible && chk_Awaiting_Documentation.CheckState == CheckState.Unchecked)
			{
				cmd_Fractional_Buyer_Cancel_Click(cmd_Fractional_Buyer_Cancel, new EventArgs());
			}

			// Determine Transaction Type
			Build_Transaction_Type();

			if ((Trans_Type == "FS") || (Trans_Type == "SS"))
			{
				cmd_Commit_Transaction.Enabled = Transaction_OK() && !pnl_Fractional_Seller.Visible;
			}
			else if ((Trans_Type == "SS") || (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L"))
			{ 

				Determine_Transaction_Type();

			}

		}

		private void chk_Correction_Transaction_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			Build_Transaction_Type();

			if (chk_Correction_Transaction.CheckState == CheckState.Checked)
			{
				chk_Internal_Transaction.CheckState = CheckState.Unchecked;
				chk_Internal_Transaction.Enabled = false;
			}
			else
			{
				chk_Internal_Transaction.Enabled = true;
			}

		}

		private void chk_Fractional_Correction_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			Update_grid_trans_types();

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Determine if transaction is complete
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			cmd_Commit_Transaction.Enabled = Transaction_OK() && !pnl_Fractional_Seller.Visible;

			if (chk_Fractional_Correction.CheckState == CheckState.Checked)
			{ //aey 7/28/04
				chk_Correction_Transaction.CheckState = CheckState.Checked;
			}
			else
			{
				chk_Correction_Transaction.CheckState = CheckState.Unchecked;
			}

		}

		private void chk_Internal_Transaction_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_Internal_Transaction.CheckState == CheckState.Checked)
			{
				chk_Correction_Transaction.CheckState = CheckState.Unchecked;
				Build_Transaction_Type();
			}
			else
			{
				Build_Transaction_Type();
				pnl_Update_Aircraft_row.Visible = false;
			}

		}

		private void chk_NewAircraft_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chk_NewAircraft.CheckState == CheckState.Checked)
			{
				if (CheckForNUTransaction(modAdminCommon.gbl_Aircraft_ID))
				{
					MessageBox.Show("NU Transaction Already Exists For This Aircraft", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					chk_NewAircraft.CheckState = CheckState.Unchecked;
				}
			}

		}

		private void chkFractionalAwaitDocs_CheckStateChanged(Object eventSender, EventArgs eventArgs)
		{

			if (chkFractionalAwaitDocs.CheckState == CheckState.Checked)
			{
				chk_Awaiting_Documentation.CheckState = CheckState.Checked;
			}
			else
			{
				chk_Awaiting_Documentation.CheckState = CheckState.Unchecked;
			}

			chk_Awaiting_Documentation_CheckStateChanged(chk_Awaiting_Documentation, new EventArgs());

			cmdDoneWithGrid.Enabled = Fractional_Sale_Complete();

		}

		private void cmd_await_doc_Click(Object eventSender, EventArgs eventArgs)
		{

			chk_Awaiting_Documentation.CheckState = CheckState.Checked;

			cmdDoneWithGrid.Enabled = Fractional_Sale_Complete();

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_await_doc_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_await_doc_Click(cmd_await_doc, new EventArgs());
			}
		}

		private void cmd_await_doc_Seller_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";

			cmd_Identify_Buyer.Visible = false;
			UI_Seller_Buyer = "Seller";

			bool OK = true;
			int saved_row = grd_Fractional.CurrentRowIndex;
			int tempForEndVar = grd_Fractional.RowsCount - 1;
			for (int Row = 1; Row <= tempForEndVar; Row++)
			{
				grd_Fractional.CurrentRowIndex = Row;
				grd_Fractional.CurrentColumnIndex = 4;
				if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer") && (Trans_Type == "SS"))
				{
				}
				else if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessee"))
				{ 
					M = "Only 1 Lessee allowed per transaction.";
					MessageBox.Show(M, "LESSEE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					OK = false;
					lbl_Step_4.Text = "STEP 4: Lessee";
					break;
				}
				else if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer"))
				{ 
					M = "Only 1 Buyer allowed per transaction UPDATE.";
					MessageBox.Show(M, "BUYER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					OK = false;
					lbl_Step_4.Text = "STEP 4: Buyer";
					break;
				}
			}
			grd_Fractional.CurrentRowIndex = saved_row;
			cmd_Fractional_Buyer_OK.Enabled = false;

			if (OK)
			{
				pnl_Buyer.Visible = true; //Step 4
				pnl_Registered_As.Visible = false; //Step 4a
				cmd_Fractional_Buyer_OK.Visible = true;
				cmd_Fractional_Buyer_Cancel.Visible = true;
				lst_Buyer.Items.Clear();
			}

			chk_Awaiting_Documentation.Visible = false;
			chk_Awaiting_Documentation.CheckState = CheckState.Checked;
			chk_Awaiting_Documentation_CheckStateChanged(chk_Awaiting_Documentation, new EventArgs());

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_await_doc_Seller_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_await_doc_Seller_Click(cmd_await_doc_Seller, new EventArgs());
			}
		}

		private void cmd_cancel_Click(Object eventSender, EventArgs eventArgs)
		{

			modAdminCommon.Num_Embedded = 0;
			chk_Financial_Documents.CheckState = CheckState.Unchecked;

			bComingBackFromTransaction = false;

			Journal_ID = 0;

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			mnuFileClose_Click(mnuFileClose, new EventArgs());

		}

		private void cmd_Cancel_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_cancel_Click(cmd_Cancel, new EventArgs());
			}
		}

		private void cmd_Commit_Transaction_Click(Object eventSender, EventArgs eventArgs)
		{

			string Query = "";
			int primary_internal_company_id = 0;
			string primary_comp_name = "";

			if (cbo_Trans_Seller.Text.Trim() == "" || cbo_Trans_Buyer.Text.Trim() == "")
			{
				MessageBox.Show("Please specify Buyer Type or Seller Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

			// get the primary, internal company id if there is one, in case we need to re-set it
			if (chk_Internal_Transaction.CheckState == CheckState.Checked)
			{
				Find_If_Primary_Exists(modAdminCommon.gbl_Aircraft_ID, ref primary_internal_company_id, ref primary_comp_name);
			}


			//9/10/04 validation to insure that buyer or seller has not changed
			if (($"{Trans_Type},").IndexOf("WS,FC,SZ,DP,") >= 0)
			{

				if (Buyer_Comp_ID > 0 && Buyer_Contact_ID == 0)
				{
					Query = "Select * from company WITH(NOLOCK)";
					Query = $"{Query} where comp_id = {Buyer_Comp_ID.ToString()}";
					Query = $"{Query} and comp_journ_id = 0";
					Query = $"{Query} and comp_active_flag = 'Y'";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Buyer company - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}

				if (Seller_Comp_ID > 0 && Seller_Contact_ID == 0)
				{
					Query = "Select * from company WITH(NOLOCK)";
					Query = $"{Query} where comp_id = {Seller_Comp_ID.ToString()}";
					Query = $"{Query} and comp_journ_id = {MOD_Journal_ID.ToString()}";
					if (MOD_Journal_ID == 0)
					{ //aey 5/25/05
						Query = $"{Query} and comp_active_flag='Y'";
					}
					else
					{
					}
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Seller company - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}

				if (Buyer_Comp_ID > 0 && Buyer_Contact_ID > 0)
				{
					Query = "Select * from contact WITH(NOLOCK)";
					Query = $"{Query} where contact_id = {Buyer_Contact_ID.ToString()}";
					Query = $"{Query} and contact_comp_id = {Buyer_Comp_ID.ToString()}";
					Query = $"{Query} and contact_active_flag = 'Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Buyer company contact - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}

				if (Seller_Comp_ID > 0 && Seller_Contact_ID > 0)
				{

					Query = "Select * from contact WITH(NOLOCK)";
					Query = $"{Query} where contact_id = {Seller_Contact_ID.ToString()}";
					Query = $"{Query} and contact_comp_id = {Seller_Comp_ID.ToString()}";
					Query = $"{Query} and contact_active_flag = 'Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Seller company contact - Please reselect", "Seller Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
			}

			//10/26/04 aey allow for the change of the purchase date for share sales
			RespShareSale = System.Windows.Forms.DialogResult.Yes;
			if (Trans_Type.StartsWith("SS", StringComparison.Ordinal))
			{
				RespShareSale = MessageBox.Show($"If shares sold total 100% of the Aircraft, the date purchased needs to update.{Environment.NewLine}Update date purchased?", "Share Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
			}

			SellFracTransPHtoPH = System.Windows.Forms.DialogResult.No;

			PastNewToMarket = CheckForNUTransaction(modAdminCommon.gbl_Aircraft_ID);

			if (($"{AvailListedDate}").Trim() != "")
			{
				// 06/03/2008 By David D. Cruger
				// Need to Use CDate otherwise the > operator wasn't working correctly
				if (!opt_Historical.Checked && chk_Internal_Transaction.CheckState == CheckState.Unchecked && DateTime.Parse(AvailListedDate) > DateTime.Parse(txt_transaction_date.Text))
				{
					MessageBox.Show("The Date Sold cannot be before the List Date. Please correct before committing.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}
			}

			// ******************************************************************************
			// MAKE SURE THAT THE REGISTRATION NUMBER IS FILLED IN FOR HISTORICAL TRANSACTIONS
			if (opt_Historical.Checked && Strings.Len(txt_Registration_No.Text.Trim()) == 0)
			{
				MessageBox.Show("You must identify a registration number for a historical transaction.  Please correct before committing.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}
			if (cbo_Trans_Seller.Items.Count > 1)
			{
				if (MessageBox.Show($"You have chosen '{cbo_Trans_Seller.Text}' to be the business type for the Seller on this transaction.{Environment.NewLine}{Environment.NewLine}Are you sure this is correct?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
				{
					return;
				}
			}

			if (chk_Awaiting_Documentation.CheckState == CheckState.Unchecked)
			{
				if (cbo_Trans_Buyer.Items.Count > 1)
				{
					if (MessageBox.Show($"You have chosen '{cbo_Trans_Buyer.Text}' to be the business type for the Buyer on this transaction.{Environment.NewLine}{Environment.NewLine}Are you sure this is correct?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
					{
						return;
					}
				}
			}

			//aey 8/6/04
			if (Aircraft_Ownership_Type == "W" && Trans_Type == "WS" && ($"{cbo_Trans_Seller.Text}").StartsWith("MF", StringComparison.Ordinal) && ($"{cbo_Trans_Buyer.Text}").StartsWith("PM", StringComparison.Ordinal))
			{
				MessageBox.Show("This type of transaction is not allowed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

			//aey 8/6/04
			if (Aircraft_Ownership_Type == "F" && Trans_Type == "WS" && ($"{cbo_Trans_Seller.Text}").StartsWith("PH", StringComparison.Ordinal) && ($"{cbo_Trans_Buyer.Text}").StartsWith("PM", StringComparison.Ordinal))
			{
				MessageBox.Show("This type of transaction is not allowed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				return;
			}

			//aey 8/6/04
			if (Aircraft_Ownership_Type == "F" && Trans_Type == "WS" && ($"{cbo_Trans_Seller.Text}").StartsWith("PH", StringComparison.Ordinal) && !opt_Historical.Checked && (($"{cbo_Trans_Buyer.Text}").StartsWith("PH", StringComparison.Ordinal) || chk_Internal_Transaction.CheckState == CheckState.Checked))
			{ //seller needs to be FO
				SellFracTransPHtoPH = System.Windows.Forms.DialogResult.Yes; // MsgBox("Do you want to change Program Holder Ownership?", vbYesNo, "Change Program Holder")
			}


			// if its a whole sale, then clear the asking update date
			// 7/16/2020 - MSW -
			if (Trans_Type == "WS")
			{
				Query = "UPDATE Aircraft_General_Dates SET agd_cc_asking_price_date = NULL ";
				Query = $"{Query}WHERE agd_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				Query = $"{Query} AND agd_journ_id = 0 ";

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

			// RUN THE PROCEDURE TO PROCESS THE TRANSACTION
			Transaction_Commit();


			if (frm_aircraft.DefInstance.GrdHelicopter.Visible)
			{
				Save_Helicopter_Grid(modAdminCommon.gbl_Aircraft_ID, Journal_ID.ToString());
			}



			int tempRefParam = 0;
			modAircraft.delete_and_insert_hotbox(ref tempRefParam, ref modAdminCommon.gbl_Aircraft_ID);

			if (primary_internal_company_id > 0)
			{
				// then do not clear the confidential notes
			}
			else if (frm_aircraft.DefInstance.txt_ac_confidential_notes.Text.Trim() != "")
			{ 
				//If MsgBox("Would You Like To Clear The Notes on this Aircraft?", vbYesNo) = vbYes Then
				frm_aircraft.DefInstance.txt_ac_confidential_notes.Text = "";
				frm_aircraft.DefInstance.Save_Aircraft_Click();
				// End If
			}

			// ADDED MSW - if its internal and there no longer is a primary - if > 0 means there was internal and it was primary
			string Query2 = "";
			if (primary_internal_company_id > 0)
			{
				int tempRefParam2 = 0;
				string tempRefParam3 = "";
				if (!Find_If_Primary_Exists(modAdminCommon.gbl_Aircraft_ID, ref tempRefParam2, ref tempRefParam3))
				{
					if (Is_Company_AC_Attached(modAdminCommon.gbl_Aircraft_ID, ref primary_internal_company_id))
					{ // if ther relationship still exists
						if (MessageBox.Show($"Would You Like To Set Primary to Company {primary_comp_name} ({primary_internal_company_id.ToString()}) ?", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
						{

							if (modAdminCommon.gbl_Aircraft_ID > 0 && primary_internal_company_id > 0)
							{
								// BUILD UPDATE QUERY 2 TO SET THE PRIMARY TO THE SPECIFIC REFERENCE SELECTED
								Query2 = "UPDATE Aircraft_Reference SET cref_primary_poc_flag = 'Y' ";
								Query2 = $"{Query2}WHERE (cref_ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()}) ";
								Query2 = $"{Query2}and (cref_comp_id = {primary_internal_company_id.ToString()}) ";
								Query2 = $"{Query2}and cref_journ_id = 0 ";
								Query2 = Query2;
								DbCommand TempCommand_2 = null;
								TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
								TempCommand_2.CommandText = Query2;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
								TempCommand_2.ExecuteNonQuery();
							}

						}
					}
				}
			}



			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		public bool Find_If_Primary_Exists(int AC_ID, ref int comp_id, ref string comp_name)
		{
			bool result = false;
			string Query = "";
			ADORecordSetHelper ado_Usage = new ADORecordSetHelper();


			try
			{


				Query = "SELECT * FROM Aircraft_Reference WITH(NOLOCK) ";
				Query = $"{Query} Inner join company on cref_comp_id = comp_id and comp_journ_id = 0";
				Query = $"{Query} where cref_ac_id = {AC_ID.ToString()} and cref_primary_poc_flag = 'Y' ";

				ado_Usage.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Usage.BOF && ado_Usage.EOF))
				{

					while(!ado_Usage.EOF)
					{

						result = true;
						comp_id = Convert.ToInt32(ado_Usage["cref_comp_id"]);
						comp_name = Convert.ToString(ado_Usage["comp_name"]);

						ado_Usage.MoveNext();
					};
				}

				ado_Usage.Close();
				ado_Usage = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Usage_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return result;
		}
		public bool Is_Company_AC_Attached(int AC_ID, ref int comp_id)
		{
			bool result = false;
			string Query = "";
			ADORecordSetHelper ado_Usage = new ADORecordSetHelper();


			try
			{


				Query = $"SELECT * FROM Aircraft_Reference WITH(NOLOCK) where cref_ac_id = {AC_ID.ToString()}  and cref_comp_id = {comp_id.ToString()} ";
				Query = $"{Query} and cref_journ_id = 0 ";


				ado_Usage.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(ado_Usage.BOF && ado_Usage.EOF))
				{

					while(!ado_Usage.EOF)
					{

						result = true;
						comp_id = Convert.ToInt32(ado_Usage["cref_comp_id"]);

						ado_Usage.MoveNext();
					};
				}

				ado_Usage.Close();
				ado_Usage = null;
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Fill_Aircraft_Usage_List_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return result;
		}
		private void Save_Helicopter_Grid(int AC_ID, string journ_id)
		{

			StringBuilder Query = new StringBuilder();
			string exists_select = "";

			try
			{

				modAdminCommon.ADO_Transaction("BeginTrans");

				Query = new StringBuilder($"DELETE FROM Helicopter_Detail_Times WHERE heldt_ac_id = {AC_ID.ToString()}");
				Query.Append($" and heldt_journ_id = {journ_id}");

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query.ToString();
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				modAdminCommon.ADO_Transaction("CommitTrans");

				modAdminCommon.ADO_Transaction("BeginTrans");
				int tempForEndVar = frm_aircraft.DefInstance.GrdHelicopter.RowsCount - 1;
				for (int K = 1; K <= tempForEndVar; K++)
				{
					frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex = K;
					frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 0; //category code

					if (frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Trim() != modGlobalVars.cEmptyString)
					{

						exists_select = $" select * from Helicopter_Detail_Times with (NOLOCK) where heldt_ac_id =  {AC_ID.ToString()}";
						exists_select = $"{exists_select} and heldt_journ_id = {journ_id}";
						frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 0;
						exists_select = $"{exists_select} and heldt_category_type = '{frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(40, frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Length)).Trim()}' ";
						frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 1; //sub cat
						exists_select = $"{exists_select} and heldt_subcat_type = '{frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(40, frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Length)).Trim()}' ";
						frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 2; //ser no full
						exists_select = $"{exists_select} and heldt_ser_no_full = '{modAdminCommon.Fix_Quote(frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(20, frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Length))).Trim()}' ";

						if (!modAdminCommon.Exist(exists_select))
						{

							Query = new StringBuilder("INSERT INTO Helicopter_Detail_Times (heldt_ac_id, heldt_journ_id, heldt_category_type, heldt_subcat_type, heldt_ser_no_full,");
							Query.Append("heldt_ttsn, heldt_remaining_hours, heldt_soh) ");
							Query.Append($"Values({AC_ID.ToString()},{journ_id},");
							frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 0;
							Query.Append($"'{frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(40, frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Length)).Trim()}',");

							frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 1; //sub cat
							Query.Append($"'{frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(40, frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Length)).Trim()}',");

							frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 2; //ser no full
							Query.Append($"'{modAdminCommon.Fix_Quote(frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Substring(0, Math.Min(20, frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Length))).Trim()}',");

							frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 3; //ttsn
							if (frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Trim() == modGlobalVars.cEmptyString)
							{
								Query.Append("NULL,");
							}
							else
							{
								Query.Append($"{StringsHelper.Replace(frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString(), ",", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()},");
							}
							frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 4; //remaining hours
							if (frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Trim() == modGlobalVars.cEmptyString)
							{
								Query.Append("NULL,");
							}
							else
							{
								Query.Append($"{StringsHelper.Replace(frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString(), ",", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()},");
							}
							frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex = 5; //soh
							if (frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString().Trim() == modGlobalVars.cEmptyString)
							{
								Query.Append("NULL)");
							}
							else
							{
								Query.Append($"{StringsHelper.Replace(frm_aircraft.DefInstance.GrdHelicopter[frm_aircraft.DefInstance.GrdHelicopter.CurrentRowIndex, frm_aircraft.DefInstance.GrdHelicopter.CurrentColumnIndex].FormattedValue.ToString(), ",", modGlobalVars.cEmptyString, 1, -1, CompareMethod.Binary).Trim()})");
							}

							DbCommand TempCommand_2 = null;
							TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
							TempCommand_2.CommandText = Query.ToString();
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
							TempCommand_2.ExecuteNonQuery();
						}


					}

				}

				modAdminCommon.ADO_Transaction("CommitTrans");
			}
			catch
			{

				modAdminCommon.ADO_Transaction("RollbackTrans");
			}

		}

		private void cmd_Commit_Transaction_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Commit_Transaction_Click(cmd_Commit_Transaction, new EventArgs());
			}

		}

		private void cmd_Fractional_Buyer_Cancel_Click(Object eventSender, EventArgs eventArgs)
		{

			if ((Trans_Type == "FS") || (Trans_Type == "SS") || (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L"))
			{

				pnl_Buyer.Visible = false;
				pnl_Registered_As.Visible = false;

			}
			else
			{

				fra_Awaiting_Documentation.Visible = false;
				chk_Awaiting_Documentation.CheckState = CheckState.Unchecked;

				cmd_Fractional_Buyer_OK.Visible = false;
				cmd_Fractional_Buyer_OK.Enabled = false;
				cmd_Fractional_Buyer_Cancel.Visible = false;
				cmd_Fractional_Buyer_Cancel.Enabled = false;

				cmd_Identify_Buyer.Enabled = true;

				lst_Buyer.Items.Clear();
				cbo_Trans_Buyer.Items.Clear();

				Buyer_Company_Business_Type = "";
				Buyer_Comp_Name = "";

				// Determine Transaction Type
				Build_Transaction_Type();

				if ((Trans_Type == "FS") || (Trans_Type == "SS"))
				{
					cmd_Commit_Transaction.Enabled = Transaction_OK() && !pnl_Fractional_Seller.Visible;
				}
				else if ((Trans_Type == "SS") || (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L"))
				{ 

					Determine_Transaction_Type();

				}

			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Fractional_Buyer_Cancel_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Fractional_Buyer_Cancel_Click(cmd_Fractional_Buyer_Cancel, new EventArgs());
			}

		}

		private void cmd_Fractional_Buyer_OK_Click(Object eventSender, EventArgs eventArgs)
		{

			if ((Trans_Type == "FS") || (Trans_Type == "SS") || (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L"))
			{
				if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
				{
					modAircraftChange.Fill_cbo_Trans_Buyer(cbo_Trans_Buyer, 0, "", true);
				}
				Add_Fractional_Buyer(Buyer_Comp_ID, Buyer_Contact_ID);
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Request the user to supply a fractional % value
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				if (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L")
				{
					pnl_Indicate_Seller_Buyer.Visible = false;
					if (chk_Awaiting_Documentation.CheckState == CheckState.Unchecked)
					{
						grd_Fractional.CurrentRowIndex = grd_Fractional.RowsCount - 1;
						grd_Fractional.CurrentColumnIndex = 2;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = Strings.FormatNumber(100, 3, TriState.False, TriState.False, TriState.False);
						grd_Fractional.CurrentColumnIndex = 3;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = Strings.FormatNumber(100, 3, TriState.False, TriState.False, TriState.False);
						grd_Fractional.CurrentColumnIndex = 4;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Lessee";
						Update_grid_trans_types();
						grd_Fractional.Refresh();
						cmdDoneWithGrid.Enabled = Fractional_Sale_Complete();
					}
				}
				else
				{
					if (Trans_Type != "FS")
					{
						pnl_Indicate_Seller_Buyer.Visible = true;
					}
					if (UI_Seller_Buyer == "Seller")
					{
						opt_Fractional_Seller.Checked = true;
						opt_Fractional_Buyer.Checked = false;
					}
					else if (UI_Seller_Buyer == "Buyer")
					{ 
						opt_Fractional_Seller.Checked = false;
						opt_Fractional_Buyer.Checked = true;
					}
					else
					{
						opt_Fractional_Seller.Checked = false;
						opt_Fractional_Buyer.Checked = false;
					}
					txt_Percentage.Text = "100";
					lbl_Percentage.Visible = true;
					txt_Percentage.Visible = true;
					lbl_To_Buy_Sell.Visible = true;
					grd_Fractional.Refresh();
				}

				pnl_Buyer.Visible = false;
				pnl_Registered_As.Visible = false;
				cmd_Fractional_Buyer_OK.Visible = false;
				cmd_Fractional_Buyer_Cancel.Visible = false;

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Determine if transaction is complete
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				if (Trans_Type == "FS")
				{
					cmd_Commit_Transaction.Enabled = Transaction_OK() && !pnl_Fractional_Seller.Visible;
				}
				else if (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L")
				{ 
					Determine_Transaction_Type();
				}

			}
			else
			{

				cmd_Fractional_Buyer_OK.Visible = false;
				cmd_Fractional_Buyer_Cancel.Visible = false;

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Determine Transaction Type
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Determine_Transaction_Type();

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Determine if transaction is complete
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				cmd_Commit_Transaction.Enabled = (Seller_Comp_ID > 0) && ((Buyer_Comp_ID > 0) || chk_Awaiting_Documentation.CheckState == CheckState.Checked);
			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Fractional_Buyer_OK_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Fractional_Buyer_OK_Click(cmd_Fractional_Buyer_OK, new EventArgs());
			}
		}

		private void cmd_Fractional_Cancel_Click(Object eventSender, EventArgs eventArgs)
		{

			if ((Trans_Type == "FS") || (Trans_Type == "SS") || (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L"))
			{
				pnl_Indicate_Seller_Buyer.Visible = false;
			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Fractional_Cancel_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Fractional_Cancel_Click(cmd_Fractional_Cancel, new EventArgs());
			}

		}

		private void cmd_Fractional_OK_Click(Object eventSender, EventArgs eventArgs)
		{

			double old_value = 0;
			double change_value = 0;
			double new_value = 0;
			int Row = 0;
			int saved_row = 0;
			string Ttype = "";
			string errMsg = "";

			try
			{

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// The user has designated a Seller or Buyer and the appropriate percentage for the transaction.

				errMsg = "not Awaiting doc";
				if ((((opt_Fractional_Seller.Checked) ? -1 : 0) & ((chk_Awaiting_Documentation.CheckState == CheckState.Unchecked) ? -1 : 0)) != 0)
				{
					Row = grd_Fractional.CurrentRowIndex;

					Seller_Comp_ID = grid_Array_comp_id[Row];
					Seller_Contact_ID = grid_Array_contact_id[Row];
					Seller_Contact_Type = grid_Array_contact_type[Row];
					grd_Fractional.CurrentColumnIndex = 1;

					if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						old_value = Double.Parse(Strings.FormatNumber(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString()), 3, TriState.False, TriState.False, TriState.True)); //Current %
					}

					if (modCommon.Is_A_Real_Number(txt_Percentage.Text.Trim()))
					{
						change_value = Double.Parse(Strings.FormatNumber(txt_Percentage, 3, TriState.False, TriState.False, TriState.True));
					}

					if (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L")
					{
						change_value = Double.Parse(Strings.FormatNumber(100, 3, TriState.False, TriState.False, TriState.True));
					}

					errMsg = "chng val";
					if (change_value > 0)
					{
						if (old_value > 0)
						{
							new_value = Double.Parse(Strings.FormatNumber(old_value - change_value, 3, TriState.False, TriState.False, TriState.True));
						}

						if (new_value < 0)
						{
							change_value = old_value;
							new_value = 0;
						}

						if (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L")
						{
							change_value = Double.Parse(Strings.FormatNumber(100, 3, TriState.False, TriState.False, TriState.True));
						}

						grd_Fractional.CurrentColumnIndex = 2;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = Strings.FormatNumber(new_value, 3, TriState.False, TriState.False, TriState.True); //New %
						grd_Fractional.CurrentColumnIndex = 3;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = $"-{Strings.FormatNumber(change_value, 3, TriState.False, TriState.False, TriState.True)}"; //Net Change %
						grd_Fractional.CurrentColumnIndex = 4;
						if (Trans_Type == "FS" || Trans_Type == "SS")
						{
							grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Seller"; //Seller/Buyer
						}
						else
						{
							grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Lessor"; //Lessor/Lessee
						}
						grd_Fractional.CurrentColumnIndex = 5;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = ""; //Transaction Type
						Seller_Company_Business_Type = grid_Array_comp_Bus_Type[grd_Fractional.CurrentRowIndex]; //comp_Company_Business_Type'
						Seller_Comp_Name = grid_Array_comp_name[grd_Fractional.CurrentRowIndex];

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Modify any 'Buyer' Transaction Types that came before the 'Seller'
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						errMsg = "Buyer";
						saved_row = grd_Fractional.CurrentRowIndex;
						int tempForEndVar = grd_Fractional.RowsCount - 1;
						for (Row = 1; Row <= tempForEndVar; Row++)
						{
							grd_Fractional.CurrentRowIndex = Row;
							grd_Fractional.CurrentColumnIndex = 4;
							if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer") || (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessee"))
							{
								grd_Fractional.CurrentColumnIndex = 5;
								Ttype = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
								if (chk_Correction_Transaction.CheckState == CheckState.Checked)
								{
									Ttype = $"{Ttype.Substring(0, Math.Min(2, Ttype.Length))}CORR";
								}
								else
								{
									if (Strings.Len(Ttype) > 4)
									{
										Ttype = $"{Ttype.Substring(0, Math.Min(2, Ttype.Length))}{Seller_Company_Business_Type}{Ttype.Substring(Math.Max(Ttype.Length - 2, 0))}";
									}
									else if (Strings.Len(Ttype) > 2)
									{ 
										Ttype = $"{Ttype.Substring(0, Math.Min(2, Ttype.Length))}{Seller_Company_Business_Type}";
									}
									else
									{
										Ttype = Trans_Type.Trim();
									}
								}
								grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = Ttype;
							}
						}
						grd_Fractional.CurrentRowIndex = saved_row;
					}
					else
					{
						grd_Fractional.CurrentColumnIndex = 2;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = ""; //New %
						grd_Fractional.CurrentColumnIndex = 3;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = ""; //Net Change %
						grd_Fractional.CurrentColumnIndex = 4;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = ""; //Seller/Buyer
						grd_Fractional.CurrentColumnIndex = 5;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = ""; //Transaction Type
					}

				}
				else if (opt_Fractional_Buyer.Checked)
				{ 
					errMsg = "Frac Buyer";
					grd_Fractional.CurrentColumnIndex = 1;

					if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						old_value = Double.Parse(Strings.FormatNumber(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString()), 3, TriState.False, TriState.False, TriState.True)); //Current %
					}

					if (modCommon.Is_A_Real_Number(txt_Percentage.Text.Trim()))
					{
						change_value = Double.Parse(Strings.FormatNumber(Conversion.Val(txt_Percentage.Text), 3, TriState.False, TriState.False, TriState.True));
					}

					if (change_value > 0)
					{

						new_value = Double.Parse(Strings.FormatNumber(old_value + change_value, 3, TriState.False, TriState.False, TriState.True));

						grd_Fractional.CurrentColumnIndex = 2;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = Strings.FormatNumber(new_value, 3, TriState.False, TriState.False, TriState.True); //New %
						grd_Fractional.CurrentColumnIndex = 3;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = Strings.FormatNumber(change_value, 3, TriState.False, TriState.False, TriState.True); //Net Change %
						grd_Fractional.CurrentColumnIndex = 4;

						if ((Trans_Type == "FS") || (Trans_Type == "SS"))
						{
							grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Buyer"; //Seller/Buyer
						}
						else
						{
							grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Lessee"; //Seller/Buyer
						}

						Buyer_Company_Business_Type = grid_Array_comp_Bus_Type[grd_Fractional.CurrentRowIndex]; //comp_Company_Business_Type'
						Buyer_Comp_Name = grid_Array_comp_name[grd_Fractional.CurrentRowIndex];
						Determine_Transaction_Type();
						grd_Fractional.CurrentColumnIndex = 5;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = Transaction_Type; //Transaction Type
					}
					else
					{
						grd_Fractional.CurrentColumnIndex = 2;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = ""; //New %
						grd_Fractional.CurrentColumnIndex = 3;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = ""; //Net Change %
						grd_Fractional.CurrentColumnIndex = 4;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = ""; //Seller/Buyer
						grd_Fractional.CurrentColumnIndex = 5;
						grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = ""; //Transaction Type
					}
				}

				errMsg = "Upgrade";
				Update_grid_trans_types();
				grd_Fractional.Redraw = true;

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Determine if transaction is complete
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				errMsg = "is complete";
				if (Transaction_OK())
				{
					cmdDoneWithGrid.Enabled = true;
					cmd_Commit_Transaction.Enabled = !pnl_Fractional_Seller.Visible;
				}
				else
				{
					cmdDoneWithGrid.Enabled = false;
					cmd_Commit_Transaction.Enabled = false;
				}

				pnl_Indicate_Seller_Buyer.Visible = false;
				errMsg = "exp date";

				if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Seller" && grid_Array_fraction_expire_date[grd_Fractional.CurrentRowIndex] != "")
				{
					Seller_Fraction_Expires_Date = DateTime.Parse(grid_Array_fraction_expire_date[grd_Fractional.CurrentRowIndex]).ToString("d");
				}
				else
				{
					Seller_Fraction_Expires_Date = "";
				}

				if (mvHasFocus)
				{
					mvHasFocus = false;
				}
			}
			catch (System.Exception excep)
			{
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Cmd_Fractional_OK_Error: {Information.Err().Number.ToString()} {excep.Message} {errMsg}");
			}

		}

		private void cmd_Fractional_OK_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Fractional_OK_Click(cmd_Fractional_OK, new EventArgs());
			}
		}

		private void cmd_Ident_Hist_Frac_Seller_Click(Object eventSender, EventArgs eventArgs)
		{
			if (mvHasFocus)
			{
				mvHasFocus = false;
			}
			cmd_Identify_Seller_Click(cmd_Identify_Seller, new EventArgs());
		}

		private void cmd_Ident_Hist_Frac_Seller_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Ident_Hist_Frac_Seller_Click(cmd_Ident_Hist_Frac_Seller, new EventArgs());
			}

		}

		private void cmd_Identify_Buyer_Click(Object eventSender, EventArgs eventArgs)
		{

			if (Trans_Type == "WS")
			{
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetBuyer;
			}
			else if (Trans_Type == "FS")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetBuyer;
			}
			else if (Trans_Type == "SZ")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geSeizedBy;
			}
			else if (Trans_Type == "FC")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geReposessedBy;
			}
			else if (Trans_Type == "SS")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetBuyer;
			}
			else if (Trans_Type == "DP")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetBuyer;
			}
			else if ((Trans_Type.StartsWith("L", StringComparison.Ordinal)))
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geLessee;
			}
			else
			{
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetBuyer;
			}

			// look for the "Transaction" Company find form in our collection and use it

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].EntryPoint =modGlobalVars.e_find_form_entry_points.geAircraftChange;
				//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].ActionTypes = tCompFind_ActionTypes;
				//UPGRADE_TODO: (1067) Member Reference_AircraftID is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].Reference_AircraftID = modAdminCommon.gbl_Aircraft_ID;
				//UPGRADE_TODO: (1067) Member HistoricalSearch is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].HistoricalSearch = false;
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].Show();
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes

			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Identify_Buyer_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Identify_Buyer_Click(cmd_Identify_Buyer, new EventArgs());
			}

		}

		private void cmd_Identify_Fractional_Buyer_Click(Object eventSender, EventArgs eventArgs)
		{

			string M = "";

			chkFractionalAwaitDocs.CheckState = CheckState.Unchecked;

			bool OK = true;
			int saved_row = grd_Fractional.CurrentRowIndex;
			int tempForEndVar = grd_Fractional.RowsCount - 1;
			for (int Row = 1; Row <= tempForEndVar; Row++)
			{
				grd_Fractional.CurrentRowIndex = Row;
				grd_Fractional.CurrentColumnIndex = 4;
				if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer") && (Trans_Type == "SS"))
				{
					M = "Only 1 Buyer allowed per transaction.";
					MessageBox.Show(M, "BUYER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					OK = false;
					cmd_Fractional_OK_Click(cmd_Fractional_OK, new EventArgs());
					break;
				}
				else if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessee"))
				{ 
					M = "Only 1 Lessee allowed per transaction.";
					MessageBox.Show(M, "LESSEE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					OK = false;
					break;
				}
				else if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer"))
				{ 
					M = "Only 1 Buyer allowed per transaction UPDATE.";
					MessageBox.Show(M, "BUYER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
					OK = false;
					break;
				}
			}
			grd_Fractional.CurrentRowIndex = saved_row;
			cmd_Fractional_Buyer_OK.Enabled = false;

			if (OK)
			{
				cmd_Identify_Buyer_Click(cmd_Identify_Buyer, new EventArgs());
				return;

				pnl_Buyer.Visible = true; //Step 4
				pnl_Registered_As.Visible = false; //Step 4a
				cmd_Fractional_Buyer_OK.Visible = true;
				cmd_Fractional_Buyer_Cancel.Visible = true;
				lst_Buyer.Items.Clear();
			}

			UI_Seller_Buyer = "Buyer";
			chk_Awaiting_Documentation.CheckState = CheckState.Unchecked;
			chk_Awaiting_Documentation_CheckStateChanged(chk_Awaiting_Documentation, new EventArgs());

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Identify_Fractional_Buyer_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Identify_Fractional_Buyer_Click(cmd_Identify_Fractional_Buyer, new EventArgs());
			}

		}

		private void cmd_Identify_Registered_As_Click(Object eventSender, EventArgs eventArgs)
		{

			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Set the 'Contact_Find' form entry point to return to this form
			// Set the return flag to 'Get Buyer' so we know why we are activated when 'Contact_Find' returns
			// Set the 'Contact_Find' form 'Reference_Aircraft_ID' flag to indicate the aircraft in question
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			if (Trans_Type == "WS")
			{
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geRegisteredAs;
			}
			else if (Trans_Type == "FS")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geNoAction;
			}
			else if (Trans_Type == "SZ")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geRegisteredAs;
			}
			else if (Trans_Type == "FC")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geRegisteredAs;
			}
			else if (Trans_Type == "SS")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geRegisteredAs;
			}
			else if (Trans_Type == "DP")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geRegisteredAs;
			}
			else if ((Trans_Type.StartsWith("L", StringComparison.Ordinal)))
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geNoAction;
			}
			else
			{
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geRegisteredAs;
			}

			// look for the "Transaction" Company find form in our collection and use it

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].EntryPoint =modGlobalVars.e_find_form_entry_points.geAircraftChange;
				//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].ActionTypes = tCompFind_ActionTypes;
				//UPGRADE_TODO: (1067) Member Reference_AircraftID is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].Reference_AircraftID = modAdminCommon.gbl_Aircraft_ID;
				//UPGRADE_TODO: (1067) Member HistoricalSearch is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].HistoricalSearch = false;
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].Show();
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes

			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Identify_Registered_As_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Identify_Registered_As_Click(cmd_Identify_Registered_As, new EventArgs());
			}

		}

		private void cmd_Identify_Seller_Click(Object eventSender, EventArgs eventArgs)
		{

			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Set the 'Contact_Find' form entry point to return to this form
			// Set the return flag to 'Get Seller' so we know why we are activated when 'Contact_Find' returns
			// Set the 'Contact_Find' form 'Reference_Aircraft_ID' flag to indicate the aircraft in question
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			if (Trans_Type == "WS")
			{
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetSeller;
			}
			else if (Trans_Type == "FS")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetSeller;
			}
			else if (Trans_Type == "SZ")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetOwner;
			}
			else if (Trans_Type == "FC")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetOwner;
			}
			else if (Trans_Type == "SS")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetSeller;
			}
			else if (Trans_Type == "DP")
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetSeller;
			}
			else if ((Trans_Type.StartsWith("L", StringComparison.Ordinal)))
			{ 
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetSeller;
			}
			else
			{
				tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geGetSeller;
			}

			// look for the "Transaction" Company find form in our collection and use it

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member EntryPoint is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].EntryPoint =modGlobalVars.e_find_form_entry_points.geAircraftChange;
				//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].ActionTypes = tCompFind_ActionTypes;
				//UPGRADE_TODO: (1067) Member Reference_AircraftID is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].Reference_AircraftID = modAdminCommon.gbl_Aircraft_ID;
				//UPGRADE_TODO: (1067) Member HistoricalSearch is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].HistoricalSearch = false;
				//UPGRADE_TODO: (1067) Member Show is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].Show();
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].BringToFront(); //gap-note Manual change to fix BringToFront rule failing sometimes

			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_Identify_Seller_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_Identify_Seller_Click(cmd_Identify_Seller, new EventArgs());
			}

		}

		private void cmd_remove_grid_row_Click(Object eventSender, EventArgs eventArgs)
		{

			if (grd_Fractional.RowsCount > 2)
			{
				grd_Fractional.RemoveItem(grd_Fractional.CurrentRowIndex);
			}
			pnl_Indicate_Seller_Buyer.Visible = false;

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmd_remove_grid_row_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmd_remove_grid_row_Click(cmd_remove_grid_row, new EventArgs());
			}
		}

		private void cmdDoneWithGrid_Click(Object eventSender, EventArgs eventArgs)
		{

			if (CheckFractionalGrid())
			{
				chk_Awaiting_Documentation.CheckState = chkFractionalAwaitDocs.CheckState;
				chk_Awaiting_Documentation_CheckStateChanged(chk_Awaiting_Documentation, new EventArgs());
				HideFractionalGrid();
			}

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

		}

		private void cmdDoneWithGrid_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdDoneWithGrid_Click(cmdDoneWithGrid, new EventArgs());
			}
		}

		private void cmdShowFractionalGrid_Click(Object eventSender, EventArgs eventArgs)
		{

			if (mvHasFocus)
			{
				mvHasFocus = false;
			}

			ShowFractionalGrid();

		}

		private void cmdShowFractionalGrid_MouseUp(Object eventSender, MouseEventArgs eventArgs)
		{
			int Button = (eventArgs.Button == MouseButtons.Left) ? 1 : ((eventArgs.Button == MouseButtons.Right) ? 2 : 4);
			int Shift = ((int) Control.ModifierKeys) / 65536;
			float X = eventArgs.X * 15;
			float Y = eventArgs.Y * 15;
			if (mvHasFocus)
			{
				mvHasFocus = false;
				cmdShowFractionalGrid_Click(cmdShowFractionalGrid, new EventArgs());
			}
		}

		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				string M = "";
				bool OK_To_GO = false;

				if (Aircraft_ID > 0)
				{
					modAdminCommon.gbl_Aircraft_ID = Aircraft_ID;
				}

				if (modAdminCommon.gbl_bHomeClicked)
				{
					this.Close();

				}
				else if (Been_Here)
				{ 

					CheckPermission();

					//UPGRADE_TODO: (1067) Member ActionTypes is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					//UPGRADE_WARNING: (6021) Casting 'Variant' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					tCompFind_ActionTypes = (modGlobalVars.e_find_form_action_types) Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].ActionTypes);

					if (tCompFind_ActionTypes != modGlobalVars.e_find_form_action_types.geNoAction)
					{
						//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Found_Company_Id = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].GetFormExitValues(modGlobalVars.gcFOUNDCOMPANYID));
						//UPGRADE_TODO: (1067) Member GetFormExitValues is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
						Found_Contact_Id = Convert.ToInt32(modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].GetFormExitValues(modGlobalVars.gcFOUNDCONTACTID));
					}

					if (Found_Company_Id > 0 && Found_Contact_Id >= 0)
					{

						if ((tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geGetSeller) || (tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geGetOwner) || (tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geLessor))
						{

							//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
							// Fill the seller list box
							// "Returning from the 'Contact_Find' form...Get Seller"
							//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
							modAircraftChange.Display_Seller_Info(lst_Seller, cbo_Trans_Seller, Found_Company_Id, Found_Contact_Id, ref Seller_Contact_Type, ref Seller_Aircraft_Business_Type, ref Seller_Company_Business_Type, ref Seller_Comp_Name);

							Seller_Comp_ID = Found_Company_Id;
							Seller_Contact_ID = Found_Contact_Id;

							cmd_Fractional_Buyer_OK.Enabled = true;

							if ((Trans_Type == "SS") || (Trans_Type == "FS") || (Trans_Type.StartsWith("L", StringComparison.Ordinal)))
							{
								if (Trans_Type == "FS" && ac_journ_id > 0)
								{
									UI_Seller_Buyer = "Seller";
									Add_Fractional_Buyer(Found_Company_Id, Found_Contact_Id);
									opt_Fractional_Seller_CheckedChanged(opt_Fractional_Seller, new EventArgs());
								}
								cmd_Fractional_Buyer_OK_Click(cmd_Fractional_Buyer_OK, new EventArgs());
							}
							else
							{
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								// Determine Transaction Type
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								Determine_Transaction_Type();
							}

							if (Trans_Type.StartsWith("L", StringComparison.Ordinal) && opt_Historical.Checked)
							{
								pnl_Buyer.Visible = true;
							}

						}
						else if ((tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geGetBuyer) || (tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geSeizedBy) || (tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geReposessedBy) || (tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geLessee))
						{ 
							//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
							// Fill the buyer list box
							// "Returning from the 'Contact_Find' form...Get_Buyer"
							//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
							Buyer_Comp_ID = 0;
							Buyer_Contact_ID = 0;
							Buyer_Contact_Type = "";
							Buyer_Percentage = "";
							Buyer_Company_Business_Type = "";
							Buyer_Primary_Business_Type = "";
							Buyer_Comp_Name = "";

							modAircraftChange.Display_Buyer_Info(lst_Buyer, cbo_Trans_Buyer, Found_Company_Id, Found_Contact_Id, ref Buyer_Company_Business_Type, ref Buyer_Comp_Name);

							Buyer_Comp_ID = Found_Company_Id;
							Buyer_Contact_ID = Found_Contact_Id;
							cmd_Fractional_Buyer_OK.Enabled = true;
							// if the buyer is a manufacturer or distributor and the record is already marked as new to
							// market then remove this flag

							if ((Buyer_Company_Business_Type == "MF" || Buyer_Company_Business_Type == "DS") && chk_NewAircraft.CheckState == CheckState.Checked)
							{
								chk_NewAircraft.CheckState = CheckState.Unchecked;
							}

							if (chk_Correction_Transaction.CheckState != CheckState.Checked)
							{
								Is_Internal_Transaction();
							}

							if ((Trans_Type == "SS") || (Trans_Type == "FS") || (Trans_Type.StartsWith("L", StringComparison.Ordinal)))
							{
								UI_Seller_Buyer = "Buyer";
								cmd_Fractional_Buyer_OK_Click(cmd_Fractional_Buyer_OK, new EventArgs());
								ShowFractionalGrid();
							}
							else
							{
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								// Determine Transaction Type
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								Determine_Transaction_Type();
							}

							chkFractionalAwaitDocs.CheckState = CheckState.Unchecked;

							if (Trans_Type.StartsWith("L", StringComparison.Ordinal) && opt_Historical.Checked)
							{
								pnl_Buyer.Visible = true;
								pnl_Verify.Visible = true;
								pnl_Seller.Visible = true;
								pnl_Fractional_Seller.Visible = false;
								if (lst_Seller.Items.Count > 0 && lst_Buyer.Items.Count > 0)
								{
									cmd_Commit_Transaction.Enabled = true;
								}
							}

						}
						else if ((tCompFind_ActionTypes == modGlobalVars.e_find_form_action_types.geRegisteredAs))
						{ 
							//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
							// Fill the Registered As Buyer list box
							// "Returning from the 'Contact_Find' form...Get_Buyer"
							//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
							modAircraftChange.Display_Registered_As_Info(lst_Registered_As, Found_Company_Id, Found_Contact_Id);
							Registered_As_Buyer_comp_id = Found_Company_Id;
							Registered_As_Buyer_contact_id = Found_Contact_Id;

							//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
							// Determine Transaction Type
							//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
							Determine_Transaction_Type();

						}

					}

					Refresh_Form_Controls();

					return;

				}
				else
				{
					// we have not been here before
					Been_Here = true;

					fra_Awaiting_Documentation.Visible = false;

					cmd_Fractional_Buyer_OK.Visible = false;
					cmd_Fractional_Buyer_OK.Enabled = false;
					cmd_Fractional_Buyer_Cancel.Visible = false;
					cmd_Fractional_Buyer_Cancel.Enabled = false;

					cmd_Identify_Buyer.Enabled = true;

					lst_Buyer.Items.Clear();
					cbo_Trans_Buyer.Items.Clear();

					Buyer_Company_Business_Type = "";
					Buyer_Comp_Name = "";

					MOD_Journal_ID = 0;
					Journal_ID = 0;

					if (Trans_Type == "FS" && ac_journ_id > 0)
					{
						MOD_Journal_ID = ac_journ_id;
						Journal_ID = ac_journ_id;
						cmd_Ident_Hist_Frac_Seller.Visible = true;
					}

					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// Validate the received transaction type

					if ((Trans_Type != "WS") && (Trans_Type != "SS") && (Trans_Type != "FS") && (Trans_Type != "SZ") && (Trans_Type != "FC") && (Trans_Type != "DP") && (!Trans_Type.StartsWith("L", StringComparison.Ordinal)))
					{

						Been_Here = false;

						if (!modCommon.Is_Form_Already_Loaded("frm_Aircraft"))
						{
							//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//VB.Global.Load(frm_aircraft.DefInstance);
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

						this.Close();
						return;
					}
					else
					{

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Clear the interface between this form and the 'Contact_Find' form
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geNoAction;

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Retrieve the currently referenced 'Aircraft' table row
						//
						// NOTE: MOD_Journal_ID will =  0 for a new transaction,
						//                             >0 for a modify transaction (the Journal_ID)
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						Get_Aircraft(MOD_Journal_ID);

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Initialize the form
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						Setup_Form();

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// IF 'Fractional Sale', 'Shared Sale' or 'Leased Aircraft' transaction
						//    Fill the 'grd_fractional' grid
						// ENDIF
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						if ((Trans_Type == "FS") || (Trans_Type == "SS") || (Trans_Type.StartsWith("L", StringComparison.Ordinal)))
						{
							Fill_grd_Fractional(modAdminCommon.gbl_Aircraft_ID, MOD_Journal_ID);
						}

						if (Aircraft_Ownership_Type == "S" && (Trans_Type.StartsWith("L", StringComparison.Ordinal)))
						{ //aey 9/17/04
							HideFractionalGrid();
							cmdShowFractionalGrid.Visible = false;
						}
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Determine if this is an Internal Transaction
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						if (Found_Company_Id > 0)
						{
							if (MOD_Trans_Type.Trim().Substring(Math.Max(MOD_Trans_Type.Trim().Length - 2, 0)) == "IT")
							{
								chk_Internal_Transaction.CheckState = CheckState.Checked;
							}
							else
							{
								chk_Internal_Transaction.CheckState = CheckState.Unchecked;
								if (Is_Internal_Transaction())
								{
									chk_Internal_Transaction.CheckState = CheckState.Checked;
								}
							}
							chk_Internal_Transaction_CheckStateChanged(chk_Internal_Transaction, new EventArgs());
						}

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Determine the Transaction Type
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						Determine_Transaction_Type();

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Initialize the ToolBar
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						ToolbarSetup();
						ToolbarButtonsSetup();

						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						// Check for cross transaction type operations
						//    W - Wholly Owned
						//    D = Delivery Position
						//    F - Fractional Ownership
						//    S - Shared Ownership
						//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
						OK_To_GO = true;
						switch(Aircraft_Ownership_Type)
						{
							case "W" : 
								switch(Trans_Type)
								{
									case "WS" : case "DP" : case "SZ" : case "FC" : case "FS" : case "SS" : case "LA" : case "LO" : case "LS" : case "LN" : case "LX" : case "LT" : 
										break;
								} 
								break;
							case "D" : 
								switch(Trans_Type)
								{
									case "WS" : case "DP" : case "SZ" : case "FC" : 
										//OK 
										break;
									case "FS" : case "SS" : case "LA" : case "LO" : case "LS" : case "LN" : case "LX" : case "LT" : 
										M = "Cannot peform this transaction on an Aircraft in 'Delivery Position'."; 
										OK_To_GO = false; 
										break;
								} 
								 
								break;
							case "F" : 
								switch(Trans_Type)
								{
									case "WS" : case "SS" : case "SZ" : case "FC" : case "FS" : 
										//OK 
										break;
									case "DP" : 
										M = "Cannot peform this transaction on an Aircraft in 'Delivery Position'."; 
										OK_To_GO = false; 
										break;
									case "LA" : case "LO" : case "LS" : case "LN" : case "LX" : case "LT" : 
										// now ok 
										//  M = "This transaction is not yet available on a 'Fractional Ownership' Aircraft." 
										//  OK_To_GO = False 
										break;
								} 
								 
								break;
							case "S" : 
								switch(Trans_Type)
								{
									// ALLOWED WS ON SHARED AIRCRAFT - RTW - 7/11/03
									case "DP" : 
										M = "Cannot peform this transaction on a 'Shared Ownership' Aircraft."; 
										OK_To_GO = false; 
										break;
									case "SZ" : case "FC" : 
										//OK 
										break;
									case "FS" : 
										M = "Cannot peform this transaction on a 'Shared Ownership' Aircraft."; 
										OK_To_GO = false; 
										//Case "LA", "LO", "LS", "LN", "LX", "LT" 'aey 9/17/04 , "WS" 
										break;
									case "LO" : case "LS" : case "LN" : case "LX" : 
										M = "This transaction is not yet available on a 'Shared Ownership' Aircraft."; 
										OK_To_GO = false; 
										break;
								} 
								break;
						}
						if (!OK_To_GO)
						{
							MessageBox.Show(M, "Cross Type Sale", MessageBoxButtons.OK, MessageBoxIcon.Information);
							Been_Here = false;

							if (!modCommon.Is_Form_Already_Loaded("frm_Aircraft"))
							{
								//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//VB.Global.Load(frm_aircraft.DefInstance);
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

							this.Close();
							return;

						} // If Not OK_To_GO Then

					}

					txt_Internal_Notes.Focus();

				}

				// added MSW - 2/21/23
				if (mdi_ResearchAssistant.DefInstance.lbl_test_omg.Visible)
				{
					lbl_test_omg4.Visible = true;
				}


				Refresh_Form_Controls();
				Working_Off();

			}
		} // Form_Activate

		public void Get_Aircraft(int journ_id)
		{

			string Query = "";
			try
			{

				ADORecordSetHelper snp_Curstat = new ADORecordSetHelper(); // Snapshot aey 7/21/04 converted to ado

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Retrieve the currently referenced 'Aircraft' table row
				// Fill the 'lst_Aircraft_Info' list box
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Query = "SELECT ac_forsale_flag, ac_status, ac_amod_id, ac_delivery, ";
				Query = $"{Query}ac_asking, ac_asking_price, ac_list_date, amod_make_name, ";
				Query = $"{Query}amod_model_name, ac_reg_no, ac_ownership_type, ac_lifecycle_stage, ";
				Query = $"{Query}ac_exclusive_flag, ac_ser_no_full ";
				Query = $"{Query}FROM Aircraft, Aircraft_Model ";
				Query = $"{Query}WHERE ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} AND ac_journ_id = {journ_id.ToString()} AND amod_id = ac_amod_id";

				snp_Curstat.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				lst_Aircraft_Info.Items.Clear();

				if (!(snp_Curstat.BOF && snp_Curstat.EOF))
				{
					lst_Aircraft_Info.AddItem($"Make:{($"{Convert.ToString(snp_Curstat["amod_make_name"])} ").Trim()} Model:{Convert.ToString(snp_Curstat["amod_model_name"])}");
					lst_Aircraft_Info.AddItem($"Serial#:{Convert.ToString(snp_Curstat["ac_ser_no_full"])}");
					lst_Aircraft_Info.AddItem($"Status: {($"{Convert.ToString(snp_Curstat["ac_status"])} ").Trim()}");
					Aircraft_Ownership_Type = ($"{Convert.ToString(snp_Curstat["ac_ownership_type"])}").Trim();
					Aircraft_Serial_Number = ($" {Convert.ToString(snp_Curstat["ac_ser_no_full"])}").Trim();
					Aircraft_LifeCycle_Stage = ($" {Convert.ToString(snp_Curstat["ac_lifecycle_stage"])}").Trim();
					gbl_ac_amod_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_Curstat["ac_amod_id"])}").Trim()));
					if (($"{Convert.ToString(snp_Curstat["ac_status"])} ").Trim() == "For Sale")
					{
						lst_Aircraft_Info.AddItem($"Availability: {($"{Convert.ToString(snp_Curstat["ac_delivery"])} ").Trim()}");
						if (($"{Convert.ToString(snp_Curstat["ac_asking"])} ").Trim() == "Price")
						{
							lst_Aircraft_Info.AddItem($"Asking Price: ${modAdminCommon.gbl_LeftAdjust(($"{Convert.ToString(snp_Curstat["ac_asking_price"])} ").Trim(), "###,###,###")}");
						}
						else
						{
							lst_Aircraft_Info.AddItem(($"{Convert.ToString(snp_Curstat["ac_asking"])} ").Trim());
						}
						System.DateTime TempDate2 = DateTime.FromOADate(0);
						lst_Aircraft_Info.AddItem($"List Date: {((DateTime.TryParse(($"{Convert.ToString(snp_Curstat["ac_list_date"])} ").Trim(), out TempDate2)) ? TempDate2.ToString("MM/dd/yyyy") : ($"{Convert.ToString(snp_Curstat["ac_list_date"])} ").Trim())}");
					}

					lst_Aircraft_Info.AddItem($"Reg No: {($"{Convert.ToString(snp_Curstat["ac_reg_no"])}").Trim()}");

					// IDENTIFY WHETHER THE AIRCRAFT IS CURRENTLY ON EXCLUSIVE
					Aircraft_Exclusive = ($"{Convert.ToString(snp_Curstat["ac_exclusive_flag"])}").Trim() == "Y";
					txt_Registration_No.Text = ($"{Convert.ToString(snp_Curstat["ac_reg_no"])}").Trim();
				}

				pnl_Current_Status.Visible = true;

				lst_Aircraft_Info.Refresh();

				pnl_Current_Status.Refresh();

				snp_Curstat.Close();
				snp_Curstat = null;
			}
			catch (System.Exception excep)
			{

				Working_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Get_Aircraft_status_Error: {Information.Err().Number.ToString()} {excep.Message} {Query}");
				return;
			}

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			bComingBackFromTransaction = false;

			modAdminCommon.Open_Client_Connection();

			tCompFind_ActionTypes = modGlobalVars.e_find_form_action_types.geNoAction;

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Clear Seller and Buyer IDs
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			Seller_Comp_ID = 0;
			Seller_Contact_ID = 0;
			Seller_Contact_Type = "";
			Seller_Company_Business_Type = "";
			Seller_Aircraft_Business_Type = "";
			Seller_Comp_Name = "";
			Seller_Percentage = "";

			Buyer_Comp_ID = 0;
			Buyer_Contact_ID = 0;
			Buyer_Contact_Type = "";
			Buyer_Percentage = "";
			Buyer_Company_Business_Type = "";
			Buyer_Primary_Business_Type = "";
			Buyer_Comp_Name = "";

		}

		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{

			AvailListedDate = "";
			modAdminCommon.CLIENT_ADO_DB = null;

		}

		private void grd_Fractional_Click(Object eventSender, EventArgs eventArgs)
		{

			int Row = 0;

			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// The user wishes to Set the selected Owner row as 'Seller' or 'Buyer'
			// [NOTE: Don't allow removal of any of the Lease oriented contact types.]
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

			if (Trans_Type.Substring(0, Math.Min(1, Trans_Type.Length)).ToUpper() == "L")
			{
				txt_Percentage.Visible = false;
				lbl_Percentage.Visible = false;
				lbl_To_Buy_Sell.Visible = false;
			}
			else
			{
				txt_Percentage.Visible = true;
				lbl_Percentage.Visible = true;
				lbl_To_Buy_Sell.Visible = true;
			}
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Un-highlight all rows
			//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			int save_row = grd_Fractional.CurrentRowIndex;
			int save_col = grd_Fractional.CurrentColumnIndex;
			int tempForEndVar = grd_Fractional.RowsCount - 1;
			for (Row = 1; Row <= tempForEndVar; Row++)
			{
				grd_Fractional.CurrentRowIndex = Row;
				grd_Fractional.CurrentColumnIndex = 0;
				grd_Fractional.CellBackColor = Color.White;
				grd_Fractional.CellForeColor = Color.Black;
			}
			grd_Fractional.CurrentRowIndex = save_row;
			grd_Fractional.CurrentColumnIndex = save_col;

			pnl_Buyer.Visible = false;
			Row = grd_Fractional.CurrentRowIndex;
			if (Row > 0)
			{
				grd_Fractional.CurrentColumnIndex = 0;
				grd_Fractional.CellBackColor = SystemColors.Highlight;
				grd_Fractional.CellForeColor = Color.White;
				pnl_Indicate_Seller_Buyer.Visible = true;
				opt_Fractional_Seller.Checked = false;
				opt_Fractional_Buyer.Checked = false;
				grd_Fractional.CurrentColumnIndex = 1;

				if (txt_Percentage.Text.Trim() == "")
				{
					if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						txt_Percentage.Text = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.False);
					}
					else
					{
						if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
						{
							txt_Percentage.Text = Strings.FormatNumber(100, 3, TriState.False, TriState.False, TriState.False);
						}
					}

				}
				else
				{

					if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						txt_Percentage.Text = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.False);
					}

				}

				lbl_Percentage.Visible = false;
				txt_Percentage.Visible = false;
				lbl_To_Buy_Sell.Visible = false;

				grd_Fractional.CurrentColumnIndex = 4;

				if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Seller")
				{
					opt_Fractional_Seller.Checked = true;
					opt_Fractional_Buyer.Checked = false;
					grd_Fractional.CurrentColumnIndex = 3;

					if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						txt_Percentage.Text = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.False);
					}

				}
				else if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer"))
				{ 
					opt_Fractional_Seller.Checked = false;
					opt_Fractional_Buyer.Checked = true;
					grd_Fractional.CurrentColumnIndex = 3;

					if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						txt_Percentage.Text = Strings.FormatNumber(Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString())), 3, TriState.False, TriState.False, TriState.False);
					}

				}

				cmd_remove_grid_row.Enabled = !((grid_Array_contact_type[Row] == "00") || (grid_Array_contact_type[Row] == "12") || (grid_Array_contact_type[Row] == "13") || (grid_Array_contact_type[Row] == "17") || (grid_Array_contact_type[Row] == "39") || (grid_Array_contact_type[Row] == "57") || (grid_Array_contact_type[Row] == "97"));
			}
			grd_Fractional.CurrentColumnIndex = 5;


		}

		public void Fill_grd_Fractional(int AC_ID, int journ_id)
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			//*                                                                                        *
			//* Local Variables (Removed)                                                              *
			//*  buyer                         change_percent                new_percent               *
			//*                                                                                        *
			//******************************************************************************************

			string strError = "";
			try
			{

				string Query = "";
				ADORecordSetHelper snp_O = new ADORecordSetHelper(); //8/11/05 aey
				StringBuilder M = new StringBuilder();
				int Row = 0;
				double current_percent = 0; //aey 7/1/04

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Initialize the grid, headings, etc...
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				strError = "Start";
				grd_Fractional.Visible = false;
				grd_Fractional.Clear();
				grd_Fractional.RowsCount = 2;
				grd_Fractional.ColumnsCount = 6;
				grd_Fractional.CurrentRowIndex = 0;
				grd_Fractional.CurrentColumnIndex = 0;
				grd_Fractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Fractional.SetColumnWidth(0, 457);
				grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Type - Name";
				grd_Fractional.CurrentColumnIndex = 1;
				grd_Fractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Fractional.SetColumnWidth(1, 53);
				grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Current %";
				grd_Fractional.CurrentColumnIndex = 2;
				grd_Fractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Fractional.SetColumnWidth(2, 53);
				grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "New %";
				grd_Fractional.CurrentColumnIndex = 3;
				grd_Fractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Fractional.SetColumnWidth(3, 67);
				grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Net Change";
				grd_Fractional.CurrentColumnIndex = 4;
				grd_Fractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Fractional.SetColumnWidth(4, 77);

				strError = "trantype";

				if (Trans_Type == "FS")
				{
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Seller/Buyer";
					cmd_Identify_Fractional_Buyer.Text = "Buyer from Available Companies";
					cmd_await_doc.Visible = false;
					chkFractionalAwaitDocs.Visible = true;
					cmdDoneWithGrid.Visible = true;
					cmd_await_doc.Text = "Buyer Unknown/Awaiting Documentation";
					cmd_await_doc_Seller.Visible = false;
					cmd_await_doc_Seller.Text = "Seller Unknown/Awaiting Documentation";
				}
				else if (Trans_Type == "SS")
				{ 
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Seller/Buyer";
					cmd_Identify_Fractional_Buyer.Text = "Buyer/Seller from Available Companies";
					cmd_await_doc.Visible = false;
					chkFractionalAwaitDocs.Visible = true;
					cmdDoneWithGrid.Visible = true;
					cmd_await_doc.Text = "Buyer Unknown/Awaiting Documentation";
					cmd_await_doc_Seller.Visible = false;
					cmd_await_doc_Seller.Text = "Seller Unknown/Awaiting Documentation";
				}
				else if (Trans_Type == "WS")
				{ 
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Seller/Buyer";
				}
				else
				{
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Lessor/Lessee";
					cmd_Identify_Fractional_Buyer.Text = "Lessee from Available Companies";
					cmd_await_doc.Visible = false;
					chkFractionalAwaitDocs.Visible = true;
					cmdDoneWithGrid.Visible = true;
					cmd_await_doc.Text = "Lessee Unknown/Awaiting Documentation";
					cmd_await_doc_Seller.Visible = false;
				}

				grd_Fractional.CurrentColumnIndex = 5;
				grd_Fractional.CellBackColor = ColorTranslator.FromOle(Convert.ToInt32(Double.Parse(modAdminCommon.HeadingColor)));
				grd_Fractional.SetColumnWidth(5, 60);
				grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Trans Type";
				grd_Fractional.FixedRows = 1;
				grd_Fractional.FixedColumns = 0;

				strError = "ac >0 ";
				string lquery = "";
				if (AC_ID > 0)
				{
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// Retrieve all Holder/Owner References for the Aircraft [ac_id]
					// from the 'Aircraft_Reference' table
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					grid_Array_comp_id = new int[3];
					grid_Array_comp_Bus_Type = new string[]{"", "", ""};
					grid_Array_contact_id = new int[3];
					grid_Array_contact_type = new string[]{"", "", ""};
					grid_Array_POC = new string[]{"", "", ""};
					grid_Array_comp_name = new string[]{"", "", ""};
					grid_Array_fraction_expire_date = new string[]{"", "", ""};

					Query = "SELECT cref_ac_id, ";
					Query = $"{Query}cref_journ_id, ";
					Query = $"{Query}cref_comp_id, ";
					Query = $"{Query}cref_owner_percent, ";
					Query = $"{Query}cref_contact_id, ";
					Query = $"{Query}cref_contact_type, ";
					Query = $"{Query}cref_primary_poc_flag, ";
					Query = $"{Query}cref_fraction_expires_date, ";
					Query = $"{Query}comp_id, ";
					Query = $"{Query}comp_name, ";
					Query = $"{Query}comp_city, ";
					Query = $"{Query}comp_state, ";
					Query = $"{Query}comp_business_type, ";
					Query = $"{Query}actype_code, ";
					Query = $"{Query}actype_name ";
					Query = $"{Query}FROM Aircraft_Reference, Company, Aircraft_Contact_Type ";
					Query = $"{Query}WHERE cref_ac_id = {AC_ID.ToString()}";
					Query = $"{Query} AND cref_journ_id = {journ_id.ToString()}";
					Query = $"{Query} AND cref_comp_id = comp_id";
					Query = $"{Query} AND comp_journ_id = {journ_id.ToString()}";
					Query = $"{Query} AND cref_contact_type = actype_code";

					if (Trans_Type == "FS")
					{
						Query = $"{Query} AND cref_contact_type IN ('00', '17', '97') ";
					}
					else if (Trans_Type == "SS")
					{ 
						Query = $"{Query} AND cref_contact_type IN ('00', '08', '17') ";
					}
					else if (Trans_Type == "WS")
					{ 
						Query = $"{Query} AND cref_contact_type IN ('00', '17', '18', '19') "; //86,89
					}
					else if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
					{ 
						lquery = $"select ac_id from Aircraft where ac_id = {AC_ID.ToString()} and ac_journ_id = 0 and ac_lease_flag = 'Y'";
						if (!modAdminCommon.Exist(lquery))
						{ // if aircraft is not leased
							Query = $"{Query}  AND cref_contact_type IN ('00','97','17') ";
						}
						else
						{
							// if aircraft is leased
							Query = $"{Query}  AND cref_contact_type IN ('12', '13', '39', '57') ";
						}
					}

					Query = $"{Query}ORDER BY cref_contact_type ";

					MOD_Seller.comp_id = 0;
					strError = "query";

					snp_O.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

					if (!(snp_O.BOF && snp_O.EOF))
					{


						while(!snp_O.EOF)
						{
							strError = $"con_type: {Convert.ToString(snp_O["cref_contact_type"])} ";

							if (($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() == "36")
							{
								// we have an operator
							}
							else if ((($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() == "95"))
							{ 
								MOD_Seller.comp_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_O["comp_id"])}").Trim()));
								MOD_Seller.contact_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_O["cref_contact_id"])}").Trim()));
								MOD_Seller.Contact_Type = ($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim();
								MOD_Seller.percent = Double.Parse(($"0{Convert.ToString(snp_O["cref_owner_percent"])}").Trim());
								MOD_Seller.business_type = ($"{Convert.ToString(snp_O["comp_business_type"])}").Trim();
							}
							else if ((($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() == "96"))
							{ 
								MOD_Buyer.comp_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_O["comp_id"])}").Trim()));
								MOD_Buyer.contact_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_O["cref_contact_id"])}").Trim()));
								MOD_Buyer.Contact_Type = ($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim();
								MOD_Buyer.percent = Double.Parse(($"0{Convert.ToString(snp_O["cref_owner_percent"])}").Trim());
								MOD_Buyer.business_type = ($"{Convert.ToString(snp_O["comp_business_type"])}").Trim();
							}
							else if ((($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() == "55") || (($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() == "13"))
							{ 
								MOD_Seller.comp_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_O["comp_id"])}").Trim()));
								MOD_Seller.contact_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_O["cref_contact_id"])}").Trim()));
								MOD_Seller.Contact_Type = ($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim();
								MOD_Seller.percent = Double.Parse(($"0{Convert.ToString(snp_O["cref_owner_percent"])}").Trim());
								MOD_Seller.business_type = ($"{Convert.ToString(snp_O["comp_business_type"])}").Trim();
							}
							else if ((($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() == "12") || (($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() == "65"))
							{ 
								MOD_Buyer.comp_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_O["comp_id"])}").Trim()));
								MOD_Buyer.contact_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_O["cref_contact_id"])}").Trim()));
								MOD_Buyer.Contact_Type = ($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim();
								MOD_Buyer.percent = Double.Parse(($"0{Convert.ToString(snp_O["cref_owner_percent"])}").Trim());
								MOD_Buyer.business_type = ($"{Convert.ToString(snp_O["comp_business_type"])}").Trim();
							}
							if ((($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() != "36") && (($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() != "95") && (($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() != "96"))
							{
								grid_Array_comp_id = ArraysHelper.RedimPreserve(grid_Array_comp_id, new int[]{grd_Fractional.RowsCount + 1});
								grid_Array_comp_Bus_Type = ArraysHelper.RedimPreserve(grid_Array_comp_Bus_Type, new int[]{grd_Fractional.RowsCount + 1});
								grid_Array_contact_id = ArraysHelper.RedimPreserve(grid_Array_contact_id, new int[]{grd_Fractional.RowsCount + 1});
								grid_Array_contact_type = ArraysHelper.RedimPreserve(grid_Array_contact_type, new int[]{grd_Fractional.RowsCount + 1});
								grid_Array_POC = ArraysHelper.RedimPreserve(grid_Array_POC, new int[]{grd_Fractional.RowsCount + 1});
								grid_Array_comp_name = ArraysHelper.RedimPreserve(grid_Array_comp_name, new int[]{grd_Fractional.RowsCount + 1});
								grid_Array_fraction_expire_date = ArraysHelper.RedimPreserve(grid_Array_fraction_expire_date, new int[]{grd_Fractional.RowsCount + 1});

								grid_Array_comp_id[grd_Fractional.CurrentRowIndex] = Convert.ToInt32(Double.Parse(($"0{Convert.ToString(snp_O["comp_id"])}").Trim()));
								grid_Array_comp_Bus_Type[grd_Fractional.CurrentRowIndex] = ($"{Convert.ToString(snp_O["comp_business_type"])}").Trim();
								grid_Array_contact_id[grd_Fractional.CurrentRowIndex] = Convert.ToInt32(Conversion.Val($"{Convert.ToString(snp_O["cref_contact_id"])}"));
								grid_Array_contact_type[grd_Fractional.CurrentRowIndex] = ($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim();
								grid_Array_POC[grd_Fractional.CurrentRowIndex] = ($"{Convert.ToString(snp_O["cref_primary_poc_flag"])}").Trim();
								grid_Array_fraction_expire_date[grd_Fractional.CurrentRowIndex] = ($"{Convert.ToString(snp_O["cref_fraction_expires_date"])}").Trim();
								//'''''''''''''''''''''''''''''''
								// These Fields No Longer Exist '
								//'''''''''''''''''''''''''''''''
								grid_Array_comp_name[grd_Fractional.CurrentRowIndex] = ($"0{Convert.ToString(snp_O["comp_name"])}").Trim();
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								// Preserve Point of Contact information
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								if (($"{Convert.ToString(snp_O["cref_primary_poc_flag"])}").Trim().ToUpper() == "Y")
								{
									POC_Row = grd_Fractional.CurrentRowIndex;
								}
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								// Put Company Information into column 0
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								M = new StringBuilder(($"{Convert.ToString(snp_O["actype_name"])}").Trim());
								M.Append($" - {($"{Convert.ToString(snp_O["comp_name"])}").Trim()}");
								M.Append($" ({($"{Convert.ToString(snp_O["Comp_city"])}").Trim()}");
								M.Append($", {($"{Convert.ToString(snp_O["comp_state"])}").Trim()}");
								M.Append(")");
								grd_Fractional.CurrentColumnIndex = 0;
								grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = M.ToString();
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								// Put Current Percentage into column 1
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								grd_Fractional.CurrentColumnIndex = 1;
								if (Conversion.Val($"{Convert.ToString(snp_O["cref_owner_percent"])}") <= 0)
								{
									if (($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() == "00")
									{
										grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "100";
									}
								}
								else if (($"{Convert.ToString(snp_O["cref_contact_type"])}").Trim() == "17")
								{ 
									grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = StringsHelper.Format(($"0{Convert.ToString(snp_O["cref_owner_percent"])}").Trim(), "###,###,##0.000");
								}
								else
								{
									grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = StringsHelper.Format(($"0{Convert.ToString(snp_O["cref_owner_percent"])}").Trim(), "###,###,##0.000");
								}
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								// Clear New Percentage in column 2
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								grd_Fractional.CurrentColumnIndex = 2;
								grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								// Clear Net Change in column 3
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								grd_Fractional.CurrentColumnIndex = 3;
								grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								// Clear Seller/Buyer in column 4
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								grd_Fractional.CurrentColumnIndex = 4;
								grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								// Clear Trans Code in column 5
								//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
								grd_Fractional.CurrentColumnIndex = 5;
								grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
								grd_Fractional.RowsCount++;
								grd_Fractional.CurrentRowIndex++;
							}
							snp_O.MoveNext();
						};
					}
					snp_O.Close();
					snp_O = null;

					if (grd_Fractional.RowsCount > 2)
					{
						grd_Fractional.RowsCount--;
					}


					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// IF this is an Aircraft Lease transaction
					//    IF there is no current Lessor
					//       IF there is one grid row filled
					//          Fill the New column = 0%
					//          Fill the Net Change column = 100%
					//          Fill the Lessor/Lessee column to 'Lessor'
					//       ENDIF
					//    ENDIF
					// ENDIF
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					strError = "lease";
					if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
					{
						if ((MOD_Seller.comp_id == 0) && (MOD_Buyer.comp_id == 0))
						{
							Row = 1;
							if (grid_Array_comp_id[Row] > 0 && grid_Array_contact_type[grd_Fractional.CurrentRowIndex] != "97")
							{
								grd_Fractional.CurrentRowIndex = Row;
								grd_Fractional.CurrentColumnIndex = 1;
								grd_Fractional.CurrentColumnIndex = 2;
								grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "0";
								grd_Fractional.CurrentColumnIndex = 3;
								grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = Strings.FormatNumber(-100, 3, TriState.False, TriState.False, TriState.False);
								grd_Fractional.CurrentColumnIndex = 4;
								grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "Lessor";
								Seller_Company_Business_Type = grid_Array_comp_Bus_Type[grd_Fractional.CurrentRowIndex];
								Seller_Comp_Name = grid_Array_comp_name[grd_Fractional.CurrentRowIndex];
								MOD_Seller.comp_id = grid_Array_comp_id[grd_Fractional.CurrentRowIndex];
								MOD_Seller.contact_id = grid_Array_contact_id[grd_Fractional.CurrentRowIndex];
								MOD_Seller.Contact_Type = grid_Array_contact_type[grd_Fractional.CurrentRowIndex];
								MOD_Seller.percent = current_percent;
								MOD_Seller.business_type = MOD_Seller.business_type;
							}
						}
					}

				}

				if (Trans_Type != "WS")
				{
					grd_Fractional.Visible = true;
					grd_Fractional.Redraw = true;
				}

				snp_O = null;

				Working_Off();
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				strError = $"{strError}ac_id:{AC_ID.ToString()} jid{journ_id.ToString()} {Information.Err().Number.ToString()} {excep.Message} ac:{AC_ID.ToString()} jid:{journ_id.ToString()} tt:{Trans_Type}";
				Working_Off();
				modAdminCommon.Report_Error($"Fill_grd_Fractional_Error: {strError}");
				return;
			}

		}


		public void mnuFileClose_Click(Object eventSender, EventArgs eventArgs)
		{

			Been_Here = false;

			if (chk_Financial_Documents.CheckState == CheckState.Checked)
			{

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.JournalIDToShow = Journal_ID;
				frm_aircraft.DefInstance.ComingBackFromTransaction = bComingBackFromTransaction;
				frm_Transaction_Documents.DefInstance.Buyer_Contact_ID = Buyer_Contact_ID;
				frm_Transaction_Documents.DefInstance.Buyer_Comp_ID = Buyer_Comp_ID;
				frm_Transaction_Documents.DefInstance.Transaction_Date = txt_transaction_date.Text.Trim();
				frm_Transaction_Documents.DefInstance.Journal_ID = Journal_ID;
				frm_Transaction_Documents.DefInstance.Entry_Point = "Aircraft_Change";
				frm_Transaction_Documents.DefInstance.From_Form = "Transaction";
				frm_Transaction_Documents.DefInstance.Show();
				frm_Transaction_Documents.DefInstance.Activate();

			}
			else
			{

				if (!modCommon.Is_Form_Already_Loaded("frm_Aircraft"))
				{
					//UPGRADE_ISSUE: (2064) Void method Global.Load was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//VB.Global.Load(frm_aircraft.DefInstance);
				}

				frm_aircraft.DefInstance.Form_Initialize();
				frm_aircraft.DefInstance.StartForm = modGlobalVars.tStart_Form;
				frm_aircraft.DefInstance.ComingBackFromTransaction = bComingBackFromTransaction;
				frm_aircraft.DefInstance.LeaseSuccess = true;
				frm_aircraft.DefInstance.JournalIDToShow = Journal_ID;
				frm_aircraft.DefInstance.VS_journ_id_ForSale = VS_journ_id;
				frm_aircraft.DefInstance.Show();
				//UPGRADE_WARNING: (2065) Form method frm_aircraft.ZOrder has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.BringToFront();
				//UPGRADE_WARNING: (2065) Form event Form.Activated has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2065
				frm_aircraft.DefInstance.Form_Activated(frm_aircraft.DefInstance, new EventArgs());

			}

			if (modGlobalVars.bCallShowAndLoadOnlyOnce)
			{

				//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
				modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].Clear_Search_Criteria(true, false, true);

			}

			this.Close();

		}

		private bool isInitializingComponent;
		private void opt_Current_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				lbl_Registration_No.Visible = false;
				txt_Registration_No.Visible = false;

			}
		}

		private void opt_Fractional_Buyer_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				string M = "";
				bool OK = false;
				int saved_row = 0;

				if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
				{
					txt_Percentage.Visible = false;
					lbl_Percentage.Visible = false;
					lbl_To_Buy_Sell.Visible = false;
				}
				else
				{
					lbl_Percentage.Visible = true;
					txt_Percentage.Visible = true;
					lbl_To_Buy_Sell.Visible = true;
					lbl_To_Buy_Sell.Text = "To Buy";
				}

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// For Share Sale Transactions, allow only 1 Buyer
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				if (Trans_Type == "SS")
				{
					OK = true;
					saved_row = grd_Fractional.CurrentRowIndex;
					int tempForEndVar = grd_Fractional.RowsCount - 1;
					for (int Row = 1; Row <= tempForEndVar; Row++)
					{
						grd_Fractional.CurrentRowIndex = Row;
						grd_Fractional.CurrentColumnIndex = 4;
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer")
						{
						}
						else if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessee")
						{ 
							if (saved_row != Row)
							{
								M = "Only 1 Lessee allowed per transaction.";
								MessageBox.Show(M, "LESSEE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
								OK = false;
								pnl_Indicate_Seller_Buyer.Visible = false;
								break;
							}
						}
					}
					grd_Fractional.CurrentRowIndex = saved_row;

					if (!OK)
					{
						cmd_Fractional_Cancel_Click(cmd_Fractional_Cancel, new EventArgs());
					}

				}
				else if ((Trans_Type == "FS"))
				{ 
					OK = true;
					saved_row = grd_Fractional.CurrentRowIndex;
					int tempForEndVar2 = grd_Fractional.RowsCount - 1;
					for (int Row = 1; Row <= tempForEndVar2; Row++)
					{
						grd_Fractional.CurrentRowIndex = Row;
						grd_Fractional.CurrentColumnIndex = 4;
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer")
						{
							if (saved_row != Row)
							{
								M = "Only 1 Buyer allowed per transaction UPDATE.";
								MessageBox.Show(M, "BUYER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
								OK = false;
								pnl_Indicate_Seller_Buyer.Visible = false;
								break;
							}
						}
					}
					grd_Fractional.CurrentRowIndex = saved_row;

					if (!OK)
					{
						cmd_Fractional_Cancel_Click(cmd_Fractional_Cancel, new EventArgs());
					}
				}

			}
		}

		private void opt_Fractional_Seller_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				string M = "";

				if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
				{
					txt_Percentage.Visible = false;
					lbl_Percentage.Visible = false;
					lbl_To_Buy_Sell.Visible = false;
				}
				else
				{
					lbl_Percentage.Visible = true;
					txt_Percentage.Visible = true;
					lbl_To_Buy_Sell.Visible = true;
					lbl_To_Buy_Sell.Text = "To Sell";
				}

				bool OK = true;
				int saved_row = grd_Fractional.CurrentRowIndex;
				int tempForEndVar = grd_Fractional.RowsCount - 1;
				for (int Row = 1; Row <= tempForEndVar; Row++)
				{
					grd_Fractional.CurrentRowIndex = Row;
					grd_Fractional.CurrentColumnIndex = 4;
					if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Seller")
					{
						if (saved_row != Row)
						{
							M = "Only 1 Seller allowed per transaction.";
							MessageBox.Show(M, "SELLER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
							pnl_Indicate_Seller_Buyer.Visible = false;
							break;
						}
					}
					else if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessor"))
					{ 
						if (saved_row != Row)
						{
							M = "Only 1 Lessor allowed per transaction.";
							MessageBox.Show(M, "LESSOR ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
							pnl_Indicate_Seller_Buyer.Visible = false;
							break;
						}
					}
				}
				grd_Fractional.CurrentRowIndex = saved_row;

				if (!OK)
				{
					cmd_Fractional_Cancel_Click(cmd_Fractional_Cancel, new EventArgs());
				}

			}
		}

		private void opt_Historical_CheckedChanged(Object eventSender, EventArgs eventArgs)
		{
			if (((RadioButton) eventSender).Checked)
			{
				if (isInitializingComponent)
				{
					return;
				}

				lbl_Registration_No.Visible = true;
				txt_Registration_No.Visible = true;
				txt_Registration_No.Focus();
				if (Trans_Type.StartsWith("L", StringComparison.Ordinal) && opt_Historical.Checked)
				{
					pnl_Fractional_Seller.Visible = false;
					pnl_Seller.Visible = true;
					pnl_Buyer.Visible = true;
				}

				if (opt_Historical.Checked)
				{
					chk_Avail_Prior.Enabled = true;
					lbl_Avail_Prior.Enabled = true;
				}



			}
		}

		private void tbr_ToolBar_ButtonClick(Object eventSender, EventArgs eventArgs)
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
						Journal_ID = 0; 
						mnuFileClose_Click(mnuFileClose, new EventArgs()); 
						 
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

				modAdminCommon.Report_Error($"tbr_ToolBar_Error: AC_Change {Button.Name} {excep.Message}");
				modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
				return;
			}

		}

		private void ToolbarButtonsSetup()
		{


			ToolStrip tbr = tbr_ToolBar; //gap-note ToolStrip instead of Control

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Visible = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Visible = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Visible = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Visible = true;

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Enabled = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Enabled = true;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Enabled = false;
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Enabled = true;

		}

		private void ToolbarSetup()
		{


			ToolStrip tbr = tbr_ToolBar; //gap-note ToolStrip instead of Control

			//UPGRADE_TODO: (1067) Member ImageList is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.ImageList = mdi_ResearchAssistant.DefInstance.imgNormal;

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[2] as ToolStripButton).Image = (Image) resources.GetObject( "Home");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[4] as ToolStripButton).Image = (Image) resources.GetObject( "Back");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[6] as ToolStripButton).Image = (Image) resources.GetObject( "Save");
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			(tbr.Items[8] as ToolStripButton).Image = (Image) resources.GetObject( "Help");

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].Text = "Home";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].Text = "Back";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].Text = "Save";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].Text = "Help";

			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[2].ToolTipText = "Go to Main Menu";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[4].ToolTipText = "Go to Previous Screen";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[6].ToolTipText = "Save screen data";
			//UPGRADE_TODO: (1067) Member Buttons is not defined in type VB.Control. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
			tbr.Items[8].ToolTipText = "Online Help";

		}

		private void Setup_Form()
		{
			//******************************************************************************************
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Default to a current transaction
			// Clear the Registration Number field
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// SET TO A HISTORICAL FRACTIONAL SALE IF THE AIRCRAFT IS WHOLLY OWNED
			if (Aircraft_Ownership_Type == "W" && Trans_Type == "FS")
			{
				opt_Historical.Checked = true;
				lbl_Registration_No.Visible = true;
				txt_Registration_No.Visible = true;
				opt_Current.Enabled = false;
				// SET TO A HISTORICAL Lease SALE IF THE AIRCRAFT IS OF SHARED OWNERSHIP
			}
			else if (Aircraft_Ownership_Type == "S" && Trans_Type == "LA")
			{ 
				opt_Historical.Checked = true;
				lbl_Registration_No.Visible = true;
				txt_Registration_No.Visible = true;
				opt_Current.Enabled = false;
				// SET TO A HISTORICAL WHOLE SALE IF THE AIRCRAFT IS OF SHARED OWNERSHIP
			}
			else if (Aircraft_Ownership_Type == "S" && Trans_Type == "WS")
			{ 
				opt_Historical.Checked = true;
				lbl_Registration_No.Visible = true;
				txt_Registration_No.Visible = true;
				opt_Current.Enabled = false;
			}
			else
			{
				lbl_Registration_No.Visible = false;
				txt_Registration_No.Visible = false;
				opt_Current.Checked = true;
			}

			txt_Registration_No.Text = "";
			chk_Date_Sold_Unknown.Visible = false;

			pnl_Sale_Type.Visible = true; //Step 1

			pnl_Date.Visible = true; //Step 2

			opt_Current.Visible = true;
			opt_Historical.Visible = true;

			Prior_Availability = Aircraft_Available(modAdminCommon.gbl_Aircraft_ID, MOD_Journal_ID);

			cmd_Cancel.Text = "Cancel Transaction";
			cmd_Commit_Transaction.Text = "Commit Transaction";

			switch(Trans_Type)
			{
				case "FS" :  // Setup form for fractional sale 
					cmd_await_doc.Visible = false; 
					chkFractionalAwaitDocs.Visible = true; 
					cmdDoneWithGrid.Visible = true; 
					cmd_await_doc_Seller.Visible = false; 
					lbl_Message.Text = "Fractional Sales Transaction"; 
					lbl_Trans_Seller.Text = "Seller Type"; 
					lbl_Trans_Buyer.Text = "Buyer Type"; 
					pnl_Seller.Visible = false;  //Step 3 
					cmd_Identify_Fractional_Buyer.Text = "Add New Fractional Buyer"; 
					lbl_Fraction_Sale.Text = "Step 3: Fractional Sale"; 
					pnl_Buyer.Visible = false;  //Step 4 
					pnl_Registered_As.Visible = false;  //Step 4a 
					pnl_Fractional_Seller.Visible = true;  //Step 3/4 
					pnl_Indicate_Seller_Buyer.Visible = false; 
					lbl_Percentage.Visible = false; 
					txt_Percentage.Visible = false; 
					lbl_To_Buy_Sell.Visible = false; 
					pnl_Verify.Visible = false;  //Step 5 
					chk_Financial_Documents.Visible = false; 
					Fill_grd_Fractional(0, MOD_Journal_ID); 
					lbl_Aircrft_Ownership_Worksheet.Text = "Aircraft Fractional Ownership Worksheet"; 
					pnl_Lease_Information.Visible = false; 
					 
					break;
				case "WS" :  // Setup form for full sale 
					lbl_Message.Text = "Full Aircraft Sale Transaction"; 
					lbl_Trans_Seller.Text = "Seller Type"; 
					lbl_Trans_Buyer.Text = "Buyer Type"; 
					pnl_Seller.Visible = true;  //Step 3 
					lbl_Step_3.Text = "STEP 3: Seller"; 
					cmd_Identify_Seller.Text = "Identify Seller"; 
					pnl_Buyer.Visible = true;  //Step 4 
					pnl_Registered_As.Visible = true;  //Step 4a 
					pnl_Indicate_Seller_Buyer.Visible = false; 
					cmd_Fractional_Buyer_OK.Visible = false; 
					cmd_Fractional_Buyer_Cancel.Visible = false; 
					lbl_Step_4.Text = "STEP 4: Buyer"; 
					cmd_Identify_Buyer.Text = "Identify Buyer"; 
					cmd_Fractional_Buyer_OK.Visible = false; 
					cmd_Fractional_Buyer_Cancel.Visible = false; 
					pnl_Fractional_Seller.Visible = false;  //Step 3/4 
					pnl_Verify.Visible = true;  //Step 5 
					chk_Financial_Documents.Visible = true; 
					pnl_Lease_Information.Visible = false; 
					 
					chk_NewAircraft.CheckState = CheckState.Unchecked; 
					if (Aircraft_LifeCycle_Stage == "1" || Aircraft_LifeCycle_Stage == "2")
					{
						if (!CheckForNUTransaction(modAdminCommon.gbl_Aircraft_ID))
						{
							chk_NewAircraft.CheckState = CheckState.Checked;
						}
					} 
					 
					break;
				case "SZ" :  // Setup form for Government Seizure 
					lbl_Message.Text = "Government Seizure Transaction"; 
					lbl_Trans_Seller.Text = "Owner Type"; 
					lbl_Trans_Buyer.Text = "Seized by Type"; 
					pnl_Seller.Visible = true;  //Step 3 
					lbl_Step_3.Text = "STEP 3: Owner"; 
					cmd_Identify_Seller.Text = "Identify Owner"; 
					pnl_Buyer.Visible = true;  //Step 4 
					pnl_Registered_As.Visible = true;  //Step 4a 
					pnl_Indicate_Seller_Buyer.Visible = false; 
					cmd_Fractional_Buyer_OK.Visible = false; 
					cmd_Fractional_Buyer_Cancel.Visible = false; 
					lbl_Step_4.Text = "STEP 4: Seized by"; 
					cmd_Identify_Buyer.Text = "Identify Seized by"; 
					cmd_Fractional_Buyer_OK.Visible = false; 
					cmd_Fractional_Buyer_Cancel.Visible = false; 
					pnl_Fractional_Seller.Visible = false;  //Step 3/4 
					pnl_Verify.Visible = true;  //Step 5 
					chk_Financial_Documents.Visible = false; 
					pnl_Lease_Information.Visible = false; 
					 
					break;
				case "FC" :  // Setup form for Repossession/Foreclosure 
					lbl_Message.Text = "Repossession/Foreclosure Transaction"; 
					lbl_Trans_Seller.Text = "Owner Type"; 
					lbl_Trans_Buyer.Text = "Repossed by Type"; 
					pnl_Seller.Visible = true;  //Step 3 
					lbl_Step_3.Text = "STEP 3: Owner"; 
					cmd_Identify_Seller.Text = "Identify Owner"; 
					pnl_Buyer.Visible = true;  //Step 4 
					pnl_Registered_As.Visible = true;  //Step 4a 
					pnl_Indicate_Seller_Buyer.Visible = false; 
					cmd_Fractional_Buyer_OK.Visible = false; 
					cmd_Fractional_Buyer_Cancel.Visible = false; 
					lbl_Step_4.Text = "STEP 4: Reposessed By"; 
					cmd_Identify_Buyer.Text = "Identify Repossed By"; 
					cmd_Fractional_Buyer_OK.Visible = false; 
					cmd_Fractional_Buyer_Cancel.Visible = false; 
					pnl_Fractional_Seller.Visible = false;  //Step 3/4 
					pnl_Verify.Visible = true;  //Step 5 
					chk_Financial_Documents.Visible = true; 
					pnl_Lease_Information.Visible = false; 
					 
					break;
				case "SS" :  // Setup form for Share Sale 
					cmd_await_doc.Visible = false; 
					chkFractionalAwaitDocs.Visible = true; 
					cmdDoneWithGrid.Visible = true; 
					cmd_await_doc_Seller.Visible = false; 
					lbl_Message.Text = "Aircraft Share Sale Transaction"; 
					lbl_Trans_Seller.Text = "Seller Type"; 
					lbl_Trans_Buyer.Text = "Buyer Type"; 
					pnl_Seller.Visible = false;  //Step 3 
					cmd_Identify_Fractional_Buyer.Text = "Add New Share Buyer"; 
					lbl_Fraction_Sale.Text = "Step 3: Share Sale"; 
					pnl_Buyer.Visible = false;  //Step 4 
					pnl_Registered_As.Visible = false;  //Step 4a 
					pnl_Fractional_Seller.Visible = true;  //Step 3/4 
					pnl_Indicate_Seller_Buyer.Visible = false; 
					lbl_Percentage.Visible = false; 
					txt_Percentage.Visible = false; 
					lbl_To_Buy_Sell.Visible = false; 
					pnl_Verify.Visible = false;  //Step 5 
					chk_Financial_Documents.Visible = true; 
					Fill_grd_Fractional(0, MOD_Journal_ID); 
					lbl_Aircrft_Ownership_Worksheet.Text = "Aircraft Shared Ownership Worksheet"; 
					pnl_Lease_Information.Visible = false; 
					 
					break;
				case "DP" :  // Setup form for Delivery Position 
					lbl_Message.Text = "Delivery Position Transaction"; 
					lbl_Trans_Seller.Text = "Seller Type"; 
					lbl_Trans_Buyer.Text = "Buyer Type"; 
					pnl_Seller.Visible = true;  //Step 3 
					lbl_Step_3.Text = "STEP 3: Seller"; 
					cmd_Identify_Seller.Text = "Identify Seller"; 
					pnl_Buyer.Visible = true;  //Step 4 
					pnl_Registered_As.Visible = true;  //Step 4a 
					pnl_Indicate_Seller_Buyer.Visible = false; 
					cmd_Fractional_Buyer_OK.Visible = false; 
					cmd_Fractional_Buyer_Cancel.Visible = false; 
					lbl_Step_4.Text = "STEP 4: Buyer"; 
					cmd_Identify_Buyer.Text = "Identify DP Holder"; 
					cmd_Fractional_Buyer_OK.Visible = false; 
					cmd_Fractional_Buyer_Cancel.Visible = false; 
					pnl_Fractional_Seller.Visible = false;  //Step 3/4 
					pnl_Verify.Visible = true;  //Step 5 
					chk_Financial_Documents.Visible = true; 
					pnl_Lease_Information.Visible = false; 
					 
					break;
				default: // check if it is a lease 
					if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
					{
						cmd_await_doc.Visible = false;
						chkFractionalAwaitDocs.Visible = false;
						cmdDoneWithGrid.Visible = true;
						cmd_await_doc_Seller.Visible = false;
						lbl_Message.Text = "Aircraft Lease Transaction";
						lbl_Trans_Seller.Text = "Lessor Type";
						lbl_Trans_Buyer.Text = "Lessee Type";
						cmd_Identify_Seller.Text = "Identify Lessor";
						lbl_Step_3.Text = "STEP 3: Lessor";
						pnl_Seller.Visible = false; //Step 3
						pnl_Buyer.Visible = false; //Step 4
						pnl_Registered_As.Visible = false; //Step 4a
						lbl_Fraction_Sale.Text = "Step 3: Aircraft Lease";
						pnl_Fractional_Seller.Visible = true; //Step 3/4
						pnl_Indicate_Seller_Buyer.Visible = false;
						cmd_Fractional_Buyer_OK.Visible = false;
						cmd_Fractional_Buyer_Cancel.Visible = false;
						lbl_Step_4.Text = "STEP 4: Lessee";
						cmd_Identify_Buyer.Text = "Identify Lessee";
						cmd_Fractional_Buyer_OK.Visible = false;
						cmd_Fractional_Buyer_Cancel.Visible = false;
						lbl_Percentage.Visible = false;
						txt_Percentage.Visible = false;
						lbl_To_Buy_Sell.Visible = false;
						pnl_Verify.Visible = false; //Step 5
						chk_Financial_Documents.Visible = false;
						Fill_grd_Fractional(0, MOD_Journal_ID);
						pnl_Lease_Information.Visible = true; //Lease Information


						if (Prior_Availability)
						{
							chk_Avail_Prior.CheckState = CheckState.Checked;
							chk_Lease_Take_Off_Market.Visible = true;
						}
						else
						{
							chk_Avail_Prior.CheckState = CheckState.Unchecked;
							chk_Lease_Take_Off_Market.Visible = false;
						}


						chk_Avail_Prior.Enabled = false;
						if ((chk_Avail_Prior.CheckState == CheckState.Checked) && (chk_Lease_Take_Off_Market.CheckState == CheckState.Unchecked))
						{
							Trans_Type = "LA";
						}
						else if ((chk_Avail_Prior.CheckState == CheckState.Checked) && (chk_Lease_Take_Off_Market.CheckState == CheckState.Checked))
						{ 
							Trans_Type = "LO";
						}
						else if ((chk_Avail_Prior.CheckState == CheckState.Unchecked) && (chk_Lease_Take_Off_Market.CheckState == CheckState.Checked))
						{ 
							Trans_Type = "LN";
						}
						else if ((chk_Avail_Prior.CheckState == CheckState.Unchecked) && (chk_Lease_Take_Off_Market.CheckState == CheckState.Unchecked))
						{ 
							Trans_Type = "LT";
						}
						else
						{
							Trans_Type = "LS";
						}
						lbl_Aircrft_Ownership_Worksheet.Text = "Aircraft Leased Ownership Worksheet";
						cmd_Identify_Fractional_Buyer.Text = "Add New Lessee";
						opt_Fractional_Seller.Text = "Lessor";
						opt_Fractional_Buyer.Text = "Lessee";
					}  // if a lease 
					break;
			} // case on the transaction type

			cmd_Commit_Transaction.Enabled = false;

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Set transaction date to TODAY
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			cal_transaction_date.SetDate(DateTime.Parse(modAdminCommon.DateToday));
			txt_transaction_date.Text = DateTimeHelper.ToString(cal_transaction_date.SelectionRange.Start);

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Initialize the 'chk_Awaiting_Documentation' panel
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			chk_Awaiting_Documentation_CheckStateChanged(chk_Awaiting_Documentation, new EventArgs());

			modFillCompConControls.fill_state_FromArray(cbo_Unknown_State, false, true, false);
			modFillCompConControls.fill_country_FromArray(cbo_Unknown_Country);

			if ((Trans_Type != "SS") && (Trans_Type != "FS") && (!Trans_Type.StartsWith("L", StringComparison.Ordinal)))
			{
				if (opt_Current.Checked)
				{
					modAircraftChange.Get_Seller(Trans_Type, MOD_Journal_ID, pnl_Seller, lst_Seller, cbo_Trans_Seller, ref Seller_Comp_ID, ref Seller_Contact_ID, ref Seller_Contact_Type, ref Seller_Aircraft_Business_Type, ref Seller_Company_Business_Type, ref Seller_Comp_Name);
				}
			}

			if (chk_Internal_Transaction.CheckState == CheckState.Checked)
			{
				if (Aircraft_Available(modAdminCommon.gbl_Aircraft_ID, MOD_Journal_ID))
				{
					chk_was_available.CheckState = CheckState.Checked;
					chk_Lease_Take_Off_Market.Visible = true;
					chk_Lease_Take_Off_Market.CheckState = CheckState.Unchecked;
				}
				else
				{
					chk_was_available.CheckState = CheckState.Unchecked;
					chk_Lease_Take_Off_Market.Visible = false;
				}
			}
			else
			{
				pnl_Update_Aircraft_row.Visible = false;
			}

		}

		private void Determine_Transaction_Type()
		{


			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Step 5 - Verify Transaction

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Position the 'cbo_Trans_Seller' combo box using 'Seller_Company_Business_Type'
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			cbo_Trans_Seller_Click_SKIP = true;
			if (Strings.Len(Seller_Company_Business_Type.Trim()) > 0)
			{
				int tempForEndVar = cbo_Trans_Seller.Items.Count - 1;
				for (int i = 0; i <= tempForEndVar; i++)
				{
					if (cbo_Trans_Seller.GetListItem(i).StartsWith(Seller_Company_Business_Type.Substring(0, Math.Min(2, Seller_Company_Business_Type.Length)), StringComparison.Ordinal))
					{
						cbo_Trans_Seller.SelectedIndex = i;
						break;
					}
				}
			}
			cbo_Trans_Seller_Click_SKIP = false;

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Position the 'cbo_Trans_Buyer' combo box using 'Buyer_Company_Business_Type'
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			cbo_Trans_Buyer_Click_SKIP = true;
			if (Strings.Len(Buyer_Company_Business_Type.Trim()) > 0)
			{
				int tempForEndVar2 = cbo_Trans_Buyer.Items.Count - 1;
				for (int i = 0; i <= tempForEndVar2; i++)
				{
					if (cbo_Trans_Buyer.GetListItem(i).StartsWith(Buyer_Company_Business_Type.Substring(0, Math.Min(2, Buyer_Company_Business_Type.Length)), StringComparison.Ordinal))
					{
						cbo_Trans_Buyer.SelectedIndex = i;
						break;
					}
				}
			}
			cbo_Trans_Buyer_Click_SKIP = false;

			Build_Transaction_Type();

			if ((Trans_Type != "FS") && (Trans_Type != "SS"))
			{
				if (cbo_Trans_Seller.Text != "" && cbo_Trans_Buyer.Text != "")
				{
					cmd_Commit_Transaction.Enabled = true;
				}
				else
				{
					// ADDED MSW - 5/2/2012 - IF THE BUYER BOX IS FILLED AND THE BUYER COMPANY TYPES
					// ARE NOT - THEN THE BUYER DOES NOT HAVE CORRECT BUSINESS TYPES
					// - IF THIS HAPPENS , DISPLAY THE LABEL IN RED AND SHOW WHY THE COMMIT BUTTON DOESNT SHOW
					if (lst_Buyer.Items.Count > 0 && cbo_Trans_Buyer.Visible)
					{
						lbl_no_bus_types.Text = "The Buyer Has InCorrect Business Types. Please Correct This Before Completing This Transaction.";
						lbl_no_bus_types.Visible = true;
					}
					cmd_Commit_Transaction.Enabled = false;
				}
			}
			else
			{
				cmd_Commit_Transaction.Enabled = (Transaction_OK() || chk_Awaiting_Documentation.CheckState == CheckState.Checked);

			}
			if (MOD_Trans_Type == "FSPEND")
			{
				cmd_Commit_Transaction.Enabled = true;
				cmd_Commit_Transaction.Text = "Convert to Sale";
			}

		}

		private bool Is_Internal_Transaction()
		{

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Analyze the Seller and Buyer Company relationship to determine if

			//aey 9/2/04 -- check to see if these companies have a current relationship
			bool result = false;
			string Query = "SELECT compref_internal_flag ";
			Query = $"{Query}FROM Company_Reference WITH(NOLOCK)";
			Query = $"{Query}WHERE compref_internal_flag='Y' and compref_journ_id =0 ";
			Query = $"{Query}AND ((compref_comp_id = {Buyer_Comp_ID.ToString()} and compref_rel_comp_id = {Seller_Comp_ID.ToString()}) ";
			Query = $"{Query}OR (compref_comp_id = {Seller_Comp_ID.ToString()} and compref_rel_comp_id = {Buyer_Comp_ID.ToString()})) ";

			if (modAdminCommon.Exist(Query))
			{
				chk_Internal_Transaction.CheckState = CheckState.Checked;
				return true;
			}

			if ((Buyer_Company_Business_Type == "MF" || Buyer_Company_Business_Type == "DS") && (Seller_Company_Business_Type == "MF" || Seller_Company_Business_Type == "DS"))
			{
				chk_Internal_Transaction.CheckState = CheckState.Checked;
				result = true;
			}


			return result;
		}

		private void Build_Transaction_Type()
		{


			Transaction_Type = Trans_Type;

			if (chk_Correction_Transaction.CheckState == CheckState.Checked)
			{
				Transaction_Type = $"{Transaction_Type}CORR";
			}
			else
			{
				if (Strings.Len(cbo_Trans_Seller.Text.Trim()) > 0)
				{
					Transaction_Type = $"{Transaction_Type}{cbo_Trans_Seller.Text.Trim().Substring(0, Math.Min(2, cbo_Trans_Seller.Text.Trim().Length))}";
				}
				else
				{
					Transaction_Type = $"{Transaction_Type} ";
				}

				if (chk_Internal_Transaction.CheckState == CheckState.Checked)
				{
					Transaction_Type = $"{Transaction_Type}IT";
				}
				else
				{
					if (Strings.Len(cbo_Trans_Buyer.Text.Trim()) > 0)
					{
						Transaction_Type = $"{Transaction_Type}{cbo_Trans_Buyer.Text.Trim().Substring(0, Math.Min(2, cbo_Trans_Buyer.Text.Trim().Length))}";
					}
					else
					{
						Transaction_Type = $"{Transaction_Type} ";
					}
				}
			}

			if (Trans_Type.StartsWith("WS", StringComparison.Ordinal) && Aircraft_LifeCycle_Stage == "1")
			{
				txt_Transaction_Type.Text = $"{Transaction_Type.Substring(0, Math.Min(2, Transaction_Type.Length))}MF{Transaction_Type.Substring(Math.Min(4, Transaction_Type.Length), Math.Min(2, Math.Max(0, Transaction_Type.Length - 4)))}";
			}
			else
			{
				txt_Transaction_Type.Text = Transaction_Type;
			}

			string TFrom = Transaction_Type.Substring(Math.Min(2, Transaction_Type.Length), Math.Min(2, Math.Max(0, Transaction_Type.Length - 2)));
			string TTo = Transaction_Type.Substring(Math.Min(4, Transaction_Type.Length), Math.Min(2, Math.Max(0, Transaction_Type.Length - 4)));

			if (TFrom == "EU" && (TTo == "MF" || TTo == "DS"))
			{
				MessageBox.Show($"Transaction: {Transaction_Type} is not allowed", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				cmd_Commit_Transaction.Visible = false;

			}

		}

		private void Add_Fractional_Buyer(int comp_id, int contact_id)
		{
			try
			{

				string Query = "";
				ADORecordSetHelper snp_B = new ADORecordSetHelper(); //8/11/05 aey
				string M = "";

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Add a New Fractional Buyer to the bottom of the 'grd_Fractional' grid
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				Query = "SELECT comp_id, comp_name, comp_city, comp_state, comp_business_type, cbus_type, cbus_name ";
				Query = $"{Query}FROM Company WITH(NOLOCK), Company_Business_Type WITH(NOLOCK)";
				Query = $"{Query}WHERE comp_id = {comp_id.ToString()} AND comp_journ_id = 0 AND comp_business_type = cbus_type";
				snp_B.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_B.BOF && snp_B.EOF))
				{
					grd_Fractional.RowsCount++;
					grd_Fractional.CurrentRowIndex = grd_Fractional.RowsCount - 1;
					grid_Array_comp_id = ArraysHelper.RedimPreserve(grid_Array_comp_id, new int[]{grd_Fractional.RowsCount + 1});
					grid_Array_comp_Bus_Type = ArraysHelper.RedimPreserve(grid_Array_comp_Bus_Type, new int[]{grd_Fractional.RowsCount + 1});
					grid_Array_contact_id = ArraysHelper.RedimPreserve(grid_Array_contact_id, new int[]{grd_Fractional.RowsCount + 1});
					grid_Array_contact_type = ArraysHelper.RedimPreserve(grid_Array_contact_type, new int[]{grd_Fractional.RowsCount + 1});
					grid_Array_POC = ArraysHelper.RedimPreserve(grid_Array_POC, new int[]{grd_Fractional.RowsCount + 1});
					grid_Array_comp_name = ArraysHelper.RedimPreserve(grid_Array_comp_name, new int[]{grd_Fractional.RowsCount + 1});
					//added aey 7/21/04
					grid_Array_fraction_expire_date = ArraysHelper.RedimPreserve(grid_Array_fraction_expire_date, new int[]{grd_Fractional.RowsCount + 1});

					grid_Array_comp_id[grd_Fractional.CurrentRowIndex] = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_B["comp_id"])}").Trim()));
					grid_Array_comp_Bus_Type[grd_Fractional.CurrentRowIndex] = ($"{Convert.ToString(snp_B["comp_business_type"])}").Trim();
					grid_Array_contact_id[grd_Fractional.CurrentRowIndex] = contact_id;
					grid_Array_contact_type[grd_Fractional.CurrentRowIndex] = ""; //"97"
					//'''''''''''''''''''''''''''''''
					// These Fields No Longer Exist '
					//'''''''''''''''''''''''''''''''
					grid_Array_comp_name[grd_Fractional.CurrentRowIndex] = ($"{Convert.ToString(snp_B["comp_name"])}").Trim();
					M = ($"{Convert.ToString(snp_B["cbus_name"])}").Trim();
					M = $"{M} - {($"{Convert.ToString(snp_B["comp_name"])}").Trim()}";
					M = $"{M} ({($"{Convert.ToString(snp_B["Comp_city"])}").Trim()}";
					M = $"{M}, {($"{Convert.ToString(snp_B["comp_state"])}").Trim()}";
					M = $"{M})";
					grd_Fractional.CurrentColumnIndex = 0;
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = M;
					grd_Fractional.CurrentColumnIndex = 1;
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
					grd_Fractional.CurrentColumnIndex = 2;
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
					grd_Fractional.CurrentColumnIndex = 3;
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
					grd_Fractional.CurrentColumnIndex = 4;
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
					grd_Fractional.CurrentColumnIndex = 5;
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
					grd_Fractional.Redraw = true;
				}
				else
				{
					Query = $"SELECT Comp_id FROM Company WITH(NOLOCK) WHERE comp_id = {comp_id.ToString()}";
					Query = $"{Query} AND comp_journ_id = 0 and comp_business_type NOT IN (Select cbus_type from Company_Business_type)";

					if (modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Company/Business Type Mismatch", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					}
				}
				snp_B.Close();
				snp_B = null;
			}
			catch
			{

				Working_Off();
				modAdminCommon.Report_Error("Add_Fractional_Buyer_Error: ");
				return;
			}

		}

		private bool Fractional_Sale_Complete()
		{

			double Total_Sales = 0;
			bool found_something = false;
			bool Seller_Found = false;
			bool Buyer_Found = false;

			if (chk_Correction_Transaction.CheckState == CheckState.Checked)
			{
				Seller_Found = false;
				Buyer_Found = false;
				int tempForEndVar = grd_Fractional.RowsCount - 1;
				for (int Row = 1; Row <= tempForEndVar; Row++)
				{
					grd_Fractional.CurrentRowIndex = Row;
					grd_Fractional.CurrentColumnIndex = 4;
					if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() == "Seller") || (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() == "Lessor"))
					{
						Seller_Found = true;
					}
					else if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() == "Buyer") || (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() == "Lessee") || chk_Awaiting_Documentation.CheckState == CheckState.Checked)
					{ 
						Buyer_Found = true;
					}
				}

				return Seller_Found && Buyer_Found;
			}
			else
			{
				Total_Sales = 0;
				found_something = false;
				int tempForEndVar2 = grd_Fractional.RowsCount - 1;
				for (int Row = 1; Row <= tempForEndVar2; Row++)
				{
					grd_Fractional.CurrentRowIndex = Row;
					grd_Fractional.CurrentColumnIndex = 3;
					if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() != "")
					{
						Total_Sales += Math.Abs(Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString()));
						found_something = true;
					}
				}

				return (Total_Sales > 0 && found_something) || (Total_Sales == 0 && chk_Awaiting_Documentation.CheckState == CheckState.Checked);
			}

		}


		private string Get_comp_name(int comp_id)
		{
			string result = "";
			try
			{

				string Query = "";
				ADORecordSetHelper ado_company = new ADORecordSetHelper();

				Query = $"SELECT comp_name FROM Company WITH(NOLOCK) WHERE comp_id = {comp_id.ToString()} AND comp_journ_id = 0";

				ado_company.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(ado_company.BOF && ado_company.EOF))
				{
					result = ($"{Convert.ToString(ado_company["comp_name"])}").Trim();
				}
				else
				{
					result = "";
				}

				ado_company.Close();
				ado_company = null;
			}
			catch
			{

				Working_Off();
				modAdminCommon.Report_Error("Get_comp_name_Error: ");
			}

			return result;
		}

		private void cbo_Trans_Seller_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (Strings.Len(cbo_Trans_Seller.Text) > 2)
			{
				Seller_Company_Business_Type = cbo_Trans_Seller.Text.Substring(0, Math.Min(2, cbo_Trans_Seller.Text.Length));
			}
			else
			{
				Seller_Company_Business_Type = "";
			}

			if (!cbo_Trans_Seller_Click_SKIP)
			{
				Determine_Transaction_Type();
			}

			if (Transaction_OK())
			{ //aey 5/25/05
				cmd_Commit_Transaction.Visible = true;
			}

		}

		private void cbo_Trans_Buyer_SelectedIndexChanged(Object eventSender, EventArgs eventArgs)
		{

			if (Buyer_Comp_ID > 0 || chk_Awaiting_Documentation.CheckState == CheckState.Checked)
			{
				if (Strings.Len(cbo_Trans_Buyer.Text) > 2)
				{
					Buyer_Company_Business_Type = cbo_Trans_Buyer.Text.Substring(0, Math.Min(2, cbo_Trans_Buyer.Text.Length));
				}
				else
				{
					Buyer_Company_Business_Type = "";
				}

				if (!cbo_Trans_Buyer_Click_SKIP)
				{
					Determine_Transaction_Type();
				}
			}
			else
			{
				cbo_Trans_Buyer.SelectedIndex = 0;
			}

			if (Transaction_OK())
			{ //aey 5/25/05
				cmd_Commit_Transaction.Visible = true;
			}

		}

		private bool Aircraft_Available(int AC_ID, int journ_id)
		{

			bool result = false;
			try
			{

				string Query = "";
				ADORecordSetHelper snp_A = new ADORecordSetHelper(); //8/11/05 aey Snapshot

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Retrieve Aircraft Availability from the 'Aircraft' table
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				result = false;
				Query = $"SELECT ac_forsale_flag FROM Aircraft WITH(NOLOCK) WHERE ac_id = {AC_ID.ToString()}";
				Query = $"{Query} AND ac_journ_id = {journ_id.ToString()}";
				Query = $"{Query} AND ac_forsale_flag='Y'";

				snp_A.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snp_A.BOF && snp_A.EOF))
				{
					snp_A.MoveLast();
					result = true;
				}
				snp_A.Close();
				snp_A = null;

				return result;
			}
			catch (System.Exception excep)
			{

				Working_Off();
				modAdminCommon.Report_Error($"Aircraft_Available_Error: {excep.Message}");
				return result;
			}
		}

		private int Get_POC_comp_id(int AC_ID)
		{
			//******************************************************************************************
			//* Note: VBC id'd the following unreferenced items and handled them as described:         *
			int result = 0;
			try
			{

				string Query = "";
				ADORecordSetHelper snp_POC = new ADORecordSetHelper(); // Snapshot aey 7/21/04 converted to ado

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Retrieve the 'Primary Point of Contact' from the 'Aircraft_Reference' table
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				result = 0;

				Query = $"SELECT cref_comp_id FROM Aircraft_Reference WITH(NOLOCK) WHERE cref_ac_id = {AC_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = 0";
				Query = $"{Query} AND cref_primary_poc_flag='Y'";

				snp_POC.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(snp_POC.BOF && snp_POC.EOF))
				{
					snp_POC.MoveLast();
					result = Convert.ToInt32(Double.Parse(($"{Convert.ToString(snp_POC["cref_comp_id"])}").Trim()));
				}
				snp_POC.Close();
				snp_POC = null;
			}
			catch (System.Exception excep)
			{

				Working_Off();
				modAdminCommon.Report_Error($"Get_POC_comp_id_Error: {excep.Message}");
			}
			return result;
		}

		private void Update_grid_trans_types()
		{

			string Ttype = "";

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// Update the Transaction Types in the 6th column of the grid
			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			int saved_row = grd_Fractional.CurrentRowIndex;
			int tempForEndVar = grd_Fractional.RowsCount - 1;
			for (int Row = 1; Row <= tempForEndVar; Row++)
			{
				grd_Fractional.CurrentRowIndex = Row;
				grd_Fractional.CurrentColumnIndex = 4;
				if ((grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer") || (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessee"))
				{
					grd_Fractional.CurrentColumnIndex = 5;
					Buyer_Comp_ID = grid_Array_comp_id[Row];
					Buyer_Contact_ID = grid_Array_contact_id[Row];
					Buyer_Contact_Type = grid_Array_contact_type[Row];
					if (chk_Correction_Transaction.CheckState == CheckState.Checked)
					{
						Ttype = $"{Trans_Type.Trim()}CORR";
					}
					else
					{
						if (Strings.Len(Seller_Company_Business_Type.Trim()) > 0)
						{
							Ttype = $"{Trans_Type.Trim()}{Seller_Company_Business_Type}";
						}
						else
						{
							Ttype = $"{Trans_Type.Trim()}--";
						}
						if (Is_Internal_Transaction())
						{
							Ttype = $"{Ttype.Substring(0, Math.Min(4, Ttype.Length))}IT";
						}
						else
						{
							if (Strings.Len(Buyer_Company_Business_Type.Trim()) > 0)
							{
								Ttype = $"{Ttype.Substring(0, Math.Min(4, Ttype.Length))}{Buyer_Company_Business_Type}";
							}
							else
							{
								Ttype = $"{Ttype.Substring(0, Math.Min(4, Ttype.Length))}--";
							}
						}
					}
					grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = Ttype;
				}
			}
			grd_Fractional.CurrentRowIndex = saved_row;

		}

		private void txt_Registration_No_TextChanged(Object eventSender, EventArgs eventArgs) => modAdminCommon.Registration_no = txt_Registration_No.Text.Trim(); //in common


		private void Remove_Awaiting_Documentation(int comp_id, int journ_id, bool in_Remove_Old_Reference = true)
		{

			try
			{
				string Query = "";

				if (in_Remove_Old_Reference)
				{
					Query = $"DELETE FROM Company WHERE comp_id = {comp_id.ToString()}";
					Query = $"{Query} AND comp_journ_id = {journ_id.ToString()} ";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery(); //aey 7/16/04

					//aey 6/23/05 --- included deletes for related tables - execpt for priority events

					Query = "Delete From Business_Type_Reference ";
					Query = $"{Query}where bustypref_comp_id = {comp_id.ToString()} and bustypref_journ_id = {journ_id.ToString()} ";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery(); //aey 7/16/04

					Query = "Delete From Contact ";
					Query = $"{Query}where contact_comp_id = {comp_id.ToString()} and contact_journ_id = {journ_id.ToString()} ";
					DbCommand TempCommand_3 = null;
					TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
					TempCommand_3.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
					TempCommand_3.ExecuteNonQuery(); //aey 7/16/04

					Query = "Delete From Phone_Numbers ";
					Query = $"{Query}where pnum_comp_id = {comp_id.ToString()} and pnum_journ_id = {journ_id.ToString()} ";
					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery(); //aey 7/16/04

					Query = "Delete From Company_Reference ";
					Query = $"{Query}where compref_comp_id = {comp_id.ToString()} and compref_journ_id = {journ_id.ToString()} ";
					DbCommand TempCommand_5 = null;
					TempCommand_5 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
					TempCommand_5.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
					TempCommand_5.ExecuteNonQuery(); //aey 7/16/04

					Query = "Delete From Company_Reference ";
					Query = $"{Query}where compref_rel_comp_id = {comp_id.ToString()} and compref_journ_id = {journ_id.ToString()} ";
					DbCommand TempCommand_6 = null;
					TempCommand_6 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_6);
					TempCommand_6.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_6.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_6);
					TempCommand_6.ExecuteNonQuery(); //aey 7/16/04

					Query = "Delete From Company_Aircraft_Count ";
					Query = $"{Query}where cac_comp_id = {comp_id.ToString()} and cac_journ_id = {journ_id.ToString()} ";
					DbCommand TempCommand_7 = null;
					TempCommand_7 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_7);
					TempCommand_7.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_7.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_7);
					TempCommand_7.ExecuteNonQuery(); //aey 7/16/04

					modAdminCommon.Record_Delete_Log_Entry("Company", comp_id, journ_id);
				}
			}
			catch (System.Exception excep)
			{

				Working_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Remove_Aircraft_Reference_ErrorD: {Information.Err().Number.ToString()} {excep.Message} Comp_id={comp_id.ToString()}");
			}
		}

		public bool Remove_Current_Primary_POC_Flag(int Passed_AC_ID)
		{
			bool result = false;
			try
			{

				string Query = "";

				result = true;

				Query = "Update Aircraft_Reference ";
				Query = $"{Query}set cref_primary_poc_flag='N' ";
				Query = $"{Query}WHERE cref_primary_poc_flag='Y' ";
				Query = $"{Query}AND cref_ac_id ={Passed_AC_ID.ToString()}";
				Query = $"{Query}AND cref_journ_id =0 ";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
			}
			catch
			{

				Working_Off();
				modAdminCommon.Report_Error("Remove_Current_Primary_POC_Flag_Error: ");
			}

			return result;
		}

		public void Add_To_Transmit_Field_List(string inFieldName)
		{

			try
			{

				arr_Transmit_Fields[arr_Transmit_Fields.GetUpperBound(0)] = inFieldName;
				arr_Transmit_Fields = ArraysHelper.RedimPreserve(arr_Transmit_Fields, new int[]{arr_Transmit_Fields.GetUpperBound(0) + 2});
			}
			catch
			{

				arr_Transmit_Fields = new string[]{""};
				arr_Transmit_Fields[arr_Transmit_Fields.GetUpperBound(0)] = inFieldName;
				return;
			}

		}

		public void Working_On(string inMessage)
		{
			try
			{

				this.Cursor = Cursors.WaitCursor;
				pnl_Please_Wait.Visible = true;
				//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Please_Wait.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				pnl_Please_Wait.setCaption(inMessage.Trim());
				pnl_Please_Wait.Refresh();
				modStatusBar.Update_Status_Bar(modAdminCommon.SB, inMessage, Color.Blue);
			}
			catch (System.Exception excep)
			{

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Aircraft (frm_Aircraft_Change)", $"Working_On: {Information.Err().Number.ToString()} - {excep.Message}");
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
		}

		public void Working_Off()
		{

			this.Cursor = CursorHelper.CursorDefault;
			pnl_Please_Wait.Visible = false;
			//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Please_Wait.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			pnl_Please_Wait.setCaption(" ");
			pnl_Please_Wait.Refresh();
			modStatusBar.Clear_Status_Bar(modAdminCommon.SB);
			Application.DoEvents();

		}


		public bool Set_Primary_POC_To_Owner(int inAircraft_ID)
		{
			bool result = false;
			try
			{

				string Query = "";

				result = true;

				Query = "Update Aircraft_Reference SET cref_primary_poc_flag = 'Y'";
				Query = $"{Query} WHERE cref_ac_id = {inAircraft_ID.ToString()}";
				Query = $"{Query} AND cref_journ_id = 0";
				Query = $"{Query} AND cref_contact_type = '00'";

				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = Query;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
			}
			catch
			{

				result = false;
				Working_Off();
				modAdminCommon.Report_Error("Remove_Current_Primary_POC_Flag_Error: ");
			}

			return result;
		}

		public bool Validate_Lease_Dates()
		{
			bool result = false;
			result = true;
			if (Strings.Len(txt_lease_expiration_date.Text.Trim()) > 0)
			{
				if (!Information.IsDate(txt_lease_expiration_date.Text))
				{
					return false;
				}
			}
			if (Strings.Len(txt_exp_comfirm_date.Text.Trim()) > 0)
			{
				if (!Information.IsDate(txt_exp_comfirm_date.Text))
				{
					return false;
				}
			}
			return result;
		}

		public bool Transaction_Save_Common_Aircraft_Sale()
		{

			bool result = false;
			string Transaction_Error = "";
			string tmpErrDesc = "";
			try
			{

				int PC_Record_Key = 0;
				int Fractional_Sold_ID = 0; // String used to better explain specific error
				string Query = ""; // string used to store query statements
				string Subject = ""; // used to store the subject of the transaction to be placed into the journal
				string New_Owner_Contact_Type = ""; // Contact type used to place on the new aircraft owner after the transaction
				string Buyer_Comp_Name = ""; // Name of the company buying, seizing, or foreclosing on the aircraft
				string Seller_Comp_Name = ""; // Name of the company selling, being seized from, or being foreclosed on
				string Buyer_Type = ""; // Contact type of the buyer block
				string Seller_Type = ""; // Contact type of the seller block
				bool Exclusive_Status = false; // flag used to identify if the current ac is available on exclusive
				string Buyer_Company_Business_Type = "";
				string Seller_Company_Business_Type = "";
				string RegAs_Company_Business_Type = "";
				string Previous_Ownership_Type = "";
				int ErrCount = 0; //count # of deadlock errors
				bool SendtoWeb = false; //aey 7/28/04
				bool Remove_Old_Reference = false;

				SendtoWeb = modCommon.GetTransWeb(Transaction_Type); //aey 7/29/04

				ErrCount = 0;
				result = false;
				Previous_Ownership_Type = Aircraft_Ownership_Type;

				Transaction_Error = "Start";
				// *************************************************************************
				// GET A COMPLETE SNAPSHOT OF BUYER INFORMATION NOT AWAITING DOCUMENTATION
				if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
				{
					Buyer_Comp_ID = 0;
					Buyer_Contact_ID = 0;
					Buyer_Comp_Name = "Awaiting Documentation";
				}
				else
				{
					if (!modCommon.Aircraft_Buyer_Get_Recordset(Buyer_Comp_ID, Buyer_Contact_ID))
					{
						Transaction_Error = "Get Buyer Company History";
						goto Abort_Common_Transaction;
					}

					// we know that we have a buyer recordset
					if (!(modGlobalVars.snp_Buyer_Company.BOF && modGlobalVars.snp_Buyer_Company.EOF))
					{
						modGlobalVars.snp_Buyer_Company.MoveFirst();
						Buyer_Comp_Name = Convert.ToString(modGlobalVars.snp_Buyer_Company["comp_name"]);
					}

				} // if awaiting documentation

				Transaction_Error = "buyer_co_bustype";
				Buyer_Company_Business_Type = cbo_Trans_Buyer.Text.Substring(0, Math.Min(2, cbo_Trans_Buyer.Text.Length));

				// *******************************************************
				// CHECK TO SEE IF THE CURRENT AIRCRAFT WAS ON EXCLUSIVE
				Query = $"select ac_id from Aircraft WITH(NOLOCK) where ac_exclusive_flag = 'Y' and ac_id = {modAdminCommon.gbl_Aircraft_ID.ToString()} and ac_journ_id = 0";
				if (modAdminCommon.Exist(Query))
				{ // if the aircraft is not on exclusive then remove the primary flag
					Exclusive_Status = true;
				}

				// *******************************************
				// GET A SNAPSHOT OF Company Information
				Working_On("Selecting Seller Company History ...");
				if (!modCommon.Transaction_Get_Company_History_Recordsets(Seller_Comp_ID.ToString()))
				{
					Transaction_Error = "Get Seller Company History";
					goto Abort_Common_Transaction;
				}

				// get the seller company business type
				if (!(modGlobalVars.snp_Company.BOF && modGlobalVars.snp_Company.EOF))
				{
					modGlobalVars.snp_Company.MoveFirst();
					Seller_Comp_Name = $"{Convert.ToString(modGlobalVars.snp_Company["comp_name"])}";
				}

				Seller_Company_Business_Type = cbo_Trans_Seller.Text.Substring(0, Math.Min(2, cbo_Trans_Seller.Text.Length));

				if (Seller_Company_Business_Type.Trim() == "")
				{ //moved aey 7/19/04
					Seller_Company_Business_Type = "UI";
				}

				// *******************************************
				// GET A REGISTERED AS SNAPSHOT
				if (lst_Registered_As.Items.Count > 0)
				{
					if (!modCommon.Aircraft_RegisteredAs_Get_Recordset(Registered_As_Buyer_comp_id, Registered_As_Buyer_contact_id))
					{
						Transaction_Error = "Get Registered As Company History";
						goto Abort_Common_Transaction;
					}
					// get the business type of the registered as company
					if (!(modGlobalVars.snp_RegisteredAs_Company.BOF && modGlobalVars.snp_RegisteredAs_Company.EOF))
					{
						modGlobalVars.snp_RegisteredAs_Company.MoveFirst();
						RegAs_Company_Business_Type = ($"{Convert.ToString(modGlobalVars.snp_RegisteredAs_Company["comp_business_type"])}").Trim();
					}
				}


				// *******************************************
				// GET A COMPLETE SNAPSHOT OF ALL AIRCRAFT INFORMATION
				if (!modCommon.Aircraft_History_Get_Recordsets(modAdminCommon.gbl_Aircraft_ID, Trans_Type, $"{Buyer_Comp_ID.ToString()},{Seller_Comp_ID.ToString()}", Seller_Comp_ID, Buyer_Comp_ID))
				{
					Transaction_Error = "Get Aircraft History";
					goto Abort_Common_Transaction;
				}

				// ************************************************************
				// GET PENDING FRACTIONAL OWNER REFERENCE RECORDS IF NECESSARY
				if ((~((opt_Historical.Checked) ? -1 : 0) & ((Previous_Ownership_Type == "F") ? -1 : 0) & ((chk_Internal_Transaction.CheckState != CheckState.Checked) ? -1 : 0)) != 0)
				{
					if (!modCommon.Fractional_Pending_Get_Recordsets(modAdminCommon.gbl_Aircraft_ID))
					{
						Transaction_Error = "Get Aircraft History";
						goto Abort_Common_Transaction;
					}
				}

				// ********************************************************************
				// MODIFY MESSAGES, JOURNAL SUBJECT, AND BUYER/SELLER CODES BASED ON
				// THE TYPE OF TRANSACTION.
				Transaction_Error = "Trans Type";

				switch(Trans_Type.Substring(0, Math.Min(2, Trans_Type.Length)))
				{
					case "WS" : 
						Working_On("Saving Full Aircraft Sale ...");  // Turn on a message 
						Seller_Type = "95";  // Seller 
						Buyer_Type = "96";  // Purchaser 
						New_Owner_Contact_Type = "00"; 
						 
						break;
					case "DP" : 
						Working_On("Saving Aircraft Delivery Position Sale ...");  // Turn on a message 
						Seller_Type = "95";  // Seller 
						Buyer_Type = "96";  // Purchaser 
						New_Owner_Contact_Type = "42";  //Delivery Position 
						 
						break;
					case "SZ" : 
						Working_On("Saving Aircraft Seizure ...");  // Turn on a message 
						Seller_Type = "56";  // Previous Owner 
						Buyer_Type = "51";  // Seized By 
						New_Owner_Contact_Type = "00"; 
						 
						break;
					case "FC" : 
						Working_On("Saving Aircraft Foreclosure ...");  // Turn on a message 
						Seller_Type = "56";  // Previous Owner 
						Buyer_Type = "52";  // Purchaser 
						New_Owner_Contact_Type = "00"; 
						 
						break;
					default:
						goto Abort_Common_Transaction; 
						 
						break;
				}

				Subject = modCommon.BuildJournalSubject(Transaction_Type, 0, 0, 0, 0, Seller_Comp_Name, Buyer_Comp_Name);

				if (Buyer_Company_Business_Type == "PH")
				{
					New_Owner_Contact_Type = "17"; //Program Holder
				}


				if (Transaction_Type.Substring(Math.Max(Transaction_Type.Length - 4, 0)) != "CORR")
				{
					PC_Record_Key = modCommon.Get_Next_PC_Record_Key();
					if (!(PC_Record_Key > 0))
					{
						Transaction_Error = "Get PC Record Key";
						goto Abort_Common_Transaction;
					}
				}
				else
				{
					PC_Record_Key = 0;
				}

				//some 'awaiting doc' companies have more than 1 aircraft
				Remove_Old_Reference = false;
				Query = "SELECT cref_id FROM Aircraft_Reference WITH(NOLOCK)";
				Query = $"{Query}WHERE cref_comp_id = {Seller_Comp_ID.ToString()}";
				Query = $"{Query} and cref_ac_id <> {modAdminCommon.gbl_Aircraft_ID.ToString()}";
				if (!modAdminCommon.Exist(Query))
				{
					Remove_Old_Reference = true;
				}

				// ******************************************************
				// GET THE NEXT FRACTIONAL SOLD ID
				Fractional_Sold_ID = 0;
				if (Registered_As_Owner_comp_id > 0)
				{
					modCommon.Transaction_Get_Company_History_Recordsets(Registered_As_Owner_comp_id.ToString());
				}

				modAdminCommon.ADO_Transaction("BeginTrans");

				// *******************************************************
				// RECORD A JOURNAL ENTRY
				Working_On("Creating Journal Entry ...");
				Journal_ID = Transaction_Insert_Journal_Entry(PC_Record_Key, txt_Transaction_Type.Text, ref Subject, Fractional_Sold_ID, 0, 0, SendtoWeb);
				if (Journal_ID == 0)
				{ // journal entry failed then exit
					Transaction_Error = "Insert Journal Entry";
					goto Abort_Common_Transaction;
				}


				//********************************************************
				// SAVE AIRCRAFT HISTORY COPY
				Working_On("Storing Aircraft Information Copy ...");
				if (!modCommon.Transaction_Save_Aircraft_History(Journal_ID, Transaction_Type, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, opt_Historical.Checked, modAdminCommon.Registration_no, SendtoWeb))
				{
					Transaction_Error = "Storing Aircraft Copy";
					goto Abort_Common_Transaction;
				}

				// SAVE AIRCRAFT COMPANY HISTORY COPY
				// 3/5/2004
				// RTW - ADDED THIS IF STATEMENT WHEN COMPANIES FROM THE ACTIVE AIRCRAFT WERE
				//       BEING STORED ON HISTORICAL TRANSACTIONS.
				if (!opt_Historical.Checked)
				{
					Working_On("Storing Aircraft Company Information Copy ...");
					if (!modCommon.Transaction_Save_Aircraft_Company_History(Journal_ID, modGlobalVars.snp_TransAircraft_Companies, modGlobalVars.snp_TransAircraft_Contacts, modGlobalVars.snp_TransAircraft_Company_Phones, modGlobalVars.snp_TransAircraft_Company_Btypes, modGlobalVars.snp_TransAircraft_Company_Certs, 0, SendtoWeb))
					{
						Transaction_Error = "Store Aircraft Company History";
						goto Abort_Common_Transaction;
					}
				}

				//***********************************************************
				// SAVE SELLER REFERENCE RECORD COPY
				Working_On("Saving Seller Reference Copy ...");
				if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Seller_Comp_ID, cbo_Trans_Seller.Text.Substring(0, Math.Min(2, cbo_Trans_Seller.Text.Length)), Seller_Contact_ID, Seller_Type, "0", "N"))
				{
					Transaction_Error = "Storing Seller Reference";
					goto Abort_Common_Transaction;
				}


				if (!modCommon.Transaction_Save_Company_History(Journal_ID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_TransAircraft_Company_Certs, 0, SendtoWeb))
				{
					Transaction_Error = "Storing Seller Company";
					goto Abort_Common_Transaction;
				}

				// NO REASON TO RESAVE COMPANY IF BUYER AND SELLER WERE THE SAME
				// FOR AN INTERNAL TRANSACTION
				if (Seller_Comp_ID != Buyer_Comp_ID)
				{
					//*******************************************************************************
					// SAVE BUYER COMPANY HISTORY - IF AWAITING DOCUMENTATION - PASS BUYER COMP ID = 0
					if (!modCommon.Transaction_Save_Buyer_History(ref Buyer_Comp_ID, Journal_ID, Buyer_Company_Business_Type, modGlobalVars.snp_Buyer_Company, modGlobalVars.snp_Buyer_Contacts, modGlobalVars.snp_Buyer_Company_Phones, modGlobalVars.snp_Buyer_Company_Btypes, modGlobalVars.snp_Buyer_Company_Certs, 0, SendtoWeb))
					{
						Transaction_Error = "Storing Buyer Company History";
						goto Abort_Common_Transaction;
					}
				}

				//********************************************************
				// SAVE BUYER REFERENCE RECORD
				Working_On("Saving Buyer Reference Copy ...");
				if (Buyer_Comp_ID > 0)
				{
					if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, Buyer_Type, "0", "N"))
					{
						Transaction_Error = "Storing Buyer Reference";
						goto Abort_Common_Transaction;
					}
					else
					{
						// RTW - HOLD - PUT EXBROKER HERE
						if (modAircraftChange.Buyer_Is_Broker(Buyer_Comp_ID))
						{
							modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, "99", "0", "N");
						}
					}
				}

				// *****************************
				// IF NOT HISTORICAL TRANSACTION
				Transaction_Error = $"History -{txt_transaction_date.Text}";
				if (~((opt_Historical.Checked) ? -1 : 0) != 0)
				{

					// ***********************************************************************
					// UPDATE CURRENT 'Aircraft' RECORD TO 'Not for Sale', CLEAR FIELDS, AND APPROPRIATE REFERENCES
					Working_On("Updating Current Aircraft Record ...");
					if (!Transaction_Update_Current_Aircraft_Record(modAdminCommon.gbl_Aircraft_ID, DateTime.Parse(txt_transaction_date.Text.Trim()), "W", Buyer_Comp_ID, Old_POC_comp_id))
					{
						Transaction_Error = "Updating Current Aircraft";
						goto Abort_Common_Transaction;
					} // IF NOT UPDATE OF CURRENT AIRCRAFT

					// ******************************************************************
					// OMNS - Off Market Due To Sale
					if (Clear_Availability && Prior_Availability && chk_Correction_Transaction.CheckState == CheckState.Unchecked)
					{
						modCommon.Transaction_Insert_Priority_Event("OMNS", modAdminCommon.gbl_Aircraft_ID, Journal_ID, $"New Owner: {Buyer_Comp_Name}", Buyer_Comp_ID, Buyer_Contact_ID);
					}

					// ******************************************************************
					// MSW - 7/19/2011  - event add for new delivery position holder
					if (Trans_Type.StartsWith("DP", StringComparison.Ordinal))
					{
						modCommon.Transaction_Insert_Priority_Event("NDP", modAdminCommon.gbl_Aircraft_ID, Journal_ID, $"New Delivery Position: {Buyer_Comp_Name}", Buyer_Comp_ID, Buyer_Contact_ID);
					}

					// *************************************************************************
					// STORE THE NEW OWNER TO THE REFERENCE TABLE
					Working_On("Adding New Owner ...");
					if (Exclusive_Status && chk_Internal_Transaction.CheckState == CheckState.Checked)
					{
						if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, New_Owner_Contact_Type, "100", "X"))
						{
							Transaction_Error = "Storing New Owner Reference as Exclusive";
							goto Abort_Common_Transaction;
						} // add new owner but retain exclusive status
					}
					else
					{
						// REMOVE THE CURRENT POC FLAG AND INSERT NEW OWNER

						//Call Remove_Current_Primary_POC_Flag(gbl_Aircraft_ID)
						if (!Clear_Availability && Exclusive_Status)
						{
							if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, New_Owner_Contact_Type, "100", "X"))
							{
								Transaction_Error = "Storing New Owner";
								goto Abort_Common_Transaction;
							} // add new owner and make primary
						}
						else
						{
							gPOC_Flag = "Y";
							// 9/3/2004
							// IF INTERNAL OR CORRECTION AND PRIMARY WAS NOT THE SELLER, THEN KEEP THE PRIMARY
							if (Preserve_POC)
							{
								gPOC_Flag = "N";
							}

							if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, New_Owner_Contact_Type, "100", gPOC_Flag))
							{
								Transaction_Error = "Storing New Owner";
								goto Abort_Common_Transaction;
							} // add new owner and make primary
						}
					} // exclusive and internal
				} // if historical transaction


				Transaction_Error = "awaiting doc";
				// ********************************************************************************
				// IF SELLER WAS AWAITING DOCUMENTATION, THEM REMOVE THE AWAITING DOCUMENTATION COMPANY
				if ((Seller_Company_Business_Type == "AD") || (Seller_Company_Business_Type == "UI"))
				{
					Working_On("Removing Previous Awaiting Documentation Company ...");
					Remove_Awaiting_Documentation(Seller_Comp_ID, 0, Remove_Old_Reference);
				}

				Transaction_Error = "reg owner";

				// **********************************************************************
				// IF SELLER WAS ORIGINALLY 'Registered As Owner'
				//    Insert 'Registered As Seller' into 'Aircraft_Reference' table
				//    Insert 'Registered As Seller' Company into 'Aircraft_Reference' table
				if (Registered_As_Owner_comp_id > 0)
				{

					Working_On("Saving Registered As Copy ...");
					if (modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Registered_As_Owner_comp_id, Buyer_Company_Business_Type, Registered_As_Owner_contact_id, "60", "0", "N"))
					{
						if (!modCommon.Transaction_Save_Company_History(Journal_ID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs, 0, SendtoWeb))
						{
							Transaction_Error = "Saving Registered As Company Information";
							goto Abort_Common_Transaction;
						}
					}
				}

				Transaction_Error = "reg buyer";

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// IF this is a 'Registered As Buyer' transaction
				//    Insert 'Registered As Purchaser' into 'Aircraft_Reference' table
				//    Insert 'Registered As Purchaser' Company into 'Aircraft_Reference' table
				//    Insert 'Registered As Owner' into 'Aircraft_Reference' table
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				if (lst_Registered_As.Items.Count > 0)
				{
					// put in the registered as purchaser
					Transaction_Error = "purchaser";

					if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Registered_As_Buyer_comp_id, Buyer_Company_Business_Type, Registered_As_Buyer_contact_id, "61", "0", "N"))
					{
						Transaction_Error = "Saving Registered As Reference on History";
						goto Abort_Common_Transaction;
					}
					else
					{
						// We added the registered as owner to the aircraft reference
						// ****************************************
						// SAVE REGISTERED AS RECORDSET
						if (!modCommon.Transaction_Save_RegisteredAs_History(ref Registered_As_Buyer_comp_id, Journal_ID, RegAs_Company_Business_Type, modGlobalVars.snp_RegisteredAs_Company, modGlobalVars.snp_RegisteredAs_Contacts, modGlobalVars.snp_RegisteredAs_Company_Phones, modGlobalVars.snp_RegisteredAs_Company_Btypes, modGlobalVars.snp_RegisteredAs_Company_Certs, (SendtoWeb) ? -1 : 0))
						{
							Transaction_Error = "Saving Registered As for Current";
							goto Abort_Common_Transaction;
						} // history saved for the registered as purchaser
						if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Registered_As_Buyer_comp_id, RegAs_Company_Business_Type, Registered_As_Buyer_contact_id, "62", "0", "N"))
						{
							Transaction_Error = "Saving Registered As Reference for Current AC";
							goto Abort_Common_Transaction;
						} // if reference added to the transaction for the registered as purchaser

					} // we saved reference for registered as owner
				} // we have a registered as owner

				Working_On("Saving Transaction Transmits...");
				Transaction_Error = "sale transmit";

				// *************************************************
				// RECORD A SALE TRANSMIT
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, Journal_ID, gbl_ac_amod_id, "Transaction", "Add", ref arr_Transmit_Fields);

				// *********************************************
				// IF THE AIRCRAFT IS NOT HISTORICAL THEN PERFORM
				// ACTIONS RELATING TO CHANGING THE CURRENT AIRCRAFT AND
				// THE AIRCRAFT AVAILABILITY
				Transaction_Error = "is hist";

				if (~((opt_Historical.Checked) ? -1 : 0) != 0)
				{
					Transaction_Error = "not hist";

					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Aircraft", "Change", ref arr_Transmit_Fields);

					Transaction_Error = "prior avail";

					if (Prior_Availability && Clear_Availability)
					{
						modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Delete", ref arr_Transmit_Fields);
					}

					// **************************************************************************
					// IF THE AIRCRAFT IS NOW AVAILABLE AND WASN'T PRIOR TO THE TRANSACTION
					// THEN RECORD AN ADD AVAILABLE TRANSMIT
					Transaction_Error = "curr avail";

					if (!Clear_Availability && !Prior_Availability && opt_Current.Checked)
					{
						string tempRefParam = "On Market";
						if (Transaction_Insert_Journal_Entry(Journal_ID + 1, "MA", ref tempRefParam, 0, 0, (SendtoWeb) ? -1 : 0) == 0)
						{
							Transaction_Error = "Insert Journal Entry for On Market";
							goto Abort_Common_Transaction;
						}
						modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Add", ref arr_Transmit_Fields);
					}
				} // IF NOT HISTORICAL

				Transaction_Error = "commit trans";

				// If successfull insert prioity event for
				switch(Trans_Type.Substring(0, Math.Min(2, Trans_Type.Length)))
				{
					case "SZ" : 
						// insert Priority event for Seizure 
						modCommon.Transaction_Insert_Priority_Event("SZ", modAdminCommon.gbl_Aircraft_ID, Journal_ID, Subject.Trim(), Buyer_Comp_ID, Buyer_Contact_ID); 
						break;
					case "FC" : 
						// insert Priority event for Foreclosure 
						modCommon.Transaction_Insert_Priority_Event("FC", modAdminCommon.gbl_Aircraft_ID, Journal_ID, Subject.Trim(), Buyer_Comp_ID, Buyer_Contact_ID); 
						 
						break;
				}

				modAdminCommon.ADO_Transaction("CommitTrans");

				result = true;

				Transaction_Error = "close rs";

				modCommon.Aircraft_History_Close_Recordsets();

				// *************************************************
				// IF THE TRANSACTION IS NOT HISTORICAL, THE CURRENT AIRCRAFT WAS
				// FRACTIONALLY OWNED, AND IS NOT INTERNAL THEN WE MUST DETERMINE IF
				// THE AIRCRAFT HAS ANY FRACTIONS STILL PENDING SALE
				switch(Trans_Type.Substring(0, Math.Min(2, Trans_Type.Length)))
				{
					case "WS" : case "FC" : case "SZ" : case "DP" : 
						if ((~((opt_Historical.Checked) ? -1 : 0) & ((Previous_Ownership_Type == "F") ? -1 : 0) & ((chk_Internal_Transaction.CheckState != CheckState.Checked) ? -1 : 0)) != 0)
						{
							Transaction_Save_Pending_Fractions(modAdminCommon.gbl_Aircraft_ID, ref modGlobalVars.snp_Fractions_Pending);
						}  //   If Fractional_Pending Then 
						break;
				}


				// added MSW as possible fix - 11/11/22
				// if the journal was stage 4, and
				if (modCommon.Current_Current_Ac_Stage(modAdminCommon.gbl_Aircraft_ID, Journal_ID) == "4")
				{ // added MSW - 11/11/22
					// strEReport = "Clearing Primary on Reference, making sure status is cofrect
					Query = "update Aircraft_Reference set cref_primary_poc_flag='N' ";
					Query = $"{Query}where cref_ac_id={modAdminCommon.gbl_Aircraft_ID.ToString()} ";
					Query = $"{Query}and cref_journ_id = 0 ";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();


					Query = $"update Aircraft set ac_status='{modCommon.Current_Current_Ac_Status(modAdminCommon.gbl_Aircraft_ID, Journal_ID)}' ";
					Query = $"{Query}where ac_id={modAdminCommon.gbl_Aircraft_ID.ToString()} ";
					Query = $"{Query}and ac_journ_id = 0 ";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
				}

				Working_Off();

				return result;

				Abort_Common_Transaction:
				Transaction_Error = $"{Transaction_Error} {Information.Err().Description} {Information.Err().Source} B:{Buyer_Comp_ID.ToString()}"; //aey 5/27/04
				modAdminCommon.ADO_Transaction("RollbackTrans");
				modCommon.Aircraft_History_Close_Recordsets();
				result = false;
				Working_Off();
				modAdminCommon.Report_Error($"Transaction_Save_Common_Aircraft_Sale_Error: {Transaction_Error}");
				return result;
			}
			catch (System.Exception excep)
			{

				tmpErrDesc = $"{excep.Message} {Transaction_Error} B:{Buyer_Comp_ID.ToString()} S:{Seller_Comp_ID.ToString()} ac:{modAdminCommon.gbl_Aircraft_ID.ToString()}"; //aey 5/27/04
				modAdminCommon.ADO_Transaction("RollbackTrans");
				modCommon.Aircraft_History_Close_Recordsets();
				result = false;
				Working_Off();
				modAdminCommon.Report_Error($"Transaction_Save_Common_Aircraft_Sale_Error: {tmpErrDesc}");
				return result;
			}
		} // Transaction_Save_Common_Aircraft_Sale


		public bool Transaction_Save_ProgramHolder()
		{

			bool result = false;
			string Transaction_Error = ""; // String used to store transaction errors
			int Fractional_Sold_ID = 0; // counter for looking through the rows in the grid
			int Seller_Fown_ID = 0;
			int Buyer_Fown_ID = 0;
			string Seller_Company_Name = "";
			string Buyer_Company_Name = "";
			string Buyer_Ownership_Type = "";
			string Buyer_Company_Business_Type = "";
			int PC_Record_Key = 0;
			string change_percent = "";
			string new_percent = "";
			int Next_Fown_ID = 0;
			string Subject = ""; // subject to be place in the journal entry
			int lError = 0; // Hold The Error Number Value
			string fquery = ""; // string for building fractional owner update query
			string Query = "";

			string Fraction_Expires_Date = "";
			string strTmpDate = "";
			System.DateTime dtTmpDate = DateTime.FromOADate(0);

			int ErrCount = 0;

			Fill_grd_Fractional(modAdminCommon.gbl_Aircraft_ID, MOD_Journal_ID);

			if (Trans_Type == "WS")
			{
				HideFractionalGrid();
			}

			bool SendtoWeb = modCommon.GetTransWeb(Transaction_Type); //aey 7/28/04
			string Previous_Ownership_Type = Aircraft_Ownership_Type;

			//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
			// The user has requested the completion of an Aircraft Fractional Sale Transaction
			//
			string strError = "Start"; // Hold The Error Description Value
			Working_On("Saving Fractional Aircraft Sale Transaction ...");

			// *******************************************
			// GET A SNAPSHOT OF SELLER COMPANY INFORMATION
			Working_On("Selecting Copy of Seller Company Information ...");
			if (!modCommon.Transaction_Get_Company_History_Recordsets(Seller_Comp_ID.ToString()))
			{
				Transaction_Error = "Get Seller Company Recordset";
				goto Abort_FractionalPM_Transaction;
			}

			strError = "get seller";
			// get the seller company business type
			if (!(modGlobalVars.snp_Company.BOF && modGlobalVars.snp_Company.EOF))
			{
				Seller_Company_Business_Type = Convert.ToString(modGlobalVars.snp_Company["comp_business_type"]);
				Seller_Company_Name = Convert.ToString(modGlobalVars.snp_Company["comp_name"]);
			}

			Seller_Company_Business_Type = cbo_Trans_Seller.Text.Substring(0, Math.Min(2, cbo_Trans_Seller.Text.Length));

			// ***************************************************************
			// IF THE PERCENTAGE OF THE BUYER IS 100% THEN THE CURRENT
			// AIRCRAFT WILL BE CHANGED TO WHOLLY OWNED, ELSE LEAVE FRACTIONAL
			strError = "Buyer info";

			Buyer_Ownership_Type = "F";

			// *************************************************************************
			// GET A COMPLETE SNAPSHOT OF BUYER INFORMATION NOT AWAITING DOCUMENTATION
			Working_On("Selecting Copy of Buyer Information ...");
			if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
			{
				Buyer_Comp_ID = 0;
				Buyer_Contact_ID = 0;
				Buyer_Company_Name = "Awaiting Documentation";

			}
			else
			{
				Buyer_Comp_ID = Convert.ToInt32(Conversion.Val($"{Buyer_Comp_ID.ToString()}")); //aey 6/22/04
				Buyer_Contact_ID = Convert.ToInt32(Conversion.Val($"{Buyer_Contact_ID.ToString()}"));
				if (!modCommon.Aircraft_Buyer_Get_Recordset(Buyer_Comp_ID, Buyer_Contact_ID))
				{
					Transaction_Error = "Get Buyer Company Recordset";
					goto Abort_FractionalPM_Transaction;
				}

				// we know that we have a buyer recordset
				if (!(modGlobalVars.snp_Buyer_Company.BOF && modGlobalVars.snp_Buyer_Company.EOF))
				{
					modGlobalVars.snp_Buyer_Company.MoveFirst();

					Buyer_Fown_ID = Convert.ToInt32(Conversion.Val($"{Convert.ToString(modGlobalVars.snp_Buyer_Company["comp_fractowr_id"])}"));
					Buyer_Company_Name = Get_comp_name(Buyer_Comp_ID);
					Buyer_Company_Business_Type = $"{Convert.ToString(modGlobalVars.snp_Buyer_Company["comp_business_type"])}";
				}

			} // if awaiting documentation
			Buyer_Company_Business_Type = ($"{cbo_Trans_Buyer.Text}").Substring(0, Math.Min(2, ($"{cbo_Trans_Buyer.Text}").Length));

			//   Subject = BuildJournalSubject(txt_Transaction_Type & "", 0, 0, 0, 0, Seller_Company_Name & "", Buyer_Company_Name & "")
			Subject = $"Program Holder Sale from {Seller_Company_Name} to {Buyer_Company_Name}";

			// *******************************************
			// GET A COMPLETE SNAPSHOT OF ALL AIRCRAFT INFORMATION
			strError = "A/C info";
			Working_On("Selecting Copy of Aircraft Information ...");
			if (!modCommon.Aircraft_History_Get_Recordsets(modAdminCommon.gbl_Aircraft_ID, Trans_Type, $"{Buyer_Comp_ID.ToString()},{Seller_Comp_ID.ToString()}"))
			{
				Transaction_Error = "Get Aircraft Recordset";
				goto Abort_FractionalPM_Transaction;
			}

			strError = "Record Key";
			if (Transaction_Type.Substring(Math.Max(Transaction_Type.Length - 4, 0)) != "CORR")
			{
				PC_Record_Key = modCommon.Get_Next_PC_Record_Key();
				if (!(PC_Record_Key > 0))
				{
					Transaction_Error = "Get PC Record Key";
					goto Abort_FractionalPM_Transaction;
				}
			}
			else
			{
				PC_Record_Key = 0;
			}


			// GET THE FRACTIONAL OWNER ID OF THE SELLER
			Seller_Fown_ID = modCommon.Fractional_Owner(Seller_Comp_ID);

			// GET THE NEXT FRACTIONAL OWNER ID
			// CHECK TO MAKE SURE THAT I HAVE A FRACTIONAL OWNER ID WHEN I NEED IT
			strError = "Frac Owner id";
			if (Buyer_Fown_ID == 0 || Seller_Fown_ID == 0)
			{
				Next_Fown_ID = Convert.ToInt32(Conversion.Val($"{modCommon.Get_Next_Fractional_Owner_ID().ToString()}"));
				if (Next_Fown_ID == 0)
				{
					goto Fractional_Owner_IDPM_Error;
				}
			}


			// ******************************************************
			// GET THE NEXT FRACTIONAL SOLD ID
			strError = "Frac sold id";
			Fractional_Sold_ID = modCommon.Get_Next_Fractional_Sold_ID(Seller_Fown_ID);
			if (Fractional_Sold_ID == 0)
			{
				goto Fractional_Owner_IDPM_Error;
			}

			Add_To_Transmit_Field_List(" "); // add one element to the array

			//aey 9/13/04 validate that buyer and seller companies have not changed
			// CHANGED - RTW - 2/1/2012 - MODIFIED ALL QUERIES BELOW TO JUST USE COMPANY ID NOT *
			if (Buyer_Comp_ID > 0 && Buyer_Contact_ID == 0)
			{
				Query = "Select comp_id from company  ";
				Query = $"{Query} where comp_id={Buyer_Comp_ID.ToString()}";
				Query = $"{Query} and comp_journ_id = 0 ";
				Query = $"{Query} and comp_active_flag='Y' ";
				if (!modAdminCommon.Exist(Query))
				{
					MessageBox.Show("Someone has changed the Buyer company - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					goto Transaction_Save_ProgramHolder_Error;
				}
			}

			if (Seller_Comp_ID > 0 && Seller_Contact_ID == 0)
			{
				Query = "Select comp_id from company  ";
				Query = $"{Query} where comp_id={Seller_Comp_ID.ToString()}";
				Query = $"{Query} and comp_journ_id = {MOD_Journal_ID.ToString()}";
				Query = $"{Query} and comp_active_flag='Y' ";
				if (!modAdminCommon.Exist(Query))
				{
					MessageBox.Show("Someone has changed the Seller company - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					goto Transaction_Save_ProgramHolder_Error;
				}
			}

			//aey 9/10/04 validate that the buyer and seller contacts have not changed
			if (Buyer_Comp_ID > 0 && Buyer_Contact_ID > 0)
			{
				Query = "Select contact_comp_id from contact ";
				Query = $"{Query}where contact_id={Buyer_Contact_ID.ToString()}";
				Query = $"{Query} and contact_comp_id={Buyer_Comp_ID.ToString()}";
				Query = $"{Query} and contact_journ_id = {MOD_Journal_ID.ToString()}";
				Query = $"{Query} and contact_active_flag='Y' ";
				if (!modAdminCommon.Exist(Query))
				{
					MessageBox.Show("Someone has changed the Buyer company contact - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					goto Transaction_Save_ProgramHolder_Error;
				}
			}

			if (Seller_Comp_ID > 0 && Seller_Contact_ID > 0)
			{
				Query = "Select contact_comp_id from contact ";
				Query = $"{Query}where contact_id={Seller_Contact_ID.ToString()}";
				Query = $"{Query} and contact_comp_id={Seller_Comp_ID.ToString()}";
				Query = $"{Query} and contact_journ_id = {MOD_Journal_ID.ToString()}";
				Query = $"{Query} and contact_active_flag='Y' ";
				if (!modAdminCommon.Exist(Query))
				{
					MessageBox.Show("Someone has changed the Seller company contact - Please reselect", "Seller Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					goto Transaction_Save_ProgramHolder_Error;
				}
			}


			// WE NOW HAVE SELECTED EVERYTHING THAT WE NEED TO
			// BEGIN THE TRANSACTION.
			modAdminCommon.ADO_Transaction("BeginTrans");

			// *******************************************************
			// RECORD A JOURNAL ENTRY
			strError = "Journal Entry";
			Working_On("Creating Journal Entry ...");
			Journal_ID = Transaction_Insert_Journal_Entry(PC_Record_Key, txt_Transaction_Type.Text, ref Subject, Fractional_Sold_ID, 0, Seller_Fown_ID);
			if (Journal_ID == 0)
			{ // journal entry failed then exit
				Transaction_Error = "Error Inserting Journal";
				goto Abort_FractionalPM_Transaction;
			}

			// ************************************************
			// UPDATE FRACTIONAL OWNER INFORMATION FOR WINDOWS
			Working_On($"Updating Fractional Owner Data for {Seller_Company_Name} and {Buyer_Company_Name} ...");
			if (Buyer_Fown_ID == 0)
			{
				// if the buyer was not previously on the fractional owner list
				// then assign him an id and update his company to put him on the list
				Buyer_Fown_ID = Next_Fown_ID;
				Next_Fown_ID++;
				fquery = $"update company set comp_fractowr_id = {Buyer_Fown_ID.ToString()} ";
				fquery = $"{fquery}where comp_id={Buyer_Comp_ID.ToString()} and comp_journ_id=0";
				DbCommand TempCommand = null;
				TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
				TempCommand.CommandText = fquery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
				TempCommand.ExecuteNonQuery();
				// store tramsmit for fractional owner add
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Fractional Owner", "Add", ref arr_Transmit_Fields, Buyer_Comp_ID);
			}
			else
			{
				// store transmit for fractional owner change
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Fractional Owner", "Change", ref arr_Transmit_Fields, Buyer_Comp_ID);
			}

			if (Seller_Fown_ID == 0)
			{
				// if the seller was not previously on the fractional owner list
				// then assign him an id and update his company to put him on the list
				Seller_Fown_ID = Next_Fown_ID;
				Next_Fown_ID++;

				fquery = $"update company set comp_fractowr_id={Seller_Fown_ID.ToString()} ";
				fquery = $"{fquery}where comp_id={Seller_Comp_ID.ToString()} and comp_journ_id=0";
				DbCommand TempCommand_2 = null;
				TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
				UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
				TempCommand_2.CommandText = fquery;
				//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
				TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
				UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
				TempCommand_2.ExecuteNonQuery();
				// store tramsmit for fractional owner
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Fractional Owner", "Add", ref arr_Transmit_Fields, Seller_Comp_ID);
			}
			else
			{
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Fractional Owner", "Change", ref arr_Transmit_Fields, Seller_Comp_ID);
			}

			//********************************************************
			// SAVE AIRCRAFT HISTORY COPY
			strError = "Storing A/C Hist";
			Working_On("Storing Aircraft Information Copy ...");
			if (!modCommon.Transaction_Save_Aircraft_History(Journal_ID, Transaction_Type, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, opt_Historical.Checked, modAdminCommon.Registration_no, SendtoWeb))
			{
				Transaction_Error = "Save Aircraft History";
				goto Abort_FractionalPM_Transaction;
			}


			//********************************************************
			// SAVE AIRCRAFT COMPANY HISTORY COPY
			// RTW - 3/5/2004 - EXTRA CHECK TO NOT SAVE CURRENT AC COMPANIES ON HISTORY TRANS
			if (!opt_Historical.Checked)
			{
				Working_On("Storing Aircraft Company Information Copies ...");
				if (!modCommon.Transaction_Save_Aircraft_Company_History(Journal_ID, modGlobalVars.snp_TransAircraft_Companies, modGlobalVars.snp_TransAircraft_Contacts, modGlobalVars.snp_TransAircraft_Company_Phones, modGlobalVars.snp_TransAircraft_Company_Btypes, modGlobalVars.snp_TransAircraft_Company_Certs, 0, SendtoWeb))
				{
					Transaction_Error = "Save Aircraft Company History";
					goto Abort_FractionalPM_Transaction;
				}
			}

			// *****************************************************
			// STORE TRANSMITS
			strError = "Transmits";
			Working_On("Recording Transaction Transmits ...");
			// store tramsmit for fractional owner sold
			modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, Journal_ID, gbl_ac_amod_id, "Fractional Sold", "Add", ref arr_Transmit_Fields, Seller_Comp_ID);
			// store a transmit for a normal aircraft transaction
			modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, Journal_ID, gbl_ac_amod_id, "Transaction", "Add", ref arr_Transmit_Fields);

			// *************************************************************
			// SAVE FRACTIONAL SELLER [Historic] row in 'Aircraft_Reference' table
			Working_On("Saving Fractional Seller Reference ...");
			Buyer_Percentage = Seller_Percentage;

			if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Seller_Comp_ID, Seller_Company_Business_Type, Seller_Contact_ID, "95", Seller_Percentage, "N"))
			{
				Transaction_Error = "Save Seller Reference";
				goto Abort_FractionalPM_Transaction;
			} // if seller reference not added

			// SELLER COMPANY INFORMATION
			Working_On("Saving Fractional Seller Company ...");
			if (!modCommon.Transaction_Save_Company_History(Journal_ID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs, 0, SendtoWeb))
			{
				Transaction_Error = "Save Seller Company";
				goto Abort_FractionalPM_Transaction;
			} // if historical SELLER not saved

			// *********************************************************
			// SAVE THE BUYER INFORMATION IN A HISTORY RECORD
			Working_On("Saving Fractional Buyer Company Information...");

			if (!modCommon.Transaction_Save_Buyer_History(ref Buyer_Comp_ID, Journal_ID, Buyer_Contact_Type, modGlobalVars.snp_Buyer_Company, modGlobalVars.snp_Buyer_Contacts, modGlobalVars.snp_Buyer_Company_Phones, modGlobalVars.snp_Buyer_Company_Btypes, modGlobalVars.snp_Buyer_Company_Certs, Buyer_Fown_ID, SendtoWeb))
			{
				Transaction_Error = "Save Buyer Company";
				goto Abort_FractionalPM_Transaction;
			}

			//===================================================================
			// SAVE FRACTIONAL BUYER [Historic] row in 'Aircraft_Reference' table
			Working_On("Saving Fractional Buyer Reference ...");


			Fraction_Expires_Date = "";


			if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, "96", Buyer_Percentage, "N", 0, Fraction_Expires_Date))
			{
				Transaction_Error = "Save Buyer Reference";
				goto Abort_FractionalPM_Transaction;
			} // if buyer reference not added

			// ****************************************************
			// IF NOT A HISTORICAL TRANSACTION
			string tmp_poc_flag = "";
			int tmp_transmit_flag = 0;
			string tmp_contact_type = "";
			if (!opt_Historical.Checked)
			{

				strError = "Not Historical";
				// ******************************************************************
				// UPDATE THE CURRENT AIRCRAFT RECORD AND CLEAR THE APPROPRIATE REFERENCE RECORDS
				Working_On("Updating Current Aircraft Information ...");
				if (!Transaction_Update_Current_Aircraft_Record(modAdminCommon.gbl_Aircraft_ID, DateTime.Parse(txt_transaction_date.Text.Trim()), Buyer_Ownership_Type, 0))
				{
					Transaction_Error = "Update Current Aircraft";
					goto Abort_FractionalPM_Transaction;
				} // if update to the aircraft was successful

				Working_On("Restoring Current Aircraft References ...");

				// LOOK THROUGH THE GRID ROWS
				int tempForEndVar = grd_Fractional.RowsCount - 1;
				for (int Row = 1; Row <= tempForEndVar; Row++)
				{

					// *********************************************************
					// GET THE PERCENT CHANGE ASSOCIATED WITH THE TRANSACTION
					grd_Fractional.CurrentRowIndex = Row;

					// put a more detailed message to the screen
					grd_Fractional.CurrentColumnIndex = 0;
					Working_On($"Restoring Reference {grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim()} ...");
					grd_Fractional.CurrentColumnIndex = 3;
					change_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
					if (Math.Abs(Conversion.Val(change_percent)) != 0)
					{ // GET PERCENTAGE FROM BUYER
						grd_Fractional.CurrentColumnIndex = 2;
						new_percent = Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim()).ToString();
					}
					else
					{
						// GET PERCENTAGE FROM SELLER
						grd_Fractional.CurrentColumnIndex = 1;
						new_percent = Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim()).ToString();
					}

					// ***************************************************************
					// LEAVE POC IF NEW PERCENTAGE IS NOT 0
					// OTHERWISE SET THE POC TO THE BUYER
					if ((Row == POC_Row) && (Double.Parse(($"0{new_percent}").Trim()) == 0))
					{
						POC_Row = Buyer_row;
					}

					// ********************************************************************
					// SAVE OWNERS BACK TO THE CURRENT AIRCRAFT FROM THE GRID
					if ((Conversion.Val(new_percent) > 0) || grid_Array_contact_type[Row] == "17")
					{
						// we have a percentage for this row, then save it
						if (grid_Array_contact_type[Row] == "17")
						{
							tmp_poc_flag = "Y";
							tmp_transmit_flag = 1;
						}
						else
						{
							tmp_poc_flag = "N";
							tmp_transmit_flag = 99;
						}
						tmp_contact_type = grid_Array_contact_type[Row];
						if (Strings.Len(($"{tmp_contact_type} ").Trim()) == 0)
						{
							tmp_contact_type = "97";
						}

						grd_Fractional.CurrentColumnIndex = 4;
						if (tmp_contact_type != "17")
						{
							if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() != "Buyer" || (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer" && chk_Awaiting_Documentation.CheckState == CheckState.Unchecked))
							{
								if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() != "Buyer")
								{
									if (grid_Array_fraction_expire_date[Row] != "")
									{
										Fraction_Expires_Date = DateTime.Parse(grid_Array_fraction_expire_date[Row]).ToString("d");
									}
								}

								if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, grid_Array_comp_id[Row], grid_Array_comp_Bus_Type[Row], grid_Array_contact_id[Row], tmp_contact_type, new_percent, tmp_poc_flag, tmp_transmit_flag, Fraction_Expires_Date))
								{
									Transaction_Error = "Save Fractional Owners from Grid";
									goto Abort_FractionalPM_Transaction;
								} //
							} // if not an awaiting documentation buyer
						}

						//replace program holder info
						if (tmp_contact_type == "17")
						{
							if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
							{
								tmp_contact_type = "17";
								tmp_transmit_flag = 1;
								tmp_poc_flag = "Y";
							}

							if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Buyer_Comp_ID, grid_Array_comp_Bus_Type[Row], Buyer_Contact_ID, tmp_contact_type, new_percent, tmp_poc_flag, tmp_transmit_flag, Fraction_Expires_Date))
							{
								Transaction_Error = "Save Fractional Owners from Grid";
								goto Abort_FractionalPM_Transaction;
							} //
						}

					} // if there was a percentage change indicating a important

				} // look for the next buyer

			} // not historical transaction

			// **************************************************************************
			// IF THE AIRCRAFT WAS AVAILABLE AND NOW ISN'T THEN RECORD A DELETE AVAILABLE TRANSMIT
			strError = "Avail 1";
			if (Prior_Availability && Clear_Availability)
			{
				strError = "Avail 1B";
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Delete", ref arr_Transmit_Fields);
			}

			// **************************************************************************
			// IF THE AIRCRAFT IS NOW AVAILABLE AND WASN'T PRIOR TO THE TRANSACTION
			// THEN RECORD AN ADD AVAILABLE TRANSMIT
			strError = "Avail 2";
			if (!Clear_Availability && !Prior_Availability && opt_Current.Checked)
			{
				strError = "Avail 2B";
				string tempRefParam = "On Market";
				if (Transaction_Insert_Journal_Entry(Journal_ID + 1, "MA", ref tempRefParam, 0, 0) == 0)
				{
					strError = "Avail 2C";
					Transaction_Error = "Insert On Market Journal Entry";
					goto Abort_FractionalPM_Transaction;
				}
				strError = "Avail 2D";
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Add", ref arr_Transmit_Fields);
			}

			// *******************************************************
			// ALL PROCESSING COMPLETE - COMMIT THE TRANSACTION
			modAdminCommon.ADO_Transaction("CommitTrans");

			modCommon.Aircraft_History_Close_Recordsets();

			// GET PENDING FRACTIONAL OWNER REFERENCE RECORDS IF NECESSARY

			if ((~((opt_Historical.Checked) ? -1 : 0) & ((Previous_Ownership_Type == "F") ? -1 : 0) & ((chk_Internal_Transaction.CheckState != CheckState.Checked) ? -1 : 0)) != 0)
			{
				if (!modCommon.Fractional_Pending_Get_Recordsets(modAdminCommon.gbl_Aircraft_ID))
				{
					Transaction_Error = "Get Aircraft History";
					goto Abort_FractionalPM_Transaction;
				}
			}

			switch(Trans_Type)
			{
				case "WS" : case "FC" : case "SZ" : case "DP" : 
					if ((~((opt_Historical.Checked) ? -1 : 0) & ((Previous_Ownership_Type == "F") ? -1 : 0) & ((chk_Internal_Transaction.CheckState != CheckState.Checked) ? -1 : 0)) != 0)
					{
						Transaction_Save_Pending_Fractions(modAdminCommon.gbl_Aircraft_ID, ref modGlobalVars.snp_Fractions_Pending);

					}  //   If Fractional_Pending Then 
					break;
			}


			strError = "end trans";
			Working_Off();

			return true;

			Abort_FractionalPM_Transaction:
			strError = $"{Information.Err().Description} {strError} tt:{txt_Transaction_Type.Text} te:{Transaction_Error}";

			modAdminCommon.ADO_Transaction("Rollback");
			modCommon.Aircraft_History_Close_Recordsets();
			Working_Off();

			modAdminCommon.Report_Error($"Transaction_Save_Fractional_Aircraft_Sale_Error A: {strError}");

			return result;

			Fractional_Owner_IDPM_Error:

			// 10/11/2002 - By David D. Cruger; Hold These Error Values As the RollbackTrans will clear them
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			lError = Information.Err().Number;
			strError = $"{Information.Err().Description} {strError} tt:{txt_Transaction_Type.Text} te:{Transaction_Error}";

			modAdminCommon.ADO_Transaction("Rollback");
			result = false;
			Working_Off();

			// 10/11/2002 - By David D. Cruger; Add the Held Error Values to the Report_Error Procedure
			Information.Err().Number = lError;
			Information.Err().Description = strError;
			modAdminCommon.Report_Error($"Fractional_Owner_IDPM_Error: Error Assigning Next Fractional Owner or Sold ID {strError}");

			return result;



			Transaction_Error = $"{Transaction_Error} {Information.Err().Description} {Information.Err().Source} B:{Buyer_Comp_ID.ToString()}"; //aey 5/27/04
			modAdminCommon.ADO_Transaction("RollbackTrans");
			modCommon.Aircraft_History_Close_Recordsets();
			result = false;
			Working_Off();
			modAdminCommon.Report_Error($"Abort_CommonPH_Transaction: {Transaction_Error}");

			return result;

			Transaction_Save_ProgramHolder_Error:
			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			if (Information.Err().Number == -2147467259 && ErrCount < 5)
			{ //deadlock error aey 7/16/04
				ErrCount++;
				//UPGRADE_TODO: (1065) Error handling statement (Resume) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Statement");
			}

			strError = $"{Information.Err().Description} {Transaction_Error} B:{Buyer_Comp_ID.ToString()} S:{Seller_Comp_ID.ToString()}"; //aey 5/27/04
			modAdminCommon.ADO_Transaction("RollbackTrans");
			modCommon.Aircraft_History_Close_Recordsets();
			result = false;
			Working_Off();
			modAdminCommon.Report_Error($"Transaction_Save_ProgramHolder_Error: {strError}");
			return result;
		}

		public int Transaction_Insert_Journal_Entry(int in_PC_Record_Key, string Trans_Type, ref string Subject, int in_Fract_Sold_ID, int comp_id, int inFractOwr_ID = 0, bool in_SendToWeb = true)
		{

			int result = 0;
			string errMsg = "";
			string toString = "";
			try
			{

				ADORecordSetHelper ado_J = null;
				bool type_valid = false;
				string tmp_journ_part1 = "";
				string tmp_journ_part2 = "";
				string tmp_journ_part3 = "";
				tmp_journ_part1 = "";
				tmp_journ_part2 = "";
				tmp_journ_part3 = "";

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// This routine will insert an entry into the 'Journal' table for
				// the current Aircraft Sales Transaction
				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				errMsg = "start";

				result = 0;
				if (Trans_Type == "RN")
				{
					type_valid = true;
				}
				else
				{
					type_valid = modCommon.Validate_Trans_Type(Trans_Type);
					// RTW - 11/3/2011 - ADDED NEW SPLIT OF CODES
					tmp_journ_part1 = Trans_Type.Substring(0, Math.Min(2, Trans_Type.Length));
					tmp_journ_part2 = Trans_Type.Substring(Math.Min(2, Trans_Type.Length), Math.Min(2, Math.Max(0, Trans_Type.Length - 2)));
					tmp_journ_part3 = Trans_Type.Substring(Math.Max(Trans_Type.Length - 2, 0));
				}

				int startposition = 0; // used to store who the transaction was to as extracted from the subject
				if (type_valid)
				{
					errMsg = "valid type";
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// INSERT the Journal Entry into the 'Journal' table
					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					ado_J = new ADORecordSetHelper();
					ado_J.Open("select * from Journal where journ_id = -1", modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

					//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_J.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					if (ado_J.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
					{
						ado_J.AddNew();
						ado_J["journ_date"] = DateTime.Parse(txt_transaction_date.Text.Trim()).ToString("d");
						ado_J["journ_subcategory_code"] = Trans_Type;
						// RTW - 11/3/2011 - ADDED NEW SPLIT OF CODES
						ado_J["journ_subcat_code_part1"] = tmp_journ_part1;
						ado_J["journ_subcat_code_part2"] = tmp_journ_part2;
						ado_J["journ_subcat_code_part3"] = tmp_journ_part3;

						ado_J["journ_subject"] = Subject;
						ado_J["journ_description"] = txt_Internal_Notes.Text.Trim();
						ado_J["journ_ac_id"] = modAdminCommon.gbl_Aircraft_ID;
						ado_J["journ_contact_id"] = 0;
						ado_J["journ_comp_id"] = 0;
						ado_J["journ_user_id"] = modAdminCommon.gbl_User_ID;

						ado_J["journ_entry_date"] = DateTime.Now.ToString("d");
						ado_J["journ_entry_time"] = DateTime.Now.ToString("T");

						ado_J["journ_account_id"] = modAdminCommon.gbl_Account_ID;
						ado_J["journ_prior_account_id"] = " ";
						ado_J["journ_status"] = "A";
						if (chk_NewAircraft.CheckState == CheckState.Checked)
						{
							ado_J["journ_newac_flag"] = "Y";
						}
						else
						{
							ado_J["journ_newac_flag"] = "N";
						}
						ado_J["journ_customer_note"] = txt_Customer_Notes.Text.Trim();
						ado_J["journ_pcreckey"] = in_PC_Record_Key;

						//aey 7/21/04 internal flag
						ado_J["journ_internal_trans_flag"] = (chk_Internal_Transaction.CheckState == CheckState.Checked) ? "Y" : "N";

						// for fractional owners get the fractional sold information
						if (Trans_Type.StartsWith("FS", StringComparison.Ordinal))
						{
							ado_J["journ_fractowr_id"] = inFractOwr_ID;
							ado_J["journ_fractsld_id"] = in_Fract_Sold_ID;
						}

						// *************************************************
						// RTW - 6/2/2004
						// MODIFIED TO CHECK JOURNAL CATEGORY TABLE TO DETERMINE
						// IF NEW JOURNAL ENTRY REQUIRES AN ACTION DATE

						if (in_SendToWeb)
						{
							ado_J["journ_action_date"] = "1/1/1900";
						}
						else
						{
							ado_J["journ_action_date"] = DateTime.Now.ToString().Trim();
						}
						ado_J.Update();
						result = Convert.ToInt32(ado_J["journ_id"]);

					}
					else
					{
						errMsg = "invalid type";
						result = 0;
					}

					errMsg = "start pos";
					startposition = (Convert.ToString(ado_J["journ_subject"]).IndexOf(" to ") + 1);
					if (startposition == 0)
					{
						startposition = (Convert.ToString(ado_J["journ_subject"]).IndexOf(" To ") + 1);
					}
					startposition += 3;
					toString = Convert.ToString(ado_J["journ_subject"]).Substring(Math.Min(startposition - 1, Convert.ToString(ado_J["journ_subject"]).Length), Math.Min(Strings.Len(Convert.ToString(ado_J["journ_subject"])) - startposition + 1, Math.Max(0, Convert.ToString(ado_J["journ_subject"]).Length - (startposition - 1))));

					if (!opt_Historical.Checked)
					{
						errMsg = "not hist";


						switch(Trans_Type.Substring(0, Math.Min(2, Trans_Type.Length)))
						{
							// HANDLE RECORDING NEW OWNER EVENTS FOR ALL SALES
							case "FS" : 
								if (Trans_Type != "FSPEND")
								{
									// if the new owner is not awaiting documentation
									if (Trans_Type.Substring(Math.Max(Trans_Type.Length - 2, 0)) != "UI" && Trans_Type.Substring(Math.Max(Trans_Type.Length - 2, 0)) != "PH")
									{
										// 3-20-2003 KTH
										// Added the "Format" statement to the percentages
										// because some of them had an extra zero in the
										// front on the web site
										EventCompID = Buyer_Comp_ID;
										EventContactID = Buyer_Contact_ID;
										//If EventContactID > 0 Then

										// Keith Humpf - 12/10/2003
										// The fractional sale events were rounding off the
										// percentages.  This has been fixed to keep 2 decimal
										// places instead of 0
										if (chk_Correction_Transaction.CheckState == CheckState.Unchecked)
										{ //aey 8/4/4 do not write
											modCommon.Transaction_Insert_Priority_Event("FS", modAdminCommon.gbl_Aircraft_ID, Convert.ToInt32(ado_J["journ_id"]), $"{Strings.FormatNumber(txt_Percentage, 2, TriState.False, TriState.False, TriState.True)}% - {toString}", EventCompID, EventContactID);
										}

										EventCompID = 0;

									}
								} 
								 
								break;
							case "WS" : case "SS" : 
								EventCompID = Buyer_Comp_ID; 
								EventContactID = Buyer_Contact_ID; 
								 
								// RTW - 3/24/2011 - MODIFIED TO RECORD A SPECIAL SUBJECT LINE FOR INTERNAL EVENTS AS THE LAST PARAMETER PASSED 
								if (chk_Correction_Transaction.CheckState == CheckState.Unchecked)
								{ //aey 8/4/4 do not write
									if (chk_Internal_Transaction.CheckState == CheckState.Checked && Trans_Type.StartsWith("WS", StringComparison.Ordinal))
									{
										modCommon.Transaction_Insert_Priority_Event(Trans_Type.Substring(0, Math.Min(2, Trans_Type.Length)), modAdminCommon.gbl_Aircraft_ID, Convert.ToInt32(ado_J["journ_id"]), toString, EventCompID, EventContactID, 0, false, "Full Sale Internal");
									}
									else
									{
										modCommon.Transaction_Insert_Priority_Event(Trans_Type.Substring(0, Math.Min(2, Trans_Type.Length)), modAdminCommon.gbl_Aircraft_ID, Convert.ToInt32(ado_J["journ_id"]), toString, EventCompID, EventContactID);
									}
								} 
								 
								//if its full sale, and its new ac flag = "Y" 
								//event type = "WSND" 
								//Subject = Full Sale - New Delivery 
								if (chk_NewAircraft.CheckState == CheckState.Checked)
								{
									modCommon.Transaction_Insert_Priority_Event("WSND", modAdminCommon.gbl_Aircraft_ID, Convert.ToInt32(ado_J["journ_id"]), toString, EventCompID, EventContactID);
								} 
								 
								// if the new owner is not awaiting documentation 
								if ((toString.IndexOf("Awaiting Documentation") + 1) == 0)
								{
									modCommon.Transaction_Insert_Priority_Event("NOWR", modAdminCommon.gbl_Aircraft_ID, Convert.ToInt32(ado_J["journ_id"]), toString, EventCompID, EventContactID);
								} 
								 
								break;
							case "LA" : case "LN" : case "LO" : case "LS" : case "LT" : 
								// If right(Trans_Type, 2) <> "UI" Then 'disabled 8/3/04 aey 
								EventCompID = Buyer_Comp_ID; 
								EventContactID = Buyer_Contact_ID; 
								 
								// added in MSW - 5/30/18 
								if (Trans_Type.StartsWith("LT", StringComparison.Ordinal))
								{
									if (chk_NewAircraft.CheckState == CheckState.Checked)
									{
										Subject = modCommon.BuildJournalSubject(Transaction_Type, 0, 0, 0, 0, Lessor_Comp_Name_1, Lessee_Comp_Name_1);
										Subject = $"{GetPriorityEventSubject_Change("WSND")} - {Subject}";
										modCommon.Transaction_Insert_Priority_Event("WSND", modAdminCommon.gbl_Aircraft_ID, Convert.ToInt32(ado_J["journ_id"]), toString, EventCompID, EventContactID, 0, false, Subject);
									}
								} 
								 
								if (chk_Correction_Transaction.CheckState == CheckState.Unchecked)
								{ //aey 8/4/4 do not write

									modCommon.Transaction_Insert_Priority_Event("LS", modAdminCommon.gbl_Aircraft_ID, Convert.ToInt32(ado_J["journ_id"]), toString, EventCompID, EventContactID);

									if (Trans_Type.StartsWith("LO", StringComparison.Ordinal))
									{ //aey 8/3/04 - also mark as off market
										modCommon.Transaction_Insert_Priority_Event("OM", modAdminCommon.gbl_Aircraft_ID, Convert.ToInt32(ado_J["journ_id"]), toString, EventCompID, EventContactID);
									}

								} 
								EventCompID = 0; 
								 
								//End If 
								break;
						}

					}
					else
					{
						errMsg = "hist";
						if (Trans_Type.StartsWith("WS", StringComparison.Ordinal) || Trans_Type.StartsWith("SS", StringComparison.Ordinal))
						{
							EventCompID = Buyer_Comp_ID;
							EventContactID = Buyer_Contact_ID;

							if (chk_Correction_Transaction.CheckState == CheckState.Unchecked)
							{ //aey 8/4/4 do not write
								modCommon.Transaction_Insert_Priority_Event(Trans_Type.Substring(0, Math.Min(2, Trans_Type.Length)), modAdminCommon.gbl_Aircraft_ID, Convert.ToInt32(ado_J["journ_id"]), toString, EventCompID, EventContactID);
							}

						}
					}

					if (ado_J.State == ConnectionState.Open)
					{
						ado_J.Close();
					}
					ado_J = null;
					// save aircraft history for on and off markets
					errMsg = $"save ac hist {Trans_Type}";
					if ((Trans_Type == "MA") || (Trans_Type == "OM") && opt_Current.Checked)
					{

						//********************************************************
						// SAVE AIRCRAFT HISTORY COPY
						if (!modCommon.Transaction_Save_Aircraft_History(result, Trans_Type, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, false, in_SendToWeb.ToString()))
						{
							return 0;
						}

						//********************************************************
						// SAVE AIRCRAFT COMPANY HISTORY COPY
						if (!modCommon.Transaction_Save_Aircraft_Company_History(result, modGlobalVars.snp_TransAircraft_Companies, modGlobalVars.snp_TransAircraft_Contacts, modGlobalVars.snp_TransAircraft_Company_Phones, modGlobalVars.snp_TransAircraft_Company_Btypes, modGlobalVars.snp_TransAircraft_Company_Certs, 0, in_SendToWeb))
						{
							return 0;
						}

					}

				}
				return result;
			}
			catch (System.Exception excep)
			{

				Working_Off();
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Record_Error("Transaction", $"Transaction_Insert_Journal_Entry_Error: {errMsg} {excep.Message} {Information.Err().Number.ToString()} {Trans_Type} {comp_id.ToString()}"); //aey 8/4/4
				MessageBox.Show($"Transaction_Insert_Journal_Entry_Error: {excep.Message}", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				result = 0;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
				return result;
			}
		}
		private string GetPriorityEventSubject_Change(string inCatCode)
		{

			string result = "";
			string Query = "";
			ADORecordSetHelper snpSubject = new ADORecordSetHelper(); //8/11/05 aey

			try
			{

				Query = $"SELECT priorevcat_category_name FROM Priority_Events_Category WITH(NOLOCK) WHERE priorevcat_category_code = '{inCatCode}'";

				snpSubject.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpSubject.BOF && snpSubject.EOF))
				{
					result = ($"{Convert.ToString(snpSubject["priorevcat_category_name"])}").Trim();
				}
				else
				{
					result = "";
				}

				snpSubject.Close();
				snpSubject = null;
			}
			catch
			{

				modAdminCommon.Report_Error($"GetPriorityEventSubject_Change_Error: CatCode[{inCatCode}]  ");
			}

			return result;
		}


		public void Transaction_Commit()
		{

			string strMsg = "";
			System.DateTime dtStartDate = DateTime.FromOADate(0);
			System.DateTime dtEndDate = DateTime.FromOADate(0);

			int lError = 0;
			string strError = "";
			string Query = "";
			string Query2 = "";
			string Query3 = "";
			double NumWhole = 0;
			double NumWholeAfter = 0;
			double NumFrac = 0;
			double NumFracAfter = 0;
			string AcctRep = "";
			string AcctRepNew = "";
			string AcctType = "";
			string Old_Company_Name = "";
			ADORecordSetHelper adoOwnerType = null;
			string strSellerLockedBy = "";
			string strBuyerLockedBy = "";
			string[] comp_id_array = null;

			//UPGRADE_TODO: (1065) Error handling statement (On Error Goto) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("On Error Goto Label (Transaction_Abort)");

			cmd_Commit_Transaction.Visible = false;

			strError = "start";
			modCommon.Start_Activity_Monitor_Message("Transaction", ref strMsg, ref dtStartDate, ref dtEndDate);

			// =========================================
			// RTW - 3/29/06 - INSERTED NEW CODE TO MAKE SURE THAT
			// THE BUYER OR SELLER COMPANIES ARE NOT LOCKED.
			//
			strSellerLockedBy = modCommon.CompanyLocked(Seller_Comp_ID, 0);
			strBuyerLockedBy = modCommon.CompanyLocked(Buyer_Comp_ID, 0);
			// RTW - 3/29/06 - PUT CHECK IN TO SEE IF THE COMPANIES IN THE TRANSACTION
			// ARE LOCKED BY ANOTHER USER
			//aey 5/4/06 check current user
			if ((strSellerLockedBy == "False" || strSellerLockedBy == Convert.ToString(modAdminCommon.snp_User["user_id"])) && (strBuyerLockedBy == "False" || strBuyerLockedBy == Convert.ToString(modAdminCommon.snp_User["user_id"])))
			{

				if (!Validate_Lease_Dates())
				{
					MessageBox.Show("Invalid Dates on Lease Panel.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
					return;
				}
				//========================================================
				// ALLOW USER TO IDENTIFY AIRCRAFT SETTINGS FROM MODAL FORM
				// IF THIS IS NOT A HISTORICAL INSERT TRANSACTION
				strError = "not hist";
				if (!opt_Historical.Checked)
				{

					frm_AircraftSettings.DefInstance.inTrans_Type = Trans_Type;
					frm_AircraftSettings.DefInstance.inInternal_Flag = chk_Internal_Transaction.CheckState == CheckState.Checked;
					frm_AircraftSettings.DefInstance.inCorrection_Flag = chk_Correction_Transaction.CheckState == CheckState.Checked;
					frm_AircraftSettings.DefInstance.inHistorical_Flag = opt_Historical.Checked;
					frm_AircraftSettings.DefInstance.inAvailable_flag = Aircraft_Available(modAdminCommon.gbl_Aircraft_ID, 0);

					// MAKE SURE THAT THE SETTINGS FORM IS ASSIGNED THE CURRENT TRANSACTION CODE
					frm_AircraftSettings.DefInstance.inJournal_Code = Transaction_Type;

					frm_AircraftSettings.DefInstance.ShowDialog();
					if (!Aircraft_Settings)
					{
						modAdminCommon.ADO_Transaction("RollbackTrans");
						goto UserCancel;
					}
				} // if this was historical

				Working_On("Saving Transaction ...");

				strError = "save";
				// ***********************************************
				// STORE THE CURRENT PRIMARY COMPANY FOR LATER USE
				Old_POC_comp_id = Get_POC_comp_id(modAdminCommon.gbl_Aircraft_ID); // poc_flag=Y

				Preserve_POC = false; //aey 9/2/04
				// IF WE HAVE AND INTERNAL OR CORRECTION AND THE SELLER WASN'T THE PRIMARY
				// THEN WE WOULD LIKE TO KEEP THE ORIGINAL PRIMARY SET
				if ((chk_Correction_Transaction.CheckState == CheckState.Checked || chk_Internal_Transaction.CheckState == CheckState.Checked) && Seller_Comp_ID != Old_POC_comp_id)
				{
					Preserve_POC = true;
				}

				if (Trans_Type == "SZ" || Trans_Type == "FC")
				{ //aey 9/30/04
					Preserve_POC = false;
				}

				NumFrac = -1; //set defaults
				NumWhole = -1;

				//*************************** #275 part 1 of reassign logic *****************
				if (~((opt_Historical.Checked) ? -1 : 0) != 0)
				{
					//change company acct rep if they have fractional and whole a/c ownership #275
					//(part 2 is after trans commit)
					//get the counts for the current a/c
					//we want to count the number of wholly owned a/c for which company is primary
					strError = "Hist";
					NumWhole = 0;
					NumFrac = 0;
					Query = "select count(*) as tot,company.comp_account_id,company.comp_account_type, company.comp_name ";
					Query = $"{Query}From Aircraft_Reference WITH(NOLOCK), aircraft WITH(NOLOCK), company WITH(NOLOCK)";
					Query = $"{Query}WHERE cref_comp_id = {Old_POC_comp_id.ToString()} and cref_journ_id=0 and cref_Primary_poc_flag='Y' ";
					Query = $"{Query}and cref_journ_id = ac_Journ_id and cref_ac_id=ac_id ";
					Query = $"{Query}and cref_comp_id =comp_id and comp_journ_id=ac_journ_id ";
					Query = $"{Query}and (ac_ownership_type='W' or ac_ownership_type='S') ";
					Query = $"{Query}group by company.comp_account_id,company.comp_account_type,company.comp_name";
					adoOwnerType = new ADORecordSetHelper();
					adoOwnerType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					if (!(adoOwnerType.BOF && adoOwnerType.EOF))
					{
						adoOwnerType.MoveFirst();
						NumWhole = Conversion.Val($"{Convert.ToString(adoOwnerType["tot"])}");
						AcctRep = $"{Convert.ToString(adoOwnerType["comp_account_id"])}";
						AcctType = $"{Convert.ToString(adoOwnerType["COMP_ACCOUNT_TYPE"])}";
						Old_Company_Name = $"{Convert.ToString(adoOwnerType["comp_name"])}";
					}
					adoOwnerType.Close();

					if (AcctType != "FO")
					{ //bypass if it is not fractional
						//now count the number of fractional for this company
						Query2 = "select count(*)  as tot From Aircraft_Reference WITH(NOLOCK), aircraft WITH(NOLOCK)";
						Query2 = $"{Query2}where cref_comp_id = {Old_POC_comp_id.ToString()} And cref_journ_id = 0 ";
						Query2 = $"{Query2}and (cref_contact_type='97' or cref_contact_type='17') ";
						Query2 = $"{Query2}and cref_journ_id = ac_Journ_id and cref_ac_id=ac_id ";
						Query2 = $"{Query2}and ac_ownership_type='F' ";

						adoOwnerType = new ADORecordSetHelper();
						adoOwnerType.Open(Query2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
						if (!(adoOwnerType.BOF && adoOwnerType.EOF))
						{
							adoOwnerType.MoveFirst();
							NumFrac = Conversion.Val($"{Convert.ToString(adoOwnerType["tot"])}");
						}
						adoOwnerType.Close();
					}
				} // original code follows

				if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
				{
					Buyer_Comp_ID = 0;
				}
				strError = "trans";
				//Num_Embedded = 0
				// **************************************************************************
				// DETERMINE THE TYPE OF TRANSACTION AND CALL APPROPRIATE TRANSACTION ROUTINE
				strMsg = $"TransType: ({Trans_Type}) ";

				switch(Trans_Type)
				{
					case "WS" : case "FC" : case "SZ" : case "DP" : 
						 
						//process PH -to-> PH fractional transaction   ---- aey 8/6/04 
						if (SellFracTransPHtoPH == System.Windows.Forms.DialogResult.Yes)
						{
							if (!Transaction_Save_ProgramHolder())
							{
								goto Transaction_Abort;
							}
						} 
						 
						// ******************************************************* 
						// PROCESS WHOLE SALE TRANSACTION 
						if (SellFracTransPHtoPH == System.Windows.Forms.DialogResult.No)
						{ //aey 8/6/04
							if (!Transaction_Save_Common_Aircraft_Sale())
							{
								goto Transaction_Abort;
							}
						} 
						 
						break;
					case "FS" : 
						// ******************************************************* 
						// PROCESS FRACTIONAL SALE TRANSACTION 
						if (!Transaction_Save_Fractional_Aircraft_Sale())
						{
							goto Transaction_Abort;
						} 
						 
						break;
					case "SS" : 
						// ******************************************************* 
						// PROCESS SHARE SALE TRANSACTION 
						if (!Transaction_Save_Aircraft_Share())
						{
							goto Transaction_Abort;
						} 
						 
						break;
					default:
						// ******************************************************* 
						// PROCESS LEASE TRANSACTIONS 
						if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
						{
							if (!Transaction_Save_Aircraft_Lease())
							{
								goto Transaction_Abort;
							}
						}
						else
						{
							// WE HAVE AN UNKNOWN TRANSACTION TYPE
							MessageBox.Show("Bad Transaction Type", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
							return;
						} 
						break;
				}

				if (modGlobalVars.bCallShowAndLoadOnlyOnce)
				{

					//UPGRADE_TODO: (1067) Member Clear_Search_Criteria is not defined in type Variant. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1067
					modGlobalVars.find_frm_collection[modGlobalVars.FIND_FORM_TX].Clear_Search_Criteria(true, true, true);

				}

				Working_On("Transaction Successful! Updating Callbacks and Reassigns...");
				// INSERT A VERIFIED STATUS JOURNAL ENTRY **********
				// FOR NON-HISTORICAL TRANSACTIONS
				strError = "trans type";
				if ((~((opt_Historical.Checked) ? -1 : 0) & ((Trans_Type != "FS") ? -1 : 0) & ((!Trans_Type.StartsWith("L", StringComparison.Ordinal)) ? -1 : 0)) != 0)
				{
					modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
					modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "VS";
					modAdminCommon.Rec_Journal_Info.journ_subject = "Verified Status - Aircraft Sale";
					modAdminCommon.Rec_Journal_Info.journ_description = " ";
					modAdminCommon.Rec_Journal_Info.journ_ac_id = modAdminCommon.gbl_Aircraft_ID;
					modAdminCommon.Rec_Journal_Info.journ_comp_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
					modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
					modAdminCommon.Rec_Journal_Info.journ_account_id = "";
					modAdminCommon.Rec_Journal_Info.journ_prior_account_id = " ";
					modAdminCommon.Rec_Journal_Info.journ_status = "A";
					//frm_Journal.Insert_Journal_Entry
					VS_journ_id = frm_Journal.DefInstance.Commit_Journal_Entry();
				}
				else
				{
					VS_journ_id = 0;
				} // end if for verified status journal entry

				// ***********************************************
				// BEGIN A SEPARATE TRANSACTION FOR CLEANUP ACTIVITIES
				// IF ERROR - ONLY ROLLBACK CLEANUP ACTIONS
				strError = "btrans";
				//UPGRADE_TODO: (1065) Error handling statement (On Error Goto) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("On Error Goto Label (Cleanup_Abort)");
				// GET THE NEW PRIMARY POC FOR THE AIRCRAFT
				New_POC_comp_id = Get_POC_comp_id(modAdminCommon.gbl_Aircraft_ID);

				if (Preserve_POC && Clear_Availability)
				{
					Query = "Select cref_id FROM Aircraft_reference WITH(NOLOCK) ";
					Query = $"{Query}where cref_primary_poc_flag='X' and cref_journ_id=0 and cref_ac_id={modAdminCommon.gbl_Aircraft_ID.ToString()}";
					if (modAdminCommon.Exist(Query))
					{
						Query = "update Aircraft_reference SET cref_primary_poc_flag='Y' ";
						Query = $"{Query}where cref_primary_poc_flag='X' and cref_journ_id=0 and cref_ac_id={modAdminCommon.gbl_Aircraft_ID.ToString()}";
						DbCommand TempCommand = null;
						TempCommand = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
						TempCommand.CommandText = Query;
						TempCommand.CommandType = CommandType.Text;
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
						TempCommand.ExecuteNonQuery();
					}
				}

				modAdminCommon.ADO_Transaction("BeginTrans");
				// IF THE PRIMARY COMPANY HAS CHANGED

				if (Old_POC_comp_id != New_POC_comp_id)
				{
					//Preserve_POC
					strError = "Preserve POC";
					// UPDATE COMPANY CALLBACK DATE OF PRIOR PRIMARY COMPANY AND CHECK FOR REASSIGNS
					if (Old_POC_comp_id > 0)
					{
						modCompany.update_company_callback_date(Old_POC_comp_id, modGlobalVars.cEmptyString);

						if (!frm_AircraftSettings.DefInstance.inInternal_Flag && (Trans_Type.Trim() == "WS" || Trans_Type.Trim() == "SS" || Trans_Type.Trim() == "FS" || Trans_Type.Trim() == "LT"))
						{
							modCommon.Check_For_Account_Reassignment(Old_POC_comp_id, New_POC_comp_id, modAdminCommon.gbl_Aircraft_ID, "Y");
						}
						else
						{
							// if the buyer and poc are different, then make sure you make one for the new buyer if meets criteria

							Query = "select count(distinct cref_ac_id) as tcount ";
							Query = $"{Query} FROM Company WITH(NOLOCK)";
							Query = $"{Query} inner join aircraft_reference with (NOLOCK) on cref_comp_id = comp_id and cref_journ_id = comp_journ_id";
							Query = $"{Query} WHERE comp_active_flag = 'Y'  AND comp_id=  {Buyer_Comp_ID.ToString()}   ";
							Query = $"{Query} AND comp_journ_id= 0 and cref_contact_type in ('00', '08', '12','97','39') ";

							adoOwnerType = new ADORecordSetHelper();
							adoOwnerType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
							if (!(adoOwnerType.BOF && adoOwnerType.EOF))
							{
								if (Convert.ToDouble(adoOwnerType["tcount"]) > 1)
								{
									// then dont need to insert it
								}
								else
								{
									// buyer has one or less itemf of that kind, so add reassign
									modCommon.Check_For_Account_Reassignment(Buyer_Comp_ID, Buyer_Comp_ID, modAdminCommon.gbl_Aircraft_ID, "Y");
								}
							}
							adoOwnerType.Close();
						}



					}
					// UPDATE COMPANY CALLBACK DATE OF NEW PRIMARY COMPANY BASED ON NEW AIRCRAFT ASSIGNED.
					if (New_POC_comp_id > 0)
					{
						modCompany.update_company_callback_date(New_POC_comp_id, modGlobalVars.cEmptyString);
					}
				}
				else
				{
					// the POC hasnt changed, then check buyer to see if he needs a reassign added
					// added MSW - 7/24/23
					Query = "select count(distinct cref_ac_id) as tcount ";
					Query = $"{Query} FROM Company WITH(NOLOCK)";
					Query = $"{Query} inner join aircraft_reference with (NOLOCK) on cref_comp_id = comp_id and cref_journ_id = comp_journ_id";
					Query = $"{Query} WHERE comp_active_flag = 'Y'  AND comp_id=  {Buyer_Comp_ID.ToString()}   ";
					Query = $"{Query} AND comp_journ_id= 0 and cref_contact_type in ('00', '08', '12','97','39') ";

					adoOwnerType = new ADORecordSetHelper();
					adoOwnerType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					if (!(adoOwnerType.BOF && adoOwnerType.EOF))
					{
						if (Convert.ToDouble(adoOwnerType["tcount"]) > 1)
						{
							// then dont need to insert it
						}
						else
						{
							// buyer has one or less itemf of that kind, so add reassign
							modCommon.Check_For_Account_Reassignment(Buyer_Comp_ID, Buyer_Comp_ID, modAdminCommon.gbl_Aircraft_ID, "Y");
						}
					}
					adoOwnerType.Close();
				}

				strError = "Check for inactive";
				//check for an inactive company and make it active
				Working_On("Checking for Inactive Company...");

				Query = "SELECT comp_active_flag FROM Company WITH(NOLOCK)";
				Query = $"{Query} WHERE comp_active_flag = 'N'";
				Query = $"{Query} AND comp_id= {Buyer_Comp_ID.ToString()}";
				Query = $"{Query} AND comp_journ_id= 0";

				if (modAdminCommon.Exist(Query))
				{
					Query = "UPDATE company SET comp_active_flag = 'Y'";
					Query = $"{Query} WHERE comp_id= {Buyer_Comp_ID.ToString()}";
					Query = $"{Query} AND comp_journ_id= 0";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
				}

				// RTW - 2/23/2006 - CHECK FOR MISSING EXCLUSIVE BROKERS ON EXCLUSIVE TRANSACTION
				if (Aircraft_Exclusive)
				{
					if (modAdminCommon.Exist($"select * from Integrity_Exclusive_Transactions_Without_Brokers WITH(NOLOCK) where ac_journ_id ={Journal_ID.ToString()}"))
					{
						if (modEmail.EMail_Message("Homebase", "jetnet@jetnet.com", "rick@jetnet.com", "andrew@mvintech.com", "", "Exclusive Transaction witout Broker", $"Aircraft ID = {modAdminCommon.gbl_Aircraft_ID.ToString()} Journal ID={Journal_ID.ToString()}{Environment.NewLine}{Environment.NewLine}This was inserted by {modCommon.GetUserName(modAdminCommon.gbl_User_ID)}", "", false))
						{
						}
					}
				}

				strError = "Check for Curr Company";
				if (Journal_ID > 0)
				{ //aey 4/7/05
					Query = $"exec HomebaseCheckForCurrentCompany {Buyer_Comp_ID.ToString()},{Journal_ID.ToString()}";
					DbCommand TempCommand_3 = null;
					TempCommand_3 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_3);
					TempCommand_3.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_3.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_3);
					TempCommand_3.ExecuteNonQuery();
					Query = $"exec HomebaseCheckForCurrentCompany {Seller_Comp_ID.ToString()},{Journal_ID.ToString()}";
					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();
				}

				modAdminCommon.ADO_Transaction("CommitTrans");

				Working_On("Updating Stats....");

				strError = "Update Stats";
				modCommon.Company_Stats_Update(Buyer_Comp_ID); //aey 6/15/05
				modCommon.Company_Stats_Update(Seller_Comp_ID); //aey 6/15/05
				// MSW - adds in all of the companies that were attached to the AC

				if (Companies_Connected_List.Trim() != "")
				{
					comp_id_array = Companies_Connected_List.Split(',');

					int tempForEndVar = comp_id_array.GetUpperBound(0) - 1;
					for (int i = 0; i <= tempForEndVar; i++)
					{
						modCommon.Company_Stats_Update(Convert.ToInt32(Double.Parse(comp_id_array[i])));
					}

				}



				strError = "hist event";
				// *************************************************
				// IF HISTORICAL THEN ALSO RECORD AN EVENT
				if (opt_Historical.Checked)
				{

					strError = "hist event a";
					modAdminCommon.Record_Event("Insert_Historical", Trans_Type, modAdminCommon.gbl_Aircraft_ID, Journal_ID);
				}
				else if ((((AcctType != "FO") ? -1 : 0) & ~((opt_Historical.Checked) ? -1 : 0)) != 0)
				{ 
					strError = "hist event b";

					NumWholeAfter = 0;
					Query = "select count_big(*) as tot ";
					Query = $"{Query}From Aircraft_Reference WITH(NOLOCK), aircraft WITH(NOLOCK), company WITH(NOLOCK)";
					Query = $"{Query}WHERE cref_comp_id = {Old_POC_comp_id.ToString()} and cref_journ_id=0 and cref_Primary_poc_flag='Y' ";
					Query = $"{Query}and cref_journ_id = ac_Journ_id and cref_ac_id=ac_id ";
					Query = $"{Query}and (ac_ownership_type='W' or ac_ownership_type='S') ";

					adoOwnerType = new ADORecordSetHelper();
					adoOwnerType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					if (!(adoOwnerType.BOF && adoOwnerType.EOF))
					{
						//adoOwnerType.MoveFirst
						NumWholeAfter = Conversion.Val($"{Convert.ToString(adoOwnerType["tot"])}");
					}
					adoOwnerType.Close();
					strError = "hist event b2";

					//now re-count the number of fractional for this company
					NumFracAfter = 0;
					Query2 = "select count(*) as tot From Aircraft_Reference WITH(NOLOCK), aircraft WITH(NOLOCK)";
					Query2 = $"{Query2}where cref_comp_id = {Old_POC_comp_id.ToString()} And cref_journ_id = 0 ";
					Query2 = $"{Query2}and (cref_contact_type='97' or cref_contact_type='17') ";
					Query2 = $"{Query2}and cref_journ_id = ac_Journ_id and cref_ac_id=ac_id ";
					Query2 = $"{Query2}and ac_ownership_type='F' ";

					adoOwnerType = new ADORecordSetHelper();
					adoOwnerType.Open(Query2, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
					if (!(adoOwnerType.BOF && adoOwnerType.EOF))
					{
						// adoOwnerType.MoveFirst
						NumFracAfter = Conversion.Val($"{Convert.ToString(adoOwnerType["tot"])}");
					}
					adoOwnerType.Close();

					//compare counts of before and after then
					//if wholly owned has been sold,  change account rep & write journal
					strError = "hist event c";
					if (NumWhole == 1 && NumWholeAfter == 0 && NumFrac > 0 && NumFracAfter > 0 && AcctType != "FO")
					{

						if (String.CompareOrdinal(Old_Company_Name.Substring(0, Math.Min(1, Old_Company_Name.Length)).ToUpper(), "J") <= 0)
						{
							Query3 = "Update company set comp_account_id='FO01', ";
							AcctRepNew = "FO01"; //rep 01 goes up to J
						}
						else
						{
							Query3 = "Update company set comp_account_id='FO02', ";
							AcctRepNew = "FO02"; //rep 02 is > J
						}
						Query3 = $"{Query3}Comp_account_type='FO', "; //fractional owner
						Query3 = $"{Query3}Comp_assign_flag='M' "; //set to manual, so that it's not over-written
						Query3 = $"{Query3}Where comp_id = {Old_POC_comp_id.ToString()} ";
						Query3 = $"{Query3}And comp_journ_id=0 ";

						DbCommand TempCommand_5 = null;
						TempCommand_5 = modAdminCommon.LOCAL_ADO_DB.CreateCommand();
						UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_5);
						TempCommand_5.CommandText = Query3;
						//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
						//UPGRADE_WARNING: (6021) Casting 'int' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
						TempCommand_5.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
						UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_5);
						TempCommand_5.ExecuteNonQuery();

						//write out journal record to track changes
						modAdminCommon.Rec_Journal_Info.journ_date = DateTime.Parse(modAdminCommon.DateToday);
						modAdminCommon.Rec_Journal_Info.journ_subcategory_code = "FR";
						modAdminCommon.Rec_Journal_Info.journ_subject = $"{Old_Company_Name} re-assigned to Fractional Rep {AcctRepNew}";
						modAdminCommon.Rec_Journal_Info.journ_description = " ";
						modAdminCommon.Rec_Journal_Info.journ_ac_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_comp_id = Old_POC_comp_id;
						modAdminCommon.Rec_Journal_Info.journ_contact_id = 0;
						modAdminCommon.Rec_Journal_Info.journ_user_id = modAdminCommon.gbl_User_ID;
						modAdminCommon.Rec_Journal_Info.journ_account_id = AcctRepNew;
						modAdminCommon.Rec_Journal_Info.journ_prior_account_id = AcctRep;
						modAdminCommon.Rec_Journal_Info.journ_status = "A";

					} // If NumWhole = 1 And NumWholeAfter = 0 And NumFrac > 0 And NumFracAfter > 0 And AcctType <> "FO" Then

				} // If opt_Historical = True Then

				strMsg = $"{strMsg}Seller: {Seller_Comp_ID.ToString()} Purchaser: {Buyer_Comp_ID.ToString()}";

				modCommon.End_Activity_Monitor_Message("Transaction", ref strMsg, dtStartDate, ref dtEndDate, modAdminCommon.gbl_Aircraft_ID, Journal_ID, Seller_Comp_ID, 0, 0);

				// ********************************************************************
				// IF THE USER SELECTED TO CANCEL THE TRANSACTION, JUMP DIRECTLY HERE.
				UserCancel:

				Working_Off();

				MessageBox.Show("Transaction Successful.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));

				// added MSW - 9/28/18 - to clear maint field
				//if we are doing an internal, then dont clear the ac_maintainted field, otherwise, clear it
				if (chk_Internal_Transaction.CheckState == CheckState.Checked || Trans_Type == "SS" || Trans_Type == "FS")
				{ // ss and fs added 9/5/19 msw
				}
				else
				{
					// clear that box then re-fill it
					frm_aircraft.DefInstance.cbo_ac_warranty_notes.Items.Clear();
					frm_aircraft.DefInstance.skip_question_ac_maintained = true;
					frm_aircraft.DefInstance.Save_Aircraft_Click();
					frm_aircraft.DefInstance.skip_question_ac_maintained = false;
					// 05/03/2019 - By David D. Cruger
					// Pass Zero (JournId) so only Active Certifications get loaded into the pull down
					modFillAircraftControls.Fill_Operating_Certification_CBO(frm_aircraft.DefInstance.cbo_ac_warranty_notes, 0);
				}


				mnuFileClose_Click(mnuFileClose, new EventArgs());

			}
			else
			{
				// COMPANIES NOT LOCKED BY OTHER USERS
				// DETERMINE WHICH OF THE COMPANIES IS LOCKED
				if (strBuyerLockedBy != "False")
				{ // BUYER LOCKED
					MessageBox.Show($"Buyer Company ID={Buyer_Comp_ID.ToString()} is currently locked by '{strBuyerLockedBy}'. Please have it unlocked by the user before commiting transaction.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				else
				{
					// COMPANY WE ARE REMOVING
					MessageBox.Show($"Seller Company ID={Seller_Comp_ID.ToString()} is currently locked by '{strSellerLockedBy}'. Please have it unlocked by the user before commiting transaction.", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()));
				}
				cmd_Commit_Transaction.Visible = true;
			}
			return;

			// ********************************************************************
			// IF ERROR DURING CLEANUP AFTER TRANSACTION COMMIT THEN ROLLBACK CLEANUP
			Cleanup_Abort:

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			lError = Information.Err().Number;
			strError = $"{Information.Err().Description} {strError}";

			modAdminCommon.ADO_Transaction("RollbackTrans");
			Working_Off();

			modAdminCommon.Report_Error($"Transaction_Commit_Error: Transaction Cleanup Aborted {strError}");

			return;
			//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
			UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			// *********************************************************************
			// IF UNKNOWN ERROR OCCURS DURING TRANSACTION PROCESSING THE ROLLBACK
			// THE ENTIRE TRANSACTION.
			Transaction_Abort:

			//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
			lError = Information.Err().Number;
			strError = $"{Information.Err().Description} {strError}";

			modAdminCommon.ADO_Transaction("RollbackTrans");
			Working_Off();

			modAdminCommon.Report_Error($"Transaction_Commit_Error: Transaction Aborted {lError.ToString()} {strError}");


		}

		public bool Transaction_Save_Fractional_Aircraft_Sale()
		{

			bool result = false;
			string Transaction_Error = "";
			int lError = 0;
			string strError = "";
			try
			{

				result = false; // String used to store transaction errors
				int Fractional_Sold_ID = 0; // counter for looking through the rows in the grid
				int Seller_Fown_ID = 0;
				int Buyer_Fown_ID = 0;
				string Seller_Company_Name = "";
				string Buyer_Company_Name = "";
				string Buyer_Ownership_Type = "";
				string Buyer_New_Percent = "";
				string Buyer_Company_Business_Type = "";
				int PC_Record_Key = 0;
				string change_percent = "";
				string new_percent = "";
				int Next_Fown_ID = 0;
				string Subject = ""; // subject to be place in the journal entry // Hold The Error Number Value // Hold The Error Description Value
				string fquery = ""; // string for building fractional owner update query
				bool SendtoWeb = false; //aey 7/28/04
				string Query = "";
				int Exclusive_Comp_ID = 0;
				bool Exclusive_Flag = false;
				// Dim ProgramHolder_comp_id As Long

				string Fraction_Expires_Date = "";
				string strTmpDate = "";
				System.DateTime dtTmpDate = DateTime.FromOADate(0);
				string tmp_contact_type = "";

				SendtoWeb = modCommon.GetTransWeb(Transaction_Type);

				tmp_contact_type = "";

				Exclusive_Flag = false; //aey 10/19/2004
				Exclusive_Comp_ID = 0;
				// CHANGED - RTW - 2/1/2012 - SELECTED JUST COMP ID RATHER THAN *
				fquery = "Select cref_comp_id from Aircraft_Reference where cref_primary_poc_flag = 'X' ";
				fquery = $"{fquery}and cref_ac_id= {modAdminCommon.gbl_Aircraft_ID.ToString()} and cref_journ_id = {MOD_Journal_ID.ToString()}  ";
				if (modAdminCommon.Exist(fquery))
				{
					Exclusive_Flag = true;
					Exclusive_Comp_ID = Get_Exclusive_Comp_id(fquery);
				}

				//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// The user has requested the completion of an Aircraft Fractional Sale Transaction
				//
				strError = "Start";
				Working_On("Saving Fractional Aircraft Sale Transaction ...");

				// *******************************************
				// GET A SNAPSHOT OF SELLER COMPANY INFORMATION
				Working_On("Selecting Copy of Seller Company Information ...");
				if (!modCommon.Transaction_Get_Company_History_Recordsets(Seller_Comp_ID.ToString()))
				{
					Transaction_Error = "Get Seller Company Recordset";
					goto Abort_Fractional_Transaction;
				}

				strError = "get seller";
				// get the seller company business type
				if (!(modGlobalVars.snp_Company.BOF && modGlobalVars.snp_Company.EOF))
				{
					Seller_Company_Business_Type = Convert.ToString(modGlobalVars.snp_Company["comp_business_type"]);
					Seller_Company_Name = Convert.ToString(modGlobalVars.snp_Company["comp_name"]);
				}
				Seller_Company_Business_Type = cbo_Trans_Seller.Text.Substring(0, Math.Min(2, cbo_Trans_Seller.Text.Length));
				if (Strings.Len(Seller_Company_Business_Type.Trim()) == 0)
				{ //moved aey 7/19/04
					Seller_Company_Business_Type = "UI";
				}


				// ***************************************************************
				// IF THE PERCENTAGE OF THE BUYER IS 100% THEN THE CURRENT
				// AIRCRAFT WILL BE CHANGED TO WHOLLY OWNED, ELSE LEAVE FRACTIONAL
				strError = "Buyer info";

				Buyer_New_Percent = Conversion.Val($"{new_percent}").ToString(); //aey 6/21/04
				if (Conversion.Val(Buyer_New_Percent) == 100)
				{
					Buyer_Ownership_Type = "W";
				}
				else
				{
					Buyer_Ownership_Type = "F";
				}

				grd_Fractional.CurrentColumnIndex = 3;
				// *************************************************************************
				// GET A COMPLETE SNAPSHOT OF BUYER INFORMATION NOT AWAITING DOCUMENTATION
				Working_On("Selecting Copy of Buyer Information ...");
				if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
				{
					Buyer_Comp_ID = 0;
					Buyer_Contact_ID = 0;
					Buyer_Company_Name = "Awaiting Documentation";

				}
				else
				{
					Buyer_Comp_ID = Convert.ToInt32(Conversion.Val($"{Buyer_Comp_ID.ToString()}")); //aey 6/22/04
					Buyer_Contact_ID = Convert.ToInt32(Conversion.Val($"{Buyer_Contact_ID.ToString()}"));
					if (!modCommon.Aircraft_Buyer_Get_Recordset(Buyer_Comp_ID, Buyer_Contact_ID))
					{
						Transaction_Error = "Get Buyer Company Recordset";
						goto Abort_Fractional_Transaction;
					}

					// we know that we have a buyer recordset
					if (!(modGlobalVars.snp_Buyer_Company.BOF && modGlobalVars.snp_Buyer_Company.EOF))
					{
						modGlobalVars.snp_Buyer_Company.MoveFirst();

						Buyer_Fown_ID = Convert.ToInt32(Conversion.Val($"{Convert.ToString(modGlobalVars.snp_Buyer_Company["comp_fractowr_id"])}"));
						Buyer_Company_Name = Get_comp_name(Buyer_Comp_ID);
						Buyer_Company_Business_Type = $"{Convert.ToString(modGlobalVars.snp_Buyer_Company["comp_business_type"])}";
					}

				} // if awaiting documentation

				//aey 9/13/04 validate that buyer and seller companies have not changed
				// CHANGED - RTW = 2/1/2012 - CHANGED TO SELECT JUST COMP_ID INSTEAD OF *
				if (Buyer_Comp_ID > 0 && Buyer_Contact_ID == 0)
				{
					Query = "Select comp_id from company  ";
					Query = $"{Query} where comp_id ={Buyer_Comp_ID.ToString()}";
					Query = $"{Query} and comp_journ_id = 0 ";
					Query = $"{Query} and comp_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Buyer company - Please reselect", "Buyer Company was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}

				// CHANGED - RTW = 2/1/2012 - CHANGED TO SELECT JUST COMP_ID INSTEAD OF *
				if (Seller_Comp_ID > 0 && Seller_Contact_ID == 0)
				{
					Query = "Select comp_id from company  ";
					Query = $"{Query} where comp_id={Seller_Comp_ID.ToString()}";
					Query = $"{Query} and comp_journ_id = {MOD_Journal_ID.ToString()}";
					Query = $"{Query} and comp_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Seller company - Please reselect", "Buyer Companywas changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}

				//aey 9/10/04 validate that the buyer and seller contacts have not changed
				// CHANGED - RTW = 2/1/2012 - CHANGED TO SELECT JUST COMP_ID INSTEAD OF *
				if (Buyer_Comp_ID > 0 && Buyer_Contact_ID > 0)
				{
					Query = "Select contact_comp_id from contact ";
					Query = $"{Query}where contact_id={Buyer_Contact_ID.ToString()}";
					Query = $"{Query} and contact_comp_id={Buyer_Comp_ID.ToString()}";
					// added journ id to query - 2/1/2012
					Query = $"{Query} and contact_journ_id = {MOD_Journal_ID.ToString()}";
					Query = $"{Query} and contact_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Buyer company contact - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}

				// CHANGED - RTW = 2/1/2012 - CHANGED TO SELECT JUST COMP_ID INSTEAD OF *
				if (Seller_Comp_ID > 0 && Seller_Contact_ID > 0)
				{
					Query = "Select contact_comp_id from contact ";
					Query = $"{Query}where contact_id={Seller_Contact_ID.ToString()}";
					Query = $"{Query} and contact_comp_id={Seller_Comp_ID.ToString()}";
					// added journal id to query - 2/1/2012
					Query = $"{Query} and contact_journ_id = {MOD_Journal_ID.ToString()}";
					Query = $"{Query} and contact_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Seller company contact - Please reselect", "Seller Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}


				Buyer_Company_Business_Type = ($"{cbo_Trans_Buyer.Text}").Substring(0, Math.Min(2, ($"{cbo_Trans_Buyer.Text}").Length));

				Subject = modCommon.BuildJournalSubject($"{txt_Transaction_Type.Text}", 0, 0, 0, 0, $"{Seller_Company_Name}", $"{Buyer_Company_Name}");

				// *******************************************
				// GET A COMPLETE SNAPSHOT OF ALL AIRCRAFT INFORMATION
				strError = "A/C info";
				Working_On("Selecting Copy of Aircraft Information ...");
				if (!modCommon.Aircraft_History_Get_Recordsets(modAdminCommon.gbl_Aircraft_ID, Trans_Type, $"{Buyer_Comp_ID.ToString()},{Seller_Comp_ID.ToString()}"))
				{
					Transaction_Error = "Get Aircraft Recordset";
					goto Abort_Fractional_Transaction;
				}


				// ***************************************************
				// GET THE NEXT PC RECORD KEY
				strError = "Record Key";
				if (Transaction_Type.Substring(Math.Max(Transaction_Type.Length - 4, 0)) != "CORR")
				{
					PC_Record_Key = modCommon.Get_Next_PC_Record_Key();
					if (!(PC_Record_Key > 0))
					{
						Transaction_Error = "Get PC Record Key";
						goto Abort_Fractional_Transaction;
					}
				}
				else
				{
					PC_Record_Key = 0;
				}

				// GET THE FRACTIONAL OWNER ID OF THE SELLER
				Seller_Fown_ID = Convert.ToInt32(Conversion.Val($"{modCommon.Fractional_Owner(Seller_Comp_ID).ToString()}"));

				// GET THE NEXT FRACTIONAL OWNER ID
				// CHECK TO MAKE SURE THAT I HAVE A FRACTIONAL OWNER ID WHEN I NEED IT
				strError = "Frac Owner id";
				if (Buyer_Fown_ID == 0 || Seller_Fown_ID == 0)
				{
					Next_Fown_ID = modCommon.Get_Next_Fractional_Owner_ID();
					if (Next_Fown_ID == 0)
					{
						goto Fractional_Owner_ID_Error;
					}
				}

				// ******************************************************
				// GET THE NEXT FRACTIONAL SOLD ID
				strError = "Frac sold id";
				Fractional_Sold_ID = modCommon.Get_Next_Fractional_Sold_ID(Seller_Fown_ID);
				if (Fractional_Sold_ID == 0)
				{
					goto Fractional_Owner_ID_Error;
				}

				Add_To_Transmit_Field_List(" "); // add one element to the array

				// *******************************************************
				// WE NOW HAVE SELECTED EVERYTHING THAT WE NEED TO
				// BEGIN THE TRANSACTION.
				modAdminCommon.ADO_Transaction("BeginTrans");

				// *******************************************************
				// RECORD A JOURNAL ENTRY
				strError = "Journal Entry";
				Working_On("Creating Journal Entry ...");
				Journal_ID = Transaction_Insert_Journal_Entry(PC_Record_Key, txt_Transaction_Type.Text, ref Subject, Fractional_Sold_ID, 0, Seller_Fown_ID, SendtoWeb);
				if (Journal_ID == 0)
				{ // journal entry failed then exit
					Transaction_Error = "Error Inserting Journal";
					goto Abort_Fractional_Transaction;
				}

				// ************************************************
				// UPDATE FRACTIONAL OWNER INFORMATION FOR WINDOWS
				Working_On($"Updating Fractional Owner Data for {Seller_Company_Name} and {Buyer_Company_Name} ...");
				if (Buyer_Fown_ID == 0)
				{
					// if the buyer was not previously on the fractional owner list
					// then assign him an id and update his company to put him on the list
					Buyer_Fown_ID = Next_Fown_ID;
					Next_Fown_ID++;
					fquery = $"update company set comp_fractowr_id = {Buyer_Fown_ID.ToString()} ";
					fquery = $"{fquery}where comp_id={Buyer_Comp_ID.ToString()} and comp_journ_id=0";
					DbCommand TempCommand = null;
					TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
					TempCommand.CommandText = fquery;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
					TempCommand.ExecuteNonQuery();
					// store tramsmit for fractional owner add
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Fractional Owner", "Add", ref arr_Transmit_Fields, Buyer_Comp_ID);
				}
				else
				{
					// store transmit for fractional owner change
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Fractional Owner", "Change", ref arr_Transmit_Fields, Buyer_Comp_ID);
				}

				if (Seller_Fown_ID == 0)
				{
					// if the seller was not previously on the fractional owner list
					// then assign him an id and update his company to put him on the list
					Seller_Fown_ID = Next_Fown_ID;
					fquery = $"update company set comp_fractowr_id = {Seller_Fown_ID.ToString()} ";
					fquery = $"{fquery}where comp_id={Seller_Comp_ID.ToString()} and comp_journ_id=0";
					DbCommand TempCommand_2 = null;
					TempCommand_2 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_2);
					TempCommand_2.CommandText = fquery;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_2.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_2);
					TempCommand_2.ExecuteNonQuery();
					// store tramsmit for fractional owner
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Fractional Owner", "Add", ref arr_Transmit_Fields, Seller_Comp_ID);
				}
				else
				{
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Fractional Owner", "Change", ref arr_Transmit_Fields, Seller_Comp_ID);
				}


				//********************************************************
				// SAVE AIRCRAFT HISTORY COPY
				strError = "Storing A/C Hist";
				Working_On("Storing Aircraft Information Copy ...");
				if (!modCommon.Transaction_Save_Aircraft_History(Journal_ID, Transaction_Type, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, opt_Historical.Checked, modAdminCommon.Registration_no, SendtoWeb))
				{
					Transaction_Error = "Save Aircraft History";
					goto Abort_Fractional_Transaction;
				}


				//********************************************************
				// SAVE AIRCRAFT COMPANY HISTORY COPY
				// RTW - 3/5/2004 - EXTRA CHECK TO NOT SAVE CURRENT AC COMPANIES ON HISTORY TRANS
				if (!opt_Historical.Checked)
				{
					Working_On("Storing Aircraft Company Information Copies ...");
					if (!modCommon.Transaction_Save_Aircraft_Company_History(Journal_ID, modGlobalVars.snp_TransAircraft_Companies, modGlobalVars.snp_TransAircraft_Contacts, modGlobalVars.snp_TransAircraft_Company_Phones, modGlobalVars.snp_TransAircraft_Company_Btypes, modGlobalVars.snp_TransAircraft_Company_Certs, 0, SendtoWeb))
					{
						Transaction_Error = "Save Aircraft Company History";
						goto Abort_Fractional_Transaction;
					}
				}

				// *****************************************************
				// STORE TRANSMITS
				strError = "Transmits";
				Working_On("Recording Transaction Transmits ...");
				// store tramsmit for fractional owner sold
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, Journal_ID, gbl_ac_amod_id, "Fractional Sold", "Add", ref arr_Transmit_Fields, Seller_Comp_ID);
				// store a transmit for a normal aircraft transaction
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, Journal_ID, gbl_ac_amod_id, "Transaction", "Add", ref arr_Transmit_Fields);


				// *************************************************************
				// SAVE FRACTIONAL SELLER [Historic] row in 'Aircraft_Reference' table
				Working_On("Saving Fractional Seller Reference ...");
				//Call Remove_Aircraft_Reference(gbl_Aircraft_ID, 0, Seller_Comp_ID, Seller_Contact_ID, "69")
				if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Seller_Comp_ID, Seller_Company_Business_Type, Seller_Contact_ID, "69", Seller_Percentage, "N"))
				{
					Transaction_Error = "Save Seller Reference";
					goto Abort_Fractional_Transaction;
				} // if seller reference not added


				// SELLER COMPANY INFORMATION
				Working_On("Saving Fractional Seller Company ...");
				if (!modCommon.Transaction_Save_Company_History(Journal_ID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs, 0, SendtoWeb))
				{
					Transaction_Error = "Save Seller Company";
					goto Abort_Fractional_Transaction;
				} // if historical SELLER not saved

				// *********************************************************
				// SAVE THE BUYER INFORMATION IN A HISTORY RECORD
				Working_On("Saving Fractional Buyer Company Information...");

				if (!modCommon.Transaction_Save_Buyer_History(ref Buyer_Comp_ID, Journal_ID, Buyer_Contact_Type, modGlobalVars.snp_Buyer_Company, modGlobalVars.snp_Buyer_Contacts, modGlobalVars.snp_Buyer_Company_Phones, modGlobalVars.snp_Buyer_Company_Btypes, modGlobalVars.snp_Buyer_Company_Certs, Buyer_Fown_ID, SendtoWeb))
				{
					Transaction_Error = "Save Buyer Company";
					goto Abort_Fractional_Transaction;
				}

				//===================================================================
				// SAVE FRACTIONAL BUYER [Historic] row in 'Aircraft_Reference' table
				Working_On("Saving Fractional Buyer Reference ...");

				if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, "70", Buyer_Percentage, "N", 0, Fraction_Expires_Date))
				{
					Transaction_Error = "Save Buyer Reference";
					goto Abort_Fractional_Transaction;
				} // if buyer reference not added

				// ****************************************************
				// IF NOT A HISTORICAL TRANSACTION
				string tmp_poc_flag = "";
				int tmp_transmit_flag = 0; //aey 10/19/2004
				if (~((opt_Historical.Checked) ? -1 : 0) != 0)
				{

					strError = "Not Historical";
					// ******************************************************************
					// UPDATE THE CURRENT AIRCRAFT RECORD AND CLEAR THE APPROPRIATE REFERENCE RECORDS
					Working_On("Updating Current Aircraft Information ...");
					if (!Transaction_Update_Current_Aircraft_Record(modAdminCommon.gbl_Aircraft_ID, DateTime.Parse(txt_transaction_date.Text.Trim()), Buyer_Ownership_Type, 0))
					{
						Transaction_Error = "Update Current Aircraft";
						goto Abort_Fractional_Transaction;
					} // if update to the aircraft was successful

					Working_On("Restoring Current Aircraft References ...");

					// LOOK THROUGH THE GRID ROWS
					int tempForEndVar = grd_Fractional.RowsCount - 1;
					for (int Row = 1; Row <= tempForEndVar; Row++)
					{

						// *********************************************************
						// GET THE PERCENT CHANGE ASSOCIATED WITH THE TRANSACTION
						grd_Fractional.CurrentRowIndex = Row;

						// put a more detailed message to the screen
						grd_Fractional.CurrentColumnIndex = 0;
						Working_On($"Restoring Reference {grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim()} ...");
						grd_Fractional.CurrentColumnIndex = 3;
						change_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();

						if (Math.Abs(Conversion.Val(change_percent)) > 0)
						{ // GET PERCENTAGE FROM BUYER
							grd_Fractional.CurrentColumnIndex = 2;
							new_percent = Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim()).ToString();
						}
						else
						{
							// GET PERCENTAGE FROM SELLER
							grd_Fractional.CurrentColumnIndex = 1;
							new_percent = Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim()).ToString();
						}

						// LEAVE POC IF NEW PERCENTAGE IS NOT 0
						// OTHERWISE SET THE POC TO THE BUYER
						if ((Row == POC_Row) && (Double.Parse(new_percent) == 0))
						{
							POC_Row = Buyer_row;
						}

						// SAVE OWNERS BACK TO THE CURRENT AIRCRAFT FROM THE GRID
						if ((Conversion.Val(new_percent) > 0) || grid_Array_contact_type[Row] == "17")
						{
							// we have a percentage for this row, then save it
							if (grid_Array_contact_type[Row] == "17")
							{
								if (Exclusive_Flag)
								{
									if (grid_Array_comp_id[Row] == Exclusive_Comp_ID)
									{
										tmp_poc_flag = "X";
										tmp_transmit_flag = 1;
									}
									else
									{
										tmp_poc_flag = "Y";
										tmp_transmit_flag = 1;
									}
								}
								else
								{
									tmp_poc_flag = "Y";
									tmp_transmit_flag = 1;
								}
							}
							else
							{
								tmp_poc_flag = "N";
								tmp_transmit_flag = 99;
							}

							if (grid_Array_contact_type[Row].Trim() == "")
							{
								tmp_contact_type = "97";
								grid_Array_contact_type[Row] = tmp_contact_type;
							}
							else
							{
								tmp_contact_type = grid_Array_contact_type[Row].Trim();
							}

							Fraction_Expires_Date = "";

							grd_Fractional.CurrentColumnIndex = 4;

							// ASSIGN THE EXPIRATION DATE OF THE FRACTIONS
							if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer")
							{


								if (Seller_Fraction_Expires_Date.Trim() == "")
								{

									strTmpDate = DateTime.Parse(txt_transaction_date.Text.Trim()).ToString("d");
									dtTmpDate = DateTime.FromOADate(0);


									if (Buyer_Company_Business_Type != "PH")
									{



										switch(Seller_Comp_ID)
										{
											case 5033 :  //  Alpine Air, Inc   - 3 Year Contract 
												dtTmpDate = DateTime.Parse(strTmpDate).AddYears(3); 
												 
												break;
											case 11322 :  //  CitationAir   - 3 Year Contract 
												dtTmpDate = DateTime.Parse(strTmpDate).AddYears(3); 
												 
												break;
											case 284263 :  //  Executive Helishares Sales, LLC    - 3 Year Contract 
												dtTmpDate = DateTime.Parse(strTmpDate).AddYears(3); 
												 
												break;
											default:
												 
												dtTmpDate = DateTime.Parse(strTmpDate).AddYears(5); 
												 
												break;
										} // Case Seller_Comp_ID

										if (dtTmpDate != DateTime.FromOADate(0))
										{
											Fraction_Expires_Date = dtTmpDate.ToString("d");
										}

									}
									else
									{
										Fraction_Expires_Date = "";
									}

								}
								else
								{
									Fraction_Expires_Date = DateTime.Parse(Seller_Fraction_Expires_Date).ToString("d");
								} // If Trim(Seller_Fraction_Expires_Date & " ") = "" Then

							} // If grd_Fractional.Text = "Buyer" Then

							if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() != "Buyer" || (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer" && chk_Awaiting_Documentation.CheckState == CheckState.Unchecked))
							{
								if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() != "Buyer" || tmp_contact_type == "17")
								{
									if (grid_Array_fraction_expire_date[Row] != "")
									{
										Fraction_Expires_Date = DateTime.Parse(grid_Array_fraction_expire_date[Row]).ToString("d");
									}
								}

								if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, grid_Array_comp_id[Row], grid_Array_comp_Bus_Type[Row], grid_Array_contact_id[Row], tmp_contact_type, new_percent, tmp_poc_flag, tmp_transmit_flag, Fraction_Expires_Date))
								{
									Transaction_Error = "Save Fractional Owners from Grid";
									goto Abort_Fractional_Transaction;
								} //
							} // if not an awaiting documentation buyer
						} // if there was a percentage change indicating a important
					} // look for the next buyer

					// **********************************************************
					// SAVE BUYER REFERENCE FOR CURRENT AIRCRAFT IF AWAITING DOCS
					if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
					{
						if (Buyer_Company_Business_Type == "PH")
						{
							tmp_contact_type = "17";
							tmp_transmit_flag = 1;
							tmp_poc_flag = "Y";
						}
						else
						{
							tmp_contact_type = "97";
							tmp_transmit_flag = 99;
							tmp_poc_flag = "N";
						}

						if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, tmp_contact_type, Buyer_Percentage, tmp_poc_flag, tmp_transmit_flag))
						{
							Transaction_Error = "Save Awaiting Doc Fractional Owner";
							goto Abort_Fractional_Transaction;
						}
					} // if awaiting documentation then store the reference separately because its not in the grid
				} // not historical transaction


				// **************************************************************************
				// IF THE AIRCRAFT WAS AVAILABLE AND NOW ISN'T THEN RECORD A DELETE AVAILABLE TRANSMIT
				strError = "Avail 1";

				if (Prior_Availability && Clear_Availability)
				{
					strError = "Avail 1B";
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Delete", ref arr_Transmit_Fields);
				}

				// **************************************************************************
				// IF THE AIRCRAFT IS NOW AVAILABLE AND WASN'T PRIOR TO THE TRANSACTION
				// THEN RECORD AN ADD AVAILABLE TRANSMIT
				strError = "Avail 2";

				if (!Clear_Availability && !Prior_Availability && opt_Current.Checked)
				{
					strError = "Avail 2B";

					string tempRefParam = "On Market";
					if (Transaction_Insert_Journal_Entry(Journal_ID + 1, "MA", ref tempRefParam, 0, 0) == 0)
					{
						strError = "Avail 2C";
						Transaction_Error = "Insert On Market Journal Entry";
						goto Abort_Fractional_Transaction;
					}
					strError = "Avail 2D";
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Add", ref arr_Transmit_Fields);
				}

				// *******************************************************
				// ALL PROCESSING COMPLETE - COMMIT THE TRANSACTION
				modAdminCommon.ADO_Transaction("CommitTrans");

				strError = "end trans";
				Working_Off();
				result = true;
				modCommon.Aircraft_History_Close_Recordsets();

				return result;

				Abort_Fractional_Transaction:
				strError = $"{Information.Err().Description} {strError} tt:{txt_Transaction_Type.Text} te:{Transaction_Error}";

				modAdminCommon.ADO_Transaction("Rollback");
				modCommon.Aircraft_History_Close_Recordsets();
				result = false;
				Working_Off();

				modAdminCommon.Report_Error($"Transaction_Save_Fractional_Aircraft_Sale_Error A: {strError}");

				return result;

				Fractional_Owner_ID_Error:

				// 10/11/2002 - By David D. Cruger; Hold These Error Values As the RollbackTrans will clear them
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lError = Information.Err().Number;
				strError = $"{Information.Err().Description} {strError} tt:{txt_Transaction_Type.Text} te:{Transaction_Error}";

				modAdminCommon.ADO_Transaction("Rollback");
				result = false;
				Working_Off();

				// 10/11/2002 - By David D. Cruger; Add the Held Error Values to the Report_Error Procedure
				Information.Err().Number = lError;
				Information.Err().Description = strError;
				modAdminCommon.Report_Error($"Transaction_Save_Fractional_Aircraft_Sale_Error O: Error Assigning Next Fractional Owner or Sold ID {strError}");

				return result;
			}
			catch (System.Exception excep)
			{

				// 10/11/2002 - By David D. Cruger; Hold These Error Values As the RollbackTrans will clear them
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lError = Information.Err().Number;
				strError = $"{excep.Message} {strError} tt:{txt_Transaction_Type.Text} te:{Transaction_Error}";

				modAdminCommon.ADO_Transaction("Rollback");
				result = false;
				Working_Off();

				// 10/11/2002 - By David D. Cruger; Add the Held Error Values to the Report_Error Procedure
				Information.Err().Number = lError;
				Information.Err().Description = strError;
				modAdminCommon.Report_Error($"Transaction_Save_Fractional_Aircraft_Sale_Error S: {strError}");

				return result;
			}
		}

		public bool Transaction_Save_Aircraft_Lease()
		{

			bool result = false;
			int lError = 0;
			string strError = "";
			try
			{

				result = false;

				string Transaction_Error = ""; // String used to identify failed transactions
				string Query = "";
				string Subject = ""; // subject for the journal
				string Ttype = ""; // transaction type from the grid // Row of the grid currently being worked on
				int PC_Record_Key = 0;
				int Fractional_Sold_ID = 0;

				// Seller variables
				string Seller_new_contact_type = "";

				// buyer variables
				int Buyer_row = 0;

				string Buyer_new_contact_type = "";

				string POC_Flag = "";
				string change_percent = "";
				string new_percent = "";
				ADORecordSetHelper ado_lease = new ADORecordSetHelper(); // recordset for adding the leas
				string Lessor_Comp_Name = ""; // Name of the company lessor
				string Lessee_Comp_Name = ""; // Name of company leasing
				 // Hold The Error Number Value // Hold The Error Description Value
				bool SendtoWeb = false; //aey 7/28/04

				Working_On("Saving Aircraft Lease Transaction ...");

				SendtoWeb = modCommon.GetTransWeb(Transaction_Type);


				// ***************************************************************
				// LOCATE THE LESSOR IN THE GRID
				if (!opt_Historical.Checked)
				{ // not historical, get buyer/seller from grid
					int tempForEndVar = grd_Fractional.RowsCount - 1;
					for (int Grid_Row = 1; Grid_Row <= tempForEndVar; Grid_Row++)
					{
						grd_Fractional.CurrentRowIndex = Grid_Row;
						grd_Fractional.CurrentColumnIndex = 3;
						// get the lessor percentage from the grid - this is important to verify
						// since there may be more than one lessor only the one specifically selected
						// with -100 is part of the current lease transaction
						Seller_Percentage = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString();
						grd_Fractional.CurrentColumnIndex = 4;
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessor" && Math.Abs(Conversion.Val(Seller_Percentage)) == 100)
						{
							Seller_Comp_ID = grid_Array_comp_id[Grid_Row];
							Lessor_Comp_Name = Get_comp_name(Seller_Comp_ID);
							Lessor_Comp_Name_1 = Lessor_Comp_Name;
							Seller_Contact_ID = grid_Array_contact_id[Grid_Row];
							Seller_Contact_Type = grid_Array_contact_type[Grid_Row];
							grd_Fractional.CurrentColumnIndex = 3;

							// ******************************************************************
							// ASSIGN THE NEW LESSOR AND LESSEE TYPES
							switch(Seller_Contact_Type)
							{
								case "97" : case "00" : case "13" :  // Owner 
									Seller_new_contact_type = "13";  //Owner - Lessor' [55] 
									Buyer_new_contact_type = "12";  // Lessee 
									break;
								case "12" : case "39" :  // Lessee 
									Seller_new_contact_type = "57";  // Sublessor' [57] 
									Buyer_new_contact_type = "39";  // SubLessee 
									break;
								default:
									Seller_new_contact_type = "13"; 
									Buyer_new_contact_type = "12";  // Lessee 
									break;
							}
							break; // EXIT THE GRID WHEN YOU FIND THE LESSOR
						}
					} // LOOP TO FIND
				}
				else
				{
					// do this if historical lease
					Seller_new_contact_type = "13";
					Lessor_Comp_Name = Get_comp_name(Seller_Comp_ID);
					Buyer_new_contact_type = "12"; // Lessee
				}

				// *******************************************
				// GET A SNAPSHOT OF Company Information
				Working_On("Selecting Seller Company History ...");
				if (!modCommon.Transaction_Get_Company_History_Recordsets(Seller_Comp_ID.ToString()))
				{
					Transaction_Error = "Get Seller Company Recordset";
					goto Abort_Lease_Transaction;
				}

				// get the seller company business type
				Transaction_Error = "Get Seller Business Type";
				Seller_Company_Business_Type = cbo_Trans_Seller.Text.Substring(0, Math.Min(2, cbo_Trans_Seller.Text.Length));
				// **********************************************
				// LOCATE THE LESSEE IN THE GRID
				Transaction_Error = "Locate The Lessee In Grid";

				// *************************************************************************
				// GET A COMPLETE SNAPSHOT OF BUYER INFORMATION NOT AWAITING DOCUMENTATION
				Transaction_Error = "Get Complete SnapShot of Buyer";
				if (Buyer_Comp_ID == 0)
				{
					Buyer_Contact_ID = 0;
					Lessee_Comp_Name = "Awaiting Documentation";
					Lessee_Comp_Name_1 = Lessee_Comp_Name;
				}
				else
				{

					Transaction_Error = "Aircraft Buyer Get Recordset";
					if (!modCommon.Aircraft_Buyer_Get_Recordset(Buyer_Comp_ID, Buyer_Contact_ID))
					{
						Transaction_Error = "Get Buyer Company Recordset";
						goto Abort_Lease_Transaction;
					}

					// we know that we have a buyer recordset
					Transaction_Error = "Check Buyer Recordset";
					if (!(modGlobalVars.snp_Buyer_Company.BOF && modGlobalVars.snp_Buyer_Company.EOF))
					{
						modGlobalVars.snp_Buyer_Company.MoveFirst();
						Lessee_Comp_Name = Convert.ToString(modGlobalVars.snp_Buyer_Company["comp_name"]);
						Lessee_Comp_Name_1 = Lessee_Comp_Name;
					}

				} // if awaiting documentation

				//aey 9/13/04 validate that buyer and seller companies have not changed
				// RTW - CHANGED - 2/1/2012 - CHANGED TO SELECT COMP ID INSTEAD OF *
				// AND TO USE THE JOURNAL ID IN CONTACT RELATED QUERIES
				if (Buyer_Comp_ID > 0 && Buyer_Contact_ID == 0)
				{
					Query = "Select comp_id from company WITH(NOLOCK)";
					Query = $"{Query} where comp_id={Buyer_Comp_ID.ToString()}";
					Query = $"{Query} and comp_journ_id =  0 ";
					Query = $"{Query} and comp_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Buyer company - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}

				if (Seller_Comp_ID > 0 && Seller_Contact_ID == 0)
				{
					Query = "Select comp_id from company WITH(NOLOCK)";
					Query = $"{Query} where comp_id={Seller_Comp_ID.ToString()}";
					Query = $"{Query} and comp_journ_id = {MOD_Journal_ID.ToString()}";
					Query = $"{Query} and comp_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Seller company - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}


				//9/10/04 validation to insure that buyer or seller has not changed
				if (Buyer_Comp_ID > 0 && Buyer_Contact_ID > 0)
				{
					Query = "Select contact_comp_id from contact WITH(NOLOCK)";
					Query = $"{Query} where contact_id={Buyer_Contact_ID.ToString()}";
					Query = $"{Query} and contact_comp_id={Buyer_Comp_ID.ToString()}";
					Query = $"{Query} and contact_journ_id = {MOD_Journal_ID.ToString()}";
					Query = $"{Query} and contact_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Buyer company contact - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}

				if (Seller_Comp_ID > 0 && Seller_Contact_ID > 0)
				{
					Query = "Select contact_comp_id from contact WITH(NOLOCK)";
					Query = $"{Query} where contact_id={Seller_Contact_ID.ToString()}";
					Query = $"{Query} and contact_comp_id={Seller_Comp_ID.ToString()}";
					Query = $"{Query} and contact_journ_id = {MOD_Journal_ID.ToString()}";
					Query = $"{Query} and contact_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Seller company contact - Please reselect", "Seller Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}

				Buyer_Company_Business_Type = cbo_Trans_Buyer.Text.Substring(0, Math.Min(2, cbo_Trans_Buyer.Text.Length));
				// *******************************************
				// GET A COMPLETE SNAPSHOT OF ALL AIRCRAFT INFORMATION
				if (!modCommon.Aircraft_History_Get_Recordsets(modAdminCommon.gbl_Aircraft_ID, Trans_Type, $"{Buyer_Comp_ID.ToString()},{Seller_Comp_ID.ToString()}"))
				{
					Transaction_Error = "Get Aircraft Recordset";
					goto Abort_Lease_Transaction;
				}

				// *************************************************************
				// IDENTIFY THE JOURNAL SUBJET
				Subject = modCommon.BuildJournalSubject(Transaction_Type, 0, 0, 0, 0, Lessor_Comp_Name, Lessee_Comp_Name);


				// ***************************************************
				// GET THE NEXT PC RECORD KEY
				if (Transaction_Type.Substring(Math.Max(Transaction_Type.Length - 4, 0)) != "CORR")
				{
					PC_Record_Key = modCommon.Get_Next_PC_Record_Key();
					if (!(PC_Record_Key > 0))
					{
						Transaction_Error = "Get PC Record Key";
						goto Abort_Lease_Transaction;
					}
				}
				else
				{
					PC_Record_Key = 0;
				}

				Fractional_Sold_ID = 0;

				modAdminCommon.ADO_Transaction("BeginTrans");

				// *******************************************************
				// RECORD A JOURNAL ENTRY
				Transaction_Error = "Creating Journal Entry";
				Working_On("Creating Journal Entry ...");
				Journal_ID = Transaction_Insert_Journal_Entry(PC_Record_Key, txt_Transaction_Type.Text, ref Subject, Fractional_Sold_ID, 0, 0);
				if (Journal_ID == 0)
				{ // journal entry failed then exit
					Transaction_Error = "Insert Journal Entry";
					goto Abort_Lease_Transaction;
				}


				//********************************************************
				// SAVE AIRCRAFT HISTORY COPY
				Transaction_Error = "Storing Aircraft Information Copy";
				Working_On("Storing Aircraft Information Copy ...");
				if (!modCommon.Transaction_Save_Aircraft_History(Journal_ID, Transaction_Type, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, opt_Historical.Checked, modAdminCommon.Registration_no, SendtoWeb))
				{
					Transaction_Error = "Store Aircraft History";
					goto Abort_Lease_Transaction;
				}

				if (!opt_Historical.Checked)
				{ // if not historical

					//********************************************************
					// SAVE AIRCRAFT COMPANY HISTORY COPY
					Transaction_Error = "Storing Aircraft Company History Copy";
					Working_On("Storing Aircraft Company History Copy ...");
					if (!modCommon.Transaction_Save_Aircraft_Company_History(Journal_ID, modGlobalVars.snp_TransAircraft_Companies, modGlobalVars.snp_TransAircraft_Contacts, modGlobalVars.snp_TransAircraft_Company_Phones, modGlobalVars.snp_TransAircraft_Company_Btypes, modGlobalVars.snp_TransAircraft_Company_Certs, 0, SendtoWeb))
					{
						Transaction_Error = "Get Aircraft Company History";
						goto Abort_Lease_Transaction;
					}
				}

				//***********************************************************
				// SAVE LESSOR REFERENCE RECORD COPY
				Transaction_Error = "Saving Lessor Reference Copy";
				Working_On("Saving Lessor Reference Copy ...");
				if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Seller_Comp_ID, cbo_Trans_Seller.Text.Substring(0, Math.Min(2, cbo_Trans_Seller.Text.Length)), Seller_Contact_ID, Seller_new_contact_type, "0", "N", 1))
				{
					Transaction_Error = "Store Lessor Reference";
					goto Abort_Lease_Transaction;
				}

				// SAVE THE LESSOR COMPANY HISTORY
				Transaction_Error = "Save Company History";
				if (!modCommon.Transaction_Save_Company_History(Journal_ID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs, 0, SendtoWeb))
				{
					Transaction_Error = "Store Lessor Company";
					goto Abort_Lease_Transaction;
				}

				//*******************************************************************************
				// SAVE BUYER COMPANY HISTORY - IF AWAITING DOCUMENTATION - PASS BUYER COMP ID = 0
				// CHANGED MSW 4/25/2014 - fix to create awaiting doc company with 12 as the comp business type
				Transaction_Error = "Save Buyer History";
				//If Not Transaction_Save_Buyer_History(Buyer_Comp_ID, Journal_ID, Buyer_new_contact_type, snp_Buyer_Company, snp_Buyer_Contacts, snp_Buyer_Company_Phones, snp_Buyer_Company_Btypes, snp_Buyer_Company_Certs, , SendtoWeb) Then
				if (!modCommon.Transaction_Save_Buyer_History(ref Buyer_Comp_ID, Journal_ID, Buyer_Company_Business_Type, modGlobalVars.snp_Buyer_Company, modGlobalVars.snp_Buyer_Contacts, modGlobalVars.snp_Buyer_Company_Phones, modGlobalVars.snp_Buyer_Company_Btypes, modGlobalVars.snp_Buyer_Company_Certs, 0, SendtoWeb))
				{

					Transaction_Error = "Store Lessee Company History";
					goto Abort_Lease_Transaction;
				}

				//********************************************************
				// SAVE LESSEE REFERENCE RECORD
				Transaction_Error = "Saving Lessee Reference Copy";
				Working_On("Saving Lessee Reference Copy ...");
				if (Buyer_Comp_ID > 0)
				{
					if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, Buyer_new_contact_type, "0.0", "N", 10))
					{
						Transaction_Error = "Store Lessee Reference";
						goto Abort_Lease_Transaction;
					}
				}




				if (~((opt_Historical.Checked) ? -1 : 0) != 0)
				{

					// ******************************************************************
					// UPDATE THE CURRENT AIRCRAFT RECORD AND CLEAR THE APPROPRIATE REFERENCE RECORDS
					Transaction_Error = "Updating Current Aircraft Information";
					Working_On("Updating Current Aircraft Information ...");
					if (!Transaction_Update_Current_Aircraft_Record(modAdminCommon.gbl_Aircraft_ID, DateTime.Parse(txt_transaction_date.Text.Trim()), "", 0))
					{
						Transaction_Error = "Update Current Aircraft";
						goto Abort_Lease_Transaction;
					} // if update to the aircraft was successful

					Transaction_Error = "Restoring Current Aircraft References";
					Working_On("Restoring Current Aircraft References ...");
					int tempForEndVar2 = grd_Fractional.RowsCount - 1;
					for (int Grid_Row = 1; Grid_Row <= tempForEndVar2; Grid_Row++)
					{
						grd_Fractional.CurrentRowIndex = Grid_Row;
						grd_Fractional.CurrentColumnIndex = 3;
						change_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
						if (Strings.Len(change_percent) > 0)
						{
							grd_Fractional.CurrentColumnIndex = 2;
							new_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
						}
						else
						{
							grd_Fractional.CurrentColumnIndex = 1;
							new_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
						}

						if (Grid_Row == POC_Row)
						{
							if (Double.Parse(($"0{new_percent}").Trim()) == 0)
							{
								POC_Row = Buyer_row;
							}
						}
					}


					Transaction_Error = "Store Lessor And Lessee From Grid";
					int tempForEndVar3 = grd_Fractional.RowsCount - 1;
					for (int Grid_Row = 1; Grid_Row <= tempForEndVar3; Grid_Row++)
					{
						grd_Fractional.CurrentRowIndex = Grid_Row;
						grd_Fractional.CurrentColumnIndex = 3;
						change_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
						if (Strings.Len(change_percent) > 0)
						{
							grd_Fractional.CurrentColumnIndex = 2;
							new_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
						}
						else
						{
							grd_Fractional.CurrentColumnIndex = 1;
							new_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
						}
						// *********************************************
						// STORE THE LESSOR REFERENCE
						grd_Fractional.CurrentColumnIndex = 4;
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessor" && Math.Abs(Conversion.Val(Seller_Percentage)) == 100)
						{
							POC_Flag = "N";

							Transaction_Error = "Seller_Buyer_Insert, Store Current Lessor Reference";
							if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Seller_Comp_ID, Seller_Company_Business_Type, Seller_Contact_ID, Seller_new_contact_type, "0.0", POC_Flag))
							{
								Transaction_Error = "Store Current Lessor Reference";
								goto Abort_Lease_Transaction;
							}
						} // if lessor

						// **********************************************
						// STORE THE LESSEE REFERENCE
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Lessee")
						{
							if (chk_Awaiting_Documentation.CheckState == CheckState.Unchecked)
							{
								Transaction_Error = "Store The Lessee Reference";

								Query = "UPDATE Aircraft_Reference set cref_transmit_seq_no=99 ";
								Query = $"{Query}where cref_ac_id={modAdminCommon.gbl_Aircraft_ID.ToString()} ";
								Query = $"{Query}and cref_journ_id=0 ";
								Query = $"{Query}and cref_transmit_seq_no=2";
								DbCommand TempCommand = null;
								TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
								UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
								TempCommand.CommandText = Query;
								//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
								//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
								TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
								UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
								TempCommand.ExecuteNonQuery();

								if (Aircraft_Exclusive && !Clear_Availability)
								{
									POC_Flag = "X";
								}
								else
								{
									POC_Flag = "Y";
								}

								Transaction_Error = "Seller Buyer Insert, Store Current Lessee Reference";
								if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, Buyer_new_contact_type, "0.0", POC_Flag, 2))
								{
									Transaction_Error = "Store Current Lessee Reference";
									goto Abort_Lease_Transaction;
								} //
							} // if not awaiting documentation
						} // if the lessee
					}

					if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
					{
						POC_Flag = "Y";

						if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, Buyer_new_contact_type, Buyer_Percentage, POC_Flag, 99))
						{
							Transaction_Error = "Save Awaiting Doc Lessee";
							goto Abort_Lease_Transaction;
						}
					}


				} // if not historical
				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Store 'Aircraft_Lease' table Grid_Row
				Transaction_Error = "Store Aircraft Lease Table Grid Row";
				ado_lease.ActiveConnection = modAdminCommon.ADODB_Trans_conn;
				ado_lease.CursorType = CursorTypeEnum.adOpenDynamic;
				ado_lease.LockType = UpgradeHelpers.DB.LockTypeEnum.LockOptimistic;
				ado_lease.Open("Aircraft_Lease", UpgradeHelpers.DB.LockTypeEnum.LockUnspecified, StringParameterType.Source);
				//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adAddNew was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_lease.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
				if (ado_lease.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadAddNew()))
				{
					ado_lease.AddNew();
					ado_lease["aclease_ac_id"] = modAdminCommon.gbl_Aircraft_ID;
					ado_lease["aclease_journ_id"] = Journal_ID;
					if (Strings.Len(txt_lease_type.Text.Trim()) > 0)
					{
						ado_lease["aclease_type"] = txt_lease_type.Text.Trim();
					}
					if (Strings.Len(txt_lease_term.Text.Trim()) > 0)
					{
						ado_lease["aclease_term"] = txt_lease_term.Text.Trim();
					}
					if (Strings.Len(txt_lease_expiration_date.Text.Trim()) > 0)
					{
						ado_lease["aclease_expiration_date"] = txt_lease_expiration_date.Text.Trim();
					}
					if (opt_Historical.Checked)
					{
						ado_lease["aclease_expired"] = "Y";
					}
					else
					{
						ado_lease["aclease_expired"] = "N";
					}
					if (Strings.Len(txt_lease_notes.Text.Trim()) > 0)
					{
						ado_lease["aclease_note"] = txt_lease_notes.Text.Trim();
					}
					ado_lease.Update();
				}
				if (ado_lease.State == ConnectionState.Open)
				{
					ado_lease.Close();
				}
				ado_lease = null;

				// ***********************************************
				// SAVE LEASE TRANSMIT RECORDS
				Working_On("Saving Aircraft Lease Transmits ...");

				Transaction_Error = "Saving Aircraft Lease Transmits";
				Add_To_Transmit_Field_List(" ");
				// record a share sale transmit
				Transaction_Error = "Saving Aircraft Transaction Add Transmits";
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, Journal_ID, gbl_ac_amod_id, "Transaction", "Add", ref arr_Transmit_Fields);
				// record a transmit change to the current aircraft
				Transaction_Error = "Saving Aircraft Change Transmits";

				if (!opt_Historical.Checked)
				{ //aey 2/10/05 do not write for historical
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Aircraft", "Change", ref arr_Transmit_Fields);
				}
				if (Ttype.StartsWith("LA", StringComparison.Ordinal))
				{ // if leased and still available for sale then we must transmit an available change
					Transaction_Error = "Saving Available Aircraft Change Transmits";
					if (!opt_Historical.Checked)
					{ //aey 2/10/05 do not write for historical
						modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Change", ref arr_Transmit_Fields);
					}
				}

				// **************************************************************************
				// IF THE AIRCRAFT WAS AVAILABLE AND NOW ISN'T THEN RECORD A DELETE AVAILABLE TRANSMIT

				if (Prior_Availability && Clear_Availability)
				{
					Transaction_Error = "Saving Available Aircraft Delete Transmits";
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Delete", ref arr_Transmit_Fields);
				}

				result = true;
				Working_Off();
				// *******************************************************
				// ALL PROCESSING COMPLETE - COMMIT THE TRANSACTION
				modAdminCommon.ADO_Transaction("CommitTrans");
				Working_Off();
				result = true;
				modCommon.Aircraft_History_Close_Recordsets();


				Application.DoEvents();
				Application.DoEvents();
				Application.DoEvents();


				return result;

				Abort_Lease_Transaction:

				// 10/11/2002 - By David D. Cruger; Hold These Error Values As the RollbackTrans will clear them
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lError = Information.Err().Number;
				strError = Information.Err().Description;

				modAdminCommon.ADO_Transaction("RollbackTrans");
				modCommon.Aircraft_History_Close_Recordsets();
				result = false;
				Working_Off();

				// 10/11/2002 - By David D. Cruger; Add the Held Error Values to the Report_Error Procedure
				Information.Err().Number = lError;
				Information.Err().Description = strError;
				modAdminCommon.Report_Error($"Transaction_Save_Aircraft_Lease_Error: {Transaction_Error}");

				return result;
			}
			catch (System.Exception excep)
			{

				// 10/11/2002 - By David D. Cruger; Hold These Error Values As the RollbackTrans will clear them
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lError = Information.Err().Number;
				strError = excep.Message;

				modAdminCommon.ADO_Transaction("RollbackTrans");
				result = false;
				Working_Off();

				Information.Err().Number = lError;
				Information.Err().Description = strError;
				modAdminCommon.Report_Error($"Transaction_Save_Aircraft_Lease_Error: {excep.Message}");

				return result;
			}
		}


		public bool Transaction_Save_Aircraft_Share()
		{



			bool result = false;
			int lError = 0;
			string strError = "";
			try
			{

				string Transaction_Error = ""; // string used to store error description
				int PC_Record_Key = 0;
				int Fractional_Sold_ID = 0;

				// SELLER VARIABLES

				// BUYER VARIABLES
				int Buyer_row = 0;
				string Buyer_New_Percent = "";

				string Buyer_Ownership_Type = "";

				string change_percent = "";
				string new_percent = "";
				string Subject = "";
				 // Hold The Error Number Value // Hold The Error Description Value
				bool SendtoWeb = false; //aey 7/28/04
				string Query = "";

				Working_On("Saving Aircraft Share Sale ...");

				SendtoWeb = modCommon.GetTransWeb(Transaction_Type);

				// *******************************************
				// GET A SNAPSHOT OF Company Information
				Working_On("Selecting Seller Company History ...");
				if (!modCommon.Transaction_Get_Company_History_Recordsets(Seller_Comp_ID.ToString()))
				{
					Transaction_Error = "Get Seller Company History";
					goto Abort_Share_Transaction;
				}

				Seller_Company_Business_Type = cbo_Trans_Seller.Text.Substring(0, Math.Min(2, cbo_Trans_Seller.Text.Length));

				// *************************************************************************
				// GET A COMPLETE SNAPSHOT OF BUYER INFORMATION NOT AWAITING DOCUMENTATION
				if (Buyer_Comp_ID == 0)
				{
					Buyer_Contact_ID = 0;
					Buyer_Comp_Name = "Awaiting Documentation";
					Buyer_Company_Business_Type = cbo_Trans_Buyer.Text.Substring(0, Math.Min(2, cbo_Trans_Buyer.Text.Length));

				}
				else
				{
					if (!modCommon.Aircraft_Buyer_Get_Recordset(Buyer_Comp_ID, Buyer_Contact_ID))
					{
						Transaction_Error = "Get Buyer Company History";
						goto Abort_Share_Transaction;
					}

					// we know that we have a buyer recordset
					if (!(modGlobalVars.snp_Buyer_Company.BOF && modGlobalVars.snp_Buyer_Company.EOF))
					{
						modGlobalVars.snp_Buyer_Company.MoveFirst();
						Buyer_Comp_Name = Convert.ToString(modGlobalVars.snp_Buyer_Company["comp_name"]);
						if (Strings.Len(Buyer_Company_Business_Type.Trim()) == 0)
						{
							Buyer_Company_Business_Type = "UI";
						}
					}
					Buyer_Company_Business_Type = cbo_Trans_Buyer.Text.Substring(0, Math.Min(2, cbo_Trans_Buyer.Text.Length));
				} // if awaiting documentation

				// *******************************************
				// GET A COMPLETE SNAPSHOT OF ALL AIRCRAFT INFORMATION
				if (!modCommon.Aircraft_History_Get_Recordsets(modAdminCommon.gbl_Aircraft_ID, Trans_Type, $"{Buyer_Comp_ID.ToString()},{Seller_Comp_ID.ToString()}"))
				{
					Transaction_Error = "Get Aircraft History";
					goto Abort_Share_Transaction;
				}

				// ****************************************************
				// IDENTIFY THE SUBJECT LINE OF THE TRANSACTION/JOURNAL ENTRY
				Subject = modCommon.BuildJournalSubject(txt_Transaction_Type.Text, 0, 0, 0, 0, Seller_Comp_Name, Buyer_Comp_Name);

				// ***************************************************
				// GET THE NEXT PC RECORD KEY
				if (Transaction_Type.Substring(Math.Max(Transaction_Type.Length - 4, 0)) != "CORR")
				{
					PC_Record_Key = modCommon.Get_Next_PC_Record_Key();
					if (!(PC_Record_Key > 0))
					{
						Transaction_Error = "Get PC Record Key";
						goto Abort_Share_Transaction;
					}
				}
				else
				{
					PC_Record_Key = 0;
				}

				//aey 9/13/04 validate that buyer and seller companies have not changed
				// RTW - CHANGED - 2/1/2012 - TO USE COMP_id INSTEAD OF *
				// AND TO USE JOURN ID ON CONTACT QUERIES
				if (Buyer_Comp_ID > 0 && Buyer_Contact_ID == 0)
				{
					Query = "Select comp_id from company WITH(NOLOCK)";
					Query = $"{Query} where comp_id={Buyer_Comp_ID.ToString()}";
					Query = $"{Query} and comp_journ_id = 0 ";
					Query = $"{Query} and comp_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Buyer company - Please reselect", "Buyer Company was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}

				if (Seller_Comp_ID > 0 && Seller_Contact_ID == 0)
				{
					Query = "Select comp_id from company WITH(NOLOCK)";
					Query = $"{Query} where comp_id={Seller_Comp_ID.ToString()}";
					Query = $"{Query} and comp_journ_id = {MOD_Journal_ID.ToString()}";
					Query = $"{Query} and comp_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Seller company - Please reselect", "Buyer Company was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}

				//9/10/04 validation to insure that buyer or seller has not changed
				if (Buyer_Comp_ID > 0 && Buyer_Contact_ID > 0)
				{
					Query = "Select contact_comp_id from contact WITH(NOLOCK)";
					Query = $"{Query}where contact_id={Buyer_Contact_ID.ToString()}";
					Query = $"{Query} and contact_comp_id={Buyer_Comp_ID.ToString()}";
					Query = $"{Query} and contact_journ_id = {MOD_Journal_ID.ToString()}";
					Query = $"{Query} and contact_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Buyer company contact - Please reselect", "Buyer Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}
				if (Seller_Comp_ID > 0 && Seller_Contact_ID > 0)
				{
					Query = "Select contact_comp_id from contact WITH(NOLOCK)";
					Query = $"{Query}where contact_id={Seller_Contact_ID.ToString()}";
					Query = $"{Query} and contact_comp_id={Seller_Comp_ID.ToString()}";
					Query = $"{Query} and contact_journ_id = {MOD_Journal_ID.ToString()}";
					Query = $"{Query} and contact_active_flag='Y' ";
					if (!modAdminCommon.Exist(Query))
					{
						MessageBox.Show("Someone has changed the Seller company contact - Please reselect", "Seller Contact was changed", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw new Exception();
					}
				}

				// ******************************************************
				// CLEAR THE NEXT FRACTIONAL SOLD ID
				Fractional_Sold_ID = 0;

				// *******************************************************
				// WE NOW HAVE SELECTED EVERYTHING THAT WE NEED TO
				// BEGIN THE TRANSACTION.
				modAdminCommon.ADO_Transaction("BeginTrans");

				// *******************************************************
				// RECORD A JOURNAL ENTRY
				Working_On("Creating Journal Entry ...");
				Journal_ID = Transaction_Insert_Journal_Entry(PC_Record_Key, txt_Transaction_Type.Text, ref Subject, Fractional_Sold_ID, 0, 0);
				if (Journal_ID == 0)
				{ // journal entry failed then exit
					Transaction_Error = "Insert Journal Entry";
					goto Abort_Share_Transaction;
				}

				//*******************************************************************************
				// SAVE SHARE BUYER COMPANY HISTORY - IF AWAITING DOCUMENTATION - PASS BUYER COMP ID = 0
				if (!modCommon.Transaction_Save_Buyer_History(ref Buyer_Comp_ID, Journal_ID, Buyer_Company_Business_Type, modGlobalVars.snp_Buyer_Company, modGlobalVars.snp_Buyer_Contacts, modGlobalVars.snp_Buyer_Company_Phones, modGlobalVars.snp_Buyer_Company_Btypes, modGlobalVars.snp_Buyer_Company_Certs, 0, SendtoWeb))
				{
					Transaction_Error = "Save Buyer Company History";
					goto Abort_Share_Transaction;
				}

				//********************************************************
				// SAVE AIRCRAFT HISTORY COPY
				Working_On("Storing Aircraft Information Copy ...");
				if (!modCommon.Transaction_Save_Aircraft_History(Journal_ID, Transaction_Type, modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, opt_Historical.Checked, modAdminCommon.Registration_no, SendtoWeb))
				{
					Transaction_Error = "Store Aircraft History";
					goto Abort_Share_Transaction;
				}

				//********************************************************
				// SAVE AIRCRAFT COMPANY HISTORY COPY
				// RTW - 3/5/2004 - EXTRA CHECK TO NOT SAVE CURRENT AC COMPANIES ON HISTORY TRANS
				if (!opt_Historical.Checked)
				{
					Working_On("Storing Aircraft Company Information Copy ...");
					if (!modCommon.Transaction_Save_Aircraft_Company_History(Journal_ID, modGlobalVars.snp_TransAircraft_Companies, modGlobalVars.snp_TransAircraft_Contacts, modGlobalVars.snp_TransAircraft_Company_Phones, modGlobalVars.snp_TransAircraft_Company_Btypes, modGlobalVars.snp_TransAircraft_Company_Certs, 0, SendtoWeb))
					{
						Transaction_Error = "Get Aircraft Company History";
						goto Abort_Share_Transaction;
					}
				}

				//***********************************************************
				// SAVE SHARE SELLER REFERENCE RECORD COPY
				Working_On("Saving Seller Reference Copy ...");
				if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Seller_Comp_ID, Seller_Company_Business_Type, Seller_Contact_ID, "95", Seller_Percentage, "N", 1))
				{
					Transaction_Error = "Store Seller History Reference";
					goto Abort_Share_Transaction;
				}

				// SAVE THE SHARE SELLER COMPANY HISTORY
				if (!modCommon.Transaction_Save_Company_History(Journal_ID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs, 0, SendtoWeb))
				{
					Transaction_Error = "Store Seller Company History";
					goto Abort_Share_Transaction;
				}

				//********************************************************
				// SAVE SHARE BUYER REFERENCE RECORD
				Working_On("Saving Buyer Reference Copy ...");
				if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, Journal_ID, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, "96", Buyer_Percentage, "N", 10))
				{
					Transaction_Error = "Store Buyer History Reference";
					goto Abort_Share_Transaction;
				}

				// ****************************************
				// IF HISTORICAL TRANSACTION
				int tmp_transmit_seq_no = 0;
				string tmp_poc_flag = "";
				if (~((opt_Historical.Checked) ? -1 : 0) != 0)
				{
					//'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

					int tempForEndVar = grd_Fractional.RowsCount - 1;
					for (int Row = 1; Row <= tempForEndVar; Row++)
					{
						if (grid_Array_POC[Row] == "Y")
						{
							POC_Row = Row;
						}
						grd_Fractional.CurrentRowIndex = Row;
						grd_Fractional.CurrentColumnIndex = 3;
						change_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();

						if (Math.Abs(Conversion.Val(change_percent)) > 0)
						{ // GET PERCENTAGE FROM BUYER
							grd_Fractional.CurrentColumnIndex = 2;
							new_percent = Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim()).ToString();
						}
						else
						{
							// GET PERCENTAGE FROM SELLER
							grd_Fractional.CurrentColumnIndex = 1;
							new_percent = Conversion.Val(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim()).ToString();
						}

						grd_Fractional.CurrentColumnIndex = 4;
						if (grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim() == "Buyer")
						{
							Buyer_row = Row;
						}

						if ((Row == POC_Row) && (Double.Parse(new_percent) == 0))
						{
							POC_Row = Buyer_row;
						}

						if (Row == Buyer_row)
						{
							Buyer_New_Percent = Conversion.Val(new_percent.Trim()).ToString();

							if (Conversion.Val(Buyer_New_Percent) == 100)
							{
								Buyer_Contact_Type = "00";
								Buyer_Ownership_Type = "W";
							}
							else
							{
								Buyer_Contact_Type = "08";
								Buyer_Ownership_Type = "S";
							}

						}
					}

					// ******************************************************************
					// UPDATE THE CURRENT AIRCRAFT RECORD AND CLEAR THE APPROPRIATE REFERENCE RECORDS
					Working_On("Updating Current Aircraft Information ...");
					if (!Transaction_Update_Current_Aircraft_Record(modAdminCommon.gbl_Aircraft_ID, DateTime.Parse(txt_transaction_date.Text.Trim()), Buyer_Ownership_Type))
					{
						Transaction_Error = "Update Current Aircraft";
						goto Abort_Share_Transaction;
					} // if update to the aircraft was successful

					// ******************************************************************
					// OMNS - Off Market Due To Sale
					if (Clear_Availability && Prior_Availability && chk_Correction_Transaction.CheckState == CheckState.Unchecked)
					{
						modCommon.Transaction_Insert_Priority_Event("OMNS", modAdminCommon.gbl_Aircraft_ID, Journal_ID, $"New Owner: {Buyer_Comp_Name}", Buyer_Comp_ID, Buyer_Contact_ID);
					}


					//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
					// RUN THROUGH THE ROWS OF THE GRID EXCLUDING THE HEADER ROW
					int tempForEndVar2 = grd_Fractional.RowsCount - 1;
					for (int Row = 1; Row <= tempForEndVar2; Row++)
					{
						grd_Fractional.CurrentRowIndex = Row;
						tmp_transmit_seq_no = 99;

						grd_Fractional.CurrentColumnIndex = 3;
						change_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
						grd_Fractional.CurrentColumnIndex = 4;
						//  determine the change percentage for buyer
						if (Math.Abs(Conversion.Val(change_percent)) > 0 && grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Buyer" && chk_Awaiting_Documentation.CheckState == CheckState.Unchecked)
						{
							grd_Fractional.CurrentColumnIndex = 2;
							new_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
						}
						else if (Math.Abs(Conversion.Val(change_percent)) > 0 && grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString() == "Seller")
						{ 
							grd_Fractional.CurrentColumnIndex = 2;
							new_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
						}
						else
						{
							grd_Fractional.CurrentColumnIndex = 1;
							new_percent = grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim();
							grd_Fractional.CurrentColumnIndex = 4;
							grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].Value = "";
						}

						// SAVE ALL OWNERS THAT STILL HAVE PERCENTAGES
						if (Math.Abs(Conversion.Val(new_percent)) > 0)
						{

							grd_Fractional.CurrentColumnIndex = 4;

							switch(grd_Fractional[grd_Fractional.CurrentRowIndex, grd_Fractional.CurrentColumnIndex].FormattedValue.ToString().Trim())
							{
								case "Seller" : 
									// ********************************************************** 
									// STORE THE SHARE SELLER LEAVING POC FLAG AS IS 
									if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
									{
										tmp_transmit_seq_no = 1;
									} 
									 
									if (grid_Array_POC[Row] == "X")
									{
										tmp_poc_flag = "X";
									}
									else
									{
										tmp_poc_flag = grid_Array_POC[Row];
									} 
									 
									// RECORD THE REFERENCE FOR THE SELLER 
									if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, grid_Array_comp_id[Row], grid_Array_comp_Bus_Type[Row], grid_Array_contact_id[Row], "08", new_percent, tmp_poc_flag, tmp_transmit_seq_no))
									{
										Transaction_Error = "Store Current Co-Owner Reference - Seller";
										goto Abort_Share_Transaction;
									} 
									 
									break;
								case "Buyer" : 
									// *********************************************************** 
									// STORE BUYER REFERENCE RECORD 
									 
									if (chk_Awaiting_Documentation.CheckState == CheckState.Unchecked)
									{
										// SELLER AND NOT AWAITING DOCUMENTS
										tmp_transmit_seq_no = 1;
										// IF THE AIRCRAFT WILL NOW BE WHOLLY OWNED

										if (Conversion.Val(Buyer_New_Percent) == 100)
										{
											Buyer_Contact_Type = "00";
											Buyer_Ownership_Type = "W";
										}
										else
										{
											Buyer_Contact_Type = "08";
											Buyer_Ownership_Type = "S";
										}

										// RECORD THE BUYER COMANY REFERENCE
										if (!Clear_Availability && Aircraft_Exclusive)
										{
											if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, grid_Array_comp_id[Row], Buyer_Company_Business_Type, grid_Array_contact_id[Row], Buyer_Contact_Type, new_percent, "N", tmp_transmit_seq_no))
											{
												//   Buyer_Contact_Type, new_percent, "X", tmp_transmit_seq_no) Then  'aey 9/9/04 new buyer getting additional exclusive flag
												Transaction_Error = "Store Current Co-Owner Reference - Buyer";
												goto Abort_Share_Transaction;
											}
										}
										else
										{

											gPOC_Flag = "Y";

											// ok use chosen buyer company business type
											if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, grid_Array_comp_id[Row], Buyer_Company_Business_Type, grid_Array_contact_id[Row], Buyer_Contact_Type, new_percent, gPOC_Flag, tmp_transmit_seq_no))
											{
												Transaction_Error = "Store Current Co-Owner Reference - Buyer";
												goto Abort_Share_Transaction;
											}
										}

									}  // IF NOT AWAITING DOCS BUYER 
									 
									break;
								default:
									 
									// RECORD THE REFERENCE FOR NOT BUYER OR SELLER 
									// MUST BE JUST ANOTHER CO-OWNER 
									if (grid_Array_POC[Row] == "X")
									{
										tmp_poc_flag = "X";
									}
									else
									{
										tmp_poc_flag = grid_Array_POC[Row];
									} 
									 
									//If tmp_poc_flag = "Y" And Preserve_POC = True Then tmp_poc_flag = "N" 'aey 9/3/04 
									 
									if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, grid_Array_comp_id[Row], grid_Array_comp_Bus_Type[Row], grid_Array_contact_id[Row], "08", new_percent, tmp_poc_flag, tmp_transmit_seq_no))
									{
										Transaction_Error = "Store Existing Co-Owners";
										goto Abort_Share_Transaction;
									} 
									break;
							}
						} // Percent on row greater than 0 so process

					} // get next grid row

					// AWAITING DOCUMENTATION BUYER
					if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
					{
						gPOC_Flag = "Y";

						// ok use chosen buyer company business type

						if (!modCommon.Transaction_Seller_Buyer_Insert(modAdminCommon.gbl_Aircraft_ID, 0, Buyer_Comp_ID, Buyer_Company_Business_Type, Buyer_Contact_ID, "08", Buyer_Percentage, gPOC_Flag, 99))
						{
							Transaction_Error = "Save Awaiting Doc Co Owner";
							goto Abort_Share_Transaction;
						}
					}

				} // if not historical

				Add_To_Transmit_Field_List(" ");
				// record a share sale transmit
				modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, Journal_ID, gbl_ac_amod_id, "Transaction", "Add", ref arr_Transmit_Fields);
				// record a transmit change to the current aircraft
				if (!opt_Historical.Checked)
				{ //aey 2/10/05 do not write for historical
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Aircraft", "Change", ref arr_Transmit_Fields);
				}

				// **************************************************************************
				// IF THE AIRCRAFT WAS AVAILABLE AND NOW ISN'T THEN RECORD A DELETE AVAILABLE TRANSMIT

				if (Prior_Availability && Clear_Availability)
				{
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Delete", ref arr_Transmit_Fields);
				}

				// **************************************************************************
				// IF THE AIRCRAFT IS NOW AVAILABLE AND WASN'T PRIOR TO THE TRANSACTION
				// THEN RECORD AN ADD AVAILABLE TRANSMIT

				if (!Clear_Availability && !Prior_Availability && opt_Current.Checked)
				{
					string tempRefParam = "On Market";
					if (Transaction_Insert_Journal_Entry(0, "MA", ref tempRefParam, 0, 0, 0, SendtoWeb) == 0)
					{
						Transaction_Error = "Insert Journal Entry for On Market";
						goto Abort_Share_Transaction;
					}
					modAdminCommon.Record_Transmit(Aircraft_Serial_Number, modAdminCommon.gbl_Aircraft_ID, 0, gbl_ac_amod_id, "Available", "Add", ref arr_Transmit_Fields);
				}

				// *******************************************************
				// ALL PROCESSING COMPLETE - COMMIT THE TRANSACTION
				modAdminCommon.ADO_Transaction("CommitTrans");
				Working_Off();
				result = true;

				modCommon.Aircraft_History_Close_Recordsets();

				return result;


				Abort_Share_Transaction:

				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lError = Information.Err().Number;
				strError = Information.Err().Description;

				modAdminCommon.ADO_Transaction("RollbackTrans");
				modCommon.Aircraft_History_Close_Recordsets();
				result = false;
				Working_Off();

				Information.Err().Number = lError;
				Information.Err().Description = strError;
				modAdminCommon.Report_Error($"Transaction_Save_Aircraft_Share_Error: {Transaction_Error} {Information.Err().Description} B:{Buyer_Comp_ID.ToString()} S:{Seller_Comp_ID.ToString()} ac:{modAdminCommon.gbl_Aircraft_ID.ToString()}"); //aey 5/27/04
			}
			catch (System.Exception excep)
			{

				// 10/11/2002 - By David D. Cruger; Hold These Error Values As the RollbackTrans will clear them
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lError = Information.Err().Number;
				strError = excep.Message;

				modAdminCommon.ADO_Transaction("RollbackTrans");
				result = false;
				Working_Off();

				// 10/11/2002 - By David D. Cruger; Add the Held Error Values to the Report_Error Procedure
				Information.Err().Number = lError;
				Information.Err().Description = strError;
				modAdminCommon.Report_Error("Save_Aircraft_Share_Error: ");
			}


			return result;
		}

		public bool Transaction_Update_Current_Aircraft_Record(int in_Aircraft_ID, System.DateTime in_Journal_Date, string Buyer_Ownership_Type, int Buyer_Comp_ID = 0, int in_POC_comp_id = 0)
		{
			// THE PURPOSE OF THIS FUNCTION IS TO UPDATE THE CURRENT AIRCRAFT RECORD
			// UPON COMPLETION OF A TRANSACTION.  KEY ACTIONS TAKEN INCLUDE:
			// RTW - 12/9/2010 - MODIFIED TO CLEAR THE AC REG NO EXPIRATION DATE EXCEPT FOR FRACTIONAL SALES - PER LUCIA
			//
			// **********************************************************************

			bool result = false;
			try
			{

				string Query = "";
				ADORecordSetHelper ado_aircraft = new ADORecordSetHelper();
				ADORecordSetHelper ado_reference = new ADORecordSetHelper();

				//''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				// Clear the appropriate fields in the current 'Aircraft' table row
				// to indicate that the Aircraft has been sold.
				result = true;

				//===========================================================================
				// CLEAR CONTACTS/REFERENCES
				Query = $"SELECT cref_id FROM Aircraft_Reference WHERE cref_ac_id = {in_Aircraft_ID.ToString()} AND cref_journ_id = 0";

				string DoNotClear = "";
				// NEVER CLEAR LEASE RELATED RECORDS
				DoNotClear = "'12', '13', '39', '57'";

				if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
				{
					//31 - Management company added 1/5/05
					DoNotClear = $"{DoNotClear},'00','08','97','17','62','31'";
				}

				if (Trans_Type.StartsWith("F", StringComparison.Ordinal))
				{ //aey 1/7/06
					DoNotClear = $"{DoNotClear},'08'";
				}

				if (Trans_Type.StartsWith("S", StringComparison.Ordinal))
				{ //aey 1/7/06
					DoNotClear = $"{DoNotClear},'62'";
				}

				if (txt_Transaction_Type.Text.StartsWith("DP", StringComparison.Ordinal))
				{ //aey 8/19/04
					//added to prevent clearing the owner /amnufacturer on delivery position sales
					DoNotClear = $"{DoNotClear},'00'";
				}

				if (!Clear_Availability)
				{
					DoNotClear = $"{DoNotClear},'38','93','99'";
				}

				// DON'T CLEAR THE CONTACTS
				if (!Clear_Contacts)
				{ // 37 added 10/6/04 aey '31 added 1/5/05 '62 added 1/7/05 '94 added MSW 4/3/12, added 2x to the do now clear - MSW - 11/27/18
					DoNotClear = $"{DoNotClear},'05','74','11','40','66','67','68','02','36','44','37','31','62','94'";
					if (chk_Internal_Transaction.CheckState == CheckState.Checked)
					{
						DoNotClear = $"{DoNotClear},'2X'";
					}
				}

				// THERE ALWAYS WILL BE SOME CONTACTS THAT WE DON'T WANT TO CLEAR
				Query = $"{Query} AND cref_contact_type NOT IN ({DoNotClear})";

				// IF A REGISTERED AS OWNER IS BEING RECORDED FOR THIS TRANSACTION/AIRCRAFT
				// THEN THE EXISTING REGISTERED AS OWNER MUST BE REMOVED.
				if (Registered_As_Owner_comp_id > 0)
				{
					Query = $"{Query} AND cref_contact_type IN ('62','22','63')";
				}

				// RTW - 9/29/204
				// IF THE PREVIOUS PRIMARY POC IS PROVIDED AND IT IS NOT THE BUYER
				// THE PRESERVE POC FLAG IS SET TO TRUE THEN DO NOT REMOVE THIS PRIMARY POC COMPANY
				if (in_POC_comp_id > 0 && in_POC_comp_id != Buyer_Comp_ID && Preserve_POC && !Clear_Availability)
				{
					Query = $"{Query} AND cref_comp_id <> {in_POC_comp_id.ToString()}";
				}

				ado_reference.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

				if (!(ado_reference.BOF && ado_reference.EOF))
				{
					//UPGRADE_ISSUE: (2064) ADODB.CursorOptionEnum property CursorOptionEnum.adDelete was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_ISSUE: (2064) ADODB.Recordset method ado_reference.Supports was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					if (ado_reference.Supports(UpgradeStubs.ADODB_CursorOptionEnum.getadDelete()))
					{

						while(!ado_reference.EOF)
						{
							Query = $"DELETE FROM Share_Reference WHERE sref_cref_id = {Convert.ToString(ado_reference["cref_id"])}";
							DbCommand TempCommand = null;
							TempCommand = modAdminCommon.ADODB_Trans_conn.CreateCommand();
							UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand);
							TempCommand.CommandText = Query;
							//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
							//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
							TempCommand.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
							UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand);
							TempCommand.ExecuteNonQuery();
							ado_reference.Delete();
							ado_reference.MoveNext();
						};
					}
				}

				if (ado_reference.State == ConnectionState.Open)
				{
					ado_reference.Close();
				}

				ado_reference = null;

				// ADDED MSW -- 7/27/17
				if (Clear_Availability)
				{
					Query = "update Aircraft_Reference set cref_primary_poc_flag='N' ";
					Query = $"{Query}WHERE cref_ac_id = {in_Aircraft_ID.ToString()}";
					Query = $"{Query} AND cref_journ_id = 0";
					Query = $"{Query} and cref_contact_type IN ('12','13','39')";
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

				if (!Clear_Availability || chk_Lease_Take_Off_Market.CheckState == CheckState.Checked)
				{
					if (Aircraft_Exclusive)
					{
						if (!Clear_Contacts)
						{

							// IF THE USER DECIDED TO CLEAR THE AVAILABILITY OF THE AIRCRAFT
							// THEN MAKE SURE THAT THE EXLUSIVE REFERENCES ARE ALSO CLEARED
							Query = "update Aircraft_Reference set cref_primary_poc_flag='N' ";
							Query = $"{Query}WHERE cref_ac_id = {in_Aircraft_ID.ToString()}";
							Query = $"{Query} AND cref_journ_id = 0";
							Query = $"{Query} AND cref_primary_poc_flag = 'X'";
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
					}
				}
				else if (Clear_Availability && !Clear_Contacts && Aircraft_Exclusive)
				{ 

					Query = "update Aircraft_Reference set cref_primary_poc_flag='N' ";
					Query = $"{Query}WHERE cref_ac_id = {in_Aircraft_ID.ToString()}";
					Query = $"{Query} AND cref_journ_id = 0";
					Query = $"{Query} AND cref_primary_poc_flag = 'X'";
					DbCommand TempCommand_4 = null;
					TempCommand_4 = modAdminCommon.ADODB_Trans_conn.CreateCommand();
					UpgradeHelpers.DB.DbConnectionHelper.ResetCommandTimeOut(TempCommand_4);
					TempCommand_4.CommandText = Query;
					//UPGRADE_ISSUE: (2064) ADODB.ExecuteOptionEnum property ExecuteOptionEnum.adExecuteNoRecords was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
					//UPGRADE_WARNING: (6021) Casting 'ADODB.ExecuteOptionEnum' to Enum may cause different behaviour. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-6021
					TempCommand_4.CommandType = CommandType.Text; // gap-note: Use CommandType.Text, the adExecuteNoRecords flag is equivalent to executing the command within an ExecuteNonQuery.
					UpgradeHelpers.DB.TransactionManager.SetCommandTransaction(TempCommand_4);
					TempCommand_4.ExecuteNonQuery();

				}



				//=============================================================================
				// Update appropriate fields in the Current 'Aircraft' row
				Query = $"SELECT * FROM Aircraft WHERE ac_id = {in_Aircraft_ID.ToString()} AND ac_journ_id = 0";

				ado_aircraft.Open(Query, modAdminCommon.ADODB_Trans_conn, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
				if (!(ado_aircraft.BOF && ado_aircraft.EOF))
				{
					ado_aircraft.MoveFirst();
					ado_aircraft["ac_last_verified_date"] = DateTime.Now.ToString("d");
					ado_aircraft["ac_next_verified_date"] = DateTime.Now.ToString("d");
					// CLEAR BASE INFORMATION

					if (Clear_Base)
					{
						ado_aircraft["ac_aport_id"] = 0;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_aport_iata_code"] = DBNull.Value;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_aport_icao_code"] = DBNull.Value;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_aport_faaid_code"] = DBNull.Value;
						Add_To_Transmit_Field_List("ac_aport_code");
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_aport_name"] = DBNull.Value;
						Add_To_Transmit_Field_List("ac_aport_name");
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_aport_state"] = DBNull.Value;
						Add_To_Transmit_Field_List("ac_aport_state");
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_aport_country"] = DBNull.Value;
						Add_To_Transmit_Field_List("ac_aport_city");
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_aport_city"] = DBNull.Value;
						ado_aircraft["ac_aport_private"] = "N"; //aey 7/28/05
					}

					// CLEAR SPECIFICATIONS
					if (Clear_Specifications)
					{
						frm_aircraft.DefInstance.NeedToClearSpecs = true;
					}

					// Share sales and delivery position sales should not change the date purchased
					// Internal and Correction transaction should not change the date purchased - (per Lu 6-14-2002)
					// <>L changed to =WS 8/3/04 aey
					// aey 10/26/04 added SS - Share sale
					if (Transaction_Type.Substring(Math.Max(Transaction_Type.Length - 2, 0)) != "IT" && chk_Correction_Transaction.CheckState == CheckState.Unchecked && ((Trans_Type.StartsWith("WS", StringComparison.Ordinal)) || (Trans_Type.StartsWith("SS", StringComparison.Ordinal)) || (Trans_Type.StartsWith("FC", StringComparison.Ordinal)) || (Trans_Type.StartsWith("SZ", StringComparison.Ordinal))))
					{
						if ((RespShareSale == System.Windows.Forms.DialogResult.Yes && Trans_Type.StartsWith("SS", StringComparison.Ordinal)) || (Trans_Type.StartsWith("WS", StringComparison.Ordinal) || Trans_Type.StartsWith("FC", StringComparison.Ordinal) || Trans_Type.StartsWith("SZ", StringComparison.Ordinal)))
						{
							ado_aircraft["ac_purchase_date"] = in_Journal_Date; //Don't change 'date purchased' if an internal or correction or lease transaction
							Add_To_Transmit_Field_List("ac_purchase_date");
						}
					}

					//================================================================
					// CLEAR AVAILABILITY
					if (Clear_Availability)
					{
						ado_aircraft["ac_forsale_flag"] = "N";
						ado_aircraft["ac_status"] = "Not for Sale";

						Add_To_Transmit_Field_List("ac_forsale_flag");
						Add_To_Transmit_Field_List("ac_status");
						ado_aircraft["ac_exclusive_flag"] = "N";
						ado_aircraft["ac_asking"] = " ";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_asking_price"] = DBNull.Value;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_hidden_asking_price"] = DBNull.Value;
						ado_aircraft["ac_delivery"] = " ";
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_delivery_date"] = DBNull.Value;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_list_date"] = DBNull.Value;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_foreign_currency_name"] = DBNull.Value;
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_foreign_currency_price"] = DBNull.Value;
						Add_To_Transmit_Field_List("ac_asking");
						Add_To_Transmit_Field_List("ac_asking_price");
						Add_To_Transmit_Field_List("ac_delivery");
						Add_To_Transmit_Field_List("ac_delivery_date");
						Add_To_Transmit_Field_List("ac_list_date");

					} // if clear availability was requested by the user

					//=====================================================
					// HANDLE SPECIAL CASES FOR LEASES
					if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
					{
						if (Clear_Availability)
						{
							Set_Primary_POC_To_Owner(in_Aircraft_ID);
						}
						ado_aircraft["ac_lease_flag"] = "Y";
						Add_To_Transmit_Field_List("ac_lease_flag");

					}

					//====================================================
					// SET THE REGISTRATION NUMBER
					if ((((opt_Historical.Checked) ? -1 : 0) & ((Strings.Len(txt_Registration_No.Text) > 0) ? -1 : 0)) != 0)
					{
						ado_aircraft["ac_reg_no"] = txt_Registration_No.Text.Trim();
						Add_To_Transmit_Field_List("ac_reg_no");
					}

					//====================================================
					// SET THE OWNERSHIP AS NEW OR PREOWNED
					// IF LIFE CYCLE IS CURRENTLY 3 (IN OPERATION) AND
					// NOT PRE-OWNED (NEW) AND NOT A NEW TO MARKET TRANSACTION
					// THEN SET TO PRE-OWNED
					// RTW - 3/31/2004 - MODIFIED PER CONVERSATION WITH LU
					if ((Transaction_Type.StartsWith("WS", StringComparison.Ordinal) || Transaction_Type.StartsWith("L", StringComparison.Ordinal)) && Transaction_Type.Substring(Math.Max(Transaction_Type.Length - 2, 0)) != "IT" && Transaction_Type.Substring(Math.Max(Transaction_Type.Length - 4, 0)) != "CORR")
					{
						// CHECK TO SEE THAT THERE WAS PREVIOUSLY A NEW TO MARKET TRANSACTION
						// RTW - 4/19/2004


						if (Convert.ToString(ado_aircraft["ac_previously_owned_flag"]).Trim().ToUpper() == "N" && AircraftUsed)
						{
							ado_aircraft["ac_previously_owned_flag"] = "Y";
							modAdminCommon.Record_Event("Transaction", "New to Used", in_Aircraft_ID, 0);
						}
					}

					//====================================================
					// SET THE CURRENT AIRCRAFT OWNERSHIP TYPE
					// if the aircraft is being sold from a delivery position into operation then
					// set the new stage to 3
					if (chk_NewAircraft.CheckState == CheckState.Checked)
					{
						ado_aircraft["ac_lifecycle_stage"] = 3;
					}

					//aey 1/11/05 Sales by manufacturer to end users
					//aey 3/4/05 MF or DS or FY sale
					if ((txt_Transaction_Type.Text.Substring(Math.Min(2, txt_Transaction_Type.Text.Length), Math.Min(2, Math.Max(0, txt_Transaction_Type.Text.Length - 2))) == "MF" || txt_Transaction_Type.Text.Substring(Math.Min(2, txt_Transaction_Type.Text.Length), Math.Min(2, Math.Max(0, txt_Transaction_Type.Text.Length - 2))) == "FY" || txt_Transaction_Type.Text.Substring(Math.Min(2, txt_Transaction_Type.Text.Length), Math.Min(2, Math.Max(0, txt_Transaction_Type.Text.Length - 2))) == "DS") && !(txt_Transaction_Type.Text.Substring(Math.Min(4, txt_Transaction_Type.Text.Length), Math.Min(2, Math.Max(0, txt_Transaction_Type.Text.Length - 4))) == "MF" || txt_Transaction_Type.Text.Substring(Math.Min(4, txt_Transaction_Type.Text.Length), Math.Min(2, Math.Max(0, txt_Transaction_Type.Text.Length - 4))) == "IT" || txt_Transaction_Type.Text.Substring(Math.Min(4, txt_Transaction_Type.Text.Length), Math.Min(2, Math.Max(0, txt_Transaction_Type.Text.Length - 4))) == "FY" || txt_Transaction_Type.Text.Substring(Math.Min(4, txt_Transaction_Type.Text.Length), Math.Min(2, Math.Max(0, txt_Transaction_Type.Text.Length - 4))) == "DS") && (Convert.ToDouble(ado_aircraft["ac_lifecycle_stage"]) == 2 || Convert.ToDouble(ado_aircraft["ac_lifecycle_stage"]) == 1))
					{
						ado_aircraft["ac_lifecycle_stage"] = 3;
					}

					if (Trans_Type.StartsWith("WS", StringComparison.Ordinal) && (Buyer_Company_Business_Type == "PH" || Buyer_Company_Business_Type == "PM"))
					{
						ado_aircraft["ac_ownership_type"] = "F";
						Add_To_Transmit_Field_List("ac_ownership_type");
					}
					else if (Strings.Len(Buyer_Ownership_Type.Trim()) > 0)
					{ 
						ado_aircraft["ac_ownership_type"] = Buyer_Ownership_Type.Trim();
						Add_To_Transmit_Field_List("ac_ownership_type");
					}
					else if (Trans_Type == "FS")
					{ 
						ado_aircraft["ac_ownership_type"] = "F";
					}
					else if (Trans_Type == "SS")
					{ 
						ado_aircraft["ac_ownership_type"] = "S";
					}
					else if (Trans_Type == "DP")
					{ 
						ado_aircraft["ac_ownership_type"] = "D";
					}
					else if (Trans_Type.StartsWith("L", StringComparison.Ordinal))
					{ 
						// Leave ownership type as is
					}
					else
					{
						ado_aircraft["ac_ownership_type"] = "W";
					}

					// =========================================================================
					// CLEAR THE AIRCRAFT REGISTRATION EXPIRATION DATE IF NOT A FRACTIONAL SALE
					// RTW - 12/9/2010
					if (!Trans_Type.StartsWith("FS", StringComparison.Ordinal))
					{
						//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
						ado_aircraft["ac_reg_no_expiration_date"] = DBNull.Value;
					}


					//================================================================
					// CLEAR THE ACTION DATE SO THE RECORD IS TRANSMITTED TO THE WEB
					//UPGRADE_WARNING: (1049) Use of Null/IsNull() detected. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-1049
					ado_aircraft["ac_action_date"] = DBNull.Value;
					ado_aircraft["ac_upd_date"] = DateTime.Now.ToString();
					ado_aircraft["ac_upd_user_id"] = modAdminCommon.gbl_User_ID;

					ado_aircraft.Update();
					result = true;
				}
				else
				{
					result = false;
				}
				if (ado_aircraft.State == ConnectionState.Open)
				{
					ado_aircraft.Close();
				}
				ado_aircraft = null;
			}
			catch (System.Exception excep)
			{

				Working_Off();
				result = false;
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				modAdminCommon.Report_Error($"Transaction_Update_Current_Aircraft_Record_Error: {Information.Err().Number.ToString()} {excep.Message}");
			}

			return result;
		}

		public bool Transaction_Save_Pending_Fractions(int in_Aircraft_ID, ref ADORecordSetHelper in_Fractions_Pending)
		{
			//
			// Purpose: The purpose of this function is to save pending sales transactions
			//          when a whole aircraft sale occurs to a fractionally owned aircraft.
			//
			bool result = false;
			try
			{

				string Query = "";
				int Fractional_Seller_comp_id = 0;
				int Fractional_Seller_contact_id = 0;
				int Program_Holder_Comp_ID = 0;
				int Program_Holder_Contact_ID = 0;
				string Subject = "";
				int New_Journal_ID = 0;
				int lError = 0; // Hold The Error Number Value
				string strError = ""; // Hold The Error Description Value

				result = false;

				// *************************************************
				// GET THE COMPANY ID OF THE PROGRAM HOLDER FROM THE SNAPSHOT
				Working_On("Locating Program Holder ...");
				in_Fractions_Pending.Filter = "cref_contact_type = '17'";
				if (!(in_Fractions_Pending.BOF && in_Fractions_Pending.EOF))
				{
					in_Fractions_Pending.MoveFirst();
					Program_Holder_Comp_ID = Convert.ToInt32(in_Fractions_Pending["cref_comp_id"]);
					Program_Holder_Contact_ID = Convert.ToInt32(in_Fractions_Pending["cref_contact_id"]);
				}

				// *************************************************
				// GET THE FRACTIONAL OWNERS FROM THE SNAPSHOT
				Working_On("Saving Pending Fractional Sales ...");
				in_Fractions_Pending.Filter = "cref_contact_type = '97'";
				if (!(in_Fractions_Pending.BOF && in_Fractions_Pending.EOF))
				{
					in_Fractions_Pending.MoveFirst();


					while(!in_Fractions_Pending.EOF)
					{
						Fractional_Seller_comp_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(in_Fractions_Pending["cref_comp_id"])}").Trim()));
						Fractional_Seller_contact_id = Convert.ToInt32(Double.Parse(($"{Convert.ToString(in_Fractions_Pending["cref_contact_id"])}").Trim()));
						Subject = $"Fractional Sale Pending from {Get_comp_name(Fractional_Seller_comp_id)}";
						Working_On($"Saving {Subject} ...");

						// *******************************************
						// GET A SNAPSHOT OF Company Information INFORMATION
						Working_On("Saving Transaction Company History for Pending Sale ...");
						if (!modCommon.Transaction_Get_Company_History_Recordsets($"{Fractional_Seller_comp_id.ToString()},{Program_Holder_Comp_ID.ToString()}"))
						{
							return result;
						}

						// *******************************************
						// GET A COMPLETE SNAPSHOT OF ALL AIRCRAFT INFORMATION
						if (!modCommon.Aircraft_History_Get_Recordsets(modAdminCommon.gbl_Aircraft_ID, "FS", $"{Fractional_Seller_comp_id.ToString()},{Program_Holder_Comp_ID.ToString()}"))
						{
							strError = "Get Aircraft History";
							goto Abort_This_Set;
						}

						modAdminCommon.ADO_Transaction("BeginTrans");

						// SAVE THE TRANSACTION JOURNAL ENTRY
						New_Journal_ID = Transaction_Insert_Journal_Entry(0, "FSPEND", ref Subject, 0, 0, 0, false);
						if (New_Journal_ID == 0)
						{
							goto Abort_This_Set;
						}

						// SAVE THE PENDING FRACTIONAL OWNER REFERENCE RECORD  - 91 = Fractional Owner Pending Sale
						if (!modCommon.Transaction_Seller_Buyer_Insert(in_Aircraft_ID, New_Journal_ID, Fractional_Seller_comp_id, Convert.ToString(in_Fractions_Pending["cref_business_type"]), Fractional_Seller_contact_id, "91", Convert.ToString(in_Fractions_Pending["cref_owner_percent"]), "N"))
						{
							goto Abort_This_Set;
						}

						// SAVE THE PENDING FRACTIONAL OWNER COMPANY HISTORY
						if (!modCommon.Transaction_Save_Company_History(New_Journal_ID, ref modGlobalVars.snp_Company, ref modGlobalVars.snp_Contacts, ref modGlobalVars.snp_Company_Phones, ref modGlobalVars.snp_Company_Btypes, ref modGlobalVars.snp_Company_Certs, 0, false))
						{
							goto Abort_This_Set;
						}

						// SAVE THE PROGRAM HOLDER REFERENCE RECORD - 70 = Fractional Purchaser
						if (!modCommon.Transaction_Seller_Buyer_Insert(in_Aircraft_ID, New_Journal_ID, Program_Holder_Comp_ID, "PH", Program_Holder_Contact_ID, "70", Convert.ToString(in_Fractions_Pending["cref_owner_percent"]), "N"))
						{
							goto Abort_This_Set;
						}

						// SAVE THE AIRCRAFT HisTORY RECORD
						if (!modCommon.Transaction_Save_Aircraft_History(New_Journal_ID, "FS", modGlobalVars.snp_TransAircraft, modGlobalVars.snp_TransAircraft_Reference, modGlobalVars.snp_TransAircraft_Features, modGlobalVars.snp_TransAircraft_Avionics, modGlobalVars.snp_TransAircraft_Certified, modGlobalVars.snp_TransAircraft_Specification, modGlobalVars.snp_TransAircraft_Details, modGlobalVars.snp_TransAircraft_FAA_Document, false, "", false))
						{ //, txt_Transaction_Type) Then
							goto Abort_This_Set;
						}

						modAdminCommon.ADO_Transaction("CommitTrans");

						Query = $"Select * from aircraft_reference where cref_contact_type = '60' and cref_journ_id={New_Journal_ID.ToString()} and cref_ac_id={in_Aircraft_ID.ToString()} and cref_comp_id={Fractional_Seller_comp_id.ToString()} ";
						if (modAdminCommon.Exist(Query))
						{
							//Create a historical companies so that the references are complete
							if (!CreateHistoricalCompanyRecord(Fractional_Seller_comp_id, Fractional_Seller_contact_id, New_Journal_ID))
							{
								goto Abort_This_Set;
							}
						}

						Next_Pending:
						in_Fractions_Pending.MoveNext();
					};

				}

				result = true;

				if (in_Fractions_Pending != null)
				{
					if (in_Fractions_Pending.State == ConnectionState.Open)
					{
						in_Fractions_Pending.Close();
					}
					in_Fractions_Pending = null;
				}
				return result;

				// **********************************************************************************
				// ROLLBACK THE CURRENT PENDING TRANSACTION AND GO TO THE NEXT PENDING TRANSACTION
				Abort_This_Set:

				// 10/11/2002 - By David D. Cruger; Hold These Error Values As the RollbackTrans will clear them
				//UPGRADE_WARNING: (2081) Err.Number has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2081
				lError = Information.Err().Number;
				strError = Information.Err().Description;

				modAdminCommon.ADO_Transaction("Rollback"); // 10/11/2002 - By David D. Cruger; Moved the Rollback before the Report_Error

				// 10/11/2002 - By David D. Cruger; Add the Held Error Values to the Report_Error Procedure
				Information.Err().Number = lError;
				Information.Err().Description = strError;
				modAdminCommon.Report_Error($"Transaction_Save_Pending_Fractions_Warning: {Query} {strError}");

				throw new NotImplementedException("GAP-Note This part of the code must be changed. The logic should be changed to jump again to the loop"); // goto Next_Pending; //gap-note this line and the logic must be changed
			}
			catch
			{

				Working_Off();

				return false;
				//UPGRADE_TODO: (1065) Error handling statement (Resume Next) could not be converted. More Information: https://docs.mobilize.net/vbuc/ewis/todos#id-1065
				UpgradeHelpers.Helpers.NotUpgradedHelper.NotifyNotUpgradedElement("Resume Next Statement");
			}
			return result;
		}

		public bool CreateHistoricalCompanyRecord(int incompid, int inContactId, int inJournID)
		{


			bool result = false;
			string Query = "";
			ADORecordSetHelper snpNewComp = new ADORecordSetHelper();
			ADORecordSetHelper snpNewContact = new ADORecordSetHelper();
			ADORecordSetHelper snpNewPhone = new ADORecordSetHelper();
			ADORecordSetHelper snpNewBusType = new ADORecordSetHelper();
			ADORecordSetHelper snpCurComp = new ADORecordSetHelper();
			ADORecordSetHelper snpCurContact = new ADORecordSetHelper();
			ADORecordSetHelper snpCurPhone = new ADORecordSetHelper();
			ADORecordSetHelper snpCurBusType = new ADORecordSetHelper();

			try
			{

				result = false;
				Query = $"SELECT * FROM Company WHERE comp_id = {incompid.ToString()} and comp_journ_id=0 ";
				snpCurComp.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCurComp.BOF && snpCurComp.EOF))
				{
					Query = $"SELECT * FROM Company WHERE comp_id = {incompid.ToString()} and comp_journ_id={inJournID.ToString()} ";

					if (!modAdminCommon.Exist(Query))
					{
						Query = "SELECT * FROM Company WHERE comp_id = -1 ";
						snpNewComp.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);
						snpNewComp.AddNew();

						int tempForEndVar = snpNewComp.FieldsMetadata.Count - 1;
						for (int i = 0; i <= tempForEndVar; i++)
						{
							snpNewComp[i] = snpCurComp[i];
						}

						snpNewComp["comp_active_flag"] = "N";
						snpNewComp["comp_journ_id"] = inJournID;
						snpNewComp["comp_id"] = incompid;

						snpNewComp.Update();
						snpNewComp.Close();
					}
				}

				snpNewComp = null;
				snpCurComp.Close();
				snpCurComp = null;

				Query = $"SELECT * FROM Contact WHERE contact_id = {inContactId.ToString()} and contact_comp_id = {incompid.ToString()} and contact_journ_id=0 ";
				snpCurContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCurContact.BOF && snpCurContact.EOF))
				{
					Query = $"SELECT * FROM Contact WHERE contact_id = {inContactId.ToString()} and contact_journ_id={inJournID.ToString()} ";

					if (!modAdminCommon.Exist(Query))
					{

						Query = "SELECT * FROM Contact WHERE contact_id = -1";
						snpNewContact.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while(!snpCurContact.EOF)
						{

							snpNewContact.AddNew();

							int tempForEndVar2 = snpCurContact.FieldsMetadata.Count - 1;
							for (int i = 0; i <= tempForEndVar2; i++)
							{
								snpNewContact[i] = snpCurContact[i];
							}
							snpNewContact["contact_id"] = inContactId;
							snpNewContact["contact_journ_id"] = inJournID;
							snpNewContact["contact_comp_id"] = incompid;
							snpNewContact.Update();

							snpCurContact.MoveNext();
						};

						snpNewContact.Close();
					}
				}

				snpNewContact = null;

				snpCurContact.Close();
				snpCurContact = null;
				// MSW  - 2/28/2012 - CHANGED QUERY TO USE FULL INDEX - TEMP HOLD - No Contact Record

				Query = $"SELECT * FROM Phone_Numbers WHERE pnum_comp_id ={incompid.ToString()} and pnum_journ_id=0";

				snpCurPhone.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCurPhone.BOF && snpCurPhone.EOF))
				{

					// MSW  - 2/28/2012 - CHANGED QUERY TO USE FULL INDEX - TEMP HOLD - No Contact Record
					Query = $"SELECT * FROM Phone_Numbers WHERE pnum_comp_id ={incompid.ToString()} and pnum_journ_id={inJournID.ToString()} ";
					if (!modAdminCommon.Exist(Query))
					{


						Query = "SELECT * FROM Phone_Numbers WHERE pnum_comp_id = -1";
						snpNewPhone.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while(!snpCurPhone.EOF)
						{

							snpNewPhone.AddNew();

							int tempForEndVar3 = snpCurPhone.FieldsMetadata.Count - 1;
							for (int i = 0; i <= tempForEndVar3; i++)
							{
								snpNewPhone[i] = snpCurPhone[i];
							}

							snpNewPhone["pnum_journ_id"] = inJournID;
							snpNewPhone.Update();

							snpCurPhone.MoveNext();
						};

						snpNewPhone.Close();
					}
					snpNewPhone = null;
				}

				snpCurPhone.Close();
				snpCurPhone = null;

				Query = $"SELECT * FROM Business_Type_Reference WHERE bustypref_comp_id ={incompid.ToString()} and bustypref_journ_id=0 ";
				snpCurBusType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockReadOnly);

				if (!(snpCurBusType.BOF && snpCurBusType.EOF))
				{
					Query = $"SELECT * FROM Business_Type_Reference WHERE bustypref_comp_id ={incompid.ToString()} and bustypref_journ_id={inJournID.ToString()} ";

					if (!modAdminCommon.Exist(Query))
					{
						Query = "SELECT * FROM Business_Type_Reference WHERE bustypref_id = -1";
						snpNewBusType.Open(Query, modAdminCommon.LOCAL_ADO_DB, UpgradeHelpers.DB.LockTypeEnum.LockOptimistic);

						while(!snpCurBusType.EOF)
						{
							snpNewBusType.AddNew();

							int tempForEndVar4 = snpCurBusType.FieldsMetadata.Count - 1;
							for (int i = 0; i <= tempForEndVar4; i++)
							{
								if (snpNewBusType.GetField(i).FieldMetadata.ColumnName != "bustypref_id")
								{
									snpNewBusType[i] = snpCurBusType[i];
								}
							}

							snpNewBusType["bustypref_journ_id"] = inJournID;
							snpNewBusType.Update();

							snpCurBusType.MoveNext();
						};

						snpNewBusType.Close();
					}

					snpNewBusType = null;
				}

				snpCurBusType.Close();
				snpCurBusType = null;


				return true;
			}
			catch (System.Exception excep)
			{

				modAdminCommon.Report_Error($"CreateHistoricalCompanyRecord_Error: {excep.Message}");
				return result;
			}
		}

		private bool Transaction_OK()
		{

			if (Seller_Comp_ID > 0)
			{
				if (Buyer_Comp_ID > 0)
				{
					return true;
				}
				else
				{
					if (chk_Awaiting_Documentation.CheckState == CheckState.Checked)
					{
						return true;
					}
					else
					{
						// no buyer and not awaiting documentation, transaction bad
						return false;
					}
				} // if buyer_comp_id > 0
			}
			else
			{
				// no seller, transaction bad
				return false;
			} // if seller_comp_id > 0

		}
	}
}