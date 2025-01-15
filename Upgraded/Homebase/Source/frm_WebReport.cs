using Microsoft.VisualBasic;
using System;
using System.Text;
using System.Windows.Forms;
using UpgradeHelpers.DB.ADO;
using UpgradeHelpers.Gui.Utils;
using UpgradeHelpers.Helpers;
using UpgradeStubs;

namespace JETNET_Homebase
{
	internal partial class frm_WebReport
		: System.Windows.Forms.Form
	{


		public string PassedWhereClause = "";
		public string WhichReport = "";
		public int PassedCompID = 0;
		public int PassedJournID = 0;
		public string PassedFileName = "";
		public int PassedModelID = 0;
		public string PassedMMSI = "";
		public int ac_id = 0;
		public int Ac_Maint_ID = 0;
		public int MPM_ID = 0;
		public string PassedPubLink = "";

		private object gobjIE = null; // Open In A New Version Of IE
		public frm_WebReport()
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



		public void Load_Report()
		{

			string URL = "";
			try
			{

				string strUserId = "";
				string strUserType = "";
				string sTextAddress = "";
				bool force_firefox = false;


				string temp_email = "";
				string temp_pass = "";
				string encoded_page_url = "";


				brw_Report.Visible = false;
				pnl_Please_Wait.Visible = true;
				force_firefox = false;

				strUserId = ($"{Convert.ToString(modAdminCommon.snp_User["user_id"])} ").Trim().ToUpper();
				strUserType = ($"{Convert.ToString(modAdminCommon.snp_User["user_type"])} ").Trim();


				switch(WhichReport)
				{
					case "View External Document" : case "View Document" :  // View Document 
						URL = PassedFileName; 
						 
						break;
					case "View Document in Process" : case "View NTSB in Process" : 
						URL = PassedFileName; 
						 
						break;
					case "Image Uploader Test" : 

						 
						//encoded_page_url = "/view_template.aspx?ViewID=18&ViewName=Prospect+Management&noMaster=false" 
						encoded_page_url = $"/ImageUploader.aspx?ac_id={ac_id.ToString()}&Journ_ID=0&gbl_User_ID={modAdminCommon.gbl_User_ID}&test=1"; 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						URL = $"http://www.homebasetest.com{encoded_page_url}"; 
						 
						break;
					case "Image Uploader Live" : 

						 
						//encoded_page_url = "/view_template.aspx?ViewID=18&ViewName=Prospect+Management&noMaster=false" 
						encoded_page_url = $"/ImageUploader.aspx?ac_id={ac_id.ToString()}&Journ_ID=0&gbl_User_ID={modAdminCommon.gbl_User_ID}"; 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						URL = $"http://www.homebase.com{encoded_page_url}"; 
						 
						break;
					case "Prospect Manager" : 

						 
						encoded_page_url = "/view_template.aspx?ViewID=18&ViewName=Prospect+Management&noMaster=false"; 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						encoded_page_url = URLEncoding(encoded_page_url); 
						 
						URL = $"http://www.homebase.com/default.aspx?2={temp_email}&1={temp_pass}&swap=true&pageURL={encoded_page_url}"; 
						 
						break;
					case "Company Details HB" : 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						encoded_page_url = $"/DisplayCompanyDetail.aspx?compid={PassedCompID.ToString()}"; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						encoded_page_url = URLEncoding(encoded_page_url); 
						 
						URL = $"http://www.homebase.com/default.aspx?2={temp_email}&1={temp_pass}&swap=true&pageURL={encoded_page_url}"; 

						 
						break;
					case "Homebase Login" : 

						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						 
						URL = $"http://www.homebase.com/default.aspx?2={temp_email}&1={temp_pass}&swap=true"; 
						 
						break;
					case "Company Services Used" : 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						encoded_page_url = $"/homeTables.aspx?type_of=Company&sub_type_of=ServicesUsed&comp_id={PassedCompID.ToString()}"; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						encoded_page_url = URLEncoding(encoded_page_url); 
						 
						URL = $"http://www.homebase.com/default.aspx?2={temp_email}&1={temp_pass}&swap=true&pageURL={encoded_page_url}"; 
						URL = URL; 
						 
						break;
					case "Action Items" : 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						 
						URL = $"http://www.homebase.com/default.aspx?2={temp_email}&1={temp_pass}&swap=true&pageURL=adminActions.aspx"; 
						 
						break;
					case "Aircraft Details" :  // AIRCRAFT DETAILED REPORT 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						encoded_page_url = $"/DisplayAircraftDetail.aspx?jid=0&acid={modAdminCommon.gbl_Aircraft_ID.ToString()}";  // &&homebase=Y ' removed per amanda 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						encoded_page_url = URLEncoding(encoded_page_url); 
						 
						URL = $"http://www.jetnetevolution.com/default.aspx?2={temp_email}&1={temp_pass}&swap=true&pageURL={encoded_page_url}&apiLog=true"; 
						 
						break;
					case "Company Sold Transactions" : 
						URL = $"http://www.homebase.com/PDF_Creator.aspx?export_type=Company Details&comp_id={PassedCompID.ToString()}&r_id=999&homebase=Y"; 
						 
						break;
					case "Company Details" : 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						encoded_page_url = $"/DisplayCompanyDetail.aspx?&compid={PassedCompID.ToString()}"; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						encoded_page_url = URLEncoding(encoded_page_url); 
						 
						URL = $"http://www.jetnetevolution.com/default.aspx?2={temp_email}&1={temp_pass}&swap=true&pageURL={encoded_page_url}&apiLog=true"; 
						 
						break;
					case "Company Details Email" : 
						 
						URL = $"http://www.homebase.com/PDF_Creator.aspx?export_type=Company Details&comp_id={PassedCompID.ToString()}&r_id=47&homebase=Y"; 
						 
						break;
					case "Marine Traffic" : 
						URL = $"http://www.marinetraffic.com/en/ais/details/ships/mmsi:{PassedMMSI}/"; 
						 
						break;
					case "Yacht_Pub" : 
						URL = PassedPubLink; 
						break;
					case "Research_Action" : 
						URL = PassedPubLink; 

						 
						encoded_page_url = "/view_template.aspx?ViewID=18&ViewName=Prospect+Management&noMaster=false"; 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						encoded_page_url = URLEncoding(encoded_page_url); 
						 
						URL = $"http://www.homebase.com/default.aspx?2={temp_email}&1={temp_pass}&swap=true&pageURL={encoded_page_url}"; 
						 
						break;
					case "Aircraft Model" :  // AIRCRAFT MODEL SPECS - REFERENCE CARD REPORT 
						URL = $"{modAdminCommon.gbl_WebSite}internal.asp?destination=DisplayModelSpecs.asp{modCommon.pubf_URLEncode($"?id={PassedModelID.ToString()}")}"; 
						break;
					case "Aircraft Generic Model" :  // AIRCRAFT MODEL SPECS - REFERENCE CARD REPORT 
						 
						encoded_page_url = $"/viewtopdf.aspx?viewID=998&modelList={PassedModelID.ToString()}&selectViewTimeSpan=12&generic=Y"; 
						 
						temp_email = modAdminCommon.gbl_Evo_Email_Address; 
						temp_pass = modAdminCommon.gbl_Evo_Password; 
						 
						temp_email = Base64_Encode(temp_email); 
						temp_pass = Base64_Encode(temp_pass); 
						encoded_page_url = URLEncoding(encoded_page_url); 
						 
						URL = $"http://www.jetnetevolution.com/default.aspx?2={temp_email}&1={temp_pass}&swap=true&pageURL={encoded_page_url}&apiLog=true"; 

						 
						break;
					case "Op Costs" :  // AIRCRAFT MODEL OPERATING COST REPORT 
						URL = $"{modAdminCommon.gbl_WebSite}internal.asp?destination=DisplayModelOpCosts.asp{modCommon.pubf_URLEncode($"?id={PassedModelID.ToString()}", true)}"; 
						 
						break;
					case "Aircraft List" : 
						URL = $"{modAdminCommon.gbl_WebSite}internal.asp?destination=AircraftList.asp{modCommon.pubf_URLEncode($"?Query=SELECT DISTINCT ac_id, ac_upd_date, ac_exclusive_flag, ac_lease_flag, amod_make_name, amod_model_name, ac_ser_no_full, ac_forsale_flag, amod_id, ac_year, ac_reg_no, ac_Status, comp_name, comp_city, comp_state, ac_asking, ac_delivery, ac_delivery_date, ac_list_date, ac_asking_price, actype_name FROM Aircraft WITH(NOLOCK), Aircraft_Model WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK), Company WITH(NOLOCK), Aircraft_Contact_Type WITH(NOLOCK) WHERE (ac_amod_id = amod_id AND ac_journ_id = 0) AND (ac_id = cref_ac_id AND cref_journ_id = ac_journ_id) AND (comp_id = cref_comp_id AND comp_journ_id = cref_journ_id) AND cref_primary_poc_flag = 'Y' AND cref_contact_type = actype_code {PassedWhereClause}")}"; 
						 
						break;
					case "Fractional Programs" : 
						URL = $"{modAdminCommon.gbl_WebSite}internal.asp?destination=ListProgramManagers.asp"; 
						 
						break;
					case "Company List" : 
						if (PassedWhereClause.IndexOf("amod_") >= 0 || PassedWhereClause.IndexOf("ac_") >= 0)
						{

							URL = $"{modAdminCommon.gbl_WebSite}internal.asp?destination=ListCompanies.asp{modCommon.pubf_URLEncode($"?Query=SELECT DISTINCT comp_name, comp_city, comp_state, comp_country, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, cref_contact_type FROM Company WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK), Contact WITH(NOLOCK), Aircraft WITH(NOLOCK), Aircraft_Model WITH(NOLOCK) WHERE (comp_id=cref_comp_id and comp_journ_id = cref_journ_id) and (cref_contact_id=contact_id and contact_journ_id = cref_journ_id) and (cref_ac_id=ac_id and ac_journ_id = cref_journ_id) and ac_amod_id=amod_id AND {PassedWhereClause.Substring(Math.Max(PassedWhereClause.Length - (Strings.Len(PassedWhereClause) - 7), 0))} GROUP BY comp_name, comp_city, comp_state, comp_country, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, cref_contact_type ")}";

						}
						else
						{

							URL = $"{modAdminCommon.gbl_WebSite}internal.asp?destination=ListCompanies.asp{modCommon.pubf_URLEncode($"?Query=SELECT DISTINCT comp_name, comp_city, comp_state, comp_country, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, cref_contact_type FROM Company WITH(NOLOCK), Aircraft_Reference WITH(NOLOCK), Contact WITH(NOLOCK) WHERE (comp_id=cref_comp_id and comp_journ_id = cref_journ_id) and (cref_contact_id=contact_id and contact_journ_id = cref_journ_id) AND {PassedWhereClause.Substring(Math.Max(PassedWhereClause.Length - (Strings.Len(PassedWhereClause) - 7), 0))} GROUP BY comp_name, comp_city, comp_state, comp_country, contact_sirname, contact_first_name, contact_middle_initial, contact_last_name, contact_suffix, cref_contact_type ")}";

						} 
						 
						break;
					case "Company Help" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/JetNet_RA_Help/introductiontocompaniesandcontacts.htm"; 
						 
						break;
					case "Aircraft Help" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/JetNet_RA_Help/introductiontoaircraft2.htm"; 
						 
						break;
					case "Homebase Record" : 
						 
						URL = $"http://www.homebase.com/DisplayAircraftDetail.aspx?jid=0&homebase=Y&local=Y&acid={modAdminCommon.gbl_Aircraft_ID.ToString()}"; 
						 
						force_firefox = true; 
						// 
						break;
					case "Performance Specs" : 
						 
						URL = $"http://www.homebase.com/homebasePerformance.aspx?AmodID={ac_id.ToString()}&ac_id={modAdminCommon.gbl_Aircraft_ID.ToString()}&homebase=Y"; 
						force_firefox = true; 
						// 
						break;
					case "Op Costs2" : 
						 
						URL = $"http://www.homebase.com/homebaseOpCosts.aspx?AmodID={ac_id.ToString()}";  // really amod_id & "&homebase=Y" 
						force_firefox = true; 
						 
						break;
					case "MakeModel Help" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/JetNet_RA_Help/introductiontoaircraft1.htm"; 
						 
						break;
					case "Main Help" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/JetNet_RA_Help/HelpContents1.htm"; 
						 
						break;
					case "Homebase Release" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/help/admin/homebase_release_notes.asp"; 
						 
						break;
					case "Callbacks Help" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/JetNet_RA_Help/introductiontocallbackprocess.htm"; 
						 
						break;
					case "Journal Help" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/JetNet_RA_Help/introductiontojournalentries.htm"; 
						 
						break;
					case "Transaction Help" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/JetNet_RA_Help/introductiontoaircrafttransactionprocessingandhistory.htm"; 
						 
						break;
					case "Subscription Help" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/JetNet_RA_Help/introductiontojetneton.lineweblogin.registrationprocess.htm"; 
						 
						// 07/27/2004 - By David D. Cruger 
						break;
					case "Customer Record" :  // Technical Department Customer Record 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/customer/customerrecord.asp?CompId={PassedCompID.ToString()}&Header=Yes&Main=Yes&Service=Yes&Contact=Yes&Activity=Yes"; 
						 
						break;
					case "List Survey Responses" : 
						 
						// 03/07/2013 - By David D. Cruger; Added 
						URL = $"{modAdminCommon.gbl_WebSite}/help/listcompanyjetnetsurveyresponses.asp?CompId={PassedCompID.ToString()}"; 
						 
						break;
					case "Customer, CRM Mkt, Homebase Notes" : 
						 
						URL = $"{modAdminCommon.gbl_WebSite}/customer/customerrecord.asp?CompId={PassedCompID.ToString()}&TechId=0&Header=No&Main=No&AllNotes=Yes&Top=5"; 
						 
						break;
					case "MPM Management" : 

						 
						URL = $"http://www.homebase.com/adminMPM.aspx?show_domain_users=true&id={MPM_ID.ToString()}&homebase=Y"; 

						 
						break;
					case "View Maintenance Details" : 
						 
						if (Ac_Maint_ID > 0)
						{
							URL = $"http://www.homebase.com/maintenance.aspx?acID={ac_id.ToString()}&jID=0&maint_row={Ac_Maint_ID.ToString()}&homebase=Y";
						}
						else
						{
							URL = $"http://www.homebase.com/maintenance.aspx?acID={ac_id.ToString()}&jID=0&homebase=Y";
						} 
						 
						break;
					case "ADP_Report" : 
						 
						if (modAdminCommon.gbl_User_ID == "mvit")
						{
							URL = "C:\\Program Files\\Jetnet Homebase\\DP-Report.html";
						}
						else
						{
							URL = "C:/Users/Public/Documents/DP-Report.html";
						} 
						 
						break;
					case "AIO_Report" : 
						 
						if (modAdminCommon.gbl_User_ID == "mvit")
						{
							URL = "C:\\Program Files\\Jetnet Homebase\\AIO-Report.html";
						}
						else
						{
							URL = "C:/Users/Public/Documents/AIO-Report.html";
						} 
						 
						break;
					case "Company Details Report (API)" : 
						 
						 
						URL = ""; 
						 
						if (modCommon.JAPI.bHasAPILogin)
						{

							modCommon.JETNETAPI_GetSecurityToken(modCommon.JAPI.strEMail, modCommon.JAPI.strPassword, ref modCommon.JAPI.strToken, ref modCommon.JAPI.strHeader);

							if (modCommon.JAPI.strToken != "" && modCommon.JAPI.strHeader != "")
							{
								URL = $"https://www.jetnetevolution.com/DisplayCompanyDetail.aspx?compid={PassedCompID.ToString()}&JID={PassedJournID.ToString()}&securityToken={modCommon.JAPI.strToken}";
							}
							else
							{
								MessageBox.Show("Unable to Generate JETNET API Security Token", AssemblyHelper.GetTitle(System.Reflection.Assembly.GetExecutingAssembly()), MessageBoxButtons.OK, MessageBoxIcon.Error);
							}

						}  // If .bHasAPILogin = True Then 
						  // JAPI 
						 
						break;
				} // Select Case WhichReport

				sTextAddress = URL;


				if (sTextAddress.Trim() != "")
				{


					if (force_firefox)
					{
						try
						{
							modCommon.ShellOpenURLInBrowser("M", sTextAddress); // changed to force c for chrome, changed back to M for firefox - MSW - 12/19/20
						}
						catch
						{
						}
					}
					else
					{
						try
						{
							modCommon.ShellOpenURLInBrowser(modAdminCommon.gbl_User_Browser, sTextAddress);
						}
						catch
						{
						}
					}

				} // If Trim(sTextAddress) <> "" Then

				this.Hide();
			}
			catch
			{

				modAdminCommon.Report_Error($"Load_Report_Error:URL={URL}");

				this.Close();
			}

		}

		private string Base64_Encode(string strIn)
		{

			int C1 = 0;
			int C2 = 0;
			int c3 = 0;
			int w1 = 0;
			int w2 = 0;
			int w3 = 0;
			int w4 = 0;

			StringBuilder strOut = new StringBuilder();

			int tempForEndVar = Strings.Len(strIn);
			for (int n = 1; n <= tempForEndVar; n += 3)
			{

				C1 = Strings.Asc(strIn.Substring(Math.Min(n - 1, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - (n - 1))))[0]);
				C2 = Strings.Asc($"{strIn.Substring(Math.Min(n, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - n)))}{Strings.Chr(0).ToString()}"[0]);
				c3 = Strings.Asc($"{strIn.Substring(Math.Min(n + 1, strIn.Length), Math.Min(1, Math.Max(0, strIn.Length - (n + 1))))}{Strings.Chr(0).ToString()}"[0]);

				w1 = Convert.ToInt32(Math.Floor(C1 / 4d));
				w2 = Convert.ToInt32((C1 & 3) * 16 + Math.Floor(C2 / 16d));

				if (Strings.Len(strIn) >= n + 1)
				{
					w3 = Convert.ToInt32((C2 & 15) * 4 + Math.Floor(c3 / 64d));
				}
				else
				{
					w3 = -1;
				}

				if (Strings.Len(strIn) >= n + 2)
				{
					w4 = c3 & 63;
				}
				else
				{
					w4 = -1;
				}

				strOut.Append($"{MimeEncode(w1)}{MimeEncode(w2)}{MimeEncode(w3)}{MimeEncode(w4)}");

			} // n

			return strOut.ToString();

		} // Base64_Encode


		private string MimeEncode(int intIn)
		{

			if (intIn >= 0)
			{
				return modSubscription.MBABase64Chars.Substring(Math.Min(intIn, modSubscription.MBABase64Chars.Length), Math.Min(1, Math.Max(0, modSubscription.MBABase64Chars.Length - intIn)));
			}
			else
			{
				return "=";
			}

		} // MimeEncode

		private string URLEncoding(string strText)
		{

			string strChar1 = "";
			string strChar2 = "";

			StringBuilder strResults = new StringBuilder();
			int iLen1 = Strings.Len(strText);
			if (iLen1 > 0)
			{

				int tempForEndVar = iLen1;
				for (int iCnt1 = 1; iCnt1 <= tempForEndVar; iCnt1++)
				{

					strChar1 = strText.Substring(Math.Min(iCnt1 - 1, strText.Length), Math.Min(1, Math.Max(0, strText.Length - (iCnt1 - 1)))); //  Single Char
					strChar2 = strChar1; //  Equals Char1

					//If strChar1 = Chr(32) Then strChar2 = "%20"   '    - Space
					if (strChar1 == "\"")
					{
						strChar2 = "%22";
					} //  " - Double Quote
					if (strChar1 == Strings.Chr(35).ToString())
					{
						strChar2 = "%23";
					} //  # - Pound Sign
					if (strChar1 == Strings.Chr(36).ToString())
					{
						strChar2 = "%24";
					} //  $ - Dollar Sign
					if (strChar1 == Strings.Chr(37).ToString())
					{
						strChar2 = "%25";
					} //  % - Percentage
					if (strChar1 == Strings.Chr(38).ToString())
					{
						strChar2 = "%26";
					} //  & - Ampersand
					if (strChar1 == Strings.Chr(43).ToString())
					{
						strChar2 = "%2B";
					} //  + - Plus Sign
					if (strChar1 == Strings.Chr(44).ToString())
					{
						strChar2 = "%2C";
					} //  , - Comma
					if (strChar1 == Strings.Chr(47).ToString())
					{
						strChar2 = "%2F";
					} //  / - Forward Slash

					if (strChar1 == Strings.Chr(58).ToString())
					{
						strChar2 = "%3A";
					} //  : - Colon
					if (strChar1 == Strings.Chr(59).ToString())
					{
						strChar2 = "%3B";
					} //  ; - Semi-Colon
					if (strChar1 == Strings.Chr(60).ToString())
					{
						strChar2 = "%3C";
					} //  < - Less Than Sign
					if (strChar1 == Strings.Chr(61).ToString())
					{
						strChar2 = "%3D";
					} //  = - Equal Sign
					if (strChar1 == Strings.Chr(62).ToString())
					{
						strChar2 = "%3E";
					} //  > - Greater Than Sign
					if (strChar1 == Strings.Chr(63).ToString())
					{
						strChar2 = "%3F";
					} //  ? - Question Mark
					if (strChar1 == Strings.Chr(64).ToString())
					{
						strChar2 = "%40";
					} //  @ - AT Sign

					if (strChar1 == Strings.Chr(91).ToString())
					{
						strChar2 = "%5B";
					} //  [ - Left Bracket
					if (strChar1 == Strings.Chr(92).ToString())
					{
						strChar2 = "%5C";
					} //  \ - Back Slash
					if (strChar1 == Strings.Chr(93).ToString())
					{
						strChar2 = "%5D";
					} //  ] - Right Bracket
					if (strChar1 == Strings.Chr(94).ToString())
					{
						strChar2 = "%5E";
					} //  ^ - Accent Sign
					if (strChar1 == Strings.Chr(96).ToString())
					{
						strChar2 = "%60";
					} //  ' - Single Quote

					if (strChar1 == Strings.Chr(123).ToString())
					{
						strChar2 = "%7B";
					} //  { - Left Curly Brace
					if (strChar1 == Strings.Chr(124).ToString())
					{
						strChar2 = "%7C";
					} //  | - Pipe Char
					if (strChar1 == Strings.Chr(125).ToString())
					{
						strChar2 = "%7D";
					} //  } - Right Curly Brace

					strResults.Append(strChar2);

				}

			} // If iLen1 > 0 Then

			return strResults.ToString();

		} // URLEncoding


		private void Form_Activated(Object eventSender, EventArgs eventArgs)
		{
			if (ActivateHelper.myActiveForm != eventSender)
			{
				ActivateHelper.myActiveForm = (Form) eventSender;

				modCommon.CenterFormOnHomebaseMainForm(this);

				Load_Report();

			}
		}

		private void Form_Initialize()
		{

			PassedWhereClause = "";
			WhichReport = "";
			PassedCompID = 0;
			PassedFileName = "";
			PassedModelID = 0;
			PassedJournID = 0;

		}

		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://docs.mobilize.net/vbuc/ewis/warnings#id-2080
		private void Form_Load()
		{

			//UPGRADE_ISSUE: (2064) Threed.SSPanel property pnl_Please_Wait.Caption was not upgraded. More Information: https://docs.mobilize.net/vbuc/ewis/issues#id-2064
			pnl_Please_Wait.setCaption($"Loading {WhichReport} Page from Web - Please Wait...");
			pnl_Please_Wait.Refresh();

		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}