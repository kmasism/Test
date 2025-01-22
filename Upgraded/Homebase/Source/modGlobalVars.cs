using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;

namespace JETNET_Homebase
{
	internal static class modGlobalVars
	{


		//==================
		// Public Constants
		//==================

		public const string gstrChilkatUnlockCode = "JETNET.CBX102020_rXznrpSt7s3p"; // 03/01/2018

		public const int CB_LIMITTEXT = 0x141;

		public const int txtIATACode_INDEX = 0;
		public const int txtICAOCode_INDEX = 1;
		public const int txtBaseCity_INDEX = 2;
		public const int cboBaseState_INDEX = 3;
		public const int cboBaseCountry_INDEX = 4;
		public const int txtBaseAirportName_INDEX = 5;
		public const int chkShowAirportList_INDEX = 6;
		public const int txtFAAIDCode_INDEX = 7;

		public const int opt_journ_subj_SHARES = 0;
		public const int opt_journ_subj_LETTER = 1;
		public const int opt_journ_subj_MESSAGE = 2;
		public const int opt_journ_subj_CUSTOM = 3;

		public const int opt_verify_ac_NONE = 0;
		public const int opt_verify_ac_ONE = 1;
		public const int opt_verify_ac_ALL = 2;
		public const int opt_verify_ac_PRIMARY = 3;

		public const string gcCITY_FORT_STR = "Fort ";
		public const string gcCITY_MOUNT_STR = "Mount ";
		public const string gcCITY_SAINT_STR = "Saint ";
		public const string gcCITY_SAINTE_STR = "Sainte ";
		public const string gcCITY_FORT_STR_SHORT = "FT ";
		public const string gcCITY_MOUNT_STR_SHORT = "MT ";
		public const string gcCITY_SAINT_STR_SHORT = "ST ";

		public const string gcCITY_FT_STR = "Ft. ";
		public const string gcCITY_MT_STR = "Mt. ";
		public const string gcCITY_ST_STR = "St. ";

		public const int gcMAINPAGE = 990;
		public const int gcCALLBACKS = 110;
		public const int gcAIRCRAFT = 220;
		public const int gcMODEL = 330;
		public const int gcCOMPANY = 440;
		public const int gcACCOUNT = 550;
		public const int gcADMIN = 660;
		public const int gcPUBS = 770;
		public const int gcNTSB = 880;
		public const int gcCANREG = 1010;
		public const int gcDOCLOG = 1020;
		public const int gcUSERHISTORY = 1030;
		public const int gcYACHT = 1040;

		public const string gcMAINPAGE_STR = "frm_Main_Menu";
		public const string gcCALLBACKS_STR = "frm_ActionList";
		public const string gcAIRCRAFT_STR = "frm_AircraftList";
		public const string gcMODEL_STR = "frm_Aircraft_Model";
		public const string gcCOMPANY_STR = "frm_Find_Company";
		public const string gcACCOUNT_STR = "frm_UserAccounts";
		public const string gcADMIN_STR = "";
		public const string gcPUBS_STR = "frm_WebCrawl";
		public const string gcNTSB_STR = "frm_NTSB";
		public const string gcCANREG_STR = "frm_CanReg";
		public const string gcDOCLOG_STR = "frm_DocumentLog";
		public const string gcUSERHISTORY_STR = "frm_UserHistory";
		//Global Const gcYACHT_STR = "frm_Yacht_Model_Edit"

		// PROCUCT CODE CHECK INDEX
		public const int CHK_BUSINESS_IDX = 0;
		public const int CHK_HELICOPTER_IDX = 1;
		public const int CHK_COMMERCIAL_IDX = 2;
		public const int CHK_ABI_IDX = 3;
		public const int CHK_AIRBP_IDX = 4;
		public const int CHK_YACHT_IDX = 5;
		public const int CHK_REGIONAL_IDX = 5;
		// Changed from CHK_REGIONAL_IDX to CHK_YACHT_IDX - MSW - 4/24/2012

		public const int MAX_CBUS_DIMENSIONS = 2;
		public const int CBUS_TYPENAME = 0;
		public const int CBUS_ABIFLAG = 1;
		public const int CBUS_YACHTFLAG = 2;

		public const int MAX_ACCT_DIMENSIONS = 1;
		public const int ACCTTYPE_CODE = 0;
		public const int ACCTTYPE_NAME = 1;

		public const int MAX_PURQUEST_DIMENSIONS = 1;
		public const int PURQUEST_ID = 0;
		public const int PURQUEST_NAME = 1;

		public const int MAX_AIRCONT_DIMENSIONS = 7;
		public const int AIRCONT_INDEX = 0;
		public const int AIRCONT_NAME = 1;
		public const int AIRCONT_TYPE = 2;
		public const int AIRCONT_USE = 3;
		public const int AIRCONT_COMP = 4;
		public const int AIRCONT_SHARE = 5;
		public const int AIRCONT_NAMEREF = 6;
		public const int AIRCONT_INTERNAL = 7;

		public const int MAX_SERVICE_DIMENSIONS = 1;
		public const int SERVICE_CODE = 0;
		public const int SERVICE_DESCRIPTION = 1;

		public const int MAX_WANTED_DIMENSIONS = 4;
		public const int WANTED_ID = 0;
		public const int WANTED_MAKE = 1;
		public const int WANTED_MODEL = 2;
		public const int WANTED_START = 3;
		public const int WANTED_END = 4;

		public const int MAX_FIND_FORMS = 6;
		public const int FIND_FORM_NEW = 0;
		public const int FIND_FORM_TX = 1;
		public const int FIND_FORM_DOCS = 2;
		public const int FIND_FORM_AC = 3;
		public const int FIND_FORM_CON = 4;
		public const int FIND_FORM_MISC = 5;
		public const int FIND_FORM_YACHT = 6;

		public const int gcENTRYPOINT = 1000;
		public const int gcENTRYPOINTTEXT = 1001;
		public const int gcFOUNDAIRCRAFTID = 1002;
		public const int gcFOUNDAIRCRAFTCOMPID = 1003;
		public const int gcFOUNDAIRCRAFTJID = 1004;
		public const int gcFOUNDCOMPANYID = 1005;
		public const int gcFOUNDCOMPANYTYPE = 1006;
		public const int gcFOUNDCOMPANYJID = 1007;
		public const int gcFOUNDCONTACTID = 1008;
		public const int gcFOUNDCONTACTJID = 1009;
		public const int gcFOUNDCONTACTTYPE = 1010;
		public const int gcFOUNDAWAITINGDOCSID = 1011;
		public const int gcFOUNDNEWCOMPANYNAME = 1012;
		public const int gcFOUNDYACHTID = 1013;

		public const string cSingleSpace = " ";
		public const string cNumericBlank = "NmBl";
		public const string cStringBlank = "StBl";
		public const string cCommaDelim = ",";
		public const string cImbedComma = "~";
		public const string cSingleQuote = "'";
		public const string cDoubbleSingleQuote = "''";
		public const string cEq = " = ";
		public const string cMultiDelim = ", ";
		public const string cHyphen = "-";
		public const string cEmptyString = "";

		public const int gFIND_NONE = 0;
		public const int gFIND_CHCT = 2; // Change Historical Contact Type
		public const int gFIND_ACCA = 4; // Associate Company/Contact to Aircraft
		public const int gFIND_FDMF = 6; // Find Manufacturer
		public const int gFIND_ACOR = 8; // Add Company Relationship
		public const int gFIND_ASHR = 10; // Add Share Relationship
		public const int gFIND_1000 = 12; // Fortune1000
		public const int gFIND_ACCH = 14; // Aircraft_Change
		public const int gFIND_ADOC = 16; // Aircraft_Document
		public const int gFIND_CBAK = 18; // Callbacks
		public const int gFIND_EXBK = 20; // Exclusive Broker
		public const int gFIND_Yacht = 22; // Yacht
		public const int gFIND_UserHistory = 23; // User History

		public const string STR_FIND_NONE = "";
		public const string STR_FIND_CHCT = "Change Historical Contact Type";
		public const string STR_FIND_ACCA = "Associate Company/Contact to Aircraft";
		public const string STR_FIND_FDMF = "Find Manufacturer";
		public const string STR_FIND_ACOR = "Add Company Relationship";
		public const string STR_FIND_ASHR = "Add Share Relationship";
		public const string STR_FIND_1000 = "Fortune 1000";
		public const string STR_FIND_ACCH = "Aircraft Change";
		public const string STR_FIND_ADOC = "Aircraft Document";
		public const string STR_FIND_CBAK = "Callbacks";
		public const string STR_FIND_EXBK = "Exclusive Broker";
		public const string STR_FIND_USERHISTORY = "User History";
		public const string STR_FIND_YACHT = "Find Yacht";

		public const int gFIND_NOACTION = 0; // none
		public const int gFIND_GETSELLER = 1; // Get Seller
		public const int gFIND_GETOWNER = 3; // Get Owner
		public const int gFIND_GETBUYER = 5; // Get Buyer
		public const int gFIND_GETSEIZED = 7; // Get Seized By
		public const int gFIND_GETREPOBY = 9; // Get Reposessed By
		public const int gFIND_GETLESSR = 11; // Get Lessor
		public const int gFIND_GETLESSE = 13; // Get Lessee
		public const int gFIND_GETREGAS = 15; // Get Registered As
		public const int gFIND_GETFAVOR = 17; // Get In Favor of
		public const int gFIND_GETBEHALF = 19; // Get On Behalf of
		public const int gFIND_GETRUSTE = 21; // Get Trustee
		public const int gFIND_GETSUBLES = 23; // Get Sub-Leased to
		public const int gFIND_ASSOCCOMP = 25; // Associate Company
		public const int gFIND_IDCONTACT = 27; // Identify Contact
		public const int gFIND_IDCOMPANY = 29; // Identify Company
		public const int gFIND_EXBROKER = 31; // Identify Exclusive Broker/Rep
		public const int gFIND_GETMANFAC = 33; // Associate Manufacturer

		public const string STR_FIND_NOACTION = "";
		public const string STR_FIND_GETSELLER = "Choose Seller";
		public const string STR_FIND_GETOWNER = "Choose Owner";
		public const string STR_FIND_GETBUYER = "Choose Buyer";
		public const string STR_FIND_GETSEIZED = "Choose Seized by";
		public const string STR_FIND_GETREPOBY = "Choose Reposessed by";
		public const string STR_FIND_GETLESSR = "Choose Lessor";
		public const string STR_FIND_GETLESSE = "Choose Lessee";
		public const string STR_FIND_GETREGAS = "Choose Registered as";
		public const string STR_FIND_GETFAVOR = "Choose In Favor of";
		public const string STR_FIND_GETBEHALF = "Choose On Behalf of";
		public const string STR_FIND_GETRUSTE = "Choose Trustee";
		public const string STR_FIND_GETSUBLES = "Choose Sub-Leased to";
		public const string STR_FIND_GETMANFAC = "Choose Manufacturer";
		public const string STR_FIND_IDCONTACT = "Identify Contact";
		public const string STR_FIND_IDCOMPANY = "Identify Company";
		public const string STR_FIND_ASSOCCOMP = "Associate Company";
		public const string STR_FIND_EXBROKER = "Identify Exclusive Broker/Rep";

		public enum e_first_start_form
		{
			geMainForm = gcMAINPAGE,
			geCallbackForm = gcCALLBACKS,
			geAircraftForm = gcAIRCRAFT,
			geModelForm = gcMODEL,
			geCompanyForm = gcCOMPANY,
			geAccountForm = gcACCOUNT,
			geAdminForm = gcADMIN,
			gePubsForm = gcPUBS,
			geNTSBForm = gcNTSB,
			geCanRegForm = gcCANREG,
			geDocLogForm = gcDOCLOG,
			geUserHistoryForm = gcUSERHISTORY,
			geYachtForm = gcYACHT
		}

		public enum e_find_form_entry_points
		{
			geNoEntryPoint = gFIND_NONE,
			geChangeHistContact = gFIND_CHCT,
			geAssociateToAircraft = gFIND_ACCA,
			geFindManufacturer = gFIND_FDMF,
			geAddCompanyRelation = gFIND_ACOR,
			geAddShareRelation = gFIND_ASHR,
			geFortune1000 = gFIND_1000,
			geAircraftChange = gFIND_ACCH,
			geAircraftDocument = gFIND_ADOC,
			geAccountCallback = gFIND_CBAK,
			geExclusiveBroker = gFIND_EXBK,
			geYacht = gFIND_Yacht,
			geUserHistory = gFIND_UserHistory
		}

		public enum e_find_form_action_types
		{
			geNoAction = gFIND_NOACTION,
			geGetSeller = gFIND_GETSELLER,
			geGetOwner = gFIND_GETOWNER,
			geGetBuyer = gFIND_GETBUYER,
			geSeizedBy = gFIND_GETSEIZED,
			geReposessedBy = gFIND_GETREPOBY,
			geLessor = gFIND_GETLESSR,
			geLessee = gFIND_GETLESSE,
			geRegisteredAs = gFIND_GETREGAS,
			geInFavorOf = gFIND_GETFAVOR,
			geOnBehalfOf = gFIND_GETBEHALF,
			geTrustee = gFIND_GETRUSTE,
			geSubLeasedTo = gFIND_GETSUBLES,
			geAssociateComp = gFIND_ASSOCCOMP,
			geIdContact = gFIND_IDCONTACT,
			geIdCompany = gFIND_IDCOMPANY,
			geExBroker = gFIND_EXBROKER,
			geGetManufacturer = gFIND_GETMANFAC
		}

		[Serializable]
		public struct t_find_form_exit_record
		{
			public e_find_form_entry_points tEntryPoint; // gcENTRYPOINT = 1000
			public string sEntryPointText; // gcENTRYPOINTTEXT = 1001
			public int nFoundAircraftID; // gcFOUNDAIRCRAFTID = 1002
			public int nFoundAircraftCompID; // gcFOUNDAIRCRAFTCOMPID = 1003
			public int nFoundAircraftJID; // gcFOUNDAIRCRAFTJID = 1004
			public int nFoundCompanyID; // gcFOUNDCOMPANYID = 1005
			public string sFoundCompanyTYPE; // gcFOUNDCOMPANYTYPE = 1006
			public int nFoundCompanyJID; // gcFOUNDCOMPANYJID = 1007
			public int nFoundContactID; // gcFOUNDCONTACTID = 1008
			public int nFoundContactJID; // gcFOUNDCONTACTJID = 1009
			public string sFoundContactTYPE; // gcFOUNDCONTACTTYPE = 1010
			public int nFoundAwaitingDocsID; // gcFOUNDAWAITINGDOCSID = 1011
			public string sFoundNewCompanyName; // gcFOUNDNEWCOMPANYNAME = 1012
			public int nFoundYachtID; // gcFOUNDYACHTID = 1013
			public static t_find_form_exit_record CreateInstance()
			{
				t_find_form_exit_record result = new t_find_form_exit_record();
				result.sEntryPointText = String.Empty;
				result.sFoundCompanyTYPE = String.Empty;
				result.sFoundContactTYPE = String.Empty;
				result.sFoundNewCompanyName = String.Empty;
				return result;
			}
		}

		[Serializable]
		public struct Lease_References
		{
			public int journ_id;
			public int comp_id;
			public int contact_id;
			public string Contact_Type;
			public double percent;
			public string poc;
			public static Lease_References CreateInstance()
			{
				Lease_References result = new Lease_References();
				result.Contact_Type = String.Empty;
				result.poc = String.Empty;
				return result;
			}
		}

		// 04/16/2008 - By David D. Cruger
		// Added for saving company information on return to the company record
		[Serializable]
		public class Company_Form_Saved_Info //gap-note Struct changed to class. VBUC feature.
		{
			public int lCompId; // Make Sure We Are Coming Back To The Same Company
			public int lJournId; // Same as CompId
			public short iDeliveryPositionComboListIndex; // Saves the Delivery Positon Combo
			public short ichkLimitAircraftList; // Saves The Check Box [x] Only Show First
			public int lHowManyAircraft; // Saves The How Many Aircraft Input Box Value
			public int lAircraftGridRow; // Saves The Aircraft List Grid Row
			public int lAircraftGridTopRow; // Saves The Aircraft List Grid TopRow
			public short iTab;
			public int lDocInProcGridRow;
			public int lDocInProcGridTopRow;
		}

		// type for saving wanted aircraft info on company form
		[Serializable]
		public struct t_company_save_wanted_info
		{
			public int save_amwant_id;
			public string save_amwant_model;
			public int save_amwant_modelID;
			public string save_amwant_listed_date;
			public string save_amwant_verified_date;
			public string save_amwant_start_year;
			public string save_amwant_end_year;
			public double save_amwant_max_price;
			public int save_amwant_max_aftt;
			public string save_amwant_accept_damage_cur;
			public string save_amwant_accept_damage_hist;
			public string save_amwant_notes;
			public string save_amwant_yearnote;
			public string save_amwant_pricenote;
			public short save_amwant_auto_distribute_flag;
			public string save_amwant_auto_distribute_email;
			public string save_amwant_auto_distribute_replyname;
			public static t_company_save_wanted_info CreateInstance()
			{
				t_company_save_wanted_info result = new t_company_save_wanted_info();
				result.save_amwant_model = String.Empty;
				result.save_amwant_listed_date = String.Empty;
				result.save_amwant_verified_date = String.Empty;
				result.save_amwant_start_year = String.Empty;
				result.save_amwant_end_year = String.Empty;
				result.save_amwant_accept_damage_cur = String.Empty;
				result.save_amwant_accept_damage_hist = String.Empty;
				result.save_amwant_notes = String.Empty;
				result.save_amwant_yearnote = String.Empty;
				result.save_amwant_pricenote = String.Empty;
				result.save_amwant_auto_distribute_email = String.Empty;
				result.save_amwant_auto_distribute_replyname = String.Empty;
				return result;
			}
		}

		// type for saving wanted aircraft info on company form
		[Serializable]
		public struct t_company_save_phone_info
		{

			public bool company_phone_add_flag;
			public bool company_only_change_is_hide_flag;

			public string company_phone_original_full;
			public string company_phone_original_type;
			public short company_phone_original_hide;
			public short company_phone_original_row;
			public string company_phone_new_number;
			public string company_phone_confirmdate;

			public string contact_phone_toEdit; // PHONE NUMBER TO REMOVE
			public string contact_phone_typeToEdit; // PHONE NUMBER TYPE TO REMOVE
			public string contact_phone_new; // LIST OF NEW PHONE NUMBERS TO BE UPDATED ON CONTACT RECORDS
			public string contact_phone_typeNew; // LIST OF NEW PHONE NUMBERS TO BE UPDATED ON CONTACT RECORDS

			public string company_phone_delete_number;
			public string company_phone_delete_subject;
			public bool company_phone_delete_flag;

			public bool company_phone1_changed_flag;
			public bool company_phone2_changed_flag;
			public int company_phone_id; // added MSW - 9/6/22

			public static t_company_save_phone_info CreateInstance()
			{
				t_company_save_phone_info result = new t_company_save_phone_info();
				result.company_phone_original_full = String.Empty;
				result.company_phone_original_type = String.Empty;
				result.company_phone_new_number = String.Empty;
				result.company_phone_confirmdate = String.Empty;
				result.contact_phone_toEdit = String.Empty;
				result.contact_phone_typeToEdit = String.Empty;
				result.contact_phone_new = String.Empty;
				result.contact_phone_typeNew = String.Empty;
				result.company_phone_delete_number = String.Empty;
				result.company_phone_delete_subject = String.Empty;
				return result;
			}
		}

		// type for saving company info on company form
		[Serializable]
		public struct t_company_save_info
		{

			public int s_comp_id;
			public string s_comp_name;
			public string s_comp_name_alt_type;
			public string s_comp_name_alt;
			public string s_comp_address1;
			public string s_comp_address2;
			public string s_comp_city;
			public string s_comp_state;
			public string s_comp_country;
			public string s_comp_zip_code;
			public string s_comp_timezone;
			public string s_comp_language;
			public string s_comp_web_address;
			public string s_comp_email_address;
			public string s_comp_description;
			public string s_comp_ticker_symbol;
			public string s_comp_marketing_notes;
			public string s_comp_customer_notes; // added msw 3/28/13
			public string s_comp_sic_code;
			public string s_comp_dunnandbrad;
			public int s_comp_fractowr_contact_id;
			public int s_comp_fractowr_id;
			public string s_comp_fractowr_notes;
			public string s_comp_assign_flag;
			public string s_comp_account_id;
			public string s_comp_acpros_flag;
			public string s_comp_do_not_solicit;
			public string s_comp_agency_type;
			public short s_comp_government_id;
			public string s_comp_business_type;
			public string s_comp_account_type;
			public string s_comp_account_callback_date;
			public string s_comp_abi_callback_date;
			public string s_comp_last_contact_date;
			public string s_comp_abi_last_contact_date;
			public string s_comp_service;
			public string s_comp_active_flag;
			public string s_comp_hide_flag;
			public string s_comp_awaitdoc_flag;
			public string s_comp_product_business_flag;
			public string s_comp_product_commercial_flag;
			public string s_comp_product_helicopter_flag;
			public string s_comp_product_airbp_flag;
			public string s_comp_product_abi_flag;
			public string s_comp_product_regional_flag;
			public string s_comp_product_yacht_flag;
			public string s_comp_marketing_rep; // 10/23/2015 - Added By David D. Cruger
			public string s_comp_line_access_code; // 02/22/2018 - Added By David D. Cruger
			public string s_comp_contact_address_flag; // 02/19/2016 - Added By David D. Cruger
			public string s_comp_yacht_callback_date; // 03/24/2017 - Added MSW
			public string s_comp_secondary_callback;
			public int s_comp_aport_id; // 06/18/2019 - Added By David D. Cruger

			public static t_company_save_info CreateInstance()
			{
				t_company_save_info result = new t_company_save_info();
				result.s_comp_name = String.Empty;
				result.s_comp_name_alt_type = String.Empty;
				result.s_comp_name_alt = String.Empty;
				result.s_comp_address1 = String.Empty;
				result.s_comp_address2 = String.Empty;
				result.s_comp_city = String.Empty;
				result.s_comp_state = String.Empty;
				result.s_comp_country = String.Empty;
				result.s_comp_zip_code = String.Empty;
				result.s_comp_timezone = String.Empty;
				result.s_comp_language = String.Empty;
				result.s_comp_web_address = String.Empty;
				result.s_comp_email_address = String.Empty;
				result.s_comp_description = String.Empty;
				result.s_comp_ticker_symbol = String.Empty;
				result.s_comp_marketing_notes = String.Empty;
				result.s_comp_customer_notes = String.Empty;
				result.s_comp_sic_code = String.Empty;
				result.s_comp_dunnandbrad = String.Empty;
				result.s_comp_fractowr_notes = String.Empty;
				result.s_comp_assign_flag = String.Empty;
				result.s_comp_account_id = String.Empty;
				result.s_comp_acpros_flag = String.Empty;
				result.s_comp_do_not_solicit = String.Empty;
				result.s_comp_agency_type = String.Empty;
				result.s_comp_business_type = String.Empty;
				result.s_comp_account_type = String.Empty;
				result.s_comp_account_callback_date = String.Empty;
				result.s_comp_abi_callback_date = String.Empty;
				result.s_comp_last_contact_date = String.Empty;
				result.s_comp_abi_last_contact_date = String.Empty;
				result.s_comp_service = String.Empty;
				result.s_comp_active_flag = String.Empty;
				result.s_comp_hide_flag = String.Empty;
				result.s_comp_awaitdoc_flag = String.Empty;
				result.s_comp_product_business_flag = String.Empty;
				result.s_comp_product_commercial_flag = String.Empty;
				result.s_comp_product_helicopter_flag = String.Empty;
				result.s_comp_product_airbp_flag = String.Empty;
				result.s_comp_product_abi_flag = String.Empty;
				result.s_comp_product_regional_flag = String.Empty;
				result.s_comp_product_yacht_flag = String.Empty;
				result.s_comp_marketing_rep = String.Empty;
				result.s_comp_line_access_code = String.Empty;
				result.s_comp_contact_address_flag = String.Empty;
				result.s_comp_yacht_callback_date = String.Empty;
				result.s_comp_secondary_callback = String.Empty;
				return result;
			}
		}

		public static Company_Form_Saved_Info cfsiCompanyInfo = new Company_Form_Saved_Info();

		public static IList<frm_Find_Company> find_frm_collection = null; //gap-note This property was converted to OrderedDictionary. Manual change to IList<frm_find_Company> to set correctly the type.

		//Global new_frm_Yacht                    As frm_Yacht
		public static frm_CompanyAdd new_frm_CompanyAdd = null;
		public static frm_Company new_frm_Company = null;

		// Company Recordsets - Used for Creating a "Current" Company Record
		public static ADORecordSetHelper snpCreateComp_Comp = null;
		public static ADORecordSetHelper snpCreateComp_Contact = null;
		public static ADORecordSetHelper snpCreateComp_Phone = null;
		public static ADORecordSetHelper snpCreateComp_BusType = null;

		// Aircraft Recordsets - Used for Transactions
		public static ADORecordSetHelper snp_TransAircraft = null;
		public static ADORecordSetHelper snp_TransAircraft_Reference = null;
		public static ADORecordSetHelper snp_TransShare_Reference = null;
		public static ADORecordSetHelper snp_TransAircraft_Features = null;
		public static ADORecordSetHelper snp_TransAircraft_Avionics = null;
		public static ADORecordSetHelper snp_TransAircraft_Certified = null;
		public static ADORecordSetHelper snp_TransAircraft_Specification = null;
		public static ADORecordSetHelper snp_TransAircraft_Details = null;
		public static ADORecordSetHelper snp_TransAircraft_FAA_Document = null;

		// Aircraft Company Recordsets - Used for Transactions
		public static ADORecordSetHelper snp_TransAircraft_Companies = null;
		public static ADORecordSetHelper snp_TransAircraft_OtherCompanies = null; //aey 9/10/04
		public static ADORecordSetHelper snp_TransAircraft_Contacts = null;
		public static ADORecordSetHelper snp_TransAircraft_Company_Phones = null;
		public static ADORecordSetHelper snp_TransAircraft_Company_Btypes = null;
		public static ADORecordSetHelper snp_TransAircraft_Company_Certs = null;

		// Buyer Recordsets - Used for Transactions
		public static ADORecordSetHelper snp_Buyer_Company = null;
		public static ADORecordSetHelper snp_Buyer_Contacts = null;
		public static ADORecordSetHelper snp_Buyer_Company_Phones = null;
		public static ADORecordSetHelper snp_Buyer_Company_Btypes = null;
		public static ADORecordSetHelper snp_Buyer_Company_Certs = null;

		// RegisteredAs Recordsets - Used for Transactions
		public static ADORecordSetHelper snp_RegisteredAs_Company = null;
		public static ADORecordSetHelper snp_RegisteredAs_Contacts = null;
		public static ADORecordSetHelper snp_RegisteredAs_Company_Phones = null;
		public static ADORecordSetHelper snp_RegisteredAs_Company_Btypes = null;
		public static ADORecordSetHelper snp_RegisteredAs_Company_Certs = null;

		// General Company Recordsets - Used for Transactions
		public static ADORecordSetHelper snp_Company = null;
		public static ADORecordSetHelper snp_Contacts = null;
		public static ADORecordSetHelper snp_Company_Phones = null;
		public static ADORecordSetHelper snp_Company_Btypes = null;
		public static ADORecordSetHelper snp_Company_Certs = null;

		public static ADORecordSetHelper snp_Fractions_Pending = null;

		public static e_first_start_form tStart_Form = (e_first_start_form) 0;

		public static bool bTraceCall = false;
		public static bool bKeepAircraftFocus = false;
		public static bool bKeepCompanyFocus = false;
		public static bool bKeepTransactionFocus = false;
		public static bool RefreshACFromJournal = false;
		public static bool bCallShowAndLoadOnlyOnce = false;
		public static bool b_InCommercialDB = false;
		public static string tmpCompAccountID = "";
		public static bool glbl_ContactEmailCounts = false;

		// **************************************************************
		// DEFINE NEW ARRAYS FOR LOOKUP TABLES
		public static string[] PhoneType_Array = null;
		public static string[] TimeZone_Array = null;
		public static string[] State_Array = null;
		public static string[] Country_Array = null;
		public static string[, ] AccountType_Array = null;
		public static string[] AgencyType_Array = null;
		public static string[, ] BusinessType_Array = null;
		public static string[, ] ContactType_Array = null;
		public static string[] Language_Array = null;
		public static string[] AccountRep_Array = null;
		public static Array ServicesUsed_Array = null;
		public static string[] ContactSirname_Array = null;
		public static string[] ContactSuffix_Array = null;
		public static string[] TitleGroup_Array = null;
		public static string[] CompanyProduct_Array = null;
		public static string[, ] PurchaseQuestion_Array = null;
		public static string[] GovTypeCallBack_Array = null;
		public static string[, ] WantedModel_Array = null;
		public static string[] ContactTitle_Array = null;
		public static string[] Continent_Array = null;
		public static string[] MailList_Array = null; // added rtw - 4/26/2011
		public static string[] Currency_Array = null; // added MSW - 3/15/2012
		public static string[] Engine_Array1 = null; // added MSW - 3/16/2012
		public static string[] Engine_ArrayData = null; // added MSW - 3/16/2012
		public static string[] Airframe_Maint_Prog = null; // added MSW - 3/16/2012
		public static string[] Airframe_Maint_Prog_Data = null; // added MSW - 3/18/2012

		public static string[] Airframe_Maint_Prog_History = null; // added DDC - 06/26/2019
		public static string[] Airframe_Maint_Prog_Data_History = null; // added DDC - 06/26/2019

		public static string[] Airframe_Maint_Track_Prog = null; // added MSW - 3/16/2012
		public static string[] Airframe_Maint_Track_Prog_Data = null; // added MSW - 3/18/2012

		public static bool bPhoneType_IsLoaded = false;
		public static bool bTimeZone_IsLoaded = false;
		public static bool bState_IsLoaded = false;
		public static bool bCountry_IsLoaded = false;
		public static bool bAccountType_IsLoaded = false;
		public static bool bAgencyType_IsLoaded = false;
		public static bool bBusinessType_IsLoaded = false;
		public static bool bContactType_IsLoaded = false;
		public static bool bContactTitle_IsLoaded = false;
		public static bool bLanguage_IsLoaded = false;
		public static bool bAccountRep_IsLoaded = false;
		public static bool bServicesUsed_IsLoaded = false;
		public static bool bMailLists_IsLoaded = false; // added rtw - 4/26/2011
		public static bool bCurrency_IsLoaded = false; // added MSW - 3/15/2012
		public static bool bEngine1_IsLoaded = false; // added MSW - 3/16/2012
		public static bool bEngine2_IsLoaded = false; // added MSW - 3/16/2012
		public static bool bAirframeMaintProg_IsLoaded = false; // added MSW - 3/16/2012
		public static bool bAirframeMaintProgHistory_IsLoaded = false; // added DDC - 06/26/2019
		public static bool bAirframeMaintTrackProg_IsLoaded = false; // added MSW - 3/16/2012

		public static bool bContactSirname_IsLoaded = false;
		public static bool bContactSuffix_IsLoaded = false;
		public static bool bTitleGroup_IsLoaded = false;
		public static bool bCompanyProduct_IsLoaded = false;
		public static bool bPurchaseQuestion_IsLoaded = false;
		public static bool bWantedModel_IsLoaded = false;
		public static bool bContinent_IsLoaded = false;
		public static bool isYacht_Selected_OnLoad = false; // added MSW 5/3/12

		public static string gbl_database_name = ""; // ADDED RTW 4/1/2021
	}
}