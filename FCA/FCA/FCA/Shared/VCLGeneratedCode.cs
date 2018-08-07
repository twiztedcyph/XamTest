using System;
using System.Collections.Generic;
using FCA.Models;

namespace Pellcomp.Vs.Mobile.FormCaptureApp.lib
{
	public static class PICSVerBasic
	{
		public static string BuildNumber = "15.10.014.01";
		public static string BuildDate = "5 June 2018";
	}
	
	public static class fldSurveys
	{
		public static string CSQTShortText = "S";
		public static string CSQTLongText = "M";
		public static string CSQTNumber = "N";
		public static string CSQTDateTime = "T";
		public static string CSQTTime = "I";
		public static string CSQTDropDown = "D";
		public static string CSQTRange = "R";
		public static string CSQTCheckList = "C";
		public static string CSQTGroup = "G";
		public static string CSQTHeader = "H";
		public static string CSQTMoney = ((char)163).ToString();
		public static string CSQTURL = "U";
		public static string CSQTPickList = "P";
		public static string CSQTTotal = "+";
		public static string CSQTEmpSig = "1";
		public static string CSQTLrnSig = "2";
		public static string CSQTUserSig = "3";
		public static string CSQTOtherSig = "4";
		public static string CSQTAttach = "A";
		public static string CSQTLongLabel = "L";
	}
	
	public static class uRegExpLib
	{
		public static string RegExp_sPostcodeExpression = @"^(((A[BL]|B[ABDFHLNRSTX]?|C[ABFHMORTVW]|D[ADEGHLNTY]|E[HNX]?|F[KY]|G[LUY]?|H[ADGPRSUX]|I[GMPV]|JE|K[ATWY]|L[ADELNSU]?|M[EKL]?|N[EGNPRW]?|O[LX]|P[AEHLOR]|R[GHM]|S[AEGKLMNOPRSTY]?|T[ADFNQRSW]|UB|W[ADFNRSV]|YO|ZE)[1-9]?[0-9]|((E|N|NW|SE|SW|W)1|EC[1-4]|WC[12])[A-HJKMNPR-Y]|(SW|W)([2-9]|[1-9][0-9])|EC[1-9][0-9]) [0-9][ABD-HJLNP-UW-Z]{2})|(GIR 0AA|ZZ99 9ZZ|ZZ99 ZZZ)$";
		public static string RegExp_sEmailExpression = @"^[a-zA-Z0-9!#$%'\*\+\-/=\?\^_`\{\|\}~]+(\.[a-zA-Z0-9!#$%'\*\+\-/=\?\^_`\{\|\}~]+)*@[a-zA-Z0-9][a-zA-Z0-9\-]{0,61}[a-zA-Z0-9](\.[a-zA-Z0-9][a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])*\.[a-zA-Z]{2,63}$";
		public static string RegExp_NINumber = @"[A-CEGHJ-PR-TW-Z][A-CEGHJ-NPR-TW-Z][0-9]{6}[A-DFM]";
		public static string RegExp_MobilePhone = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$";
		public static string RegExp_24HourTime = @"^([01][0-9]|2[0-3]):([0-5][0-9])$";
		public static string RegExp_ULN = @"[1-9][0-9]{9}";
	}
	
	public static class uImportPlcConsts
	{
		public static string imp_PlaceCode = "EmpCode";
		public static string imp_PlaceRecGUID = "EmpRecGUID";
	}
	
	public static class fldOrgs
	{
		public static string CStatusUnapproved = "U";
		public static string CStatusLive = "L";
		public static string CStatusDormant = "D";
		public static string CStatusArchived = "A";
		
		
		private static Dictionary<string, string> _PlacementStatus;
		public static Dictionary<string, string> PlacementStatus
		{
			get
			{
				if(_PlacementStatus == null)
				{
					_PlacementStatus = new Dictionary<string, string>();
					_PlacementStatus.Add("L", "Live");
					_PlacementStatus.Add("U", "Unapproved");
					_PlacementStatus.Add("D", "Dormant");
					_PlacementStatus.Add("A", "Archived");
				}
				return _PlacementStatus;
			}
		}
	}
	
	public static class fldGDPR
	{
		public static string methodEmail = "E";
		public static string methodSMS = "S";
		public static string methodPost = "P";
		public static string methodTelephone = "T";
		public static string methodNoneRecorded = "-";
		public static string methodDoNotContact = "X";
		
		
		private static Dictionary<string, string> _PrefContactMethodList;
		public static Dictionary<string, string> PrefContactMethodList
		{
			get
			{
				if(_PrefContactMethodList == null)
				{
					_PrefContactMethodList = new Dictionary<string, string>();
					_PrefContactMethodList.Add("E", "Email");
					_PrefContactMethodList.Add("S", "SMS");
					_PrefContactMethodList.Add("P", "Post");
					_PrefContactMethodList.Add("T", "Telephone");
					_PrefContactMethodList.Add("-", "None recorded");
					_PrefContactMethodList.Add("X", "Do not contact");
					_PrefContactMethodList.Add("", "Unspecified");
				}
				return _PrefContactMethodList;
			}
		}
		
		private static Dictionary<string, string> _ContactMethodsList;
		public static Dictionary<string, string> ContactMethodsList
		{
			get
			{
				if(_ContactMethodsList == null)
				{
					_ContactMethodsList = new Dictionary<string, string>();
					_ContactMethodsList.Add("E", "Email");
					_ContactMethodsList.Add("S", "SMS");
					_ContactMethodsList.Add("P", "Post");
					_ContactMethodsList.Add("T", "Telephone");
					_ContactMethodsList.Add("-", "None recorded");
					_ContactMethodsList.Add("X", "Do not contact");
				}
				return _ContactMethodsList;
			}
		}
	}
	
	public static class fldFormCapCommon
	{
		public static string FORM_STATUS_NEW = "~";
		public static string FORM_STATUS_LIVE = "L";
		public static string FORM_STATUS_USERDELETED = "D";
		public static string FORM_STATUS_FOR_VETTING = "F";
		public static string FORM_STATUS_VETTED = "V";
		public static string FORM_STATUS_SUBMITTED = "S";
		public static string FORM_STATUS_COMPLETED = "C";
		public static string FORM_STATUS_REJECTED = "R";
		public static string FORM_STATUS_IMPORTED = "I";
		public static string FORM_STATUS_ADMINDELETED = "X";
		public static string FORMS_TO_DOWNLOAD_TO_TABLET = "LVR";
		public static string Org_Attachment_Forms = "PELL_ORG1*CUST_OAT1*";
		public static string Learner_Start_Forms = "PELL_STT1*AVAN_ST1*AVAN_ILP1*CUST_LRN3*";
		public static string Review_Non_Import_Forms = "CUST_RVW1*CUST_RVW2*";
		public static string FCA_Org_Status_Modified = "M";
		public static string FCA_Org_Status_New = "N";
		public static string FCA_Org_Status_Unmodified = "-";
		public static int Max_AttachCount = 20;
		public static string Form_Custom_Learner_Prelim = "CUST_LRN3";
		public static string Form_Custom_Learner = "CUST_LRN1";
		public static string Form_Custom_Learner_Approve_Import = "CUST_LRN2";
		public static string Form_Custom_Review = "CUST_RVW1";
		public static string Form_Custom_Review_Approve = "CUST_RVW2";
		public static string Form_Custom_Applicant = "CUST_APP1";
		public static string Form_Custom_Applicant_Approve_Import = "CUST_APP2";
		public static string Form_Custom_OrgAttach = "CUST_OAT1";
		public static string Form_Custom_OrgEvent = "CUST_OEV1";
		public static string Form_Custom_AppEvent = "CUST_AEV1";
		public static string Form_Custom_LrnEvent = "CUST_LEV1";
		public static string Form_Custom_OrgEvent_Approve = "CUST_OEV2";
		public static string Form_Custom_AppEvent_Approve = "CUST_AEV2";
		public static string Form_Custom_LrnEvent_Approve = "CUST_LEV2";
		public static string Form_PellLearner = "PELL_LRN1";
		public static string Form_PellStart = "PELL_STT1";
		public static string Form_PellApplicant = "PELL_APP1";
		public static string Form_PellOrgAttach = "PELL_ORG1";
		public static string FCA_IT_PLACE = "PLACE";
		public static string FCA_IT_PLA_X = "PLA_";
		public static string FCA_IT_OFF_X = "OFF_";
		
		private static Dictionary<string, string> _StatusList;
		public static Dictionary<string, string> StatusList
		{
			get
			{
				if(_StatusList == null)
				{
					_StatusList = new Dictionary<string, string>();
					_StatusList.Add("~", "New");
					_StatusList.Add("L", "In progress");
					_StatusList.Add("F", "For Vetting");
					_StatusList.Add("V", "Vetted");
					_StatusList.Add("D", "Deleted by User");
					_StatusList.Add("S", "Submitted");
					_StatusList.Add("C", "Completed");
					_StatusList.Add("R", "Rejected by Admin");
					_StatusList.Add("I", "Imported");
					_StatusList.Add("X", "Deleted by Admin");
					_StatusList.Add("H", "In Check");
				}
				return _StatusList;
			}
		}
	}
	
	public static class fldClient
	{
		public static string TRAINEE_STATUS_PARTIALENTRY = "~";
		public static string TRAINEE_STATUS_DELETED = "D";
		public static string TRAINEE_STATUS_ARCHIVED = "A";
	}
	
	public enum RequiredSignature
	{
		rsUser,
		rsLearner,
		rsEmployer,
		rsEmployerB,
		rsEmployerC,
		rsOfficerA,
		rsOfficerB,
		rsParentGuradian,
		rsNoSig,
	}
	
	public enum RequiredSignatureChars
	{
		Sig_U,
		Sig_L,
		Sig_E,
		Sig_M,
		Sig_P,
		Sig_A,
		Sig_B,
		Sig_G,
	}
	
	public enum RequiredSignatureBookMark
	{
		Sig_User,
		Sig_Lrnr,
		Sig_Emp,
		Sig_EmpB,
		Sig_EmpC,
		Sig_OffA,
		Sig_OffB,
		Sig_ParG,
	}
	
	public static class uImportApplicantConsts
	{
		public static string APIDENT = "APIDENT";
		public static string APP_SURNAME = "APP_SURNAME";
		public static string APP_FIRSTNAMES = "APP_FIRSTNAMES";
		public static string APP_NI_NO = "APP_NI_NO";
		public static string APP_STATUS = "APP_STATUS";
		public static string APP_SEX = "APP_SEX";
		public static string APP_POSTCODE = "APP_POSTCODE";
		public static string APP_BIRTHDATE = "APP_BIRTHDATE";
		public static string APP_DISABILITY = "APP_DISABILITY";
		public static string APP_ETHNICITY = "APP_ETHNICITY";
		public static string APP_ADDR1 = "APP_ADDR1";
		public static string APP_ADDR2 = "APP_ADDR2";
		public static string APP_ADDR3 = "APP_ADDR3";
		public static string APP_ADDR4 = "APP_ADDR4";
		public static string APP_PHONE = "APP_PHONE";
		public static string APP_MOBPHONE = "APP_MOBPHONE";
		public static string CONT_METH = "CONT_METH";
		public static string PREF_CONTACT_METH = "PREF_CONTACT_METH";
		public static string APP_DRLICENCE = "APP_DRLICENCE";
		public static string APP_LAST_EDU = "APP_LAST_EDU";
		public static string APP_CANSTART = "APP_CANSTART";
		public static string APP_EMAIL = "APP_EMAIL";
		public static string APP_TITLE = "APP_TITLE";
		public static string APP_CurStatus = "APP_CurStatus";
		public static string APP_CurSubStatus = "APP_CurSubStatus";
		public static string APP_OFF_TRAIN = "APP_OFF_TRAIN";
		public static string APP_MENTOR = "APP_MENTOR";
		public static string APP_RECRUITED_BY = "APP_RECRUITED_BY";
		public static string APP_QualPlan = "APP_QualPlan";
		public static string APP_COHORT = "APP_COHORT";
		public static string APP_SITE = "APP_SITE";
		public static string APP_BAS_NUM = "APP_BAS_NUM";
		public static string APP_BAS_LIT = "APP_BAS_LIT";
		public static string APP_BAS_ICT = "APP_BAS_ICT";
		public static string APP_BAS_NUMRES = "APP_BAS_NUMRES";
		public static string APP_BAS_LITRES = "APP_BAS_LITRES";
		public static string APP_BAS_ICTRES = "APP_BAS_ICTRES";
		public static string APP_ULN = "APP_ULN";
		public static string APP_NOK_NAME = "APP_NOK_NAME";
		public static string APP_NOK_REL = "APP_NOK_REL";
		public static string APP_NOK_PHONE = "APP_NOK_PHONE";
		public static string APP_EmpRecGUID = "APP_EmpRecGUID";
		public static string APP_ALL_LLDD = "APP_ALL_LLDD";
		public static string APP_PRIMARY_LLDD = "APP_PRIMARY_LLDD";
		public static string APP_HHS = "APP_HHS";
		public static string APP_GCSEENGGRADE = "APP_GCSEENGGRADE";
		public static string APP_GCSEMATHGRADE = "APP_GCSEMATHGRADE";
		public static string APP_ACT = "APP_ACT";
		public static string APP_TRG_TNP = "APP_TRG_TNP";
		public static string APP_TRG_EMP = "APP_TRG_EMP";
		public static string APP_ASM_TNP = "APP_ASM_TNP";
		public static string APP_ASM_EMP = "APP_ASM_EMP";
		public static string Sig_User = "Sig_User";
		public static string Sig_Lrnr = "Sig_Lrnr";
		public static string Sig_Emp = "Sig_Emp";
		public static string Sig_EmpB = "Sig_EmpB";
		public static string Sig_EmpC = "Sig_EmpC";
		public static string Sig_OffA = "Sig_OffA";
		public static string Sig_OffB = "Sig_OffB";
		public static string Sig_ParG = "Sig_ParG";
		public static string APP_CHQBOOK = "APP_CHQBOOK";
		public static string APP_REDUNDANCY = "APP_REDUNDANCY";
		public static string APP_SPECNEEDS = "APP_SPECNEEDS";
		public static string APP_CREDITS = "APP_CREDITS";
		public static string APP_CENTRE = "APP_CENTRE";
		public static string APP_PREVWORK = "APP_PREVWORK";
		public static string APP_HASTPT = "APP_HASTPT";
		public static string APP_ENTERED = "APP_ENTERED";
		public static string APP_ENTRY = "APP_ENTRY";
		public static string APP_OUTCOME = "APP_OUTCOME";
		public static string APP_PROGRAMME = "APP_PROGRAMME";
		public static string APP_CAR_OFFICE = "APP_CAR_OFFICE";
		public static string APP_CURRPOS = "APP_CURRPOS";
		public static string APP_CONTACT = "APP_CONTACT";
		public static string APP_PROGCODE = "APP_PROGCODE";
		public static string APP_SOC1 = "APP_SOC1";
		public static string APP_SOC2 = "APP_SOC2";
		public static string APP_SOC3 = "APP_SOC3";
		public static string APP_SOC4 = "APP_SOC4";
		public static string APP_SOC5 = "APP_SOC5";
		public static string APP_SOC6 = "APP_SOC6";
		public static string APP_FUNDORG = "APP_FUNDORG";
		public static string APP_PROVIDENT = "APP_PROVIDENT";
		public static string APP_DOMICILE = "APP_DOMICILE";
		public static string APP_UPLIFT = "APP_UPLIFT";
		public static string APP_LSCDIFFIC = "APP_LSCDIFFIC";
		public static string APP_LSCDISAB = "APP_LSCDISAB";
		public static string APP_LSCLEARN = "APP_LSCLEARN";
		public static string APP_LASTREAD = "APP_LASTREAD";
		public static string APP_CONTRACT = "APP_CONTRACT";
		public static string APP_PLACED = "APP_PLACED";
		public static string APP_DISTANCE = "APP_DISTANCE";
		public static string APP_ULIN = "APP_ULIN";
		public static string APP_AREA = "APP_AREA";
		public static string APP_Withdrawn = "APP_Withdrawn";
		public static string APP_WardCode = "APP_WardCode";
		public static string APP_EMAStatus = "APP_EMAStatus";
		public static string APP_TfrTo = "APP_TfrTo";
		public static string APP_RESTUSE = "APP_RESTUSE";
		public static string APP_PREFCONT = "APP_PREFCONT";
		public static string APP_SILR_RUI = "APP_SILR_RUI";
		public static string APP_DAS_COHORT = "APP_DAS_COHORT";
		public static string APP_DAS_STATUS = "APP_DAS_STATUS";
		public static string APP_SCHOOL = "APP_SCHOOL";
		public static string APP_COLLEGE = "APP_COLLEGE";
		public static string APP_RECRUIT_AGENCY = "APP_RECRUIT_AGENCY";
		public static string APP_PRIORQUAL_NAME = "APP_PRIORQUAL_NAME";
		public static string APP_PRIORQUAL_LEVEL = "APP_PRIORQUAL_LEVEL";
		public static string APP_PRIORQUAL_ACHDATE = "APP_PRIORQUAL_ACHDATE";
		public static string APP_PRIORQUAL_GRADE = "APP_PRIORQUAL_GRADE";
		public static string APP_ILP_NOTES_GEN = "APP_ILP_NOTES_GEN";
		public static string APP_ILP_NOTES_EXP = "APP_ILP_NOTES_EXP";
		public static string APP_ILP_NOTES_EMP = "APP_ILP_NOTES_EMP";
		public static string APP_ILP_NOTES_IND = "APP_ILP_NOTES_IND";
		public static string APP_ILP_NOTES_BAS = "APP_ILP_NOTES_BAS";
		public static string APP_ILP_NOTES = "APP_ILP_NOTES";
		public static string App_Notes_SText = "App_Notes_SText";
		public static string App_Notes_LText = "App_Notes_LText";
		public static string App_Notes_Codes = "App_Notes_Codes";
		public static string App_Notes_MCodes = "App_Notes_MCodes";
		public static string App_Notes_Date = "App_Notes_Date";
		public static string App_Notes_Num = "App_Notes_Num";
		public static string APP = "APP";
	}
	
	public static class uImportConsts
	{
		public static string PICS_IMPORT_ID = "PICS_IMPORT_ID";
		public static string IMPORT_FILE_GUID = "IMPORT_FILE_GUID";
		public static string IMPORT_IMAGE_GUID = "IMPORT_IMAGE_GUID";
		public static string EXTRA_IMPORT_FILE_NAME = "EXTRA_IMPORT_FILE_NAME";
		public static string EXTRA_IMPORT_FILE_DESC = "EXTRA_IMPORT_FILE_DESC";
		public static string EXTRA_IMPORT_FILE_GUID = "EXTRA_IMPORT_FILE_GUID";
		public static string PICS_APIDENT = "PICS_APIDENT";
		public static string PICS_GROUP = "PICS_GROUP";
		public static string TITLE = "TITLE";
		public static string SURNAME = "SURNAME";
		public static string FIRSTNAME = "FIRSTNAME";
		public static string SEX = "SEX";
		public static string BIRTHDATE = "BIRTHDATE";
		public static string NINUMBER = "NINUMBER";
		public static string ADDR1 = "ADDR1";
		public static string ADDR2 = "ADDR2";
		public static string ADDR3 = "ADDR3";
		public static string ADDR4 = "ADDR4";
		public static string POSTCODE = "POSTCODE";
		public static string PHONE = "PHONE";
		public static string MOBILEPHONE = "MOBILEPHONE";
		public static string EMAIL = "EMAIL";
		public static string CONT_METH = "CONT_METH";
		public static string PREF_CONTACT_METH = "PREF_CONTACT_METH";
		public static string ETHNICORIGIN = "ETHNICORIGIN";
		public static string COUNTRY = "COUNTRY";
		public static string SITE = "SITE";
		public static string QUALPLAN = "QUALPLAN";
		public static string EXPQU = "EXPQU";
		public static string EXPQ2 = "EXPQ2";
		public static string EXPQ3 = "EXPQ3";
		public static string COHORT = "COHORT";
		public static string STARTTYPE = "STARTTYPE";
		public static string MAIN_OFFICER = "MAIN_OFFICER";
		public static string Training_Officer = "Training_Officer";
		public static string Careers_Officer = "Careers_Officer";
		public static string Placement_Officer = "Placement_Officer";
		public static string Mentor_Officer = "Mentor_Officer";
		public static string Subcontractor = "Subcontractor";
		public static string FundOrg = "FundOrg";
		public static string RiskLevel = "RiskLevel";
		public static string PROV_ID = "PROV_ID";
		public static string CONTRACT = "CONTRACT";
		public static string FIRSTLANG = "FIRSTLANG";
		public static string HASDRIVINGLICENCE = "HASDRIVINGLICENCE";
		public static string FREESCHOOLMEALS = "FREESCHOOLMEALS";
		public static string Source_Sys_ID = "Source_Sys_ID";
		public static string Source_Sys_Type = "Source_Sys_Type";
		public static string NOKNAME = "NOKNAME";
		public static string NOKREL = "NOKREL";
		public static string NOKPHONE = "NOKPHONE";
		public static string NOKPHONE2 = "NOKPHONE2";
		public static string NOKEMAIL = "NOKEMAIL";
		public static string Notes_SText_1 = "Notes_SText_1";
		public static string Notes_LText_1 = "Notes_LText_1";
		public static string Notes_Codes_1 = "Notes_Codes_1";
		public static string Notes_MCodes_1 = "Notes_MCodes_1";
		public static string Notes_Date_1 = "Notes_Date_1";
		public static string Notes_Num_1 = "Notes_Num_1";
		public static string Notes_SText_2 = "Notes_SText_2";
		public static string Notes_LText_2 = "Notes_LText_2";
		public static string Notes_Codes_2 = "Notes_Codes_2";
		public static string Notes_MCodes_2 = "Notes_MCodes_2";
		public static string Notes_Date_2 = "Notes_Date_2";
		public static string Notes_Num_2 = "Notes_Num_2";
		public static string Notes_SText_3 = "Notes_SText_3";
		public static string Notes_LText_3 = "Notes_LText_3";
		public static string Notes_Codes_3 = "Notes_Codes_3";
		public static string Notes_MCodes_3 = "Notes_MCodes_3";
		public static string Notes_Date_3 = "Notes_Date_3";
		public static string Notes_Num_3 = "Notes_Num_3";
		public static string Notes_SText_4 = "Notes_SText_4";
		public static string Notes_LText_4 = "Notes_LText_4";
		public static string Notes_Codes_4 = "Notes_Codes_4";
		public static string Notes_MCodes_4 = "Notes_MCodes_4";
		public static string Notes_Date_4 = "Notes_Date_4";
		public static string Notes_Num_4 = "Notes_Num_4";
		public static string Notes_SText_5 = "Notes_SText_5";
		public static string Notes_LText_5 = "Notes_LText_5";
		public static string Notes_Codes_5 = "Notes_Codes_5";
		public static string Notes_MCodes_5 = "Notes_MCodes_5";
		public static string Notes_Date_5 = "Notes_Date_5";
		public static string Notes_Num_5 = "Notes_Num_5";
		public static string Notes_SText_6 = "Notes_SText_6";
		public static string Notes_LText_6 = "Notes_LText_6";
		public static string Notes_Codes_6 = "Notes_Codes_6";
		public static string Notes_MCodes_6 = "Notes_MCodes_6";
		public static string Notes_Date_6 = "Notes_Date_6";
		public static string Notes_Num_6 = "Notes_Num_6";
		public static string Notes_SText_7 = "Notes_SText_7";
		public static string Notes_LText_7 = "Notes_LText_7";
		public static string Notes_Codes_7 = "Notes_Codes_7";
		public static string Notes_MCodes_7 = "Notes_MCodes_7";
		public static string Notes_Date_7 = "Notes_Date_7";
		public static string Notes_Num_7 = "Notes_Num_7";
		public static string Notes_SText_8 = "Notes_SText_8";
		public static string Notes_LText_8 = "Notes_LText_8";
		public static string Notes_Codes_8 = "Notes_Codes_8";
		public static string Notes_MCodes_8 = "Notes_MCodes_8";
		public static string Notes_Date_8 = "Notes_Date_8";
		public static string Notes_Num_8 = "Notes_Num_8";
		public static string Notes_SText_9 = "Notes_SText_9";
		public static string Notes_LText_9 = "Notes_LText_9";
		public static string Notes_Codes_9 = "Notes_Codes_9";
		public static string Notes_MCodes_9 = "Notes_MCodes_9";
		public static string Notes_Date_9 = "Notes_Date_9";
		public static string Notes_Num_9 = "Notes_Num_9";
		public static string Notes_SText_10 = "Notes_SText_10";
		public static string Notes_LText_10 = "Notes_LText_10";
		public static string Notes_Codes_10 = "Notes_Codes_10";
		public static string Notes_MCodes_10 = "Notes_MCodes_10";
		public static string Notes_Date_10 = "Notes_Date_10";
		public static string Notes_Num_10 = "Notes_Num_10";
		public static string ILP_NOTES_GEN = "ILP_NOTES_GEN";
		public static string ILP_NOTES_EXP = "ILP_NOTES_EXP";
		public static string ILP_NOTES_EMP = "ILP_NOTES_EMP";
		public static string ILP_NOTES_IND = "ILP_NOTES_IND";
		public static string ILP_NOTES_BAS = "ILP_NOTES_BAS";
		public static string ILP_NOTES_1 = "ILP_NOTES_1";
		public static string ILP_NOTES_GUID_1 = "ILP_NOTES_GUID_1";
		public static string ILP_NOTES_FILESTATUS_1 = "ILP_NOTES_FILESTATUS_1";
		public static string ILP_NOTES_2 = "ILP_NOTES_2";
		public static string ILP_NOTES_GUID_2 = "ILP_NOTES_GUID_2";
		public static string ILP_NOTES_FILESTATUS_2 = "ILP_NOTES_FILESTATUS_2";
		public static string ILP_NOTES_3 = "ILP_NOTES_3";
		public static string ILP_NOTES_GUID_3 = "ILP_NOTES_GUID_3";
		public static string ILP_NOTES_FILESTATUS_3 = "ILP_NOTES_FILESTATUS_3";
		public static string ILP_NOTES_4 = "ILP_NOTES_4";
		public static string ILP_NOTES_GUID_4 = "ILP_NOTES_GUID_4";
		public static string ILP_NOTES_FILESTATUS_4 = "ILP_NOTES_FILESTATUS_4";
		public static string ILP_NOTES_5 = "ILP_NOTES_5";
		public static string ILP_NOTES_GUID_5 = "ILP_NOTES_GUID_5";
		public static string ILP_NOTES_FILESTATUS_5 = "ILP_NOTES_FILESTATUS_5";
		public static string ILP_NOTES_6 = "ILP_NOTES_6";
		public static string ILP_NOTES_GUID_6 = "ILP_NOTES_GUID_6";
		public static string ILP_NOTES_FILESTATUS_6 = "ILP_NOTES_FILESTATUS_6";
		public static string ILP_NOTES_7 = "ILP_NOTES_7";
		public static string ILP_NOTES_GUID_7 = "ILP_NOTES_GUID_7";
		public static string ILP_NOTES_FILESTATUS_7 = "ILP_NOTES_FILESTATUS_7";
		public static string ILP_NOTES_8 = "ILP_NOTES_8";
		public static string ILP_NOTES_GUID_8 = "ILP_NOTES_GUID_8";
		public static string ILP_NOTES_FILESTATUS_8 = "ILP_NOTES_FILESTATUS_8";
		public static string ILP_NOTES_9 = "ILP_NOTES_9";
		public static string ILP_NOTES_GUID_9 = "ILP_NOTES_GUID_9";
		public static string ILP_NOTES_FILESTATUS_9 = "ILP_NOTES_FILESTATUS_9";
		public static string ILP_NOTES_10 = "ILP_NOTES_10";
		public static string ILP_NOTES_GUID_10 = "ILP_NOTES_GUID_10";
		public static string ILP_NOTES_FILESTATUS_10 = "ILP_NOTES_FILESTATUS_10";
		public static string Vac_SOC = "Vac_SOC";
		public static string LEFTFTEDU = "LEFTFTEDU";
		public static string SCHOOL = "SCHOOL";
		public static string COLLEGE = "COLLEGE";
		public static string GCSEEng = "GCSEEng";
		public static string GCSEMath = "GCSEMath";
		public static string NUM_FIRSTASSLEV = "NUM_FIRSTASSLEV";
		public static string NUM_FIRSTASSRES = "NUM_FIRSTASSRES";
		public static string NUM_FIRSTASSDATE = "NUM_FIRSTASSDATE";
		public static string LIT_FIRSTASSLEV = "LIT_FIRSTASSLEV";
		public static string LIT_FIRSTASSRES = "LIT_FIRSTASSRES";
		public static string LIT_FIRSTASSDATE = "LIT_FIRSTASSDATE";
		public static string ICT_FIRSTASSLEV = "ICT_FIRSTASSLEV";
		public static string ICT_FIRSTASSRES = "ICT_FIRSTASSRES";
		public static string ICT_FIRSTASSDATE = "ICT_FIRSTASSDATE";
		public static string ESOL_FIRSTASSLEV = "ESOL_FIRSTASSLEV";
		public static string ESOL_FIRSTASSRES = "ESOL_FIRSTASSRES";
		public static string ESOL_FIRSTASSDATE = "ESOL_FIRSTASSDATE";
		public static string PRIORQUAL_NAME_1 = "PRIORQUAL_NAME_1";
		public static string PRIORQUAL_LEVEL_1 = "PRIORQUAL_LEVEL_1";
		public static string PRIORQUAL_ACHDATE_1 = "PRIORQUAL_ACHDATE_1";
		public static string PRIORQUAL_GRADE_1 = "PRIORQUAL_GRADE_1";
		public static string PRIORQUAL_NAME_2 = "PRIORQUAL_NAME_2";
		public static string PRIORQUAL_LEVEL_2 = "PRIORQUAL_LEVEL_2";
		public static string PRIORQUAL_ACHDATE_2 = "PRIORQUAL_ACHDATE_2";
		public static string PRIORQUAL_GRADE_2 = "PRIORQUAL_GRADE_2";
		public static string PRIORQUAL_NAME_3 = "PRIORQUAL_NAME_3";
		public static string PRIORQUAL_LEVEL_3 = "PRIORQUAL_LEVEL_3";
		public static string PRIORQUAL_ACHDATE_3 = "PRIORQUAL_ACHDATE_3";
		public static string PRIORQUAL_GRADE_3 = "PRIORQUAL_GRADE_3";
		public static string PRIORQUAL_NAME_4 = "PRIORQUAL_NAME_4";
		public static string PRIORQUAL_LEVEL_4 = "PRIORQUAL_LEVEL_4";
		public static string PRIORQUAL_ACHDATE_4 = "PRIORQUAL_ACHDATE_4";
		public static string PRIORQUAL_GRADE_4 = "PRIORQUAL_GRADE_4";
		public static string PRIORQUAL_NAME_5 = "PRIORQUAL_NAME_5";
		public static string PRIORQUAL_LEVEL_5 = "PRIORQUAL_LEVEL_5";
		public static string PRIORQUAL_ACHDATE_5 = "PRIORQUAL_ACHDATE_5";
		public static string PRIORQUAL_GRADE_5 = "PRIORQUAL_GRADE_5";
		public static string PRIORQUAL_NAME_6 = "PRIORQUAL_NAME_6";
		public static string PRIORQUAL_LEVEL_6 = "PRIORQUAL_LEVEL_6";
		public static string PRIORQUAL_ACHDATE_6 = "PRIORQUAL_ACHDATE_6";
		public static string PRIORQUAL_GRADE_6 = "PRIORQUAL_GRADE_6";
		public static string PRIORQUAL_NAME_7 = "PRIORQUAL_NAME_7";
		public static string PRIORQUAL_LEVEL_7 = "PRIORQUAL_LEVEL_7";
		public static string PRIORQUAL_ACHDATE_7 = "PRIORQUAL_ACHDATE_7";
		public static string PRIORQUAL_GRADE_7 = "PRIORQUAL_GRADE_7";
		public static string PRIORQUAL_NAME_8 = "PRIORQUAL_NAME_8";
		public static string PRIORQUAL_LEVEL_8 = "PRIORQUAL_LEVEL_8";
		public static string PRIORQUAL_ACHDATE_8 = "PRIORQUAL_ACHDATE_8";
		public static string PRIORQUAL_GRADE_8 = "PRIORQUAL_GRADE_8";
		public static string PRIORQUAL_NAME_9 = "PRIORQUAL_NAME_9";
		public static string PRIORQUAL_LEVEL_9 = "PRIORQUAL_LEVEL_9";
		public static string PRIORQUAL_ACHDATE_9 = "PRIORQUAL_ACHDATE_9";
		public static string PRIORQUAL_GRADE_9 = "PRIORQUAL_GRADE_9";
		public static string PRIORQUAL_NAME_10 = "PRIORQUAL_NAME_10";
		public static string PRIORQUAL_LEVEL_10 = "PRIORQUAL_LEVEL_10";
		public static string PRIORQUAL_ACHDATE_10 = "PRIORQUAL_ACHDATE_10";
		public static string PRIORQUAL_GRADE_10 = "PRIORQUAL_GRADE_10";
		public static string EmpCode = "EmpCode";
		public static string EmpRecGUID = "EmpRecGUID";
		public static string EmpEDRS = "EmpEDRS";
		public static string EmpPostCode = "EmpPostCode";
		public static string EmpName = "EmpName";
		public static string EmpAddr1 = "EmpAddr1";
		public static string EmpAddr2 = "EmpAddr2";
		public static string EmpAddr3 = "EmpAddr3";
		public static string EmpAddr4 = "EmpAddr4";
		public static string EmpAddr5 = "EmpAddr5";
		public static string EmpPhone = "EmpPhone";
		public static string EmpFax = "EmpFax";
		public static string EmpEmail = "EmpEmail";
		public static string EmpWebsite = "EmpWebsite";
		public static string EmpAllowMarketing = "EmpAllowMarketing";
		public static string EmpRisk = "EmpRisk";
		public static string EmpJobTitle = "EmpJobTitle";
		public static string EmpWorkPhone = "EmpWorkPhone";
		public static string EmpWorkEmail = "EmpWorkEmail";
		public static string EmpNotes = "EmpNotes";
		public static string EmpStart = "EmpStart";
		public static string EmpExpEnd = "EmpExpEnd";
		public static string EmpEnd = "EmpEnd";
		public static string EmpContactTitle = "EmpContactTitle";
		public static string EmpContactSurname = "EmpContactSurname";
		public static string EmpContactForename = "EmpContactForename";
		public static string EmpContactFullName = "EmpContactFullName";
		public static string EmpContactPhone = "EmpContactPhone";
		public static string EmpContactEmail = "EmpContactEmail";
		public static string EmpContactJobTitle = "EmpContactJobTitle";
		public static string OffFullName = "OffFullName";
		public static string OffSurname = "OffSurname";
		public static string OffForename = "OffForename";
		public static string OffTitle = "OffTitle";
		public static string OffJobTitle = "OffJobTitle";
		public static string OffRole = "OffRole";
		public static string OffPhone = "OffPhone";
		public static string OffMobile = "OffMobile";
		public static string OffEmail = "OffEmail";
		public static string PREVEMP = "PREVEMP";
		public static string PREVEMP_JOBTITLE = "PREVEMP_JOBTITLE";
		public static string PREVEMP_JOBNOTES = "PREVEMP_JOBNOTES";
		public static string PREVEMP_START = "PREVEMP_START";
		public static string PREVEMP_EXPEND = "PREVEMP_EXPEND";
		public static string PREVEMP_END = "PREVEMP_END";
		public static string UPIN = "UPIN";
		public static string UKPRN = "UKPRN";
		public static string LSC_ULIN = "LSC_ULIN";
		public static string L17POSTCODE = "L17POSTCODE";
		public static string L14 = "L14";
		public static string L15 = "L15";
		public static string L16 = "L16";
		public static string L31 = "L31";
		public static string L34A = "L34A";
		public static string L34B = "L34B";
		public static string L34C = "L34C";
		public static string L34D = "L34D";
		public static string L39 = "L39";
		public static string PRIOREDU = "PRIOREDU";
		public static string EMPBEFORE = "EMPBEFORE";
		public static string L40A = "L40A";
		public static string L40B = "L40B";
		public static string L41A = "L41A";
		public static string L41B = "L41B";
		public static string L42A = "L42A";
		public static string L42B = "L42B";
		public static string L44 = "L44";
		public static string BoxB = "BoxB";
		public static string L52 = "L52";
		public static string L52_POST = "L52_POST";
		public static string L52_PHONE = "L52_PHONE";
		public static string L52_EMAIL = "L52_EMAIL";
		public static string RUI = "RUI";
		public static string RUI_SURVEYS = "RUI_SURVEYS";
		public static string RUI_COURSES = "RUI_COURSES";
		public static string ALS = "ALS";
		public static string LDA = "LDA";
		public static string DLA = "DLA";
		public static string ACCOM = "ACCOM";
		public static string PREV_UKPRN = "PREV_UKPRN";
		public static string PREV_LRN = "PREV_LRN";
		public static string EHC = "EHC";
		public static string HNS = "HNS";
		public static string MGA = "MGA";
		public static string EGA = "EGA";
		public static string FME = "FME";
		public static string PPE_A = "PPE_A";
		public static string PPE_B = "PPE_B";
		public static string GCSE_MATH_GRADE = "GCSE_MATH_GRADE";
		public static string GCSE_ENG_GRADE = "GCSE_ENG_GRADE";
		public static string SEN = "SEN";
		public static string EDF_A = "EDF_A";
		public static string EDF_B = "EDF_B";
		public static string MCF = "MCF";
		public static string ECF = "ECF";
		public static string Primary_LLDD = "Primary_LLDD";
		public static string All_LLDD = "All_LLDD";
		public static string PMUKPRN = "PMUKPRN";
		public static string PLANLRNHRS_2013 = "PLANLRNHRS_2013";
		public static string PLANEEPHRS_2013 = "PLANEEPHRS_2013";
		public static string PLANLRNHRS_2014 = "PLANLRNHRS_2014";
		public static string PLANEEPHRS_2014 = "PLANEEPHRS_2014";
		public static string PLANLRNHRS_2015 = "PLANLRNHRS_2015";
		public static string PLANEEPHRS_2015 = "PLANEEPHRS_2015";
		public static string PLANLRNHRS_2016 = "PLANLRNHRS_2016";
		public static string PLANEEPHRS_2016 = "PLANEEPHRS_2016";
		public static string PLANLRNHRS_2017 = "PLANLRNHRS_2017";
		public static string PLANEEPHRS_2017 = "PLANEEPHRS_2017";
		public static string PLANLRNHRS_2018 = "PLANLRNHRS_2018";
		public static string PLANEEPHRS_2018 = "PLANEEPHRS_2018";
		public static string PLANLRNHRS_2019 = "PLANLRNHRS_2019";
		public static string PLANEEPHRS_2019 = "PLANEEPHRS_2019";
		public static string SLC_CUSTREF = "SLC_CUSTREF";
		public static string SLC_APPID = "SLC_APPID";
		public static string SLC_LOANAMOUNT = "SLC_LOANAMOUNT";
		public static string SLC_COURSECOST = "SLC_COURSECOST";
		public static string SLC_COURSEVAT = "SLC_COURSEVAT";
		public static string SLC_BALANCE = "SLC_BALANCE";
		public static string SLC_LOANSTART = "SLC_LOANSTART";
		public static string SLC_LOANEND = "SLC_LOANEND";
		public static string Prior_EmpStat_EmpCode = "Prior_EmpStat_EmpCode";
		public static string Prior_EmpStat_Code = "Prior_EmpStat_Code";
		public static string Prior_EmpStat_Date = "Prior_EmpStat_Date";
		public static string Prior_EmpStat_SEI = "Prior_EmpStat_SEI";
		public static string Prior_EmpStat_EII = "Prior_EmpStat_EII";
		public static string Prior_EmpStat_LOU = "Prior_EmpStat_LOU";
		public static string Prior_EmpStat_LOE = "Prior_EmpStat_LOE";
		public static string Prior_EmpStat_BSI = "Prior_EmpStat_BSI";
		public static string Prior_EmpStat_PEI = "Prior_EmpStat_PEI";
		public static string Prior_EmpStat_RON = "Prior_EmpStat_RON";
		public static string Prior_EmpStat_SEM = "Prior_EmpStat_SEM";
		public static string Change_EmpStat_EmpCode = "Change_EmpStat_EmpCode";
		public static string Change_EmpStat_Code = "Change_EmpStat_Code";
		public static string Change_EmpStat_Date = "Change_EmpStat_Date";
		public static string Change_EmpStat_SEI = "Change_EmpStat_SEI";
		public static string Change_EmpStat_EII = "Change_EmpStat_EII";
		public static string Change_EmpStat_LOU = "Change_EmpStat_LOU";
		public static string Change_EmpStat_LOE = "Change_EmpStat_LOE";
		public static string Change_EmpStat_BSI = "Change_EmpStat_BSI";
		public static string Change_EmpStat_PEI = "Change_EmpStat_PEI";
		public static string Change_EmpStat_RON = "Change_EmpStat_RON";
		public static string Change_EmpStat_SEM = "Change_EmpStat_SEM";
		public static string MIAP_ULN = "MIAP_ULN";
		public static string MIAP_PREFNAME = "MIAP_PREFNAME";
		public static string MIAP_VERIFTYPE = "MIAP_VERIFTYPE";
		public static string MIAP_VERIFTEXT = "MIAP_VERIFTEXT";
		public static string MIAP_FPN_SEEN = "MIAP_FPN_SEEN";
		public static string MAINAIMREF = "MAINAIMREF";
		public static string MAINFUNDSTREAM = "MAINFUNDSTREAM";
		public static string MAINPROGTYPE = "MAINPROGTYPE";
		public static string PROG_START = "PROG_START";
		public static string START_AGE = "START_AGE";
		public static string PROG_EXPEND = "PROG_EXPEND";
		public static string TECHCERTREF = "TECHCERTREF";
		public static string TECHCERT_REQD = "TECHCERT_REQD";
		public static string FS_Math_Reqd = "FS_Math_Reqd";
		public static string FS_Eng_Reqd = "FS_Eng_Reqd";
		public static string FS_ICT_Reqd = "FS_ICT_Reqd";
		public static string Err_Reqd = "Err_Reqd";
		public static string EPI_DELIVLOC_SOURCE = "EPI_DELIVLOC_SOURCE";
		public static string PROG_A11A = "PROG_A11A";
		public static string PROG_A15 = "PROG_A15";
		public static string PROG_A26 = "PROG_A26";
		public static string PROG_DELIVLOC = "PROG_DELIVLOC";
		public static string PROG_A51A = "PROG_A51A";
		public static string PROG_A14 = "PROG_A14";
		public static string PROG_A46A = "PROG_A46A";
		public static string PROG_A46B = "PROG_A46B";
		public static string PROG_A46C = "PROG_A46C";
		public static string PROG_A46D = "PROG_A46D";
		public static string PROG_A48A = "PROG_A48A";
		public static string PROG_A48B = "PROG_A48B";
		public static string PROG_A49 = "PROG_A49";
		public static string PROG_A63 = "PROG_A63";
		public static string PROG_A64 = "PROG_A64";
		public static string PROG_A65 = "PROG_A65";
		public static string PROG_A69 = "PROG_A69";
		public static string PROG_A70 = "PROG_A70";
		public static string PROG_SSP = "PROG_SSP";
		public static string PROG_SPP = "PROG_SPP";
		public static string PROG_CVE = "PROG_CVE";
		public static string PROG_A72A = "PROG_A72A";
		public static string PROG_A72B = "PROG_A72B";
		public static string PROG_WITHDRAW = "PROG_WITHDRAW";
		public static string PROG_COMPSTAT = "PROG_COMPSTAT";
		public static string PROG_PROGROUTE = "PROG_PROGROUTE";
		public static string PROG_PATHWAY = "PROG_PATHWAY";
		public static string PROG_RES = "PROG_RES";
		public static string PROG_ORIGSTART = "PROG_ORIGSTART";
		public static string PROG_PRIORFUNDADJ = "PROG_PRIORFUNDADJ";
		public static string PROG_OTHERFUNDADJ = "PROG_OTHERFUNDADJ";
		public static string PROG_WPL = "PROG_WPL";
		public static string PROG_ADL = "PROG_ADL";
		public static string PROG_EEF = "PROG_EEF";
		public static string PROG_FFI = "PROG_FFI";
		public static string PROG_WPP = "PROG_WPP";
		public static string PROG_POD = "PROG_POD";
		public static string PROG_TBS = "PROG_TBS";
		public static string PROG_HHS = "PROG_HHS";
		public static string PROG_HHSA = "PROG_HHSA";
		public static string PROG_HHSB = "PROG_HHSB";
		public static string PROG_ACT = "PROG_ACT";
		public static string PROG_ACHIEVE = "PROG_ACHIEVE";
		public static string PROG_EPA_ORG_EmpRecGUID = "PROG_EPA_ORG_EmpRecGUID";
		public static string DAS_COHORT = "DAS_COHORT";
		public static string DAS_STATUS = "DAS_STATUS";
		public static string TRG_TNP = "TRG_TNP";
		public static string TRG_EMP = "TRG_EMP";
		public static string TRG_EMP_START = "TRG_EMP_START";
		public static string TRG_EMP_SPRD = "TRG_EMP_SPRD";
		public static string ASM_TNP = "ASM_TNP";
		public static string ASM_EMP = "ASM_EMP";
		public static string ASM_EMP_START = "ASM_EMP_START";
		public static string ASM_EMP_SPRD = "ASM_EMP_SPRD";
		public static string LLWR_ULI = "LLWR_ULI";
		public static string PREV_SURNAME = "PREV_SURNAME";
		public static string LLWR_CareResp = "LLWR_CareResp";
		public static string LLWR_HouseHoldSit = "LLWR_HouseHoldSit";
		public static string LLWR_LastSch = "LLWR_LastSch";
		public static string LLWR_NatId = "LLWR_NatId";
		public static string LLWR_WelshSpkr = "LLWR_WelshSpkr";
		public static string LLWR_WelshQualLev = "LLWR_WelshQualLev";
		public static string LLWR_PrimeDisab = "LLWR_PrimeDisab";
		public static string LLWR_AddLearnSup = "LLWR_AddLearnSup";
		public static string LLWR_WLHC = "LLWR_WLHC";
		public static string LLWR_HighQual = "LLWR_HighQual";
		public static string LLWR_LenNonEmp = "LLWR_LenNonEmp";
		public static string LLWR_ProgID = "LLWR_ProgID";
		public static string LLWR_ProgCode = "LLWR_ProgCode";
		public static string LLWR_ProvProgRef = "LLWR_ProvProgRef";
		public static string LLWR_EstCentHrs = "LLWR_EstCentHrs";
		public static string LLWR_ActCentHrs = "LLWR_ActCentHrs";
		public static string LLWR_EstWorkHrs = "LLWR_EstWorkHrs";
		public static string LLWR_ActWorkHrs = "LLWR_ActWorkHrs";
		public static string LLWR_UnitAuth = "LLWR_UnitAuth";
		public static string LLWR_EmpStart = "LLWR_EmpStart";
		public static string LLWR_EmpLength = "LLWR_EmpLength";
		public static string LLWR_EmpSME = "LLWR_EmpSME";
		public static string LLWR_EmpSize = "LLWR_EmpSize";
		public static string LLWR_AppLevy = "LLWR_AppLevy";
		public static string LLWR_MigWorker = "LLWR_MigWorker";
		public static string LLWR_HrsWeek = "LLWR_HrsWeek";
		public static string LLWR_Sector = "LLWR_Sector";
		public static string LLWR_ProgType = "LLWR_ProgType";
		public static string LLWR_FeeSource = "LLWR_FeeSource";
		public static string LLWR_SpecFund = "LLWR_SpecFund";
		public static string PROG_TYPE = "PROG_TYPE";
		public static string AIMREF = "AIMREF";
		public static string AIMSTART = "AIMSTART";
		public static string AIMEXPECT = "AIMEXPECT";
		public static string AIMEND = "AIMEND";
		public static string AIMACHIEVE = "AIMACHIEVE";
		public static string AIMASSESSOR = "AIMASSESSOR";
		public static string AIMIV = "AIMIV";
		public static string AIMEV = "AIMEV";
		public static string AIMWANTED = "AIMWANTED";
		public static string A10 = "A10";
		public static string A11A = "A11A";
		public static string A15 = "A15";
		public static string A17 = "A17";
		public static string A18 = "A18";
		public static string A19 = "A19";
		public static string A20 = "A20";
		public static string A21 = "A21";
		public static string A22 = "A22";
		public static string A23 = "A23";
		public static string A26 = "A26";
		public static string A32 = "A32";
		public static string A34 = "A34";
		public static string A35 = "A35";
		public static string A36 = "A36";
		public static string A46A = "A46A";
		public static string A46B = "A46B";
		public static string A46C = "A46C";
		public static string A46D = "A46D";
		public static string A47A = "A47A";
		public static string A47B = "A47B";
		public static string A48A = "A48A";
		public static string A48B = "A48B";
		public static string A49 = "A49";
		public static string A50 = "A50";
		public static string A51A = "A51A";
		public static string A52 = "A52";
		public static string A53 = "A53";
		public static string A54 = "A54";
		public static string A57 = "A57";
		public static string A58 = "A58";
		public static string A59 = "A59";
		public static string A60 = "A60";
		public static string A61 = "A61";
		public static string A62 = "A62";
		public static string A63 = "A63";
		public static string A64 = "A64";
		public static string A65 = "A65";
		public static string A66 = "A66";
		public static string A67 = "A67";
		public static string A68 = "A68";
		public static string A69 = "A69";
		public static string A70 = "A70";
		public static string A71 = "A71";
		public static string A72A = "A72A";
		public static string A72B = "A72B";
		public static string ALN = "ALN";
		public static string ASN = "ASN";
		public static string WITHDRAW = "WITHDRAW";
		public static string COMPSTAT = "COMPSTAT";
		public static string PROGROUTE = "PROGROUTE";
		public static string AIMTYPE = "AIMTYPE";
		public static string A49_SSP = "A49_SSP";
		public static string A49_SPP = "A49_SPP";
		public static string A49_CVE = "A49_CVE";
		public static string SPP = "SPP";
		public static string PATHWAY = "PATHWAY";
		public static string RESTART = "RESTART";
		public static string FSI = "FSI";
		public static string ORIGSTART = "ORIGSTART";
		public static string PRIORFUNDADJ = "PRIORFUNDADJ";
		public static string OTHERFUNDADJ = "OTHERFUNDADJ";
		public static string WPL = "WPL";
		public static string ADL = "ADL";
		public static string EEF = "EEF";
		public static string FFI = "FFI";
		public static string AIM_DELIVLOC = "AIM_DELIVLOC";
		public static string WPP = "WPP";
		public static string POD = "POD";
		public static string TBS = "TBS";
		public static string AddDelivHours = "AddDelivHours";
		public static string ContRefNum = "ContRefNum";
		public static string FLN = "FLN";
		public static string HHS = "HHS";
		public static string HHSA = "HHSA";
		public static string HHSB = "HHSB";
		public static string ACT = "ACT";
		public static string WORKPLACEMODE = "WORKPLACEMODE";
		public static string WORKPLACEHOURS = "WORKPLACEHOURS";
		public static string WKPLCAIMGUID = "WKPLCAIMGUID";
		public static string OVERRIDE_ALL = "OVERRIDE_ALL";
		public static string FAM_Type = "FAM_Type";
		public static string FAM_Code = "FAM_Code";
		public static string FAM_From = "FAM_From";
		public static string FAM_To = "FAM_To";
		public static string ATTHOUR = "ATTHOUR";
		public static string ATTHOURNOTES = "ATTHOURNOTES";
		public static string ADDINC_QUALCODE = "ADDINC_QUALCODE";
		public static string ADDINC_QUALUSEMAIN = "ADDINC_QUALUSEMAIN";
		public static string ADDINC_USEPLACE = "ADDINC_USEPLACE";
		public static string ADDINC_ITEMCODE = "ADDINC_ITEMCODE";
		public static string ADDINC_PERIOD = "ADDINC_PERIOD";
		public static string ADDINC_PERIOD_NOW = "ADDINC_PERIOD_NOW";
		public static string ADDINC_INCEXP = "ADDINC_INCEXP";
		public static string ADDINC_EXPDATE = "ADDINC_EXPDATE";
		public static string ADDINC_EXPAMT = "ADDINC_EXPAMT";
		public static string ADDINC_ACTDATE = "ADDINC_ACTDATE";
		public static string ADDINC_ACTAMT = "ADDINC_ACTAMT";
		public static string ADDINC_REF = "ADDINC_REF";
		public static string ADDINC_DESC = "ADDINC_DESC";
		public static string ADDINC_METHOD = "ADDINC_METHOD";
		public static string ADDINC_COSTCEN = "ADDINC_COSTCEN";
		public static string ADDINC_COSTCENFRMCOHORT = "ADDINC_COSTCENFRMCOHORT";
		public static string ADDINC_STATUS = "ADDINC_STATUS";
		public static string ADDINC_NOTES = "ADDINC_NOTES";
		public static string Planned_Review_Date = "Planned_Review_Date";
		public static string Planned_Review_Type = "Planned_Review_Type";
		public static string JCP_CONTRACT = "JCP_CONTRACT";
		public static string JCP_CLIENTGROUP = "JCP_CLIENTGROUP";
		public static string JCP_HASREF2 = "JCP_HASREF2";
		public static string JCP_HASSL2 = "JCP_HASSL2";
		public static string JCP_UNEMPDUR = "JCP_UNEMPDUR";
		public static string JCP_PRIBENEFIT = "JCP_PRIBENEFIT";
		public static string JCP_ETHNICITY = "JCP_ETHNICITY";
		public static string JCP_ESFDISAB = "JCP_ESFDISAB";
		public static string JCP_ESFBENEFIT = "JCP_ESFBENEFIT";
		public static string JCP_PROVENTRY = "JCP_PROVENTRY";
		public static string JCP_COURSEDURATION = "JCP_COURSEDURATION";
		public static string JCP_PROVCLASS = "JCP_PROVCLASS";
		public static string JCP_ESFOBJECTIVE = "JCP_ESFOBJECTIVE";
		public static string JCP_ESFBACKGROUND = "JCP_ESFBACKGROUND";
		public static string JCP_JOBCENTRE = "JCP_JOBCENTRE";
		public static string ACTPLAN = "ACTPLAN";
		public static string Opportunity_Ident = "Opportunity_Ident";
		public static string Sig_User = "Sig_User";
		public static string Sig_Lrnr = "Sig_Lrnr";
		public static string Sig_Emp = "Sig_Emp";
		public static string Sig_EmpB = "Sig_EmpB";
		public static string Sig_EmpC = "Sig_EmpC";
		public static string Sig_OffA = "Sig_OffA";
		public static string Sig_OffB = "Sig_OffB";
		public static string Sig_ParG = "Sig_ParG";
		public static string Act_DP_Code = "Act_DP_Code";
		public static string Action_By = "Action_By";
		public static string Review_Type = "Review_Type";
		public static string Attended_Type = "Attended_Type";
		public static string APP_ETHNICITY = "APP_ETHNICITY";
		public static string EmpStat_LOE = "EmpStat_LOE";
		public static string EmpStat_EII = "EmpStat_EII";
		public static string EmpStat_LOU = "EmpStat_LOU";
		public static string EmpStat_SEI = "EmpStat_SEI";
		public static string EmpStat_BSI = "EmpStat_BSI";
		public static string EmpStat_RON = "EmpStat_RON";
		public static string EmpStat_PEI = "EmpStat_PEI";
		public static string EmpStat_SEM = "EmpStat_SEM";
		public static string EmpStat_Code = "EmpStat_Code";
		public static string Act_FUp_After = "Act_FUp_After";
		public static string COUNT = "COUNT";
		public static string ETHN1 = "ETHN1";
		public static string ETHN2 = "ETHN2";
		public static string APP_BAS_NUM = "APP_BAS_NUM";
		public static string APP_BAS_LIT = "APP_BAS_LIT";
		public static string APP_BAS_ICT = "APP_BAS_ICT";
	}
	
	public static class uSurveys
	{
		public static string SAVAL_MANDATORY = "MAND";
		public static string SAVAL_MAND_ERROR = "MANDERROR";
		public static string SAVAL_MIN_VALUE = "MIN_VALUE";
		public static string SAVAL_MAX_VALUE = "MAX_VALUE";
		public static string SAVAL_MIN_ERROR = "MIN_ERROR";
		public static string SAVAL_MAX_ERROR = "MAX_ERROR";
		public static string SAVAL_DEFAULT = "DEFAULT";
		public static string SAVAL_DPS = "DEC_PLACES";
	}
	
	public static class oPICSConfig
	{
		public static string FCA_Section = "FORMCAPAPP";
		public static string cfgKey_FCA_DeleteForms = "FCA_DeleteForms";
		public static string cfgKey_FCA_Apps_Enabled = "FCA_Apps_Enabled";
		public static string cfgKey_FCA_Apps_Filter_RecrOff = "FCA_Apps_Flt_RecrOff";
		public static string cfgKey_FCA_Apps_Filter_Status = "FCA_Apps_Flt_Status";
		public static string cfgKey_FCA_Learners_Enabled = "FCA_Lrnr_Enabled";
		public static string cfgKey_FCA_Learners_Filter_MainOff = "FCA_Lrnr_Flt_MainOff";
		public static string cfgKey_FCA_SendEvApp_Ready_ApStatus = "FCA_SendEvApp_Ready_ApStatus";
		public static string cfgKey_FCA_SendEvApp_Ready_ApSubStatus = "FCA_SendEvApp_Ready_ApSubStatus";
		public static string cfgKey_FCA_ReviewsDaysFwd = "FCA_ReviewsDaysFwd";
		public static string cfgKey_FCA_ReviewsDaysBack = "FCA_ReviewsDaysBAck";
		public static string cfgKey_FCA_ReviewDefault_Form = "FCA_Review_Def_Form_";
		public static string cfgKey_FCA_Debug_Mode = "FCA_Debug_Mode";
		public static string cfgKey_FCA_Orgs_AllowCreate = "FCA_Orgs_AllowCreate";
		public static string cfgKey_FCA_Orgs_StatusForNew = "FCA_Orgs_StatusForNew";
		
		private static List<string> _ReviewDefaultFormConfigList;
		public static List<string> ReviewDefaultFormConfigList
		{
			get
			{
				if(_ReviewDefaultFormConfigList == null)
				{
					_ReviewDefaultFormConfigList = new List<string>();
					_ReviewDefaultFormConfigList.Add("FCA_Review_Def_Form_N");
					_ReviewDefaultFormConfigList.Add("FCA_Review_Def_Form_S");
					_ReviewDefaultFormConfigList.Add("FCA_Review_Def_Form_C");
					_ReviewDefaultFormConfigList.Add("FCA_Review_Def_Form_A");
					_ReviewDefaultFormConfigList.Add("FCA_Review_Def_Form_M");
					_ReviewDefaultFormConfigList.Add("FCA_Review_Def_Form_H");
				}
				return _ReviewDefaultFormConfigList;
			}
		}
	}
	
	public static class SharedListLoad
	{
		
		private static Dictionary<string, string> _Act_DP_Code;
		public static Dictionary<string, string> Act_DP_Code
		{
			get
			{
				if(_Act_DP_Code == null)
				{
					_Act_DP_Code = new Dictionary<string, string>();
					_Act_DP_Code.Add("EDU1", "EDU1 - Traineeship");
					_Act_DP_Code.Add("EDU2", "EDU2 - Apprenticeship");
					_Act_DP_Code.Add("EDU3", "EDU3 - Supported Internship");
					_Act_DP_Code.Add("EDU4", "EDU4 - Other FE* (Full-time)");
					_Act_DP_Code.Add("EDU5", "EDU5 - Other FE* (Part-time)");
					_Act_DP_Code.Add("EDU6", "EDU6 - HE");
					_Act_DP_Code.Add("EMP1", "EMP1 - In paid employment for 16 hours or more per week");
					_Act_DP_Code.Add("EMP2", "EMP2 - In paid employment for less than 16 hours per week");
					_Act_DP_Code.Add("EMP4", "EMP4 - Self employed for 16 hours or more per week");
					_Act_DP_Code.Add("EMP5", "EMP5 - Self employed for less than 16 hours per week");
					_Act_DP_Code.Add("GAP1", "GAP1 - Gap year before starting HE");
					_Act_DP_Code.Add("NPE1", "NPE1 - Not in paid employment, looking for work and available to start work");
					_Act_DP_Code.Add("NPE2", "NPE2 - Not in paid employment, not looking for work and/or not available to start work (including retired)");
					_Act_DP_Code.Add("OTH1", "OTH1 - Other outcome – not listed");
					_Act_DP_Code.Add("OTH3", "OTH3 - Unable to contact learner");
					_Act_DP_Code.Add("OTH4", "OTH4 - Not known");
					_Act_DP_Code.Add("SDE1", "SDE1 - Supported independent living");
					_Act_DP_Code.Add("SDE2", "SDE2 - Independent living");
					_Act_DP_Code.Add("SDE3", "SDE3 - Learner returning home");
					_Act_DP_Code.Add("SDE4", "SDE4 - Long term residential placement");
					_Act_DP_Code.Add("VOL1", "VOL1 - Voluntary work");
				}
				return _Act_DP_Code;
			}
		}
		
		private static Dictionary<string, string> _Action_By;
		public static Dictionary<string, string> Action_By
		{
			get
			{
				if(_Action_By == null)
				{
					_Action_By = new Dictionary<string, string>();
					_Action_By.Add("", "Unknown");
					_Action_By.Add("L", "Learner");
					_Action_By.Add("M", "Mentor");
					_Action_By.Add("R", "Reviewer");
				}
				return _Action_By;
			}
		}
		
		private static Dictionary<string, string> _GCSE_MATH_GRADE;
		public static Dictionary<string, string> GCSE_MATH_GRADE
		{
			get
			{
				if(_GCSE_MATH_GRADE == null)
				{
					_GCSE_MATH_GRADE = new Dictionary<string, string>();
					_GCSE_MATH_GRADE.Add("A", "A");
					_GCSE_MATH_GRADE.Add("A*", "A*");
					_GCSE_MATH_GRADE.Add("A*A", "A*A");
					_GCSE_MATH_GRADE.Add("A*A*", "A*A*");
					_GCSE_MATH_GRADE.Add("AA", "AA");
					_GCSE_MATH_GRADE.Add("AB", "AB");
					_GCSE_MATH_GRADE.Add("B", "B");
					_GCSE_MATH_GRADE.Add("BB", "BB");
					_GCSE_MATH_GRADE.Add("BC", "BC");
					_GCSE_MATH_GRADE.Add("C", "C");
					_GCSE_MATH_GRADE.Add("CC", "CC");
					_GCSE_MATH_GRADE.Add("CD", "CD");
					_GCSE_MATH_GRADE.Add("D", "D");
					_GCSE_MATH_GRADE.Add("DD", "DD");
					_GCSE_MATH_GRADE.Add("DE", "DE");
					_GCSE_MATH_GRADE.Add("E", "E");
					_GCSE_MATH_GRADE.Add("EE", "EE");
					_GCSE_MATH_GRADE.Add("EF", "EF");
					_GCSE_MATH_GRADE.Add("F", "F");
					_GCSE_MATH_GRADE.Add("FF", "FF");
					_GCSE_MATH_GRADE.Add("FG", "FG");
					_GCSE_MATH_GRADE.Add("G", "G");
					_GCSE_MATH_GRADE.Add("GG", "GG");
					_GCSE_MATH_GRADE.Add("N", "N");
					_GCSE_MATH_GRADE.Add("U", "U");
					_GCSE_MATH_GRADE.Add("1", "1");
					_GCSE_MATH_GRADE.Add("2", "2");
					_GCSE_MATH_GRADE.Add("3", "3");
					_GCSE_MATH_GRADE.Add("4", "4");
					_GCSE_MATH_GRADE.Add("5", "5");
					_GCSE_MATH_GRADE.Add("6", "6");
					_GCSE_MATH_GRADE.Add("7", "7");
					_GCSE_MATH_GRADE.Add("8", "8");
					_GCSE_MATH_GRADE.Add("9", "9");
					_GCSE_MATH_GRADE.Add("NONE", "NONE");
				}
				return _GCSE_MATH_GRADE;
			}
		}
		
		private static Dictionary<string, string> _GCSE_ENG_GRADE;
		public static Dictionary<string, string> GCSE_ENG_GRADE
		{
			get
			{
				if(_GCSE_ENG_GRADE == null)
				{
					_GCSE_ENG_GRADE = new Dictionary<string, string>();
					_GCSE_ENG_GRADE.Add("A", "A");
					_GCSE_ENG_GRADE.Add("A*", "A*");
					_GCSE_ENG_GRADE.Add("A*A", "A*A");
					_GCSE_ENG_GRADE.Add("A*A*", "A*A*");
					_GCSE_ENG_GRADE.Add("AA", "AA");
					_GCSE_ENG_GRADE.Add("AB", "AB");
					_GCSE_ENG_GRADE.Add("B", "B");
					_GCSE_ENG_GRADE.Add("BB", "BB");
					_GCSE_ENG_GRADE.Add("BC", "BC");
					_GCSE_ENG_GRADE.Add("C", "C");
					_GCSE_ENG_GRADE.Add("CC", "CC");
					_GCSE_ENG_GRADE.Add("CD", "CD");
					_GCSE_ENG_GRADE.Add("D", "D");
					_GCSE_ENG_GRADE.Add("DD", "DD");
					_GCSE_ENG_GRADE.Add("DE", "DE");
					_GCSE_ENG_GRADE.Add("E", "E");
					_GCSE_ENG_GRADE.Add("EE", "EE");
					_GCSE_ENG_GRADE.Add("EF", "EF");
					_GCSE_ENG_GRADE.Add("F", "F");
					_GCSE_ENG_GRADE.Add("FF", "FF");
					_GCSE_ENG_GRADE.Add("FG", "FG");
					_GCSE_ENG_GRADE.Add("G", "G");
					_GCSE_ENG_GRADE.Add("GG", "GG");
					_GCSE_ENG_GRADE.Add("N", "N");
					_GCSE_ENG_GRADE.Add("U", "U");
					_GCSE_ENG_GRADE.Add("1", "1");
					_GCSE_ENG_GRADE.Add("2", "2");
					_GCSE_ENG_GRADE.Add("3", "3");
					_GCSE_ENG_GRADE.Add("4", "4");
					_GCSE_ENG_GRADE.Add("5", "5");
					_GCSE_ENG_GRADE.Add("6", "6");
					_GCSE_ENG_GRADE.Add("7", "7");
					_GCSE_ENG_GRADE.Add("8", "8");
					_GCSE_ENG_GRADE.Add("9", "9");
					_GCSE_ENG_GRADE.Add("NONE", "NONE");
				}
				return _GCSE_ENG_GRADE;
			}
		}
		
		private static Dictionary<string, string> _NUM_FIRSTASSLEV;
		public static Dictionary<string, string> NUM_FIRSTASSLEV
		{
			get
			{
				if(_NUM_FIRSTASSLEV == null)
				{
					_NUM_FIRSTASSLEV = new Dictionary<string, string>();
					_NUM_FIRSTASSLEV.Add("", "Not specified");
					_NUM_FIRSTASSLEV.Add("X", "Not required");
					_NUM_FIRSTASSLEV.Add("A", "Below Entry 1");
					_NUM_FIRSTASSLEV.Add("B", "Entry 1");
					_NUM_FIRSTASSLEV.Add("C", "Entry 2");
					_NUM_FIRSTASSLEV.Add("D", "Entry 3");
					_NUM_FIRSTASSLEV.Add("E", "Level 1");
					_NUM_FIRSTASSLEV.Add("F", "Level 2");
					_NUM_FIRSTASSLEV.Add("G", "Level 3");
					_NUM_FIRSTASSLEV.Add("Y", "Concession");
					_NUM_FIRSTASSLEV.Add("Z", "Proxy");
				}
				return _NUM_FIRSTASSLEV;
			}
		}
		
		private static Dictionary<string, string> _LIT_FIRSTASSLEV;
		public static Dictionary<string, string> LIT_FIRSTASSLEV
		{
			get
			{
				if(_LIT_FIRSTASSLEV == null)
				{
					_LIT_FIRSTASSLEV = new Dictionary<string, string>();
					_LIT_FIRSTASSLEV.Add("", "Not specified");
					_LIT_FIRSTASSLEV.Add("X", "Not required");
					_LIT_FIRSTASSLEV.Add("A", "Below Entry 1");
					_LIT_FIRSTASSLEV.Add("B", "Entry 1");
					_LIT_FIRSTASSLEV.Add("C", "Entry 2");
					_LIT_FIRSTASSLEV.Add("D", "Entry 3");
					_LIT_FIRSTASSLEV.Add("E", "Level 1");
					_LIT_FIRSTASSLEV.Add("F", "Level 2");
					_LIT_FIRSTASSLEV.Add("G", "Level 3");
					_LIT_FIRSTASSLEV.Add("Y", "Concession");
					_LIT_FIRSTASSLEV.Add("Z", "Proxy");
				}
				return _LIT_FIRSTASSLEV;
			}
		}
		
		private static Dictionary<string, string> _ICT_FIRSTASSLEV;
		public static Dictionary<string, string> ICT_FIRSTASSLEV
		{
			get
			{
				if(_ICT_FIRSTASSLEV == null)
				{
					_ICT_FIRSTASSLEV = new Dictionary<string, string>();
					_ICT_FIRSTASSLEV.Add("", "Not specified");
					_ICT_FIRSTASSLEV.Add("X", "Not required");
					_ICT_FIRSTASSLEV.Add("A", "Below Entry 1");
					_ICT_FIRSTASSLEV.Add("B", "Entry 1");
					_ICT_FIRSTASSLEV.Add("C", "Entry 2");
					_ICT_FIRSTASSLEV.Add("D", "Entry 3");
					_ICT_FIRSTASSLEV.Add("E", "Level 1");
					_ICT_FIRSTASSLEV.Add("F", "Level 2");
					_ICT_FIRSTASSLEV.Add("G", "Level 3");
					_ICT_FIRSTASSLEV.Add("Y", "Concession");
					_ICT_FIRSTASSLEV.Add("Z", "Proxy");
				}
				return _ICT_FIRSTASSLEV;
			}
		}
		
		private static Dictionary<string, string> _MCF;
		public static Dictionary<string, string> MCF
		{
			get
			{
				if(_MCF == null)
				{
					_MCF = new Dictionary<string, string>();
					_MCF.Add("1", "Learner is exempt from GCSE maths condition of funding due to a learning difficulty");
					_MCF.Add("2", "Learner is exempt from GCSE maths condition of funding as they hold an equivalent overseas qualification");
					_MCF.Add("3", "Learner has met the GCSE maths condition of funding as they hold an approved equivalent UK qualification");
					_MCF.Add("4", "Learner has met the GCSE maths condition of funding by undertaking/completing a valid maths GCSE or equivalent qualification at another institution through collaboration with the home institution");
					_MCF.Add("5", "Unassigned");
					_MCF.Add("6", "Unassigned");
					_MCF.Add("0", "Not applicable");
				}
				return _MCF;
			}
		}
		
		private static Dictionary<string, string> _ECF;
		public static Dictionary<string, string> ECF
		{
			get
			{
				if(_ECF == null)
				{
					_ECF = new Dictionary<string, string>();
					_ECF.Add("1", "Learner is exempt from GCSE English condition of funding due to a learning difficulty");
					_ECF.Add("2", "Learner is exempt from GCSE English condition of funding as they hold an equivalent overseas qualification");
					_ECF.Add("3", "Learner has met the GCSE English condition of funding as they hold an approved equivalent UK qualification");
					_ECF.Add("4", "Learner has met the GCSE English condition of funding by undertaking/completing a valid English GCSE or equivalent qualification at another institution through collaboration with the home institution");
					_ECF.Add("5", "Unassigned");
					_ECF.Add("6", "Unassigned");
					_ECF.Add("0", "Not applicable");
				}
				return _ECF;
			}
		}
		
		private static Dictionary<string, string> _MGA;
		public static Dictionary<string, string> MGA
		{
			get
			{
				if(_MGA == null)
				{
					_MGA = new Dictionary<string, string>();
					_MGA.Add("1", "Achieved A*-C by Y11");
					_MGA.Add("2", "Since Y11");
					_MGA.Add("3", "Not achieved A*-C ");
					_MGA.Add("0", "Not applicable");
				}
				return _MGA;
			}
		}
		
		private static Dictionary<string, string> _EGA;
		public static Dictionary<string, string> EGA
		{
			get
			{
				if(_EGA == null)
				{
					_EGA = new Dictionary<string, string>();
					_EGA.Add("1", "Achieved A*-C by Y11");
					_EGA.Add("2", "Since Y11");
					_EGA.Add("3", "Not achieved A*-C ");
					_EGA.Add("0", "Not applicable");
				}
				return _EGA;
			}
		}
		
		private static Dictionary<string, string> _HHS;
		public static Dictionary<string, string> HHS
		{
			get
			{
				if(_HHS == null)
				{
					_HHS = new Dictionary<string, string>();
					_HHS.Add("1", "No household member is in employment and the household includes one or more dependent children");
					_HHS.Add("2", "No household member is in employment and the household does not include any dependent children");
					_HHS.Add("3", "Learner lives in a single adult household with dependent children");
					_HHS.Add("98", "Learner has withheld this information");
					_HHS.Add("99", "None of HHS1, HHS2 or HHS3 applies");
					_HHS.Add("0", "Not applicable");
				}
				return _HHS;
			}
		}
		
		private static Dictionary<string, string> _PROG_HHS;
		public static Dictionary<string, string> PROG_HHS
		{
			get
			{
				if(_PROG_HHS == null)
				{
					_PROG_HHS = new Dictionary<string, string>();
					_PROG_HHS.Add("1", "No household member is in employment and the household includes one or more dependent children");
					_PROG_HHS.Add("2", "No household member is in employment and the household does not include any dependent children");
					_PROG_HHS.Add("3", "Learner lives in a single adult household with dependent children");
					_PROG_HHS.Add("98", "Learner has withheld this information");
					_PROG_HHS.Add("99", "None of HHS1, HHS2 or HHS3 applies");
					_PROG_HHS.Add("0", "Not applicable");
				}
				return _PROG_HHS;
			}
		}
		
		private static Dictionary<string, string> _ACT;
		public static Dictionary<string, string> ACT
		{
			get
			{
				if(_ACT == null)
				{
					_ACT = new Dictionary<string, string>();
					_ACT.Add("1", "Apprenticeship funded through a contract for services with the employer");
					_ACT.Add("2", "Apprenticeship funded through a contract for services with the SFA");
				}
				return _ACT;
			}
		}
		
		private static Dictionary<string, string> _PROG_ACT;
		public static Dictionary<string, string> PROG_ACT
		{
			get
			{
				if(_PROG_ACT == null)
				{
					_PROG_ACT = new Dictionary<string, string>();
					_PROG_ACT.Add("1", "Apprenticeship funded through a contract for services with the employer");
					_PROG_ACT.Add("2", "Apprenticeship funded through a contract for services with the SFA");
				}
				return _PROG_ACT;
			}
		}
		
		private static Dictionary<string, string> _FFI;
		public static Dictionary<string, string> FFI
		{
			get
			{
				if(_FFI == null)
				{
					_FFI = new Dictionary<string, string>();
					_FFI.Add("1", "Fully Funded");
					_FFI.Add("2", "Co-Funded");
					_FFI.Add("0", "N/A");
				}
				return _FFI;
			}
		}
		
		private static Dictionary<string, string> _PROG_FFI;
		public static Dictionary<string, string> PROG_FFI
		{
			get
			{
				if(_PROG_FFI == null)
				{
					_PROG_FFI = new Dictionary<string, string>();
					_PROG_FFI.Add("1", "Fully Funded");
					_PROG_FFI.Add("2", "Co-Funded");
					_PROG_FFI.Add("0", "N/A");
				}
				return _PROG_FFI;
			}
		}
		
		private static Dictionary<string, string> _RUI_SURVEYS;
		public static Dictionary<string, string> RUI_SURVEYS
		{
			get
			{
				if(_RUI_SURVEYS == null)
				{
					_RUI_SURVEYS = new Dictionary<string, string>();
					_RUI_SURVEYS.Add("Y", "Do not contact about Surveys");
					_RUI_SURVEYS.Add(".", "Contact me about Surveys");
				}
				return _RUI_SURVEYS;
			}
		}
		
		private static Dictionary<string, string> _RUI_COURSES;
		public static Dictionary<string, string> RUI_COURSES
		{
			get
			{
				if(_RUI_COURSES == null)
				{
					_RUI_COURSES = new Dictionary<string, string>();
					_RUI_COURSES.Add("Y", "Do not contact about Courses");
					_RUI_COURSES.Add(".", "Contact me about Courses");
				}
				return _RUI_COURSES;
			}
		}
		
		private static Dictionary<string, string> _RUI;
		public static Dictionary<string, string> RUI
		{
			get
			{
				if(_RUI == null)
				{
					_RUI = new Dictionary<string, string>();
					_RUI.Add("1", "No courses or learning opportunities");
					_RUI.Add("2", "No surveys or research");
					_RUI.Add("4", "No contact (Illness or other circumstances)");
					_RUI.Add("5", "No contact (learner has died)");
					_RUI.Add("6", "Allow contact about courses or learning opportunities");
					_RUI.Add("7", "Allow contact for surveys and research");
				}
				return _RUI;
			}
		}
		
		private static Dictionary<string, string> _L52_POST;
		public static Dictionary<string, string> L52_POST
		{
			get
			{
				if(_L52_POST == null)
				{
					_L52_POST = new Dictionary<string, string>();
					_L52_POST.Add("Y", "Do not contact by Post");
					_L52_POST.Add(".", "Contact by Post");
				}
				return _L52_POST;
			}
		}
		
		private static Dictionary<string, string> _L52_PHONE;
		public static Dictionary<string, string> L52_PHONE
		{
			get
			{
				if(_L52_PHONE == null)
				{
					_L52_PHONE = new Dictionary<string, string>();
					_L52_PHONE.Add("Y", "Do not contact by Phone");
					_L52_PHONE.Add(".", "Contact by Phone");
				}
				return _L52_PHONE;
			}
		}
		
		private static Dictionary<string, string> _L52_EMAIL;
		public static Dictionary<string, string> L52_EMAIL
		{
			get
			{
				if(_L52_EMAIL == null)
				{
					_L52_EMAIL = new Dictionary<string, string>();
					_L52_EMAIL.Add("Y", "Do not contact by Email");
					_L52_EMAIL.Add(".", "Contact by Email");
				}
				return _L52_EMAIL;
			}
		}
		
		private static Dictionary<string, string> _L52;
		public static Dictionary<string, string> L52
		{
			get
			{
				if(_L52 == null)
				{
					_L52 = new Dictionary<string, string>();
					_L52.Add("P", "Not by Post");
					_L52.Add("T", "Not by Telephone");
					_L52.Add("E", "Not by EMail");
					_L52.Add("4", "Allow Post");
					_L52.Add("5", "Allow Telephone");
					_L52.Add("6", "Allow EMail");
				}
				return _L52;
			}
		}
		
		private static Dictionary<string, string> _L14;
		public static Dictionary<string, string> L14
		{
			get
			{
				if(_L14 == null)
				{
					_L14 = new Dictionary<string, string>();
					_L14.Add("Y", "Yes");
					_L14.Add("N", "No");
				}
				return _L14;
			}
		}
		
		private static Dictionary<string, string> _L15;
		public static Dictionary<string, string> L15
		{
			get
			{
				if(_L15 == null)
				{
					_L15 = new Dictionary<string, string>();
					_L15.Add("98", "No disability");
					_L15.Add("01", "Visual impairment");
					_L15.Add("02", "Hearing impairment");
					_L15.Add("03", "Disability affecting mobility");
					_L15.Add("04", "Other physical disability");
					_L15.Add("05", "Other medical condition (for example epilepsy, asthma, diabetes)");
					_L15.Add("06", "Emotional/behavioural difficulties");
					_L15.Add("07", "Mental ill health");
					_L15.Add("08", "Temporary disability after illness (for example post-viral) or accident");
					_L15.Add("09", "Profound complex disabilities");
					_L15.Add("10", "Aspergers Syndrome");
					_L15.Add("90", "Multiple disabilities");
					_L15.Add("97", "Other");
					_L15.Add("99", "Not known/information not provided");
				}
				return _L15;
			}
		}
		
		private static Dictionary<string, string> _L16;
		public static Dictionary<string, string> L16
		{
			get
			{
				if(_L16 == null)
				{
					_L16 = new Dictionary<string, string>();
					_L16.Add("98", "No learning difficulty");
					_L16.Add("01", "Moderate learning difficulty");
					_L16.Add("02", "Severe learning difficulty");
					_L16.Add("10", "Dyslexia");
					_L16.Add("11", "Dyscalculia");
					_L16.Add("19", "Other specific learning difficulty");
					_L16.Add("20", "Autism Spectrum Disorder");
					_L16.Add("90", "Multiple learning difficulties");
					_L16.Add("97", "Other");
					_L16.Add("99", "Not known/information not provided");
				}
				return _L16;
			}
		}
		
		private static Dictionary<string, string> _LDA;
		public static Dictionary<string, string> LDA
		{
			get
			{
				if(_LDA == null)
				{
					_LDA = new Dictionary<string, string>();
					_LDA.Add("1", "Has Section 139A Learning Difficulty Assessment");
					_LDA.Add("0", "Not applicable");
				}
				return _LDA;
			}
		}
		
		private static Dictionary<string, string> _EHC;
		public static Dictionary<string, string> EHC
		{
			get
			{
				if(_EHC == null)
				{
					_EHC = new Dictionary<string, string>();
					_EHC.Add("1", "Learner has an Education Health Care plan");
					_EHC.Add("0", "Not applicable");
				}
				return _EHC;
			}
		}
		
		private static Dictionary<string, string> _PRIOREDU;
		public static Dictionary<string, string> PRIOREDU
		{
			get
			{
				if(_PRIOREDU == null)
				{
					_PRIOREDU = new Dictionary<string, string>();
					_PRIOREDU.Add("00", "Not required");
					_PRIOREDU.Add("09", "Entry level");
					_PRIOREDU.Add("07", "Other sub lev 1");
					_PRIOREDU.Add("01", "Level 1");
					_PRIOREDU.Add("02", "Full Level 2");
					_PRIOREDU.Add("03", "Full Level 3");
					_PRIOREDU.Add("10", "Level 4");
					_PRIOREDU.Add("11", "Level 5");
					_PRIOREDU.Add("12", "Level 6");
					_PRIOREDU.Add("13", "Level 7 and above");
					_PRIOREDU.Add("97", "Other");
					_PRIOREDU.Add("98", "Not known");
					_PRIOREDU.Add("99", "None");
				}
				return _PRIOREDU;
			}
		}
		
		private static Dictionary<string, string> _COUNTRY;
		public static Dictionary<string, string> COUNTRY
		{
			get
			{
				if(_COUNTRY == null)
				{
					_COUNTRY = new Dictionary<string, string>();
					_COUNTRY.Add("000", "Not known");
					_COUNTRY.Add("AFG", "Afghanistan");
					_COUNTRY.Add("ALA", "Aland Islands");
					_COUNTRY.Add("ALB", "Albania");
					_COUNTRY.Add("DZA", "Algeria");
					_COUNTRY.Add("ASM", "American Samoa");
					_COUNTRY.Add("AND", "Andorra");
					_COUNTRY.Add("AGO", "Angola");
					_COUNTRY.Add("AIA", "Anguilla");
					_COUNTRY.Add("ATA", "Antarctica");
					_COUNTRY.Add("ATG", "Antigua and Barbuda");
					_COUNTRY.Add("ARG", "Argentina");
					_COUNTRY.Add("ARM", "Armenia");
					_COUNTRY.Add("ABW", "Aruba");
					_COUNTRY.Add("AUS", "Australia");
					_COUNTRY.Add("AUT", "Austria");
					_COUNTRY.Add("AZE", "Azerbaijan");
					_COUNTRY.Add("BHS", "Bahamas");
					_COUNTRY.Add("BHR", "Bahrain");
					_COUNTRY.Add("BGD", "Bangladesh");
					_COUNTRY.Add("BRB", "Barbados");
					_COUNTRY.Add("BLR", "Belarus");
					_COUNTRY.Add("BEL", "Belgium");
					_COUNTRY.Add("BLZ", "Belize");
					_COUNTRY.Add("BEN", "Benin");
					_COUNTRY.Add("BMU", "Bermuda");
					_COUNTRY.Add("BTN", "Bhutan");
					_COUNTRY.Add("BOL", "Bolivia");
					_COUNTRY.Add("BIH", "Bosnia and Herzegovina");
					_COUNTRY.Add("BWA", "Botswana");
					_COUNTRY.Add("BVT", "Bouvet Island");
					_COUNTRY.Add("BRA", "Brazil");
                    _COUNTRY.Add("ATB", "British Antarctic Territory");
					_COUNTRY.Add("IOT", "British Indian Ocean Territory");
					_COUNTRY.Add("BRN", "Brunei");
					_COUNTRY.Add("BGR", "Bulgaria");
					_COUNTRY.Add("BFA", "Burkina Faso");
					_COUNTRY.Add("BUR", "Burma");
					_COUNTRY.Add("BDI", "Burundi");
					_COUNTRY.Add("KHM", "Cambodia");
					_COUNTRY.Add("CMR", "Cameroon");
					_COUNTRY.Add("CAN", "Canada");
					_COUNTRY.Add("CTE", "Canton and Enderbury Islands");
					_COUNTRY.Add("CPV", "Cape Verde");
					_COUNTRY.Add("CYM", "Cayman Islands");
					_COUNTRY.Add("CAF", "Central African Republic");
					_COUNTRY.Add("TCD", "Chad");
					_COUNTRY.Add("CHL", "Chile");
					_COUNTRY.Add("CHN", "China");
					_COUNTRY.Add("CXR", "Christmas Island");
					_COUNTRY.Add("CCK", "Cocos (Keeling) Islands");
					_COUNTRY.Add("COL", "Colombia");
					_COUNTRY.Add("COM", "Comoros");
					_COUNTRY.Add("COG", "Congo");
					_COUNTRY.Add("COD", "Congo, Democratic Republic");
					_COUNTRY.Add("COK", "Cook Islands");
					_COUNTRY.Add("CRI", "Costa Rica");
					_COUNTRY.Add("HRV", "Croatia");
					_COUNTRY.Add("CUB", "Cuba");
					_COUNTRY.Add("CYP", "Cyprus");
					_COUNTRY.Add("CZE", "Czech Republic");
					_COUNTRY.Add("CSK", "Czechoslovakia");
					_COUNTRY.Add("DHY", "Dahomey");
					_COUNTRY.Add("YMD", "Democratic Yemen");
					_COUNTRY.Add("DNK", "Denmark");
					_COUNTRY.Add("DJI", "Djibouti");
					_COUNTRY.Add("DMA", "Dominica");
					_COUNTRY.Add("DOM", "Dominican Republic");
					_COUNTRY.Add("ATN", "Dronning Maud Land");
					_COUNTRY.Add("TMP", "East Timor");
					_COUNTRY.Add("ECU", "Ecuador");
					_COUNTRY.Add("EGY", "Egypt");
					_COUNTRY.Add("SLV", "El Salvador");
					_COUNTRY.Add("GNQ", "Equatorial Guinea");
					_COUNTRY.Add("ERI", "Eritrea");
					_COUNTRY.Add("EST", "Estonia");
					_COUNTRY.Add("ETH", "Ethiopia");
					_COUNTRY.Add("FLK", "Falkland Islands");
					_COUNTRY.Add("FRO", "Faroe Islands");
					_COUNTRY.Add("FJI", "Fiji");
					_COUNTRY.Add("FIN", "Finland");
					_COUNTRY.Add("FRA", "France");
					_COUNTRY.Add("GUF", "French Guiana");
					_COUNTRY.Add("PYF", "French Polynesia");
					_COUNTRY.Add("ATF", "French Southern Territories");
					_COUNTRY.Add("AFI", "French Territory of Afars and Issas");
					_COUNTRY.Add("GAB", "Gabon");
					_COUNTRY.Add("GMB", "Gambia, The");
					_COUNTRY.Add("GEO", "Georgia");
					_COUNTRY.Add("DDR", "German Democratic Republic");
					_COUNTRY.Add("DEU", "Germany");
					_COUNTRY.Add("GHA", "Ghana");
					_COUNTRY.Add("GIB", "Gibraltar");
					_COUNTRY.Add("GEL", "Gilbert Islands");
					_COUNTRY.Add("GRC", "Greece");
					_COUNTRY.Add("GRL", "Greenland");
					_COUNTRY.Add("GRD", "Grenada");
					_COUNTRY.Add("GLP", "Guadeloupe");
					_COUNTRY.Add("GUM", "Guam");
					_COUNTRY.Add("GTM", "Guatemala");
					_COUNTRY.Add("GGY", "Guernsey");
					_COUNTRY.Add("GIN", "Guinea");
					_COUNTRY.Add("GNB", "Guinea-Bissau");
					_COUNTRY.Add("GUY", "Guyana");
					_COUNTRY.Add("HTI", "Haiti");
					_COUNTRY.Add("HMD", "Heard Island and McDonald Islands");
					_COUNTRY.Add("VAT", "Holy See/Vatican City");
					_COUNTRY.Add("HND", "Honduras");
					_COUNTRY.Add("HKG", "Hong Kong");
					_COUNTRY.Add("HUN", "Hungary");
					_COUNTRY.Add("ISL", "Iceland");
					_COUNTRY.Add("IND", "India");
					_COUNTRY.Add("IDN", "Indonesia");
					_COUNTRY.Add("IRN", "Iran");
					_COUNTRY.Add("IRQ", "Iraq");
					_COUNTRY.Add("IRL", "Ireland");
					_COUNTRY.Add("IMN", "Isle of Man");
					_COUNTRY.Add("ISR", "Israel");
					_COUNTRY.Add("ITA", "Italy");
					_COUNTRY.Add("CIV", "Ivory Coast");
					_COUNTRY.Add("JAM", "Jamaica");
					_COUNTRY.Add("JPN", "Japan");
					_COUNTRY.Add("JEY", "Jersey");
					_COUNTRY.Add("JTN", "Johnston Atoll");
					_COUNTRY.Add("JOR", "Jordan");
					_COUNTRY.Add("KAZ", "Kazakhstan");
					_COUNTRY.Add("KEN", "Kenya");
					_COUNTRY.Add("KIR", "Kiribati");
					_COUNTRY.Add("PRK", "Korea, North");
					_COUNTRY.Add("KOR", "Korea, South");
					_COUNTRY.Add("KWT", "Kuwait");
					_COUNTRY.Add("KGZ", "Kyrgyzstan");
					_COUNTRY.Add("LAO", "Laos");
					_COUNTRY.Add("LVA", "Latvia");
					_COUNTRY.Add("LBN", "Lebanon");
					_COUNTRY.Add("LSO", "Lesotho");
					_COUNTRY.Add("LBR", "Liberia");
					_COUNTRY.Add("LBY", "Libya");
					_COUNTRY.Add("LIE", "Liechtenstein");
					_COUNTRY.Add("LTU", "Lithuania");
					_COUNTRY.Add("LUX", "Luxembourg");
					_COUNTRY.Add("MAC", "Macao");
					_COUNTRY.Add("MKD", "Macedonia");
					_COUNTRY.Add("MDG", "Madagascar");
					_COUNTRY.Add("MWI", "Malawi");
					_COUNTRY.Add("MYS", "Malaysia");
					_COUNTRY.Add("MDV", "Maldives");
					_COUNTRY.Add("MLI", "Mali");
					_COUNTRY.Add("MLT", "Malta");
					_COUNTRY.Add("MHL", "Marshall Islands");
					_COUNTRY.Add("MTQ", "Martinique");
					_COUNTRY.Add("MRT", "Mauritania");
					_COUNTRY.Add("MUS", "Mauritius");
					_COUNTRY.Add("MYT", "Mayotte");
					_COUNTRY.Add("MEX", "Mexico");
					_COUNTRY.Add("FSM", "Micronesia");
					_COUNTRY.Add("MID", "Midway Islands");
					_COUNTRY.Add("MDA", "Moldova");
					_COUNTRY.Add("MCO", "Monaco");
					_COUNTRY.Add("MNG", "Mongolia");
					_COUNTRY.Add("MNE", "Montenegro");
					_COUNTRY.Add("MSR", "Montserrat");
					_COUNTRY.Add("MAR", "Morocco");
					_COUNTRY.Add("MOZ", "Mozambique");
					_COUNTRY.Add("MMR", "Myanmar");
					_COUNTRY.Add("NAM", "Namibia");
					_COUNTRY.Add("NRU", "Nauru");
					_COUNTRY.Add("NPL", "Nepal");
					_COUNTRY.Add("NLD", "Netherlands");
					_COUNTRY.Add("ANT", "Netherlands Antilles");
					_COUNTRY.Add("NCL", "New Caledonia");
					_COUNTRY.Add("NHB", "New Hebrides");
					_COUNTRY.Add("NZL", "New Zealand");
					_COUNTRY.Add("NIC", "Nicaragua");
					_COUNTRY.Add("NER", "Niger");
					_COUNTRY.Add("NGA", "Nigeria");
					_COUNTRY.Add("NIU", "Niue");
					_COUNTRY.Add("NFK", "Norfolk Island");
					_COUNTRY.Add("MNP", "Northern Mariana Islands");
					_COUNTRY.Add("NOR", "Norway");
					_COUNTRY.Add("OMN", "Oman");
					_COUNTRY.Add("PAK", "Pakistan");
					_COUNTRY.Add("PLW", "Palau");
					_COUNTRY.Add("PSE", "Palestine");
					_COUNTRY.Add("PAN", "Panama");
                    _COUNTRY.Add("PCZ", "Panama Canal Zone");
					_COUNTRY.Add("PNG", "Papua New Guinea");
					_COUNTRY.Add("PRY", "Paraguay");
					_COUNTRY.Add("PER", "Peru");
					_COUNTRY.Add("PHL", "Philippines");
					_COUNTRY.Add("PCN", "Pitcairn");
					_COUNTRY.Add("POL", "Poland");
					_COUNTRY.Add("PRT", "Portugal");
					_COUNTRY.Add("PRI", "Puerto Rico");
					_COUNTRY.Add("QAT", "Qatar");
					_COUNTRY.Add("REU", "Reunion");
					_COUNTRY.Add("ROU", "Romania");
					_COUNTRY.Add("RUS", "Russia");
					_COUNTRY.Add("RWA", "Rwanda");
					_COUNTRY.Add("SHN", "Saint Helena");
					_COUNTRY.Add("KNA", "Saint Kitts and Nevis");
					_COUNTRY.Add("LCA", "Saint Lucia");
					_COUNTRY.Add("SPM", "Saint Pierre and Miquelon");
					_COUNTRY.Add("VCT", "Saint Vincent and the Grenadines");
					_COUNTRY.Add("WSM", "Samoa");
					_COUNTRY.Add("SMR", "San Marino");
					_COUNTRY.Add("STP", "Sao Tome and Principe");
					_COUNTRY.Add("SAU", "Saudi Arabia");
					_COUNTRY.Add("SEN", "Senegal");
					_COUNTRY.Add("SRB", "Serbia");
					_COUNTRY.Add("SCG", "Serbia and Montenegro");
					_COUNTRY.Add("SYC", "Seychelles");
					_COUNTRY.Add("SLE", "Sierra Leone");
					_COUNTRY.Add("SGP", "Singapore");
					_COUNTRY.Add("SVK", "Slovakia");
					_COUNTRY.Add("SVN", "Slovenia");
					_COUNTRY.Add("SLB", "Solomon Islands");
					_COUNTRY.Add("SOM", "Somalia");
					_COUNTRY.Add("ZAF", "South Africa");
					_COUNTRY.Add("SGS", "South Georgia");
                    _COUNTRY.Add("VDR", "South Vietnam");
                    _COUNTRY.Add("ESP", "Spain");
					_COUNTRY.Add("LKA", "Sri Lanka");
					_COUNTRY.Add("SDN", "Sudan");
					_COUNTRY.Add("SUR", "Suriname");
					_COUNTRY.Add("SJM", "Svalbard and Jan Mayen");
					_COUNTRY.Add("SWZ", "Swaziland");
					_COUNTRY.Add("SWE", "Sweden");
					_COUNTRY.Add("CHE", "Switzerland");
					_COUNTRY.Add("SYR", "Syria");
					_COUNTRY.Add("TWN", "Taiwan");
					_COUNTRY.Add("TJK", "Tajikistan");
					_COUNTRY.Add("TZA", "Tanzania");
					_COUNTRY.Add("THA", "Thailand");
					_COUNTRY.Add("TLS", "Timor-Leste");
					_COUNTRY.Add("TGO", "Togo");
					_COUNTRY.Add("TKL", "Tokelau");
					_COUNTRY.Add("TON", "Tonga");
					_COUNTRY.Add("TTO", "Trinidad and Tobago");
					_COUNTRY.Add("PCI", "Trust Territory of the Pacific Islands");
					_COUNTRY.Add("TUN", "Tunisia");
					_COUNTRY.Add("TUR", "Turkey");
					_COUNTRY.Add("TKM", "Turkmenistan");
					_COUNTRY.Add("TCA", "Turks and Caicos Islands");
					_COUNTRY.Add("TUV", "Tuvalu");
					_COUNTRY.Add("UGA", "Uganda");
					_COUNTRY.Add("UKR", "Ukraine");
					_COUNTRY.Add("SUN", "Union of Soviet Socialist Republics");
					_COUNTRY.Add("ARE", "United Arab Emirates");
					_COUNTRY.Add("GBR", "United Kingdom");
					_COUNTRY.Add("USA", "United States");
					_COUNTRY.Add("UMI", "United States Minor Outlying Islands");
					_COUNTRY.Add("PUS", "United States Miscellaneous Pacific Islands");
					_COUNTRY.Add("HVO", "Upper Volta");
					_COUNTRY.Add("URY", "Uruguay");
					_COUNTRY.Add("UZB", "Uzbekistan");
					_COUNTRY.Add("VUT", "Vanuatu");
					_COUNTRY.Add("VEN", "Venezuela");
					_COUNTRY.Add("VNM", "Vietnam");
					_COUNTRY.Add("VGB", "Virgin Islands, British");
					_COUNTRY.Add("VIR", "Virgin Islands, U.S.");
					_COUNTRY.Add("WAK", "Wake Island");
					_COUNTRY.Add("WLF", "Wallis and Futuna");
					_COUNTRY.Add("ESH", "Western Sahara");
					_COUNTRY.Add("YEM", "Yemen");
					_COUNTRY.Add("YUG", "Yugoslavia");
					_COUNTRY.Add("ZAR", "Zaire");
					_COUNTRY.Add("ZMB", "Zambia");
					_COUNTRY.Add("ZWE", "Zimbabwe");
				}
				return _COUNTRY;
			}
		}
		
		private static Dictionary<string, string> _COUNT;
		public static Dictionary<string, string> COUNT
		{
			get
			{
				if(_COUNT == null)
				{
					_COUNT = new Dictionary<string, string>();
                    _COUNT.Add("000", "Not known");
                    _COUNT.Add("AFG", "Afghanistan");
                    _COUNT.Add("ALA", "Aland Islands");
                    _COUNT.Add("ALB", "Albania");
                    _COUNT.Add("DZA", "Algeria");
                    _COUNT.Add("ASM", "American Samoa");
                    _COUNT.Add("AND", "Andorra");
                    _COUNT.Add("AGO", "Angola");
                    _COUNT.Add("AIA", "Anguilla");
                    _COUNT.Add("ATA", "Antarctica");
                    _COUNT.Add("ATG", "Antigua and Barbuda");
                    _COUNT.Add("ARG", "Argentina");
                    _COUNT.Add("ARM", "Armenia");
                    _COUNT.Add("ABW", "Aruba");
                    _COUNT.Add("AUS", "Australia");
                    _COUNT.Add("AUT", "Austria");
                    _COUNT.Add("AZE", "Azerbaijan");
                    _COUNT.Add("BHS", "Bahamas");
                    _COUNT.Add("BHR", "Bahrain");
                    _COUNT.Add("BGD", "Bangladesh");
                    _COUNT.Add("BRB", "Barbados");
                    _COUNT.Add("BLR", "Belarus");
                    _COUNT.Add("BEL", "Belgium");
                    _COUNT.Add("BLZ", "Belize");
                    _COUNT.Add("BEN", "Benin");
                    _COUNT.Add("BMU", "Bermuda");
                    _COUNT.Add("BTN", "Bhutan");
                    _COUNT.Add("BOL", "Bolivia");
                    _COUNT.Add("BIH", "Bosnia and Herzegovina");
                    _COUNT.Add("BWA", "Botswana");
                    _COUNT.Add("BVT", "Bouvet Island");
                    _COUNT.Add("BRA", "Brazil");
                    _COUNT.Add("ATB", "British Antarctic Territory");
                    _COUNT.Add("IOT", "British Indian Ocean Territory");
                    _COUNT.Add("BRN", "Brunei");
                    _COUNT.Add("BGR", "Bulgaria");
                    _COUNT.Add("BFA", "Burkina Faso");
                    _COUNT.Add("BUR", "Burma");
                    _COUNT.Add("BDI", "Burundi");
                    _COUNT.Add("KHM", "Cambodia");
                    _COUNT.Add("CMR", "Cameroon");
                    _COUNT.Add("CAN", "Canada");
                    _COUNT.Add("CTE", "Canton and Enderbury Islands");
                    _COUNT.Add("CPV", "Cape Verde");
                    _COUNT.Add("CYM", "Cayman Islands");
                    _COUNT.Add("CAF", "Central African Republic");
                    _COUNT.Add("TCD", "Chad");
                    _COUNT.Add("CHL", "Chile");
                    _COUNT.Add("CHN", "China");
                    _COUNT.Add("CXR", "Christmas Island");
                    _COUNT.Add("CCK", "Cocos (Keeling) Islands");
                    _COUNT.Add("COL", "Colombia");
                    _COUNT.Add("COM", "Comoros");
                    _COUNT.Add("COG", "Congo");
                    _COUNT.Add("COD", "Congo, Democratic Republic");
                    _COUNT.Add("COK", "Cook Islands");
                    _COUNT.Add("CRI", "Costa Rica");
                    _COUNT.Add("HRV", "Croatia");
                    _COUNT.Add("CUB", "Cuba");
                    _COUNT.Add("CYP", "Cyprus");
                    _COUNT.Add("CZE", "Czech Republic");
                    _COUNT.Add("CSK", "Czechoslovakia");
                    _COUNT.Add("DHY", "Dahomey");
                    _COUNT.Add("YMD", "Democratic Yemen");
                    _COUNT.Add("DNK", "Denmark");
                    _COUNT.Add("DJI", "Djibouti");
                    _COUNT.Add("DMA", "Dominica");
                    _COUNT.Add("DOM", "Dominican Republic");
                    _COUNT.Add("ATN", "Dronning Maud Land");
                    _COUNT.Add("TMP", "East Timor");
                    _COUNT.Add("ECU", "Ecuador");
                    _COUNT.Add("EGY", "Egypt");
                    _COUNT.Add("SLV", "El Salvador");
                    _COUNT.Add("GNQ", "Equatorial Guinea");
                    _COUNT.Add("ERI", "Eritrea");
                    _COUNT.Add("EST", "Estonia");
                    _COUNT.Add("ETH", "Ethiopia");
                    _COUNT.Add("FLK", "Falkland Islands");
                    _COUNT.Add("FRO", "Faroe Islands");
                    _COUNT.Add("FJI", "Fiji");
                    _COUNT.Add("FIN", "Finland");
                    _COUNT.Add("FRA", "France");
                    _COUNT.Add("GUF", "French Guiana");
                    _COUNT.Add("PYF", "French Polynesia");
                    _COUNT.Add("ATF", "French Southern Territories");
                    _COUNT.Add("AFI", "French Territory of Afars and Issas");
                    _COUNT.Add("GAB", "Gabon");
                    _COUNT.Add("GMB", "Gambia, The");
                    _COUNT.Add("GEO", "Georgia");
                    _COUNT.Add("DDR", "German Democratic Republic");
                    _COUNT.Add("DEU", "Germany");
                    _COUNT.Add("GHA", "Ghana");
                    _COUNT.Add("GIB", "Gibraltar");
                    _COUNT.Add("GEL", "Gilbert Islands");
                    _COUNT.Add("GRC", "Greece");
                    _COUNT.Add("GRL", "Greenland");
                    _COUNT.Add("GRD", "Grenada");
                    _COUNT.Add("GLP", "Guadeloupe");
                    _COUNT.Add("GUM", "Guam");
                    _COUNT.Add("GTM", "Guatemala");
                    _COUNT.Add("GGY", "Guernsey");
                    _COUNT.Add("GIN", "Guinea");
                    _COUNT.Add("GNB", "Guinea-Bissau");
                    _COUNT.Add("GUY", "Guyana");
                    _COUNT.Add("HTI", "Haiti");
                    _COUNT.Add("HMD", "Heard Island and McDonald Islands");
                    _COUNT.Add("VAT", "Holy See/Vatican City");
                    _COUNT.Add("HND", "Honduras");
                    _COUNT.Add("HKG", "Hong Kong");
                    _COUNT.Add("HUN", "Hungary");
                    _COUNT.Add("ISL", "Iceland");
                    _COUNT.Add("IND", "India");
                    _COUNT.Add("IDN", "Indonesia");
                    _COUNT.Add("IRN", "Iran");
                    _COUNT.Add("IRQ", "Iraq");
                    _COUNT.Add("IRL", "Ireland");
                    _COUNT.Add("IMN", "Isle of Man");
                    _COUNT.Add("ISR", "Israel");
                    _COUNT.Add("ITA", "Italy");
                    _COUNT.Add("CIV", "Ivory Coast");
                    _COUNT.Add("JAM", "Jamaica");
                    _COUNT.Add("JPN", "Japan");
                    _COUNT.Add("JEY", "Jersey");
                    _COUNT.Add("JTN", "Johnston Atoll");
                    _COUNT.Add("JOR", "Jordan");
                    _COUNT.Add("KAZ", "Kazakhstan");
                    _COUNT.Add("KEN", "Kenya");
                    _COUNT.Add("KIR", "Kiribati");
                    _COUNT.Add("PRK", "Korea, North");
                    _COUNT.Add("KOR", "Korea, South");
                    _COUNT.Add("KWT", "Kuwait");
                    _COUNT.Add("KGZ", "Kyrgyzstan");
                    _COUNT.Add("LAO", "Laos");
                    _COUNT.Add("LVA", "Latvia");
                    _COUNT.Add("LBN", "Lebanon");
                    _COUNT.Add("LSO", "Lesotho");
                    _COUNT.Add("LBR", "Liberia");
                    _COUNT.Add("LBY", "Libya");
                    _COUNT.Add("LIE", "Liechtenstein");
                    _COUNT.Add("LTU", "Lithuania");
                    _COUNT.Add("LUX", "Luxembourg");
                    _COUNT.Add("MAC", "Macao");
                    _COUNT.Add("MKD", "Macedonia");
                    _COUNT.Add("MDG", "Madagascar");
                    _COUNT.Add("MWI", "Malawi");
                    _COUNT.Add("MYS", "Malaysia");
                    _COUNT.Add("MDV", "Maldives");
                    _COUNT.Add("MLI", "Mali");
                    _COUNT.Add("MLT", "Malta");
                    _COUNT.Add("MHL", "Marshall Islands");
                    _COUNT.Add("MTQ", "Martinique");
                    _COUNT.Add("MRT", "Mauritania");
                    _COUNT.Add("MUS", "Mauritius");
                    _COUNT.Add("MYT", "Mayotte");
                    _COUNT.Add("MEX", "Mexico");
                    _COUNT.Add("FSM", "Micronesia");
                    _COUNT.Add("MID", "Midway Islands");
                    _COUNT.Add("MDA", "Moldova");
                    _COUNT.Add("MCO", "Monaco");
                    _COUNT.Add("MNG", "Mongolia");
                    _COUNT.Add("MNE", "Montenegro");
                    _COUNT.Add("MSR", "Montserrat");
                    _COUNT.Add("MAR", "Morocco");
                    _COUNT.Add("MOZ", "Mozambique");
                    _COUNT.Add("MMR", "Myanmar");
                    _COUNT.Add("NAM", "Namibia");
                    _COUNT.Add("NRU", "Nauru");
                    _COUNT.Add("NPL", "Nepal");
                    _COUNT.Add("NLD", "Netherlands");
                    _COUNT.Add("ANT", "Netherlands Antilles");
                    _COUNT.Add("NCL", "New Caledonia");
                    _COUNT.Add("NHB", "New Hebrides");
                    _COUNT.Add("NZL", "New Zealand");
                    _COUNT.Add("NIC", "Nicaragua");
                    _COUNT.Add("NER", "Niger");
                    _COUNT.Add("NGA", "Nigeria");
                    _COUNT.Add("NIU", "Niue");
                    _COUNT.Add("NFK", "Norfolk Island");
                    _COUNT.Add("MNP", "Northern Mariana Islands");
                    _COUNT.Add("NOR", "Norway");
                    _COUNT.Add("OMN", "Oman");
                    _COUNT.Add("PAK", "Pakistan");
                    _COUNT.Add("PLW", "Palau");
                    _COUNT.Add("PSE", "Palestine");
                    _COUNT.Add("PAN", "Panama");
                    _COUNT.Add("PCZ", "Panama Canal Zone");
                    _COUNT.Add("PNG", "Papua New Guinea");
                    _COUNT.Add("PRY", "Paraguay");
                    _COUNT.Add("PER", "Peru");
                    _COUNT.Add("PHL", "Philippines");
                    _COUNT.Add("PCN", "Pitcairn");
                    _COUNT.Add("POL", "Poland");
                    _COUNT.Add("PRT", "Portugal");
                    _COUNT.Add("PRI", "Puerto Rico");
                    _COUNT.Add("QAT", "Qatar");
                    _COUNT.Add("REU", "Reunion");
                    _COUNT.Add("ROU", "Romania");
                    _COUNT.Add("RUS", "Russia");
                    _COUNT.Add("RWA", "Rwanda");
                    _COUNT.Add("SHN", "Saint Helena");
                    _COUNT.Add("KNA", "Saint Kitts and Nevis");
                    _COUNT.Add("LCA", "Saint Lucia");
                    _COUNT.Add("SPM", "Saint Pierre and Miquelon");
                    _COUNT.Add("VCT", "Saint Vincent and the Grenadines");
                    _COUNT.Add("WSM", "Samoa");
                    _COUNT.Add("SMR", "San Marino");
                    _COUNT.Add("STP", "Sao Tome and Principe");
                    _COUNT.Add("SAU", "Saudi Arabia");
                    _COUNT.Add("SEN", "Senegal");
                    _COUNT.Add("SRB", "Serbia");
                    _COUNT.Add("SCG", "Serbia and Montenegro");
                    _COUNT.Add("SYC", "Seychelles");
                    _COUNT.Add("SLE", "Sierra Leone");
                    _COUNT.Add("SGP", "Singapore");
                    _COUNT.Add("SVK", "Slovakia");
                    _COUNT.Add("SVN", "Slovenia");
                    _COUNT.Add("SLB", "Solomon Islands");
                    _COUNT.Add("SOM", "Somalia");
                    _COUNT.Add("ZAF", "South Africa");
                    _COUNT.Add("SGS", "South Georgia");
                    _COUNT.Add("VDR", "South Vietnam");
                    _COUNT.Add("ESP", "Spain");
                    _COUNT.Add("LKA", "Sri Lanka");
                    _COUNT.Add("SDN", "Sudan");
                    _COUNT.Add("SUR", "Suriname");
                    _COUNT.Add("SJM", "Svalbard and Jan Mayen");
                    _COUNT.Add("SWZ", "Swaziland");
                    _COUNT.Add("SWE", "Sweden");
                    _COUNT.Add("CHE", "Switzerland");
                    _COUNT.Add("SYR", "Syria");
                    _COUNT.Add("TWN", "Taiwan");
                    _COUNT.Add("TJK", "Tajikistan");
                    _COUNT.Add("TZA", "Tanzania");
                    _COUNT.Add("THA", "Thailand");
                    _COUNT.Add("TLS", "Timor-Leste");
                    _COUNT.Add("TGO", "Togo");
                    _COUNT.Add("TKL", "Tokelau");
                    _COUNT.Add("TON", "Tonga");
                    _COUNT.Add("TTO", "Trinidad and Tobago");
                    _COUNT.Add("PCI", "Trust Territory of the Pacific Islands");
                    _COUNT.Add("TUN", "Tunisia");
                    _COUNT.Add("TUR", "Turkey");
                    _COUNT.Add("TKM", "Turkmenistan");
                    _COUNT.Add("TCA", "Turks and Caicos Islands");
                    _COUNT.Add("TUV", "Tuvalu");
                    _COUNT.Add("UGA", "Uganda");
                    _COUNT.Add("UKR", "Ukraine");
                    _COUNT.Add("SUN", "Union of Soviet Socialist Republics");
                    _COUNT.Add("ARE", "United Arab Emirates");
                    _COUNT.Add("GBR", "United Kingdom");
                    _COUNT.Add("USA", "United States");
                    _COUNT.Add("UMI", "United States Minor Outlying Islands");
                    _COUNT.Add("PUS", "United States Miscellaneous Pacific Islands");
                    _COUNT.Add("HVO", "Upper Volta");
                    _COUNT.Add("URY", "Uruguay");
                    _COUNT.Add("UZB", "Uzbekistan");
                    _COUNT.Add("VUT", "Vanuatu");
                    _COUNT.Add("VEN", "Venezuela");
                    _COUNT.Add("VNM", "Vietnam");
                    _COUNT.Add("VGB", "Virgin Islands, British");
                    _COUNT.Add("VIR", "Virgin Islands, U.S.");
                    _COUNT.Add("WAK", "Wake Island");
                    _COUNT.Add("WLF", "Wallis and Futuna");
                    _COUNT.Add("ESH", "Western Sahara");
                    _COUNT.Add("YEM", "Yemen");
                    _COUNT.Add("YUG", "Yugoslavia");
                    _COUNT.Add("ZAR", "Zaire");
                    _COUNT.Add("ZMB", "Zambia");
                    _COUNT.Add("ZWE", "Zimbabwe");
				}
				return _COUNT;
			}
		}
		
		private static Dictionary<string, string> _Review_Type;
		public static Dictionary<string, string> Review_Type
		{
			get
			{
				if(_Review_Type == null)
				{
					_Review_Type = new Dictionary<string, string>();
					_Review_Type.Add("N", "Normal");
					_Review_Type.Add("S", "ALSN Status");
					_Review_Type.Add("C", "Careers");
					_Review_Type.Add("A", "Assessment");
					_Review_Type.Add("M", "Miscellaneous");
					_Review_Type.Add("H", "Health and Safety");
					_Review_Type.Add("1", "Interview (S1)");
					_Review_Type.Add("2", "Interview (S2)");
					_Review_Type.Add("3", "Employment Review");
					_Review_Type.Add("4", "Monitoring Review");
					_Review_Type.Add("5", "Suspension Review");
					_Review_Type.Add("6", "Action Plan Review");
				}
				return _Review_Type;
			}
		}
		
		private static Dictionary<string, string> _Attended_Type;
		public static Dictionary<string, string> Attended_Type
		{
			get
			{
				if(_Attended_Type == null)
				{
					_Attended_Type = new Dictionary<string, string>();
					_Attended_Type.Add("Y", "Yes");
					_Attended_Type.Add("P", "By Phone");
					_Attended_Type.Add("A", "In Learner's absence");
					_Attended_Type.Add("F", "In Employer's absence");
					_Attended_Type.Add("N", "No");
					_Attended_Type.Add("C", "Cancelled");
					_Attended_Type.Add("S", "Canc'd - Suspended Learner");
					_Attended_Type.Add("D", "Canc'd by Reviewer");
					_Attended_Type.Add("E", "Canc'd by Learner");
					_Attended_Type.Add("U", "Unknown");
				}
				return _Attended_Type;
			}
		}
		
		private static Dictionary<string, string> _All_LLDD;
		public static Dictionary<string, string> All_LLDD
		{
			get
			{
				if(_All_LLDD == null)
				{
					_All_LLDD = new Dictionary<string, string>();
					_All_LLDD.Add("04", "Visual impairment");
					_All_LLDD.Add("05", "Hearing impairment");
					_All_LLDD.Add("06", "Disability affecting mobility");
					_All_LLDD.Add("07", "Profound complex disabilities");
					_All_LLDD.Add("08", "Social and emotional difficulties");
					_All_LLDD.Add("09", "Mental health difficulty");
					_All_LLDD.Add("10", "Moderate learning difficulty");
					_All_LLDD.Add("11", "Severe learning difficulty");
					_All_LLDD.Add("12", "Dyslexia");
					_All_LLDD.Add("13", "Dyscalculia");
					_All_LLDD.Add("14", "Autism spectrum disorder");
					_All_LLDD.Add("15", "Asperger's syndrome");
					_All_LLDD.Add("16", "Temporary disability after illness  or accident");
					_All_LLDD.Add("17", "Speech, Language and Communication Needs");
					_All_LLDD.Add("93", "Other physical disability");
					_All_LLDD.Add("94", "Other specific learning difficulty (e.g. Dyspraxia)");
					_All_LLDD.Add("95", "Other medical condition (for example epilepsy, asthma, diabetes)");
					_All_LLDD.Add("96", "Other learning difficulty");
					_All_LLDD.Add("97", "Other disability");
					_All_LLDD.Add("98", "Prefer not to say");
					_All_LLDD.Add("99", "Not provided");
				}
				return _All_LLDD;
			}
		}
		
		private static Dictionary<string, string> _Primary_LLDD;
		public static Dictionary<string, string> Primary_LLDD
		{
			get
			{
				if(_Primary_LLDD == null)
				{
					_Primary_LLDD = new Dictionary<string, string>();
					_Primary_LLDD.Add("04", "Visual impairment");
					_Primary_LLDD.Add("05", "Hearing impairment");
					_Primary_LLDD.Add("06", "Disability affecting mobility");
					_Primary_LLDD.Add("07", "Profound complex disabilities");
					_Primary_LLDD.Add("08", "Social and emotional difficulties");
					_Primary_LLDD.Add("09", "Mental health difficulty");
					_Primary_LLDD.Add("10", "Moderate learning difficulty");
					_Primary_LLDD.Add("11", "Severe learning difficulty");
					_Primary_LLDD.Add("12", "Dyslexia");
					_Primary_LLDD.Add("13", "Dyscalculia");
					_Primary_LLDD.Add("14", "Autism spectrum disorder");
					_Primary_LLDD.Add("15", "Asperger's syndrome");
					_Primary_LLDD.Add("16", "Temporary disability after illness  or accident");
					_Primary_LLDD.Add("17", "Speech, Language and Communication Needs");
					_Primary_LLDD.Add("93", "Other physical disability");
					_Primary_LLDD.Add("94", "Other specific learning difficulty (e.g. Dyspraxia)");
					_Primary_LLDD.Add("95", "Other medical condition (for example epilepsy, asthma, diabetes)");
					_Primary_LLDD.Add("96", "Other learning difficulty");
					_Primary_LLDD.Add("97", "Other disability");
					_Primary_LLDD.Add("98", "Prefer not to say");
					_Primary_LLDD.Add("99", "Not provided");
				}
				return _Primary_LLDD;
			}
		}
		
		private static Dictionary<string, string> _ETHNICORIGIN;
		public static Dictionary<string, string> ETHNICORIGIN
		{
			get
			{
				if(_ETHNICORIGIN == null)
				{
					_ETHNICORIGIN = new Dictionary<string, string>();
					_ETHNICORIGIN.Add("SW", "White Scottish");
					_ETHNICORIGIN.Add("31", "White British");
					_ETHNICORIGIN.Add("32", "White Irish");
					_ETHNICORIGIN.Add("33", "Gypsy or Irish Traveller");
					_ETHNICORIGIN.Add("34", "White Other");
					_ETHNICORIGIN.Add("35", "White and Caribbean");
					_ETHNICORIGIN.Add("36", "White and African");
					_ETHNICORIGIN.Add("37", "White and Asian");
					_ETHNICORIGIN.Add("38", "Other Mixed");
					_ETHNICORIGIN.Add("39", "Indian");
					_ETHNICORIGIN.Add("40", "Pakistani");
					_ETHNICORIGIN.Add("41", "Bangladeshi");
					_ETHNICORIGIN.Add("42", "Chinese");
					_ETHNICORIGIN.Add("43", "Other Asian");
					_ETHNICORIGIN.Add("SB", "Black Scottish");
					_ETHNICORIGIN.Add("44", "Black African");
					_ETHNICORIGIN.Add("45", "Black Caribbean");
					_ETHNICORIGIN.Add("46", "Black Other");
					_ETHNICORIGIN.Add("47", "Arab");
					_ETHNICORIGIN.Add("98", "Other");
					_ETHNICORIGIN.Add("99", "Not known");
					_ETHNICORIGIN.Add("ZZ", "Prefer not to say");
				}
				return _ETHNICORIGIN;
			}
		}
		
		private static Dictionary<string, string> _ETHN1;
		public static Dictionary<string, string> ETHN1
		{
			get
			{
				if(_ETHN1 == null)
				{
					_ETHN1 = new Dictionary<string, string>();
					_ETHN1.Add("31", "White British");
					_ETHN1.Add("32", "White Irish");
					_ETHN1.Add("33", "Gypsy or Irish Traveller");
					_ETHN1.Add("34", "White Other");
					_ETHN1.Add("35", "White and Caribbean");
					_ETHN1.Add("36", "White and African");
					_ETHN1.Add("37", "White and Asian");
					_ETHN1.Add("38", "Other Mixed");
					_ETHN1.Add("39", "Indian");
					_ETHN1.Add("40", "Pakistani");
					_ETHN1.Add("41", "Bangladeshi");
					_ETHN1.Add("42", "Chinese");
					_ETHN1.Add("43", "Other Asian");
					_ETHN1.Add("44", "Black African");
					_ETHN1.Add("45", "Black Caribbean");
					_ETHN1.Add("46", "Black Other");
					_ETHN1.Add("47", "Arab");
					_ETHN1.Add("98", "Other");
					_ETHN1.Add("99", "Not known");
					_ETHN1.Add("ZZ", "Prefer not to say");
				}
				return _ETHN1;
			}
		}
		
		private static Dictionary<string, string> _ETHN2;
		public static Dictionary<string, string> ETHN2
		{
			get
			{
				if(_ETHN2 == null)
				{
					_ETHN2 = new Dictionary<string, string>();
					_ETHN2.Add("WA", "White");
					_ETHN2.Add("WB", "Black Caribbean");
					_ETHN2.Add("WC", "Black African");
					_ETHN2.Add("WD", "Black Other");
					_ETHN2.Add("WE", "Indian");
					_ETHN2.Add("WF", "Pakistani");
					_ETHN2.Add("WG", "Bangladeshi");
					_ETHN2.Add("WH", "Chinese");
					_ETHN2.Add("WI", "Other Asian");
					_ETHN2.Add("WJ", "White and Caribbean");
					_ETHN2.Add("WK", "White and African");
					_ETHN2.Add("WL", "White and Asian");
					_ETHN2.Add("WM", "Other Mixed");
					_ETHN2.Add("WQ", "Arab");
					_ETHN2.Add("WN", "Other Ethnic");
					_ETHN2.Add("WO", "Information refused");
					_ETHN2.Add("WP", "Not known");
				}
				return _ETHN2;
			}
		}
		
		private static Dictionary<string, string> _SEX;
		public static Dictionary<string, string> SEX
		{
			get
			{
				if(_SEX == null)
				{
					_SEX = new Dictionary<string, string>();
					_SEX.Add("1", "Male");
					_SEX.Add("2", "Female");
				}
				return _SEX;
			}
		}
		
		private static Dictionary<string, string> _EmpStat_LOE;
		public static Dictionary<string, string> EmpStat_LOE
		{
			get
			{
				if(_EmpStat_LOE == null)
				{
					_EmpStat_LOE = new Dictionary<string, string>();
					_EmpStat_LOE.Add("01", "Learner has been employed for up to 3 months");
					_EmpStat_LOE.Add("02", "Learner has been employed for 4 to 6 months");
					_EmpStat_LOE.Add("03", "Learner has been employed for 7 to 12 months");
					_EmpStat_LOE.Add("04", "Learner has been employed for more than 12 months");
					_EmpStat_LOE.Add("", "n/a");
				}
				return _EmpStat_LOE;
			}
		}
		
		private static Dictionary<string, string> _EmpStat_EII;
		public static Dictionary<string, string> EmpStat_EII
		{
			get
			{
				if(_EmpStat_EII == null)
				{
					_EmpStat_EII = new Dictionary<string, string>();
					_EmpStat_EII.Add("02", "Learner is employed for less than 16 hours per week");
					_EmpStat_EII.Add("03", "Learner is employed for 16 - 19 hours per week");
					_EmpStat_EII.Add("04", "Learner is employed for 20 hours or more per week");
					_EmpStat_EII.Add("", "n/a");
				}
				return _EmpStat_EII;
			}
		}
		
		private static Dictionary<string, string> _EmpStat_LOU;
		public static Dictionary<string, string> EmpStat_LOU
		{
			get
			{
				if(_EmpStat_LOU == null)
				{
					_EmpStat_LOU = new Dictionary<string, string>();
					_EmpStat_LOU.Add("01", "Learner has been unemployed for less than 6 months");
					_EmpStat_LOU.Add("02", "Learner has been unemployed for 6-11 months");
					_EmpStat_LOU.Add("03", "Learner has been unemployed for 12-23 months");
					_EmpStat_LOU.Add("04", "Learner has been unemployed for 24-35 months");
					_EmpStat_LOU.Add("05", "Learner has been unemployed for 36 months or more");
					_EmpStat_LOU.Add("", "n/a");
				}
				return _EmpStat_LOU;
			}
		}
		
		private static Dictionary<string, string> _EmpStat_SEI;
		public static Dictionary<string, string> EmpStat_SEI
		{
			get
			{
				if(_EmpStat_SEI == null)
				{
					_EmpStat_SEI = new Dictionary<string, string>();
					_EmpStat_SEI.Add("01", "Learner is self employed");
					_EmpStat_SEI.Add("", "n/a");
				}
				return _EmpStat_SEI;
			}
		}
		
		private static Dictionary<string, string> _EmpStat_BSI;
		public static Dictionary<string, string> EmpStat_BSI
		{
			get
			{
				if(_EmpStat_BSI == null)
				{
					_EmpStat_BSI = new Dictionary<string, string>();
					_EmpStat_BSI.Add("01", "Learner is in receipt of Job Seekers Allowance (JSA)");
					_EmpStat_BSI.Add("02", "Learner is in receipt of Employment and Support Allowance - Work Related Activity Group (ESA WRAG)");
					_EmpStat_BSI.Add("03", "Learner is in receipt of another state benefit other than JSA or ESA (WRAG)");
					_EmpStat_BSI.Add("04", "Learner is in receipt of Universal Credit");
					_EmpStat_BSI.Add("", "n/a");
				}
				return _EmpStat_BSI;
			}
		}
		
		private static Dictionary<string, string> _EmpStat_RON;
		public static Dictionary<string, string> EmpStat_RON
		{
			get
			{
				if(_EmpStat_RON == null)
				{
					_EmpStat_RON = new Dictionary<string, string>();
					_EmpStat_RON.Add("01", "Learner is aged 14-15 and is at risk of becoming NEET (Not in education, employment or training)");
					_EmpStat_RON.Add("", "n/a");
				}
				return _EmpStat_RON;
			}
		}
		
		private static Dictionary<string, string> _EmpStat_PEI;
		public static Dictionary<string, string> EmpStat_PEI
		{
			get
			{
				if(_EmpStat_PEI == null)
				{
					_EmpStat_PEI = new Dictionary<string, string>();
					_EmpStat_PEI.Add("01", "Learner was in full time education or training prior to enrolment");
					_EmpStat_PEI.Add("", "n/a");
				}
				return _EmpStat_PEI;
			}
		}
		
		private static Dictionary<string, string> _EmpStat_SEM;
		public static Dictionary<string, string> EmpStat_SEM
		{
			get
			{
				if(_EmpStat_SEM == null)
				{
					_EmpStat_SEM = new Dictionary<string, string>();
					_EmpStat_SEM.Add("01", "Small employer");
					_EmpStat_SEM.Add("", "n/a");
				}
				return _EmpStat_SEM;
			}
		}
		
		private static Dictionary<string, string> _EmpStat_Code;
		public static Dictionary<string, string> EmpStat_Code
		{
			get
			{
				if(_EmpStat_Code == null)
				{
					_EmpStat_Code = new Dictionary<string, string>();
					_EmpStat_Code.Add("10", "In paid employment");
					_EmpStat_Code.Add("11", "Not in paid employment and looking for work");
					_EmpStat_Code.Add("12", "Not in paid employment and not looking for work");
					_EmpStat_Code.Add("98", "Not known / not provided");
				}
				return _EmpStat_Code;
			}
		}
		
		private static Dictionary<string, string> _TITLE;
		public static Dictionary<string, string> TITLE
		{
			get
			{
				if(_TITLE == null)
				{
					_TITLE = new Dictionary<string, string>();
					_TITLE.Add("1", "Mr");
					_TITLE.Add("2", "Mrs");
					_TITLE.Add("3", "Miss");
					_TITLE.Add("4", "Ms");
					_TITLE.Add("5", "Dr");
					_TITLE.Add("6", "Rev");
					_TITLE.Add("7", "Hon");
					_TITLE.Add("8", "Mx");
					_TITLE.Add("9", "Other");
				}
				return _TITLE;
			}
		}
		
		private static Dictionary<string, string> _Act_FUp_After;
		public static Dictionary<string, string> Act_FUp_After
		{
			get
			{
				if(_Act_FUp_After == null)
				{
					_Act_FUp_After = new Dictionary<string, string>();
					_Act_FUp_After.Add("1D", "1 day");
					_Act_FUp_After.Add("2D", "2 days");
					_Act_FUp_After.Add("3D", "3 days");
					_Act_FUp_After.Add("4D", "4 days");
					_Act_FUp_After.Add("5D", "5 days");
					_Act_FUp_After.Add("6D", "6 days");
					_Act_FUp_After.Add("1W", "1 week");
					_Act_FUp_After.Add("2W", "2 weeks");
					_Act_FUp_After.Add("3W", "3 weeks");
					_Act_FUp_After.Add("4W", "4 weeks");
					_Act_FUp_After.Add("1M", "1 month");
					_Act_FUp_After.Add("6W", "6 weeks");
					_Act_FUp_After.Add("8W", "8 weeks");
					_Act_FUp_After.Add("2M", "2 months");
					_Act_FUp_After.Add("10W", "10 weeks");
					_Act_FUp_After.Add("12W", "12 weeks");
					_Act_FUp_After.Add("3M", "3 months");
					_Act_FUp_After.Add("4M", "4 months");
					_Act_FUp_After.Add("5M", "5 months");
					_Act_FUp_After.Add("6M", "6 months");
					_Act_FUp_After.Add("9M", "9 months");
					_Act_FUp_After.Add("12M", "1 year");
					_Act_FUp_After.Add("24M", "2 years");
					_Act_FUp_After.Add("36M", "3 years");
					_Act_FUp_After.Add("48M", "4 years");
					_Act_FUp_After.Add("60M", "5 years");
				}
				return _Act_FUp_After;
			}
		}
		
		private static Dictionary<string, string> _MIAP_VERIFTYPE;
		public static Dictionary<string, string> MIAP_VERIFTYPE
		{
			get
			{
				if(_MIAP_VERIFTYPE == null)
				{
					_MIAP_VERIFTYPE = new Dictionary<string, string>();
					_MIAP_VERIFTYPE.Add("0", "None provided");
					_MIAP_VERIFTYPE.Add("1", "Relationship with school");
					_MIAP_VERIFTYPE.Add("2", "Passport");
					_MIAP_VERIFTYPE.Add("3", "Driving licence");
					_MIAP_VERIFTYPE.Add("4", "ID card (national identification)");
					_MIAP_VERIFTYPE.Add("5", "National Insurance card");
					_MIAP_VERIFTYPE.Add("6", "Certificate of Entitlement to Funding");
					_MIAP_VERIFTYPE.Add("7", "Bank credit/debit card");
					_MIAP_VERIFTYPE.Add("999", "Other: please specify");
				}
				return _MIAP_VERIFTYPE;
			}
		}
		
		private static Dictionary<string, string> _MIAP_FPN_SEEN;
		public static Dictionary<string, string> MIAP_FPN_SEEN
		{
			get
			{
				if(_MIAP_FPN_SEEN == null)
				{
					_MIAP_FPN_SEEN = new Dictionary<string, string>();
					_MIAP_FPN_SEEN.Add("0", "FPN not seen");
					_MIAP_FPN_SEEN.Add("1", "FPN seen and able to share data");
					_MIAP_FPN_SEEN.Add("2", "FPN seen and unable to share data");
				}
				return _MIAP_FPN_SEEN;
			}
		}
		
		private static Dictionary<string, string> _ESOL_FIRSTASSLEV;
		public static Dictionary<string, string> ESOL_FIRSTASSLEV
		{
			get
			{
				if(_ESOL_FIRSTASSLEV == null)
				{
					_ESOL_FIRSTASSLEV = new Dictionary<string, string>();
					_ESOL_FIRSTASSLEV.Add("", "Not specified");
					_ESOL_FIRSTASSLEV.Add("X", "Not required");
					_ESOL_FIRSTASSLEV.Add("A", "Below Entry 1");
					_ESOL_FIRSTASSLEV.Add("B", "Entry 1");
					_ESOL_FIRSTASSLEV.Add("C", "Entry 2");
					_ESOL_FIRSTASSLEV.Add("D", "Entry 3");
					_ESOL_FIRSTASSLEV.Add("E", "Level 1");
					_ESOL_FIRSTASSLEV.Add("F", "Level 2");
					_ESOL_FIRSTASSLEV.Add("G", "Level 3");
				}
				return _ESOL_FIRSTASSLEV;
			}
		}
		
		private static Dictionary<string, string> _TECHCERT_REQD;
		public static Dictionary<string, string> TECHCERT_REQD
		{
			get
			{
				if(_TECHCERT_REQD == null)
				{
					_TECHCERT_REQD = new Dictionary<string, string>();
					_TECHCERT_REQD.Add("Y", "Required");
					_TECHCERT_REQD.Add("N", "Not required");
				}
				return _TECHCERT_REQD;
			}
		}
		
		private static Dictionary<string, string> _FS_Math_Reqd;
		public static Dictionary<string, string> FS_Math_Reqd
		{
			get
			{
				if(_FS_Math_Reqd == null)
				{
					_FS_Math_Reqd = new Dictionary<string, string>();
					_FS_Math_Reqd.Add("Y", "Required");
					_FS_Math_Reqd.Add("R", "Relaxation");
					_FS_Math_Reqd.Add("P", "Proxy");
					_FS_Math_Reqd.Add("N", "Not required");
				}
				return _FS_Math_Reqd;
			}
		}
		
		private static Dictionary<string, string> _FS_Eng_Reqd;
		public static Dictionary<string, string> FS_Eng_Reqd
		{
			get
			{
				if(_FS_Eng_Reqd == null)
				{
					_FS_Eng_Reqd = new Dictionary<string, string>();
					_FS_Eng_Reqd.Add("Y", "Required");
					_FS_Eng_Reqd.Add("R", "Relaxation");
					_FS_Eng_Reqd.Add("P", "Proxy");
					_FS_Eng_Reqd.Add("N", "Not required");
				}
				return _FS_Eng_Reqd;
			}
		}
		
		private static Dictionary<string, string> _FS_ICT_Reqd;
		public static Dictionary<string, string> FS_ICT_Reqd
		{
			get
			{
				if(_FS_ICT_Reqd == null)
				{
					_FS_ICT_Reqd = new Dictionary<string, string>();
					_FS_ICT_Reqd.Add("Y", "Required");
					_FS_ICT_Reqd.Add("R", "Relaxation");
					_FS_ICT_Reqd.Add("P", "Proxy");
					_FS_ICT_Reqd.Add("N", "Not required");
				}
				return _FS_ICT_Reqd;
			}
		}
		
		private static Dictionary<string, string> _Err_Reqd;
		public static Dictionary<string, string> Err_Reqd
		{
			get
			{
				if(_Err_Reqd == null)
				{
					_Err_Reqd = new Dictionary<string, string>();
					_Err_Reqd.Add("Y", "Required");
					_Err_Reqd.Add("R", "Relaxation");
					_Err_Reqd.Add("P", "Proxy");
					_Err_Reqd.Add("N", "Not required");
				}
				return _Err_Reqd;
			}
		}
		
		private static Dictionary<string, string> _APP_HHS;
		public static Dictionary<string, string> APP_HHS
		{
			get
			{
				if(_APP_HHS == null)
				{
					_APP_HHS = new Dictionary<string, string>();
					_APP_HHS.Add("1", "No household member is in employment and the household includes one or more dependent children");
					_APP_HHS.Add("2", "No household member is in employment and the household does not include any dependent children");
					_APP_HHS.Add("3", "Learner lives in a single adult household with dependent children");
					_APP_HHS.Add("98", "Learner has withheld this information");
					_APP_HHS.Add("99", "None of HHS1, HHS2 or HHS3 applies");
					_APP_HHS.Add("0", "Not applicable");
				}
				return _APP_HHS;
			}
		}
		
		private static Dictionary<string, string> _APP_ACT;
		public static Dictionary<string, string> APP_ACT
		{
			get
			{
				if(_APP_ACT == null)
				{
					_APP_ACT = new Dictionary<string, string>();
					_APP_ACT.Add("1", "Apprenticeship funded through a contract for services with the employer");
					_APP_ACT.Add("2", "Apprenticeship funded through a contract for services with the SFA");
				}
				return _APP_ACT;
			}
		}
		
		private static Dictionary<string, string> _APP_LSCLEARN;
		public static Dictionary<string, string> APP_LSCLEARN
		{
			get
			{
				if(_APP_LSCLEARN == null)
				{
					_APP_LSCLEARN = new Dictionary<string, string>();
					_APP_LSCLEARN.Add("Y", "Yes");
					_APP_LSCLEARN.Add("N", "No");
				}
				return _APP_LSCLEARN;
			}
		}
		
		private static Dictionary<string, string> _APP_LSCDISAB;
		public static Dictionary<string, string> APP_LSCDISAB
		{
			get
			{
				if(_APP_LSCDISAB == null)
				{
					_APP_LSCDISAB = new Dictionary<string, string>();
					_APP_LSCDISAB.Add("98", "No disability");
					_APP_LSCDISAB.Add("01", "Visual impairment");
					_APP_LSCDISAB.Add("02", "Hearing impairment");
					_APP_LSCDISAB.Add("03", "Disability affecting mobility");
					_APP_LSCDISAB.Add("04", "Other physical disability");
					_APP_LSCDISAB.Add("05", "Other medical condition (for example epilepsy, asthma, diabetes)");
					_APP_LSCDISAB.Add("06", "Emotional/behavioural difficulties");
					_APP_LSCDISAB.Add("07", "Mental ill health");
					_APP_LSCDISAB.Add("08", "Temporary disability after illness (for example post-viral) or accident");
					_APP_LSCDISAB.Add("09", "Profound complex disabilities");
					_APP_LSCDISAB.Add("10", "Aspergers Syndrome");
					_APP_LSCDISAB.Add("90", "Multiple disabilities");
					_APP_LSCDISAB.Add("97", "Other");
					_APP_LSCDISAB.Add("99", "Not known/information not provided");
				}
				return _APP_LSCDISAB;
			}
		}
		
		private static Dictionary<string, string> _APP_LSCDIFFIC;
		public static Dictionary<string, string> APP_LSCDIFFIC
		{
			get
			{
				if(_APP_LSCDIFFIC == null)
				{
					_APP_LSCDIFFIC = new Dictionary<string, string>();
					_APP_LSCDIFFIC.Add("98", "No learning difficulty");
					_APP_LSCDIFFIC.Add("01", "Moderate learning difficulty");
					_APP_LSCDIFFIC.Add("02", "Severe learning difficulty");
					_APP_LSCDIFFIC.Add("10", "Dyslexia");
					_APP_LSCDIFFIC.Add("11", "Dyscalculia");
					_APP_LSCDIFFIC.Add("19", "Other specific learning difficulty");
					_APP_LSCDIFFIC.Add("20", "Autism Spectrum Disorder");
					_APP_LSCDIFFIC.Add("90", "Multiple learning difficulties");
					_APP_LSCDIFFIC.Add("97", "Other");
					_APP_LSCDIFFIC.Add("99", "Not known/information not provided");
				}
				return _APP_LSCDIFFIC;
			}
		}
		
		private static Dictionary<string, string> _APP_PRIMARY_LLDD;
		public static Dictionary<string, string> APP_PRIMARY_LLDD
		{
			get
			{
				if(_APP_PRIMARY_LLDD == null)
				{
					_APP_PRIMARY_LLDD = new Dictionary<string, string>();
					_APP_PRIMARY_LLDD.Add("04", "Visual impairment");
					_APP_PRIMARY_LLDD.Add("05", "Hearing impairment");
					_APP_PRIMARY_LLDD.Add("06", "Disability affecting mobility");
					_APP_PRIMARY_LLDD.Add("07", "Profound complex disabilities");
					_APP_PRIMARY_LLDD.Add("08", "Social and emotional difficulties");
					_APP_PRIMARY_LLDD.Add("09", "Mental health difficulty");
					_APP_PRIMARY_LLDD.Add("10", "Moderate learning difficulty");
					_APP_PRIMARY_LLDD.Add("11", "Severe learning difficulty");
					_APP_PRIMARY_LLDD.Add("12", "Dyslexia");
					_APP_PRIMARY_LLDD.Add("13", "Dyscalculia");
					_APP_PRIMARY_LLDD.Add("14", "Autism spectrum disorder");
					_APP_PRIMARY_LLDD.Add("15", "Asperger's syndrome");
					_APP_PRIMARY_LLDD.Add("16", "Temporary disability after illness  or accident");
					_APP_PRIMARY_LLDD.Add("17", "Speech, Language and Communication Needs");
					_APP_PRIMARY_LLDD.Add("93", "Other physical disability");
					_APP_PRIMARY_LLDD.Add("94", "Other specific learning difficulty (e.g. Dyspraxia)");
					_APP_PRIMARY_LLDD.Add("95", "Other medical condition (for example epilepsy, asthma, diabetes)");
					_APP_PRIMARY_LLDD.Add("96", "Other learning difficulty");
					_APP_PRIMARY_LLDD.Add("97", "Other disability");
					_APP_PRIMARY_LLDD.Add("98", "Prefer not to say");
					_APP_PRIMARY_LLDD.Add("99", "Not provided");
				}
				return _APP_PRIMARY_LLDD;
			}
		}
		
		private static Dictionary<string, string> _APP_ALL_LLDD;
		public static Dictionary<string, string> APP_ALL_LLDD
		{
			get
			{
				if(_APP_ALL_LLDD == null)
				{
					_APP_ALL_LLDD = new Dictionary<string, string>();
					_APP_ALL_LLDD.Add("04", "Visual impairment");
					_APP_ALL_LLDD.Add("05", "Hearing impairment");
					_APP_ALL_LLDD.Add("06", "Disability affecting mobility");
					_APP_ALL_LLDD.Add("07", "Profound complex disabilities");
					_APP_ALL_LLDD.Add("08", "Social and emotional difficulties");
					_APP_ALL_LLDD.Add("09", "Mental health difficulty");
					_APP_ALL_LLDD.Add("10", "Moderate learning difficulty");
					_APP_ALL_LLDD.Add("11", "Severe learning difficulty");
					_APP_ALL_LLDD.Add("12", "Dyslexia");
					_APP_ALL_LLDD.Add("13", "Dyscalculia");
					_APP_ALL_LLDD.Add("14", "Autism spectrum disorder");
					_APP_ALL_LLDD.Add("15", "Asperger's syndrome");
					_APP_ALL_LLDD.Add("16", "Temporary disability after illness  or accident");
					_APP_ALL_LLDD.Add("17", "Speech, Language and Communication Needs");
					_APP_ALL_LLDD.Add("93", "Other physical disability");
					_APP_ALL_LLDD.Add("94", "Other specific learning difficulty (e.g. Dyspraxia)");
					_APP_ALL_LLDD.Add("95", "Other medical condition (for example epilepsy, asthma, diabetes)");
					_APP_ALL_LLDD.Add("96", "Other learning difficulty");
					_APP_ALL_LLDD.Add("97", "Other disability");
					_APP_ALL_LLDD.Add("98", "Prefer not to say");
					_APP_ALL_LLDD.Add("99", "Not provided");
				}
				return _APP_ALL_LLDD;
			}
		}
		
		private static Dictionary<string, string> _APP_ETHNICITY;
		public static Dictionary<string, string> APP_ETHNICITY
		{
			get
			{
				if(_APP_ETHNICITY == null)
				{
					_APP_ETHNICITY = new Dictionary<string, string>();
					_APP_ETHNICITY.Add("SW", "White Scottish");
					_APP_ETHNICITY.Add("31", "White British");
					_APP_ETHNICITY.Add("32", "White Irish");
					_APP_ETHNICITY.Add("33", "Gypsy or Irish Traveller");
					_APP_ETHNICITY.Add("34", "White Other");
					_APP_ETHNICITY.Add("35", "White and Caribbean");
					_APP_ETHNICITY.Add("36", "White and African");
					_APP_ETHNICITY.Add("37", "White and Asian");
					_APP_ETHNICITY.Add("38", "Other Mixed");
					_APP_ETHNICITY.Add("39", "Indian");
					_APP_ETHNICITY.Add("40", "Pakistani");
					_APP_ETHNICITY.Add("41", "Bangladeshi");
					_APP_ETHNICITY.Add("42", "Chinese");
					_APP_ETHNICITY.Add("43", "Other Asian");
					_APP_ETHNICITY.Add("SB", "Black Scottish");
					_APP_ETHNICITY.Add("44", "Black African");
					_APP_ETHNICITY.Add("45", "Black Caribbean");
					_APP_ETHNICITY.Add("46", "Black Other");
					_APP_ETHNICITY.Add("47", "Arab");
					_APP_ETHNICITY.Add("98", "Other");
					_APP_ETHNICITY.Add("99", "Not known");
					_APP_ETHNICITY.Add("ZZ", "Prefer not to say");
				}
				return _APP_ETHNICITY;
			}
		}
		
		private static Dictionary<string, string> _APP_SEX;
		public static Dictionary<string, string> APP_SEX
		{
			get
			{
				if(_APP_SEX == null)
				{
					_APP_SEX = new Dictionary<string, string>();
					_APP_SEX.Add("1", "Male");
					_APP_SEX.Add("2", "Female");
				}
				return _APP_SEX;
			}
		}
		
		private static Dictionary<string, string> _APP_TITLE;
		public static Dictionary<string, string> APP_TITLE
		{
			get
			{
				if(_APP_TITLE == null)
				{
					_APP_TITLE = new Dictionary<string, string>();
					_APP_TITLE.Add("1", "Mr");
					_APP_TITLE.Add("2", "Mrs");
					_APP_TITLE.Add("3", "Miss");
					_APP_TITLE.Add("4", "Ms");
					_APP_TITLE.Add("5", "Dr");
					_APP_TITLE.Add("6", "Rev");
					_APP_TITLE.Add("7", "Hon");
					_APP_TITLE.Add("8", "Mx");
					_APP_TITLE.Add("9", "Other");
				}
				return _APP_TITLE;
			}
		}
		
		private static Dictionary<string, string> _APP_DAS_STATUS;
		public static Dictionary<string, string> APP_DAS_STATUS
		{
			get
			{
				if(_APP_DAS_STATUS == null)
				{
					_APP_DAS_STATUS = new Dictionary<string, string>();
					_APP_DAS_STATUS.Add("0", "Non-DAS");
					_APP_DAS_STATUS.Add("1", "DAS Eligible");
					_APP_DAS_STATUS.Add("2", "Ready for DAS");
					_APP_DAS_STATUS.Add("3", "Sent to DAS");
					_APP_DAS_STATUS.Add("4", "On DAS");
				}
				return _APP_DAS_STATUS;
			}
		}
		
		private static Dictionary<string, string> _APP_BAS_NUM;
		public static Dictionary<string, string> APP_BAS_NUM
		{
			get
			{
				if(_APP_BAS_NUM == null)
				{
					_APP_BAS_NUM = new Dictionary<string, string>();
					_APP_BAS_NUM.Add("", "Not specified");
					_APP_BAS_NUM.Add("X", "Not required");
					_APP_BAS_NUM.Add("A", "Below Entry 1");
					_APP_BAS_NUM.Add("B", "Entry 1");
					_APP_BAS_NUM.Add("C", "Entry 2");
					_APP_BAS_NUM.Add("D", "Entry 3");
					_APP_BAS_NUM.Add("E", "Level 1");
					_APP_BAS_NUM.Add("F", "Level 2");
					_APP_BAS_NUM.Add("G", "Level 3");
				}
				return _APP_BAS_NUM;
			}
		}
		
		private static Dictionary<string, string> _APP_BAS_LIT;
		public static Dictionary<string, string> APP_BAS_LIT
		{
			get
			{
				if(_APP_BAS_LIT == null)
				{
					_APP_BAS_LIT = new Dictionary<string, string>();
					_APP_BAS_LIT.Add("", "Not specified");
					_APP_BAS_LIT.Add("X", "Not required");
					_APP_BAS_LIT.Add("A", "Below Entry 1");
					_APP_BAS_LIT.Add("B", "Entry 1");
					_APP_BAS_LIT.Add("C", "Entry 2");
					_APP_BAS_LIT.Add("D", "Entry 3");
					_APP_BAS_LIT.Add("E", "Level 1");
					_APP_BAS_LIT.Add("F", "Level 2");
					_APP_BAS_LIT.Add("G", "Level 3");
				}
				return _APP_BAS_LIT;
			}
		}
		
		private static Dictionary<string, string> _APP_BAS_ICT;
		public static Dictionary<string, string> APP_BAS_ICT
		{
			get
			{
				if(_APP_BAS_ICT == null)
				{
					_APP_BAS_ICT = new Dictionary<string, string>();
					_APP_BAS_ICT.Add("", "Not specified");
					_APP_BAS_ICT.Add("X", "Not required");
					_APP_BAS_ICT.Add("A", "Below Entry 1");
					_APP_BAS_ICT.Add("B", "Entry 1");
					_APP_BAS_ICT.Add("C", "Entry 2");
					_APP_BAS_ICT.Add("D", "Entry 3");
					_APP_BAS_ICT.Add("E", "Level 1");
					_APP_BAS_ICT.Add("F", "Level 2");
					_APP_BAS_ICT.Add("G", "Level 3");
				}
				return _APP_BAS_ICT;
			}
		}
		
		private static Dictionary<string, string> _LLWR_CareResp;
		public static Dictionary<string, string> LLWR_CareResp
		{
			get
			{
				if(_LLWR_CareResp == null)
				{
					_LLWR_CareResp = new Dictionary<string, string>();
					_LLWR_CareResp.Add("1", "Primary carer of a child/children (under 18)");
					_LLWR_CareResp.Add("2", "Primary carer of disabled adult (18 and over)");
					_LLWR_CareResp.Add("3", "Primary carer of older person/people (65 and over)");
					_LLWR_CareResp.Add("4", "No caring responsibilities");
					_LLWR_CareResp.Add("5", "information refused");
					_LLWR_CareResp.Add("6", "Primary Carer of a child/children (Under 18) and Primary Carer of a disabled adult (18 and over)");
					_LLWR_CareResp.Add("7", "Primary Carer of a child/children (Under 18) and Primary Carer of older person/people (65 and Over)");
					_LLWR_CareResp.Add("8", "Primary Carer of a disabled adult (18 and over) and Primary Carer of older person/people (65 and Over)");
					_LLWR_CareResp.Add("0", "Primary Carer of a child/children (Under 18) and Primary Carer of a disabled adult (18 and over) and Primary Carer of older person/people (65 and Over)");
					_LLWR_CareResp.Add("9", "Not known");
				}
				return _LLWR_CareResp;
			}
		}
		
		private static Dictionary<string, string> _LLWR_HouseHoldSit;
		public static Dictionary<string, string> LLWR_HouseHoldSit
		{
			get
			{
				if(_LLWR_HouseHoldSit == null)
				{
					_LLWR_HouseHoldSit = new Dictionary<string, string>();
					_LLWR_HouseHoldSit.Add("01", "Living in a jobless household");
					_LLWR_HouseHoldSit.Add("02", "Living in a jobless household with dependent children");
					_LLWR_HouseHoldSit.Add("03", "Living in a single adult household with dependent children");
					_LLWR_HouseHoldSit.Add("04", "Homeless or affected by housing exclusion");
					_LLWR_HouseHoldSit.Add("05", "Any other household");
					_LLWR_HouseHoldSit.Add("06", "Information refused");
					_LLWR_HouseHoldSit.Add("07", "Living in a single adult household");
					_LLWR_HouseHoldSit.Add("99", "Not known");
				}
				return _LLWR_HouseHoldSit;
			}
		}
		
		private static Dictionary<string, string> _LLWR_NatId;
		public static Dictionary<string, string> LLWR_NatId
		{
			get
			{
				if(_LLWR_NatId == null)
				{
					_LLWR_NatId = new Dictionary<string, string>();
					_LLWR_NatId.Add("WAL", "Welsh");
					_LLWR_NatId.Add("ENG", "English");
					_LLWR_NatId.Add("SCO", "Scottish");
					_LLWR_NatId.Add("IRE", "Irish");
					_LLWR_NatId.Add("BRI", "British");
					_LLWR_NatId.Add("OTH", "Other");
					_LLWR_NatId.Add("NKN", "not known/not required");
					_LLWR_NatId.Add("NOR", "no response");
				}
				return _LLWR_NatId;
			}
		}
		
		private static Dictionary<string, string> _LLWR_WelshSpkr;
		public static Dictionary<string, string> LLWR_WelshSpkr
		{
			get
			{
				if(_LLWR_WelshSpkr == null)
				{
					_LLWR_WelshSpkr = new Dictionary<string, string>();
					_LLWR_WelshSpkr.Add("1", "fluent Welsh speaker");
					_LLWR_WelshSpkr.Add("2", "Welsh speaker not fluent");
					_LLWR_WelshSpkr.Add("3", "not Welsh speaker");
				}
				return _LLWR_WelshSpkr;
			}
		}
		
		private static Dictionary<string, string> _LLWR_WelshQualLev;
		public static Dictionary<string, string> LLWR_WelshQualLev
		{
			get
			{
				if(_LLWR_WelshQualLev == null)
				{
					_LLWR_WelshQualLev = new Dictionary<string, string>();
					_LLWR_WelshQualLev.Add("0", "Welsh second language: Pre-Entry Level");
					_LLWR_WelshQualLev.Add("1", "Welsh second language qualification: Entry level");
					_LLWR_WelshQualLev.Add("2", "Welsh second language qualification: Level 1 e.g. GCSE D-G");
					_LLWR_WelshQualLev.Add("3", "Welsh second language qualification: Level 2 e.g. GCSE A*-C");
					_LLWR_WelshQualLev.Add("4", "Welsh second language qualification: Levels 3 and above e.g. AS, A level");
					_LLWR_WelshQualLev.Add("5", "Welsh first language: Pre-Entry Level");
					_LLWR_WelshQualLev.Add("6", "Welsh first language qualification: Entry level");
					_LLWR_WelshQualLev.Add("7", "Welsh first language qualification: Level 1 e.g. GCSE D-G");
					_LLWR_WelshQualLev.Add("8", "Welsh first language qualification: Level 2 e.g. GCSE A*-C");
					_LLWR_WelshQualLev.Add("9", "Welsh first language qualification: Levels 3 and above e.g. AS, A level");
					_LLWR_WelshQualLev.Add("A", "Continuing learner (earliest activities prior to 2013), previous entries on LP23, LP58 ,LP59 apply");
				}
				return _LLWR_WelshQualLev;
			}
		}
		
		private static Dictionary<string, string> _LLWR_PrimeDisab;
		public static Dictionary<string, string> LLWR_PrimeDisab
		{
			get
			{
				if(_LLWR_PrimeDisab == null)
				{
					_LLWR_PrimeDisab = new Dictionary<string, string>();
					_LLWR_PrimeDisab.Add("WA", "visual impairment");
					_LLWR_PrimeDisab.Add("WB", "hearing impairment");
					_LLWR_PrimeDisab.Add("WQ", "physical and/or medical difficulties");
					_LLWR_PrimeDisab.Add("WR", "behavioural, emotional and social difficulties");
					_LLWR_PrimeDisab.Add("WN", "multi-sensory impairment");
					_LLWR_PrimeDisab.Add("WO", "autistic spectrum disorder");
					_LLWR_PrimeDisab.Add("WP", "speech, language & communication difficulty");
					_LLWR_PrimeDisab.Add("WS", "moderate learning difficulties");
					_LLWR_PrimeDisab.Add("WT", "severe learning difficulties");
					_LLWR_PrimeDisab.Add("WI", "profound and multiple disabilities");
					_LLWR_PrimeDisab.Add("WW", "SPLD - Dyslexia");
					_LLWR_PrimeDisab.Add("WX", "SPLD - Dyscalculia");
					_LLWR_PrimeDisab.Add("WY", "SPLD - Dyspraxia");
					_LLWR_PrimeDisab.Add("WZ", "SPLD - Attention Deficit Hyperactivity Disorder");
					_LLWR_PrimeDisab.Add("W0", "General Learning Difficulties");
					_LLWR_PrimeDisab.Add("WV", "does not apply");
					_LLWR_PrimeDisab.Add("W1", "Learner considers himself or herself to have a learning difficulty and/or disability but the type is not known or not declared");
				}
				return _LLWR_PrimeDisab;
			}
		}
		
		private static Dictionary<string, string> _LLWR_AddLearnSup;
		public static Dictionary<string, string> LLWR_AddLearnSup
		{
			get
			{
				if(_LLWR_AddLearnSup == null)
				{
					_LLWR_AddLearnSup = new Dictionary<string, string>();
					_LLWR_AddLearnSup.Add("0", "Learner does not have additional learning needs (ALN)/not required.");
					_LLWR_AddLearnSup.Add("1", "Learner’s support needs are met in a discrete setting");
					_LLWR_AddLearnSup.Add("2", "Learner is accessing provision in a discrete setting and Additional Learning Support funding is utilised");
					_LLWR_AddLearnSup.Add("3", "Learner’s support needs are met in a mainstream setting");
					_LLWR_AddLearnSup.Add("4", "Learner is accessing provision in a mainstream setting and Additional Learning Support funding is utilised");
				}
				return _LLWR_AddLearnSup;
			}
		}
		
		private static Dictionary<string, string> _LLWR_WLHC;
		public static Dictionary<string, string> LLWR_WLHC
		{
			get
			{
				if(_LLWR_WLHC == null)
				{
					_LLWR_WLHC = new Dictionary<string, string>();
					_LLWR_WLHC.Add("1", "Yes");
					_LLWR_WLHC.Add("2", "No");
					_LLWR_WLHC.Add("9", "Not applicable");
				}
				return _LLWR_WLHC;
			}
		}
		
		private static Dictionary<string, string> _LLWR_HighQual;
		public static Dictionary<string, string> LLWR_HighQual
		{
			get
			{
				if(_LLWR_HighQual == null)
				{
					_LLWR_HighQual = new Dictionary<string, string>();
					_LLWR_HighQual.Add("0", "Pre-Entry Level");
					_LLWR_HighQual.Add("E", "CQFW Entry Level");
					_LLWR_HighQual.Add("1", "CQFW Level 1");
					_LLWR_HighQual.Add("2", "CQFW Level 2");
					_LLWR_HighQual.Add("3", "CQFW Level 3");
					_LLWR_HighQual.Add("4", "CQFW Level 4");
					_LLWR_HighQual.Add("5", "CQFW Level 5");
					_LLWR_HighQual.Add("6", "CQFW Level 6/HE Honours");
					_LLWR_HighQual.Add("7", "CQFW Level 7/HE Masters");
					_LLWR_HighQual.Add("8", "CQFW Level 8/HE Doctorate");
					_LLWR_HighQual.Add("9", "not known/not required");
				}
				return _LLWR_HighQual;
			}
		}
		
		private static Dictionary<string, string> _LLWR_ProgCode;
		public static Dictionary<string, string> LLWR_ProgCode
		{
			get
			{
				if(_LLWR_ProgCode == null)
				{
					_LLWR_ProgCode = new Dictionary<string, string>();
					_LLWR_ProgCode.Add("999999999", "Not applicable");
					_LLWR_ProgCode.Add("99999999", "Non Fundable Programme");
					_LLWR_ProgCode.Add("0001A02S", "GCSE learning - aggregated guided contact hours");
					_LLWR_ProgCode.Add("0003A02B", "3 GCSEs");
					_LLWR_ProgCode.Add("0004A02B", "4 GCSEs");
					_LLWR_ProgCode.Add("0005A02B", "5+ GCSEs");
					_LLWR_ProgCode.Add("0006A02B", "5 GCSEs equivalent");
					_LLWR_ProgCode.Add("0011A03P", "GCE 1 AS");
					_LLWR_ProgCode.Add("0012A03B", "2 AS");
					_LLWR_ProgCode.Add("0012A03P", "GCE 2 AS");
					_LLWR_ProgCode.Add("0012B03B", "2 AS equivalent");
					_LLWR_ProgCode.Add("0013A03B", "3 AS");
					_LLWR_ProgCode.Add("0013A03P", "GCE 3 AS");
					_LLWR_ProgCode.Add("0013B03B", "3 AS equivalent");
					_LLWR_ProgCode.Add("0013C03B", "2 AS with WBQ");
					_LLWR_ProgCode.Add("0013D03B", "2 AS equivalent with WBQ");
					_LLWR_ProgCode.Add("0014A03B", "4+ AS");
					_LLWR_ProgCode.Add("0014B03B", "4+ AS equivalent");
					_LLWR_ProgCode.Add("0014C03B", "3 AS with WBQ");
					_LLWR_ProgCode.Add("0014D03B", "3 AS equivalent with WBQ");
					_LLWR_ProgCode.Add("0015C03B", "4+ AS with WBQ");
					_LLWR_ProgCode.Add("0015D03B", "4+ AS equivalent with WBQ");
					_LLWR_ProgCode.Add("0021A03P", "GCE 1 A2");
					_LLWR_ProgCode.Add("0022A03B", "2 A2");
					_LLWR_ProgCode.Add("0022A03P", "GCE 2 A2");
					_LLWR_ProgCode.Add("0022B03B", "2 A2 equivalent");
					_LLWR_ProgCode.Add("0023A03B", "3 A2");
					_LLWR_ProgCode.Add("0023A03P", "GCE 3 A2");
					_LLWR_ProgCode.Add("0023B03B", "3 A2 equivalent");
					_LLWR_ProgCode.Add("0023C03B", "2 A2 with WBQ");
					_LLWR_ProgCode.Add("0023D03B", "2 A2 equivalent with WBQ");
					_LLWR_ProgCode.Add("0024A03B", "4+ A2");
					_LLWR_ProgCode.Add("0024B03B", "4+ A2 equivalent");
					_LLWR_ProgCode.Add("0024C03B", "3 A2 with WBQ");
					_LLWR_ProgCode.Add("0024D03B", "3 A2 equivalent with WBQ");
					_LLWR_ProgCode.Add("0025C03B", "4+ A2 with WBQ");
					_LLWR_ProgCode.Add("0025D03B", "4+ A2 equivalent with WBQ");
					_LLWR_ProgCode.Add("0030A03B", "International Baccalaureate Diploma (Year 1 or 2)");
					_LLWR_ProgCode.Add("0100XXXG", "Aggregated generic guided contact hours in SSA 1");
					_LLWR_ProgCode.Add("0101XXXV", "Aggregated vocational guided contact hours in SSA 1.1");
					_LLWR_ProgCode.Add("0102XXXV", "Aggregated vocational guided contact hours in SSA 1.2");
					_LLWR_ProgCode.Add("0103A01B", "Health and Social Care Level 1");
					_LLWR_ProgCode.Add("0103A02B", "Health and Social Care Level 2");
					_LLWR_ProgCode.Add("0103A03B", "Health and Social Care Level 3");
					_LLWR_ProgCode.Add("0103AAAB", "Access to HE Diploma - Healthcare");
					_LLWR_ProgCode.Add("0103AE0B", "Health and Social Care Entry Level");
					_LLWR_ProgCode.Add("0103B02B", "Complementary Therapies Level 2");
					_LLWR_ProgCode.Add("0103B03B", "Complementary Therapies Level 3");
					_LLWR_ProgCode.Add("0103BAAB", "Access to HE Social Care");
					_LLWR_ProgCode.Add("0103CAAB", "Access to HE Social Science");
					_LLWR_ProgCode.Add("0103XXXV", "Aggregated vocational guided contact hours in SSA 1.3");
					_LLWR_ProgCode.Add("0104A01B", "Public Services Level 1");
					_LLWR_ProgCode.Add("0104A02B", "Public Services Level 2");
					_LLWR_ProgCode.Add("0104A03B", "Public Services Level 3");
					_LLWR_ProgCode.Add("0104XXXV", "Aggregated vocational guided contact hours in SSA 1.4");
					_LLWR_ProgCode.Add("0105A01B", "Childcare Level 1");
					_LLWR_ProgCode.Add("0105A02B", "Childcare Level 2");
					_LLWR_ProgCode.Add("0105A03B", "Childcare Level 3");
					_LLWR_ProgCode.Add("0105XXXV", "Aggregated vocational guided contact hours in SSA 1.5");
					_LLWR_ProgCode.Add("0200XXXG", "Aggregated generic guided contact hours in SSA 2");
					_LLWR_ProgCode.Add("0201AAAB", "Access to HE Science");
					_LLWR_ProgCode.Add("0201BAAB", "Access to HE Environmental Science");
					_LLWR_ProgCode.Add("0201C02B", "Applied Science Level 2");
					_LLWR_ProgCode.Add("0201C03B", "Applied Science Level 3");
					_LLWR_ProgCode.Add("0201CAAB", "Access to HE Bio Science");
					_LLWR_ProgCode.Add("0201DAAB", "Access to HE Forensic Science");
					_LLWR_ProgCode.Add("0201EAAB", "Access to HE Health Science");
					_LLWR_ProgCode.Add("0201XXXV", "Aggregated vocational guided contact hours in SSA 2.1");
					_LLWR_ProgCode.Add("0202XXXV", "Aggregated vocational guided contact hours in SSA 2.2");
					_LLWR_ProgCode.Add("0300XXXG", "Aggregated generic guided contact hours in SSA 3");
					_LLWR_ProgCode.Add("0301A01B", "Land-based Studies Level 1");
					_LLWR_ProgCode.Add("0301A02B", "Land-based Studies Level 2");
					_LLWR_ProgCode.Add("0301A03B", "Land-based Studies Level 3");
					_LLWR_ProgCode.Add("0301AE0B", "Land-based Studies Level E");
					_LLWR_ProgCode.Add("0301XXXV", "Aggregated vocational guided contact hours in SSA 3.1");
					_LLWR_ProgCode.Add("0302A01B", "Horticulture and Forestry 1");
					_LLWR_ProgCode.Add("0302A02B", "Horticulture and Forestry 2");
					_LLWR_ProgCode.Add("0302A03B", "Horticulture and Forestry 3");
					_LLWR_ProgCode.Add("0302B01B", "Floristry Level 1");
					_LLWR_ProgCode.Add("0302B02B", "Floristry Level 2");
					_LLWR_ProgCode.Add("0302B03B", "Floristry Level 3");
					_LLWR_ProgCode.Add("0302XXXV", "Aggregated vocational guided contact hours in SSA 3.2");
					_LLWR_ProgCode.Add("0303A01B", "Equine Studies Level 1");
					_LLWR_ProgCode.Add("0303A02B", "Equine Studies Level 2");
					_LLWR_ProgCode.Add("0303A03B", "Equine Studies Level 3");
					_LLWR_ProgCode.Add("0303AE0B", "Horse Care Level Entry");
					_LLWR_ProgCode.Add("0303B01B", "Animal Care Level 1");
					_LLWR_ProgCode.Add("0303B02B", "Animal Care Level 2");
					_LLWR_ProgCode.Add("0303B03B", "Animal Care Level 3");
					_LLWR_ProgCode.Add("0303C02B", "Veterinary Nursing Level 2");
					_LLWR_ProgCode.Add("0303C03B", "Veterinary Nursing Level 3");
					_LLWR_ProgCode.Add("0303XXXV", "Aggregated vocational guided contact hours in SSA 3.3");
					_LLWR_ProgCode.Add("0304A01B", "Countryside & Environment Level 1");
					_LLWR_ProgCode.Add("0304A02B", "Countryside & Environment Level 2");
					_LLWR_ProgCode.Add("0304A03B", "Countryside & Environment Level 3");
					_LLWR_ProgCode.Add("0304XXXV", "Aggregated vocational guided contact hours in SSA 3.4");
					_LLWR_ProgCode.Add("0400XXXG", "Aggregated generic guided contact hours in SSA 4");
					_LLWR_ProgCode.Add("0401A01B", "Manufacturing and Engineering Level 1");
					_LLWR_ProgCode.Add("0401A02B", "Manufacturing and Engineering Level 2");
					_LLWR_ProgCode.Add("0401A03B", "Manufacturing and Engineering Level 3");
					_LLWR_ProgCode.Add("0401AAAB", "Access to HE Engineering");
					_LLWR_ProgCode.Add("0401AE0B", "Engineering Studies Level E");
					_LLWR_ProgCode.Add("0401B02B", "Electrical / Electronic Engineering Level 2");
					_LLWR_ProgCode.Add("0401B03B", "Electrical / Electronic Engineering Level 3");
					_LLWR_ProgCode.Add("0401C01B", "Fabrication and Welding Level 1");
					_LLWR_ProgCode.Add("0401C02B", "Fabrication and Welding Level 2");
					_LLWR_ProgCode.Add("0401C03B", "Fabrication and Welding Level 3");
					_LLWR_ProgCode.Add("0401D02B", "Aerospace Engineering Level 2");
					_LLWR_ProgCode.Add("0401D03B", "Aerospace Engineering Level 3");
					_LLWR_ProgCode.Add("0401E02B", "Electrical Engineering Level 2");
					_LLWR_ProgCode.Add("0401E03B", "Electrical Engineering Level 3");
					_LLWR_ProgCode.Add("0401F02B", "Land based Engineering Level 2");
					_LLWR_ProgCode.Add("0401F03B", "Land based Engineering Level 3");
					_LLWR_ProgCode.Add("0401G02B", "Marine Engineering Level 2");
					_LLWR_ProgCode.Add("0401G03B", "Marine Engineering Level 3");
					_LLWR_ProgCode.Add("0401H01B", "Automotive Engineering Level 1");
					_LLWR_ProgCode.Add("0401H02B", "Automotive Engineering Level 2");
					_LLWR_ProgCode.Add("0401H03B", "Automotive Engineering Level 3");
					_LLWR_ProgCode.Add("0401I03B", "Enhanced Engineering Level 2/3");
					_LLWR_ProgCode.Add("0401XXXV", "Aggregated vocational guided contact hours in SSA 4.1");
					_LLWR_ProgCode.Add("0402C02B", "Wood Machining Level 2");
					_LLWR_ProgCode.Add("0402E02B", "Furniture Level 2");
					_LLWR_ProgCode.Add("0402E03B", "Furniture Level 3");
					_LLWR_ProgCode.Add("0402XXXV", "Aggregated vocational guided contact hours in SSA 4.2");
					_LLWR_ProgCode.Add("0403A02B", "Operations and Maintenance Level 2");
					_LLWR_ProgCode.Add("0403A03B", "Operations and Maintenance Level 3");
					_LLWR_ProgCode.Add("0403XXXV", "Aggregated vocational guided contact hours in SSA 4.3");
					_LLWR_ProgCode.Add("0500XXXG", "Aggregated generic guided contact hours in SSA 5");
					_LLWR_ProgCode.Add("0501XXXV", "Aggregated vocational guided contact hours in SSA 5.1");
					_LLWR_ProgCode.Add("0502A01B", "Construction Level 1");
					_LLWR_ProgCode.Add("0502A02B", "Construction Level 2");
					_LLWR_ProgCode.Add("0502A03B", "Construction Level 3");
					_LLWR_ProgCode.Add("0502AE0B", "Construction & Built Environment Level E");
					_LLWR_ProgCode.Add("0502B01B", "Brickwork Level 1");
					_LLWR_ProgCode.Add("0502B02B", "Brickwork Level 2");
					_LLWR_ProgCode.Add("0502B03B", "Brickwork Level 3");
					_LLWR_ProgCode.Add("0502C01B", "Carpentry & Joinery Level 1");
					_LLWR_ProgCode.Add("0502C02B", "Carpentry & Joinery Level 2");
					_LLWR_ProgCode.Add("0502C03B", "Carpentry & Joinery Level 3");
					_LLWR_ProgCode.Add("0502D01B", "Painting and Decorating Level 1");
					_LLWR_ProgCode.Add("0502D02B", "Painting and Decorating Level 2");
					_LLWR_ProgCode.Add("0502D03B", "Painting and Decorating Level 3");
					_LLWR_ProgCode.Add("0502E01B", "Trowel Trades Level 1");
					_LLWR_ProgCode.Add("0502E02B", "Trowel Trades Level 2");
					_LLWR_ProgCode.Add("0502E03B", "Trowel Trades Level 3");
					_LLWR_ProgCode.Add("0502F01B", "Plumbing Level 1");
					_LLWR_ProgCode.Add("0502F02B", "Plumbing Level 2");
					_LLWR_ProgCode.Add("0502F03B", "Plumbing Level 3");
					_LLWR_ProgCode.Add("0502G02B", "Gas installation and Maintenance Level 2");
					_LLWR_ProgCode.Add("0502G03B", "Gas installation and Maintenance Level 3");
					_LLWR_ProgCode.Add("0502H01B", "Wall and Floor Tiling Level 1");
					_LLWR_ProgCode.Add("0502H02B", "Wall and Floor Tiling Level 2");
					_LLWR_ProgCode.Add("0502H03B", "Wall and Floor Tiling Level 3");
					_LLWR_ProgCode.Add("0502J01B", "Plant Maintenance Level 1");
					_LLWR_ProgCode.Add("0502J02B", "Plant Maintenance Level 2");
					_LLWR_ProgCode.Add("0502J03B", "Plant Maintenance Level 3");
					_LLWR_ProgCode.Add("0502K01B", "Electrical Installation Level 1");
					_LLWR_ProgCode.Add("0502K02B", "Electrical Installation Level 2");
					_LLWR_ProgCode.Add("0502K03B", "Electrical Installation Level 3");
					_LLWR_ProgCode.Add("0502XXXV", "Aggregated vocational guided contact hours in SSA 5.2");
					_LLWR_ProgCode.Add("0503XXXV", "Aggregated vocational guided contact hours in SSA 5.3");
					_LLWR_ProgCode.Add("0600XXXG", "Aggregated generic guided contact hours in SSA 6");
					_LLWR_ProgCode.Add("0601A01B", "IT Practitioners Level 1");
					_LLWR_ProgCode.Add("0601A02B", "IT Practitioners Level 2");
					_LLWR_ProgCode.Add("0601A03B", "IT Practitioners Level 3");
					_LLWR_ProgCode.Add("0601XXXV", "Aggregated vocational guided contact hours in SSA 6.1");
					_LLWR_ProgCode.Add("0602A01B", "IT Users Level 1");
					_LLWR_ProgCode.Add("0602A02B", "IT Users Level 2");
					_LLWR_ProgCode.Add("0602A03B", "IT Users Level 3");
					_LLWR_ProgCode.Add("0602AE0B", "Information Technology Level E");
					_LLWR_ProgCode.Add("0602XXXV", "Aggregated vocational guided contact hours in SSA 6.2");
					_LLWR_ProgCode.Add("0700XXXG", "Aggregated generic guided contact hours in SSA 7");
					_LLWR_ProgCode.Add("0701A01B", "Retail Level 1");
					_LLWR_ProgCode.Add("0701A02B", "Retail Level 2");
					_LLWR_ProgCode.Add("0701A03B", "Retail Level 3");
					_LLWR_ProgCode.Add("0701AE0B", "Retail Level E");
					_LLWR_ProgCode.Add("0701XXXV", "Aggregated vocational guided contact hours in SSA 7.1");
					_LLWR_ProgCode.Add("0702XXXV", "Aggregated vocational guided contact hours in SSA 7.2");
					_LLWR_ProgCode.Add("0703A01B", "Hair and Beauty Level 1");
					_LLWR_ProgCode.Add("0703A02B", "Hair and Beauty Level 2");
					_LLWR_ProgCode.Add("0703A03B", "Hair and Beauty Level 3");
					_LLWR_ProgCode.Add("0703AE0B", "Hair and Beauty Level E");
					_LLWR_ProgCode.Add("0703B01B", "Hairdressing Level 1");
					_LLWR_ProgCode.Add("0703B02B", "Hairdressing Level 2");
					_LLWR_ProgCode.Add("0703B03B", "Hairdressing Level 3");
					_LLWR_ProgCode.Add("0703C01B", "Beauty Therapy Level 1");
					_LLWR_ProgCode.Add("0703C02B", "Beauty Therapy Level 2");
					_LLWR_ProgCode.Add("0703C03B", "Beauty Therapy Level 3");
					_LLWR_ProgCode.Add("0703D02B", "Nail Technology Level 2");
					_LLWR_ProgCode.Add("0703D03B", "Nail Technology Level 3");
					_LLWR_ProgCode.Add("0703E02B", "Theatrical Special Effects Level 2");
					_LLWR_ProgCode.Add("0703E03B", "Theatrical Special Effects Level 3");
					_LLWR_ProgCode.Add("0703F03B", "Spa Therapy Level 3");
					_LLWR_ProgCode.Add("0703XXXV", "Aggregated vocational guided contact hours in SSA 7.3");
					_LLWR_ProgCode.Add("0704A01B", "Professional Cookery Level 1");
					_LLWR_ProgCode.Add("0704A02B", "Professional Cookery Level 2");
					_LLWR_ProgCode.Add("0704A03B", "Professional Cookery Level 3");
					_LLWR_ProgCode.Add("0704AE0B", "Catering Entry Level");
					_LLWR_ProgCode.Add("0704B01B", "Hospitality and Catering Level 1");
					_LLWR_ProgCode.Add("0704B02B", "Hospitality and Catering Level 2");
					_LLWR_ProgCode.Add("0704B03B", "Hospitality and Catering Level 3");
					_LLWR_ProgCode.Add("0704BE0B", "Hospitality and Catering Level E");
					_LLWR_ProgCode.Add("0704XXXV", "Aggregated vocational guided contact hours in SSA 7.4");
					_LLWR_ProgCode.Add("0800XXXG", "Aggregated generic guided contact hours in SSA 8");
					_LLWR_ProgCode.Add("0801A01B", "Sport and Leisure Level 1");
					_LLWR_ProgCode.Add("0801A02B", "Sport and Leisure Level 2");
					_LLWR_ProgCode.Add("0801A03B", "Sport and Leisure Level 3");
					_LLWR_ProgCode.Add("0801AE0B", "Sport and Leisure Level E");
					_LLWR_ProgCode.Add("0801XXXV", "Aggregated vocational guided contact hours in SSA 8.1");
					_LLWR_ProgCode.Add("0802A01B", "Travel and Tourism Level 1");
					_LLWR_ProgCode.Add("0802A02B", "Travel and Tourism Level 2");
					_LLWR_ProgCode.Add("0802A03B", "Travel and Tourism Level 3");
					_LLWR_ProgCode.Add("0802BAAB", "Access to HE Tourism & Hospitality");
					_LLWR_ProgCode.Add("0802XXXV", "Aggregated vocational guided contact hours in SSA 8.2");
					_LLWR_ProgCode.Add("0900XXXG", "Aggregated generic guided contact hours in SSA 9");
					_LLWR_ProgCode.Add("0901A01B", "Performing Arts Level 1");
					_LLWR_ProgCode.Add("0901A02B", "Performing Arts Level 2");
					_LLWR_ProgCode.Add("0901A03B", "Performing Arts Level 3");
					_LLWR_ProgCode.Add("0901AE0B", "Performing Arts Level E");
					_LLWR_ProgCode.Add("0901C02B", "Music & Music Technology Level 2");
					_LLWR_ProgCode.Add("0901C03B", "Music & Music Technology Level 3");
					_LLWR_ProgCode.Add("0901XXXV", "Aggregated vocational guided contact hours in SSA 9.1");
					_LLWR_ProgCode.Add("0902A01B", "Art and Design Level 1");
					_LLWR_ProgCode.Add("0902A02B", "Art and Design Level 2");
					_LLWR_ProgCode.Add("0902A03B", "Art and Design Level 3");
					_LLWR_ProgCode.Add("0902AE0B", "Art and Design Level E");
					_LLWR_ProgCode.Add("0902B03B", "Art Foundation Studies Level 3");
					_LLWR_ProgCode.Add("0902XXXV", "Aggregated vocational guided contact hours in SSA 9.2");
					_LLWR_ProgCode.Add("0903A01B", "Media Level 1");
					_LLWR_ProgCode.Add("0903A02B", "Media Level 2");
					_LLWR_ProgCode.Add("0903A03B", "Media Level 3");
					_LLWR_ProgCode.Add("0903B02B", "Production Arts Level 2");
					_LLWR_ProgCode.Add("0903B03B", "Production Arts Level 3");
					_LLWR_ProgCode.Add("0903XXXV", "Aggregated vocational guided contact hours in SSA 9.3");
					_LLWR_ProgCode.Add("0904XXXV", "Aggregated vocational guided contact hours in SSA 9.4");
					_LLWR_ProgCode.Add("1000XXXG", "Aggregated generic guided contact hours in SSA 10");
					_LLWR_ProgCode.Add("1001XXXV", "Aggregated vocational guided contact hours in SSA 10.1");
					_LLWR_ProgCode.Add("1002XXXV", "Aggregated vocational guided contact hours in SSA 10.2");
					_LLWR_ProgCode.Add("1003XXXV", "Aggregated vocational guided contact hours in SSA 10.3");
					_LLWR_ProgCode.Add("1004XXXV", "Aggregated vocational guided contact hours in SSA 10.4");
					_LLWR_ProgCode.Add("1100XXXG", "Aggregated generic guided contact hours in SSA 11");
					_LLWR_ProgCode.Add("1101XXXV", "Aggregated vocational guided contact hours in SSA 11.1");
					_LLWR_ProgCode.Add("1102XXXV", "Aggregated vocational guided contact hours in SSA 11.2");
					_LLWR_ProgCode.Add("1103XXXV", "Aggregated vocational guided contact hours in SSA 11.3");
					_LLWR_ProgCode.Add("1104XXXV", "Aggregated vocational guided contact hours in SSA 11.4");
					_LLWR_ProgCode.Add("1105AAAB", "Access to HE Humanities");
					_LLWR_ProgCode.Add("1105XXXV", "Aggregated vocational guided contact hours in SSA 11.5");
					_LLWR_ProgCode.Add("1200XXXG", "Aggregated generic guided contact hours in SSA 12");
					_LLWR_ProgCode.Add("1201XXXV", "Aggregated vocational guided contact hours in SSA 12.1");
					_LLWR_ProgCode.Add("1202XXXV", "Aggregated vocational guided contact hours in SSA 12.2");
					_LLWR_ProgCode.Add("1203XXXV", "Aggregated vocational guided contact hours in SSA 12.3");
					_LLWR_ProgCode.Add("1300XXXG", "Aggregated generic guided contact hours in SSA 13");
					_LLWR_ProgCode.Add("1301XXXV", "Aggregated vocational guided contact hours in SSA 13.1");
					_LLWR_ProgCode.Add("1302XXXV", "Aggregated vocational guided contact hours in SSA 13.2");
					_LLWR_ProgCode.Add("1400XXXG", "Aggregated generic guided contact hours in SSA 14");
					_LLWR_ProgCode.Add("1401A01B", "Foundation Studies Level 1");
					_LLWR_ProgCode.Add("1401A02B", "Foundation Studies Level 2");
					_LLWR_ProgCode.Add("1401AE1B", "Foundation Learning Level E1");
					_LLWR_ProgCode.Add("1401AE2B", "Foundation Learning Level E2");
					_LLWR_ProgCode.Add("1401AE3B", "Foundation Learning Level E3");
					_LLWR_ProgCode.Add("1401AXXG", "Independent skills - moderate");
					_LLWR_ProgCode.Add("1401AXXV", "Independent skills - moderate");
					_LLWR_ProgCode.Add("1401BE1B", "ILS Profound Level E1");
					_LLWR_ProgCode.Add("1401BE2B", "ILS Profound Level E2");
					_LLWR_ProgCode.Add("1401BE3B", "ILS Profound Level E3");
					_LLWR_ProgCode.Add("1401BPEB", "ILS Profound Pre Entry");
					_LLWR_ProgCode.Add("1401BXXG", "Independent skills - profound");
					_LLWR_ProgCode.Add("1401BXXV", "Independent skills - profound");
					_LLWR_ProgCode.Add("1401C01B", "ESOL Level 1");
					_LLWR_ProgCode.Add("1401C02B", "ESOL Level 2");
					_LLWR_ProgCode.Add("1401CE1B", "ESOL Level E1");
					_LLWR_ProgCode.Add("1401CE2B", "ESOL Level E2");
					_LLWR_ProgCode.Add("1401CE3B", "ESOL Level E3");
					_LLWR_ProgCode.Add("1401CPEB", "ESOL Pre-entry");
					_LLWR_ProgCode.Add("1401CXXG", "ESOL");
					_LLWR_ProgCode.Add("1401CXXV", "ESOL");
					_LLWR_ProgCode.Add("1401D01B", "Preparation for work Level 1");
					_LLWR_ProgCode.Add("1401D02B", "Preparation for work Level 2");
					_LLWR_ProgCode.Add("1401DE1B", "Preparation for Work Level E1");
					_LLWR_ProgCode.Add("1401DE2B", "Preparation for Work Level E2");
					_LLWR_ProgCode.Add("1401DE3B", "Preparation for Work Level E3");
					_LLWR_ProgCode.Add("1401DXXG", "Adult Basic Education");
					_LLWR_ProgCode.Add("1401DXXV", "Adult Basic Education");
					_LLWR_ProgCode.Add("1401EE1B", "ILS Moderate Level E1");
					_LLWR_ProgCode.Add("1401EE2B", "ILS Moderate Level E2");
					_LLWR_ProgCode.Add("1401EE3B", "ILS Moderate Level E3");
					_LLWR_ProgCode.Add("1401EPEB", "ILS Moderate Pre - Entry Level");
					_LLWR_ProgCode.Add("1401XXXV", "Aggregated vocational guided contact hours in SSA 14.1");
					_LLWR_ProgCode.Add("1402A01B", "Preparation for work Level 1");
					_LLWR_ProgCode.Add("1402A02B", "Preparation for work Level 2");
					_LLWR_ProgCode.Add("1402AE1B", "Preparation for Work Level E1");
					_LLWR_ProgCode.Add("1402AE2B", "Preparation for Work Level E2");
					_LLWR_ProgCode.Add("1402AE3B", "Preparation for Work Level E3");
					_LLWR_ProgCode.Add("1402AXXG", "Preparation for life and work");
					_LLWR_ProgCode.Add("1402AXXV", "Preparation for life and work");
					_LLWR_ProgCode.Add("1402XXXV", "Aggregated vocational guided contact hours in SSA 14.2");
					_LLWR_ProgCode.Add("1500XXXG", "Aggregated generic guided contact hours in SSA 15");
					_LLWR_ProgCode.Add("1501A02B", "Accounting Level 2");
					_LLWR_ProgCode.Add("1501A03B", "Accounting Level 3");
					_LLWR_ProgCode.Add("1501A04B", "Accounting Level 4");
					_LLWR_ProgCode.Add("1501XXXV", "Aggregated vocational guided contact hours in SSA 15.1");
					_LLWR_ProgCode.Add("1502A01B", "Business Administration Level 1");
					_LLWR_ProgCode.Add("1502A02B", "Business Administration Level 2");
					_LLWR_ProgCode.Add("1502A03B", "Business Administration Level 3");
					_LLWR_ProgCode.Add("1502AE0B", "Business Administration Level E");
					_LLWR_ProgCode.Add("1502D02B", "Legal Secretaries Level 2");
					_LLWR_ProgCode.Add("1502D03B", "Legal Secretaries Level 3");
					_LLWR_ProgCode.Add("1502E02B", "Medical Administration Level 2");
					_LLWR_ProgCode.Add("1502E03B", "Medical Administration Level 3");
					_LLWR_ProgCode.Add("1502XXXV", "Aggregated vocational guided contact hours in SSA 15.2");
					_LLWR_ProgCode.Add("1503B02B", "Business Studies Level 2");
					_LLWR_ProgCode.Add("1503B03B", "Business Studies Level 3");
					_LLWR_ProgCode.Add("1503BAAB", "Access to HE Business Studies");
					_LLWR_ProgCode.Add("1503XXXV", "Aggregated vocational guided contact hours in SSA 15.3");
					_LLWR_ProgCode.Add("1504XXXV", "Aggregated vocational guided contact hours in SSA 15.4");
					_LLWR_ProgCode.Add("1505A03B", "Law Level 3");
					_LLWR_ProgCode.Add("1505B02B", "Legal Practice Level 2");
					_LLWR_ProgCode.Add("1505B03B", "Legal Practice Level 3");
					_LLWR_ProgCode.Add("1505XXXV", "Aggregated vocational guided contact hours in SSA 15.5");
					_LLWR_ProgCode.Add("9001XXXV", "NVQs delivered in the workplace");
					_LLWR_ProgCode.Add("9101XXXV", "LearnDirect for basic skills / ESOL provision");
					_LLWR_ProgCode.Add("9102XXXV", "LearnDirect other");
				}
				return _LLWR_ProgCode;
			}
		}
		
		private static Dictionary<string, string> _LLWR_UnitAuth;
		public static Dictionary<string, string> LLWR_UnitAuth
		{
			get
			{
				if(_LLWR_UnitAuth == null)
				{
					_LLWR_UnitAuth = new Dictionary<string, string>();
					_LLWR_UnitAuth.Add("660", "Isle of Anglesey");
					_LLWR_UnitAuth.Add("661", "Gwynedd");
					_LLWR_UnitAuth.Add("662", "Conwy");
					_LLWR_UnitAuth.Add("663", "Denbighshire");
					_LLWR_UnitAuth.Add("664", "Flintshire");
					_LLWR_UnitAuth.Add("665", "Wrexham");
					_LLWR_UnitAuth.Add("666", "Powys");
					_LLWR_UnitAuth.Add("667", "Ceredigion");
					_LLWR_UnitAuth.Add("668", "Pembrokeshire");
					_LLWR_UnitAuth.Add("669", "Carmarthenshire");
					_LLWR_UnitAuth.Add("670", "Swansea");
					_LLWR_UnitAuth.Add("671", "Neath Port Talbot");
					_LLWR_UnitAuth.Add("672", "Bridgend");
					_LLWR_UnitAuth.Add("673", "The Vale of Glamorgan");
					_LLWR_UnitAuth.Add("674", "Rhondda Cynon Taff");
					_LLWR_UnitAuth.Add("675", "Merthyr Tydfil");
					_LLWR_UnitAuth.Add("676", "Caerphilly");
					_LLWR_UnitAuth.Add("677", "Blaenau Gwent");
					_LLWR_UnitAuth.Add("678", "Torfaen");
					_LLWR_UnitAuth.Add("679", "Monmouthshire");
					_LLWR_UnitAuth.Add("680", "Newport");
					_LLWR_UnitAuth.Add("681", "Cardiff");
					_LLWR_UnitAuth.Add("998", "not known");
					_LLWR_UnitAuth.Add("999", "outside Wales");
				}
				return _LLWR_UnitAuth;
			}
		}
		
		private static Dictionary<string, string> _LLWR_EmpStart;
		public static Dictionary<string, string> LLWR_EmpStart
		{
			get
			{
				if(_LLWR_EmpStart == null)
				{
					_LLWR_EmpStart = new Dictionary<string, string>();
					_LLWR_EmpStart.Add("1", "Employed (excluding self-employed)");
					_LLWR_EmpStart.Add("5", "Self employed");
					_LLWR_EmpStart.Add("6", "Economically inactive (excluding full time education and training)");
					_LLWR_EmpStart.Add("7", "Full-time education or training");
					_LLWR_EmpStart.Add("8", "Other (including part-time education or training)");
					_LLWR_EmpStart.Add("9", "Short Term Unemployed");
					_LLWR_EmpStart.Add("0", "Long Term Unemployed");
					_LLWR_EmpStart.Add("4", "Not known");
				}
				return _LLWR_EmpStart;
			}
		}
		
		private static Dictionary<string, string> _LLWR_EmpLength;
		public static Dictionary<string, string> LLWR_EmpLength
		{
			get
			{
				if(_LLWR_EmpLength == null)
				{
					_LLWR_EmpLength = new Dictionary<string, string>();
					_LLWR_EmpLength.Add("0", "Not employed with same employer prior to commencing learning programme.");
					_LLWR_EmpLength.Add("1", "1 day to less than 3 months");
					_LLWR_EmpLength.Add("2", "3 months to less than 6 months");
					_LLWR_EmpLength.Add("3", "6 months to less than 12 months");
					_LLWR_EmpLength.Add("4", "12 months or more");
					_LLWR_EmpLength.Add("9", "Not applicable");
				}
				return _LLWR_EmpLength;
			}
		}
		
		private static Dictionary<string, string> _LLWR_EmpSME;
		public static Dictionary<string, string> LLWR_EmpSME
		{
			get
			{
				if(_LLWR_EmpSME == null)
				{
					_LLWR_EmpSME = new Dictionary<string, string>();
					_LLWR_EmpSME.Add("2", "Learner not employed");
					_LLWR_EmpSME.Add("3", "Non SME - Public sector organisation");
					_LLWR_EmpSME.Add("4", "Non SME - Private sector organisation");
					_LLWR_EmpSME.Add("5", "SME - Public sector organisation");
					_LLWR_EmpSME.Add("6", "SME - Private sector organisation");
					_LLWR_EmpSME.Add("7", "SME - Third sector organisation");
					_LLWR_EmpSME.Add("8", "Non SME - Third sector organisation");
					_LLWR_EmpSME.Add("9", "Not required");
				}
				return _LLWR_EmpSME;
			}
		}
		
		private static Dictionary<string, string> _LLWR_EmpSize;
		public static Dictionary<string, string> LLWR_EmpSize
		{
			get
			{
				if(_LLWR_EmpSize == null)
				{
					_LLWR_EmpSize = new Dictionary<string, string>();
					_LLWR_EmpSize.Add("1", "0 - 1 employees");
					_LLWR_EmpSize.Add("2", "2 - 9 employees");
					_LLWR_EmpSize.Add("3", "10 – 49 employees");
					_LLWR_EmpSize.Add("4", "50 – 249 employees");
					_LLWR_EmpSize.Add("5", "250+ employees");
					_LLWR_EmpSize.Add("9", "Not required");
				}
				return _LLWR_EmpSize;
			}
		}
		
		private static Dictionary<string, string> _LLWR_AppLevy;
		public static Dictionary<string, string> LLWR_AppLevy
		{
			get
			{
				if(_LLWR_AppLevy == null)
				{
					_LLWR_AppLevy = new Dictionary<string, string>();
					_LLWR_AppLevy.Add("01", "Yes - The employer does contribute to the Apprenticeship Levy");
					_LLWR_AppLevy.Add("02", "No - The employer does not contribute to the Apprenticeship Levy");
					_LLWR_AppLevy.Add("00", "Not Applicable");
				}
				return _LLWR_AppLevy;
			}
		}
		
		private static Dictionary<string, string> _LLWR_MigWorker;
		public static Dictionary<string, string> LLWR_MigWorker
		{
			get
			{
				if(_LLWR_MigWorker == null)
				{
					_LLWR_MigWorker = new Dictionary<string, string>();
					_LLWR_MigWorker.Add("1", "Migrant - EU");
					_LLWR_MigWorker.Add("2", "Migrant - outside of EU");
					_LLWR_MigWorker.Add("3", "No");
					_LLWR_MigWorker.Add("9", "Not applicable");
				}
				return _LLWR_MigWorker;
			}
		}
		
		private static Dictionary<string, string> _LLWR_ProgType;
		public static Dictionary<string, string> LLWR_ProgType
		{
			get
			{
				if(_LLWR_ProgType == null)
				{
					_LLWR_ProgType = new Dictionary<string, string>();
					_LLWR_ProgType.Add("08", "Other WBL programme");
					_LLWR_ProgType.Add("17", "Welsh for Adults");
					_LLWR_ProgType.Add("30", "Adult Community Learning");
					_LLWR_ProgType.Add("31", "Traineeship - Engagement");
					_LLWR_ProgType.Add("32", "Traineeship - Level1");
					_LLWR_ProgType.Add("33", "Traineeship - Bridge-to-Employment");
					_LLWR_ProgType.Add("37", "Foundation Apprenticeship");
					_LLWR_ProgType.Add("38", "Apprenticeship");
					_LLWR_ProgType.Add("39", "Higher Apprenticeship");
					_LLWR_ProgType.Add("41", "Shared Foundation Apprenticeship (Level 2)");
					_LLWR_ProgType.Add("42", "Shared Apprenticeship (Level 3)");
					_LLWR_ProgType.Add("43", "Work Ready – Learning for Work");
					_LLWR_ProgType.Add("44", "Work Ready – Routeways");
					_LLWR_ProgType.Add("53", "Foundation Degree");
					_LLWR_ProgType.Add("54", "HE postgraduate");
					_LLWR_ProgType.Add("55", "HE professional or HE vocational programme");
					_LLWR_ProgType.Add("56", "HE First Degree");
					_LLWR_ProgType.Add("57", "HND");
					_LLWR_ProgType.Add("58", "HNC");
					_LLWR_ProgType.Add("59", "Other Undergraduate Qualification");
					_LLWR_ProgType.Add("71", "Access to FE");
					_LLWR_ProgType.Add("72", "Access to HE");
					_LLWR_ProgType.Add("80", "Welsh Baccalaureate");
					_LLWR_ProgType.Add("81", "Baccalaureate (other)");
					_LLWR_ProgType.Add("92", "Other FE");
				}
				return _LLWR_ProgType;
			}
		}
		
		private static Dictionary<string, string> _LLWR_FeeSource;
		public static Dictionary<string, string> LLWR_FeeSource
		{
			get
			{
				if(_LLWR_FeeSource == null)
				{
					_LLWR_FeeSource = new Dictionary<string, string>();
					_LLWR_FeeSource.Add("01", "ILA");
					_LLWR_FeeSource.Add("02", "the local education authority(LEA)/unitary authority");
					_LLWR_FeeSource.Add("03", "employer");
					_LLWR_FeeSource.Add("04", "a charitable organisation");
					_LLWR_FeeSource.Add("05", "learner or immediate family");
					_LLWR_FeeSource.Add("06", "other (external to student's family)");
					_LLWR_FeeSource.Add("07", "Career Development Loan");
					_LLWR_FeeSource.Add("08", "EU funding");
					_LLWR_FeeSource.Add("FS", "Flexible Skills Programme");
					_LLWR_FeeSource.Add("SP", "Skills Priority Programme");
					_LLWR_FeeSource.Add("90", "no tuition fees received");
					_LLWR_FeeSource.Add("99", "not known");
				}
				return _LLWR_FeeSource;
			}
		}
		
		private static Dictionary<string, string> _LLWR_SpecFund;
		public static Dictionary<string, string> LLWR_SpecFund
		{
			get
			{
				if(_LLWR_SpecFund == null)
				{
					_LLWR_SpecFund = new Dictionary<string, string>();
					_LLWR_SpecFund.Add("000", "Not required");
					_LLWR_SpecFund.Add("YRP", "Young Recruits Programme – Wage Subsidised");
					_LLWR_SpecFund.Add("YRM", "Young Recruits Programme – Micro Business payment");
					_LLWR_SpecFund.Add("WAW", "Welsh at Work *");
					_LLWR_SpecFund.Add("WAY", "Welsh at Work – YRP Wage support *");
					_LLWR_SpecFund.Add("WAM", "Welsh at Work – YRP Micro Business Support *");
					_LLWR_SpecFund.Add("YRS", "Sector Priority Fund - YRP Wage subsidised *");
					_LLWR_SpecFund.Add("YSM", "Sector Priority Fund – YRP Micro Business Support *");
					_LLWR_SpecFund.Add("ELC", "Apprentices within the Elderly Care sector");
					_LLWR_SpecFund.Add("ESC", "Essential Skills in the Community");
					_LLWR_SpecFund.Add("NGU", "Non Guarantee");
					_LLWR_SpecFund.Add("PAN", "Pathways to Apprenticeships - FE");
					_LLWR_SpecFund.Add("YJG", "Young recruits Job Growth Wales progression");
					_LLWR_SpecFund.Add("YSH", "Young recruits shared apps");
				}
				return _LLWR_SpecFund;
			}
		}
		
		private static Dictionary<string, string> _CONT_METH;
		public static Dictionary<string, string> CONT_METH
		{
			get
			{
				if(_CONT_METH == null)
				{
					_CONT_METH = new Dictionary<string, string>();
					_CONT_METH.Add("E", "Email");
					_CONT_METH.Add("S", "SMS");
					_CONT_METH.Add("P", "Post");
					_CONT_METH.Add("T", "Telephone");
					_CONT_METH.Add("-", "None recorded");
					_CONT_METH.Add("X", "Do not contact");
				}
				return _CONT_METH;
			}
		}
		
		private static Dictionary<string, string> _PREF_CONTACT_METH;
		public static Dictionary<string, string> PREF_CONTACT_METH
		{
			get
			{
				if(_PREF_CONTACT_METH == null)
				{
					_PREF_CONTACT_METH = new Dictionary<string, string>();
					_PREF_CONTACT_METH.Add("E", "Email");
					_PREF_CONTACT_METH.Add("S", "SMS");
					_PREF_CONTACT_METH.Add("P", "Post");
					_PREF_CONTACT_METH.Add("T", "Telephone");
					_PREF_CONTACT_METH.Add("-", "None recorded");
					_PREF_CONTACT_METH.Add("X", "Do not contact");
				}
				return _PREF_CONTACT_METH;
			}
		}
		
		private static Dictionary<string, string> _Prior_EmpStat_Code;
		public static Dictionary<string, string> Prior_EmpStat_Code
		{
			get
			{
				if(_Prior_EmpStat_Code == null)
				{
					_Prior_EmpStat_Code = new Dictionary<string, string>();
					_Prior_EmpStat_Code.Add("10", "In paid employment");
					_Prior_EmpStat_Code.Add("11", "Not in paid employment and looking for work");
					_Prior_EmpStat_Code.Add("12", "Not in paid employment and not looking for work");
					_Prior_EmpStat_Code.Add("98", "Not known / not provided");
				}
				return _Prior_EmpStat_Code;
			}
		}
		
		private static Dictionary<string, string> _Prior_EmpStat_SEI;
		public static Dictionary<string, string> Prior_EmpStat_SEI
		{
			get
			{
				if(_Prior_EmpStat_SEI == null)
				{
					_Prior_EmpStat_SEI = new Dictionary<string, string>();
					_Prior_EmpStat_SEI.Add("01", "Learner is self employed");
					_Prior_EmpStat_SEI.Add("", "n/a");
				}
				return _Prior_EmpStat_SEI;
			}
		}
		
		private static Dictionary<string, string> _Prior_EmpStat_EII;
		public static Dictionary<string, string> Prior_EmpStat_EII
		{
			get
			{
				if(_Prior_EmpStat_EII == null)
				{
					_Prior_EmpStat_EII = new Dictionary<string, string>();
					_Prior_EmpStat_EII.Add("02", "Learner is employed for less than 16 hours per week");
					_Prior_EmpStat_EII.Add("03", "Learner is employed for 16 - 19 hours per week");
					_Prior_EmpStat_EII.Add("04", "Learner is employed for 20 hours or more per week");
					_Prior_EmpStat_EII.Add("", "n/a");
				}
				return _Prior_EmpStat_EII;
			}
		}
		
		private static Dictionary<string, string> _Prior_EmpStat_LOU;
		public static Dictionary<string, string> Prior_EmpStat_LOU
		{
			get
			{
				if(_Prior_EmpStat_LOU == null)
				{
					_Prior_EmpStat_LOU = new Dictionary<string, string>();
					_Prior_EmpStat_LOU.Add("01", "Learner has been unemployed for less than 6 months");
					_Prior_EmpStat_LOU.Add("02", "Learner has been unemployed for 6-11 months");
					_Prior_EmpStat_LOU.Add("03", "Learner has been unemployed for 12-23 months");
					_Prior_EmpStat_LOU.Add("04", "Learner has been unemployed for 24-35 months");
					_Prior_EmpStat_LOU.Add("05", "Learner has been unemployed for 36 months or more");
					_Prior_EmpStat_LOU.Add("", "n/a");
				}
				return _Prior_EmpStat_LOU;
			}
		}
		
		private static Dictionary<string, string> _Prior_EmpStat_LOE;
		public static Dictionary<string, string> Prior_EmpStat_LOE
		{
			get
			{
				if(_Prior_EmpStat_LOE == null)
				{
					_Prior_EmpStat_LOE = new Dictionary<string, string>();
					_Prior_EmpStat_LOE.Add("01", "Learner has been employed for up to 3 months");
					_Prior_EmpStat_LOE.Add("02", "Learner has been employed for 4 to 6 months");
					_Prior_EmpStat_LOE.Add("03", "Learner has been employed for 7 to 12 months");
					_Prior_EmpStat_LOE.Add("04", "Learner has been employed for more than 12 months");
					_Prior_EmpStat_LOE.Add("", "n/a");
				}
				return _Prior_EmpStat_LOE;
			}
		}
		
		private static Dictionary<string, string> _Prior_EmpStat_BSI;
		public static Dictionary<string, string> Prior_EmpStat_BSI
		{
			get
			{
				if(_Prior_EmpStat_BSI == null)
				{
					_Prior_EmpStat_BSI = new Dictionary<string, string>();
					_Prior_EmpStat_BSI.Add("01", "Learner is in receipt of Job Seekers Allowance (JSA)");
					_Prior_EmpStat_BSI.Add("02", "Learner is in receipt of Employment and Support Allowance - Work Related Activity Group (ESA WRAG)");
					_Prior_EmpStat_BSI.Add("03", "Learner is in receipt of another state benefit other than JSA or ESA (WRAG)");
					_Prior_EmpStat_BSI.Add("04", "Learner is in receipt of Universal Credit");
					_Prior_EmpStat_BSI.Add("", "n/a");
				}
				return _Prior_EmpStat_BSI;
			}
		}
		
		private static Dictionary<string, string> _Prior_EmpStat_PEI;
		public static Dictionary<string, string> Prior_EmpStat_PEI
		{
			get
			{
				if(_Prior_EmpStat_PEI == null)
				{
					_Prior_EmpStat_PEI = new Dictionary<string, string>();
					_Prior_EmpStat_PEI.Add("01", "Learner was in full time education or training prior to enrolment");
					_Prior_EmpStat_PEI.Add("", "n/a");
				}
				return _Prior_EmpStat_PEI;
			}
		}
		
		private static Dictionary<string, string> _Prior_EmpStat_RON;
		public static Dictionary<string, string> Prior_EmpStat_RON
		{
			get
			{
				if(_Prior_EmpStat_RON == null)
				{
					_Prior_EmpStat_RON = new Dictionary<string, string>();
					_Prior_EmpStat_RON.Add("01", "Learner is aged 14-15 and is at risk of becoming NEET (Not in education, employment or training)");
					_Prior_EmpStat_RON.Add("", "n/a");
				}
				return _Prior_EmpStat_RON;
			}
		}
		
		private static Dictionary<string, string> _Prior_EmpStat_SEM;
		public static Dictionary<string, string> Prior_EmpStat_SEM
		{
			get
			{
				if(_Prior_EmpStat_SEM == null)
				{
					_Prior_EmpStat_SEM = new Dictionary<string, string>();
					_Prior_EmpStat_SEM.Add("01", "Small employer");
					_Prior_EmpStat_SEM.Add("", "n/a");
				}
				return _Prior_EmpStat_SEM;
			}
		}
		
		private static Dictionary<string, string> _Change_EmpStat_Code;
		public static Dictionary<string, string> Change_EmpStat_Code
		{
			get
			{
				if(_Change_EmpStat_Code == null)
				{
					_Change_EmpStat_Code = new Dictionary<string, string>();
					_Change_EmpStat_Code.Add("10", "In paid employment");
					_Change_EmpStat_Code.Add("11", "Not in paid employment and looking for work");
					_Change_EmpStat_Code.Add("12", "Not in paid employment and not looking for work");
					_Change_EmpStat_Code.Add("98", "Not known / not provided");
				}
				return _Change_EmpStat_Code;
			}
		}
		
		private static Dictionary<string, string> _Change_EmpStat_SEI;
		public static Dictionary<string, string> Change_EmpStat_SEI
		{
			get
			{
				if(_Change_EmpStat_SEI == null)
				{
					_Change_EmpStat_SEI = new Dictionary<string, string>();
					_Change_EmpStat_SEI.Add("01", "Learner is self employed");
					_Change_EmpStat_SEI.Add("", "n/a");
				}
				return _Change_EmpStat_SEI;
			}
		}
		
		private static Dictionary<string, string> _Change_EmpStat_EII;
		public static Dictionary<string, string> Change_EmpStat_EII
		{
			get
			{
				if(_Change_EmpStat_EII == null)
				{
					_Change_EmpStat_EII = new Dictionary<string, string>();
					_Change_EmpStat_EII.Add("02", "Learner is employed for less than 16 hours per week");
					_Change_EmpStat_EII.Add("03", "Learner is employed for 16 - 19 hours per week");
					_Change_EmpStat_EII.Add("04", "Learner is employed for 20 hours or more per week");
					_Change_EmpStat_EII.Add("", "n/a");
				}
				return _Change_EmpStat_EII;
			}
		}
		
		private static Dictionary<string, string> _Change_EmpStat_LOU;
		public static Dictionary<string, string> Change_EmpStat_LOU
		{
			get
			{
				if(_Change_EmpStat_LOU == null)
				{
					_Change_EmpStat_LOU = new Dictionary<string, string>();
					_Change_EmpStat_LOU.Add("01", "Learner has been unemployed for less than 6 months");
					_Change_EmpStat_LOU.Add("02", "Learner has been unemployed for 6-11 months");
					_Change_EmpStat_LOU.Add("03", "Learner has been unemployed for 12-23 months");
					_Change_EmpStat_LOU.Add("04", "Learner has been unemployed for 24-35 months");
					_Change_EmpStat_LOU.Add("05", "Learner has been unemployed for 36 months or more");
					_Change_EmpStat_LOU.Add("", "n/a");
				}
				return _Change_EmpStat_LOU;
			}
		}
		
		private static Dictionary<string, string> _Change_EmpStat_LOE;
		public static Dictionary<string, string> Change_EmpStat_LOE
		{
			get
			{
				if(_Change_EmpStat_LOE == null)
				{
					_Change_EmpStat_LOE = new Dictionary<string, string>();
					_Change_EmpStat_LOE.Add("01", "Learner has been employed for up to 3 months");
					_Change_EmpStat_LOE.Add("02", "Learner has been employed for 4 to 6 months");
					_Change_EmpStat_LOE.Add("03", "Learner has been employed for 7 to 12 months");
					_Change_EmpStat_LOE.Add("04", "Learner has been employed for more than 12 months");
					_Change_EmpStat_LOE.Add("", "n/a");
				}
				return _Change_EmpStat_LOE;
			}
		}
		
		private static Dictionary<string, string> _Change_EmpStat_BSI;
		public static Dictionary<string, string> Change_EmpStat_BSI
		{
			get
			{
				if(_Change_EmpStat_BSI == null)
				{
					_Change_EmpStat_BSI = new Dictionary<string, string>();
					_Change_EmpStat_BSI.Add("01", "Learner is in receipt of Job Seekers Allowance (JSA)");
					_Change_EmpStat_BSI.Add("02", "Learner is in receipt of Employment and Support Allowance - Work Related Activity Group (ESA WRAG)");
					_Change_EmpStat_BSI.Add("03", "Learner is in receipt of another state benefit other than JSA or ESA (WRAG)");
					_Change_EmpStat_BSI.Add("04", "Learner is in receipt of Universal Credit");
					_Change_EmpStat_BSI.Add("", "n/a");
				}
				return _Change_EmpStat_BSI;
			}
		}
		
		private static Dictionary<string, string> _Change_EmpStat_PEI;
		public static Dictionary<string, string> Change_EmpStat_PEI
		{
			get
			{
				if(_Change_EmpStat_PEI == null)
				{
					_Change_EmpStat_PEI = new Dictionary<string, string>();
					_Change_EmpStat_PEI.Add("01", "Learner was in full time education or training prior to enrolment");
					_Change_EmpStat_PEI.Add("", "n/a");
				}
				return _Change_EmpStat_PEI;
			}
		}
		
		private static Dictionary<string, string> _Change_EmpStat_RON;
		public static Dictionary<string, string> Change_EmpStat_RON
		{
			get
			{
				if(_Change_EmpStat_RON == null)
				{
					_Change_EmpStat_RON = new Dictionary<string, string>();
					_Change_EmpStat_RON.Add("01", "Learner is aged 14-15 and is at risk of becoming NEET (Not in education, employment or training)");
					_Change_EmpStat_RON.Add("", "n/a");
				}
				return _Change_EmpStat_RON;
			}
		}
		
		private static Dictionary<string, string> _Change_EmpStat_SEM;
		public static Dictionary<string, string> Change_EmpStat_SEM
		{
			get
			{
				if(_Change_EmpStat_SEM == null)
				{
					_Change_EmpStat_SEM = new Dictionary<string, string>();
					_Change_EmpStat_SEM.Add("01", "Small employer");
					_Change_EmpStat_SEM.Add("", "n/a");
				}
				return _Change_EmpStat_SEM;
			}
		}
		
		private static Dictionary<string, string> _PROG_HHSA;
		public static Dictionary<string, string> PROG_HHSA
		{
			get
			{
				if(_PROG_HHSA == null)
				{
					_PROG_HHSA = new Dictionary<string, string>();
					_PROG_HHSA.Add("1", "No household member is in employment and the household includes one or more dependent children");
					_PROG_HHSA.Add("2", "No household member is in employment and the household does not include any dependent children");
					_PROG_HHSA.Add("3", "Learner lives in a single adult household with dependent children");
					_PROG_HHSA.Add("98", "Learner has withheld this information");
					_PROG_HHSA.Add("99", "None of HHS1, HHS2 or HHS3 applies");
					_PROG_HHSA.Add("0", "Not applicable");
				}
				return _PROG_HHSA;
			}
		}
		
		private static Dictionary<string, string> _PROG_HHSB;
		public static Dictionary<string, string> PROG_HHSB
		{
			get
			{
				if(_PROG_HHSB == null)
				{
					_PROG_HHSB = new Dictionary<string, string>();
					_PROG_HHSB.Add("1", "No household member is in employment and the household includes one or more dependent children");
					_PROG_HHSB.Add("2", "No household member is in employment and the household does not include any dependent children");
					_PROG_HHSB.Add("3", "Learner lives in a single adult household with dependent children");
					_PROG_HHSB.Add("98", "Learner has withheld this information");
					_PROG_HHSB.Add("99", "None of HHS1, HHS2 or HHS3 applies");
					_PROG_HHSB.Add("0", "Not applicable");
				}
				return _PROG_HHSB;
			}
		}
		
		private static Dictionary<string, string> _DAS_STATUS;
		public static Dictionary<string, string> DAS_STATUS
		{
			get
			{
				if(_DAS_STATUS == null)
				{
					_DAS_STATUS = new Dictionary<string, string>();
					_DAS_STATUS.Add("0", "Non-DAS");
					_DAS_STATUS.Add("1", "DAS Eligible");
					_DAS_STATUS.Add("2", "Ready for DAS");
					_DAS_STATUS.Add("3", "Sent to DAS");
					_DAS_STATUS.Add("4", "On DAS");
				}
				return _DAS_STATUS;
			}
		}
	}
	
	public static class BaseCodeList
	{
		public static Dictionary<string, string> MakeCodeList(DBCustomFormQuestion question, ref bool MultiCode)
		{
			MultiCode = false;
			Dictionary<string, string> answers = null;
			if (question.ImportFieldName.Equals(uImportConsts.Act_DP_Code, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Act_DP_Code;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Action_By, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Action_By;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.GCSE_MATH_GRADE, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.GCSE_MATH_GRADE;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.GCSE_ENG_GRADE, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.GCSE_ENG_GRADE;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.NUM_FIRSTASSLEV, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.NUM_FIRSTASSLEV;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LIT_FIRSTASSLEV, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LIT_FIRSTASSLEV;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.ICT_FIRSTASSLEV, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.ICT_FIRSTASSLEV;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.MCF, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.MCF;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.ECF, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.ECF;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.MGA, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.MGA;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EGA, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EGA;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.HHS, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.HHS;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.PROG_HHS, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.PROG_HHS;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.ACT, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.ACT;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.PROG_ACT, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.PROG_ACT;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.FFI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.FFI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.PROG_FFI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.PROG_FFI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.RUI_SURVEYS, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.RUI_SURVEYS;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.RUI_COURSES, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.RUI_COURSES;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.RUI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.RUI;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.L52_POST, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.L52_POST;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.L52_PHONE, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.L52_PHONE;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.L52_EMAIL, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.L52_EMAIL;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.L52, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.L52;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.L14, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.L14;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.L15, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.L15;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.L16, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.L16;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LDA, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LDA;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EHC, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EHC;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.PRIOREDU, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.PRIOREDU;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.COUNTRY, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.COUNTRY;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Review_Type, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Review_Type;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Attended_Type, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Attended_Type;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.All_LLDD, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.All_LLDD;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Primary_LLDD, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Primary_LLDD;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.ETHNICORIGIN, StringComparison.CurrentCultureIgnoreCase))
			{
				if (question.ImportFieldType == uImportConsts.ETHN1)
				{
					answers = SharedListLoad.ETHN1;
				}
				else if (question.ImportFieldType == uImportConsts.ETHN2)
				{
					answers = SharedListLoad.ETHN2;
				}
				else
				{
					answers = SharedListLoad.ETHNICORIGIN;
				}
			}
			else if (question.ImportFieldName.Equals(uImportConsts.SEX, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.SEX;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EmpStat_LOE, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EmpStat_LOE;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EmpStat_EII, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EmpStat_EII;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EmpStat_LOU, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EmpStat_LOU;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EmpStat_SEI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EmpStat_SEI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EmpStat_BSI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EmpStat_BSI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EmpStat_RON, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EmpStat_RON;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EmpStat_PEI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EmpStat_PEI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EmpStat_SEM, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EmpStat_SEM;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.EmpStat_Code, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.EmpStat_Code;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.TITLE, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.TITLE;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Act_FUp_After, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Act_FUp_After;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.MIAP_VERIFTYPE, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.MIAP_VERIFTYPE;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.MIAP_FPN_SEEN, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.MIAP_FPN_SEEN;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.ESOL_FIRSTASSLEV, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.ESOL_FIRSTASSLEV;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.TECHCERT_REQD, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.TECHCERT_REQD;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.FS_Math_Reqd, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.FS_Math_Reqd;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.FS_Eng_Reqd, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.FS_Eng_Reqd;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.FS_ICT_Reqd, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.FS_ICT_Reqd;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Err_Reqd, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Err_Reqd;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_HHS, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_HHS;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_ACT, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_ACT;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_LSCLEARN, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_LSCLEARN;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_LSCDISAB, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_LSCDISAB;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_LSCDIFFIC, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_LSCDIFFIC;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_PRIMARY_LLDD, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_PRIMARY_LLDD;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_ALL_LLDD, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_ALL_LLDD;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_ETHNICITY, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_ETHNICITY;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_SEX, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_SEX;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_TITLE, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_TITLE;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_DAS_STATUS, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_DAS_STATUS;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_BAS_NUM, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_BAS_NUM;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_BAS_LIT, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_BAS_LIT;
			}
			else if (question.ImportFieldName.Equals(uImportApplicantConsts.APP_BAS_ICT, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.APP_BAS_ICT;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_CareResp, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_CareResp;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_HouseHoldSit, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_HouseHoldSit;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_NatId, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_NatId;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_WelshSpkr, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_WelshSpkr;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_WelshQualLev, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_WelshQualLev;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_PrimeDisab, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_PrimeDisab;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_AddLearnSup, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_AddLearnSup;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_WLHC, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_WLHC;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_HighQual, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_HighQual;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_ProgCode, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_ProgCode;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_UnitAuth, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_UnitAuth;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_EmpStart, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_EmpStart;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_EmpLength, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_EmpLength;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_EmpSME, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_EmpSME;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_EmpSize, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_EmpSize;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_AppLevy, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_AppLevy;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_MigWorker, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_MigWorker;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_ProgType, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_ProgType;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_FeeSource, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_FeeSource;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.LLWR_SpecFund, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.LLWR_SpecFund;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.CONT_METH, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.CONT_METH;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.PREF_CONTACT_METH, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.PREF_CONTACT_METH;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Prior_EmpStat_Code, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Prior_EmpStat_Code;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Prior_EmpStat_SEI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Prior_EmpStat_SEI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Prior_EmpStat_EII, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Prior_EmpStat_EII;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Prior_EmpStat_LOU, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Prior_EmpStat_LOU;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Prior_EmpStat_LOE, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Prior_EmpStat_LOE;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Prior_EmpStat_BSI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Prior_EmpStat_BSI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Prior_EmpStat_PEI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Prior_EmpStat_PEI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Prior_EmpStat_RON, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Prior_EmpStat_RON;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Prior_EmpStat_SEM, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Prior_EmpStat_SEM;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Change_EmpStat_Code, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Change_EmpStat_Code;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Change_EmpStat_SEI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Change_EmpStat_SEI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Change_EmpStat_EII, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Change_EmpStat_EII;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Change_EmpStat_LOU, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Change_EmpStat_LOU;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Change_EmpStat_LOE, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Change_EmpStat_LOE;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Change_EmpStat_BSI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Change_EmpStat_BSI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Change_EmpStat_PEI, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Change_EmpStat_PEI;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Change_EmpStat_RON, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Change_EmpStat_RON;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.Change_EmpStat_SEM, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.Change_EmpStat_SEM;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.PROG_HHSA, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.PROG_HHSA;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.PROG_HHSB, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.PROG_HHSB;
				MultiCode = true;
			}
			else if (question.ImportFieldName.Equals(uImportConsts.DAS_STATUS, StringComparison.CurrentCultureIgnoreCase))
			{
				answers = SharedListLoad.DAS_STATUS;
			}
			return answers;
		}
	}
}
