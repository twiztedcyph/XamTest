using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FCA.Helpers
{
    public static class FieldNameHelper
    {
        private static string[] importFields = new string[]
        {
            uImportConsts.MAIN_OFFICER,
            uImportConsts.Training_Officer,
            uImportConsts.Careers_Officer,
            uImportConsts.Placement_Officer,
            uImportConsts.Mentor_Officer,
            uImportApplicantConsts.APP_OFF_TRAIN,
            uImportApplicantConsts.APP_MENTOR,
            uImportApplicantConsts.APP_RECRUITED_BY
        };

        private static string[] importFieldNames = new string[]
        {
            uImportConsts.AIMASSESSOR,
            uImportConsts.AIMIV,
            uImportConsts.AIMEV
        };

        private static bool IsImportFieldStartWith(string ImportFieldName, string Key)
        {
            return ImportFieldName.StartsWith(Key, StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsImportFieldStartWith(string ImportFieldName, string[] Keys)
        {
            return Keys.Where(k => IsImportFieldStartWith(ImportFieldName, k)).Any();
        }

        private static bool IsImportField(string ImportFieldName, string Key)
        {
            return ImportFieldName.Equals(Key, StringComparison.CurrentCultureIgnoreCase);
        }

        private static bool IsImportField(string ImportFieldName, string[] Keys)
        {
            return Keys.Where(k => IsImportField(ImportFieldName, k)).Any();
        }

        public static bool IsOfficerQuestion(string ImportFieldName)
        {
            return IsImportField(ImportFieldName, importFields) || IsImportFieldStartWith(ImportFieldName, importFieldNames);
        }

        public static bool IsOrganisationQuestion(string ImportFieldName, string ImportFieldType)
        {
            if (ImportFieldType == null)
                ImportFieldType = string.Empty;
            return 
                IsImportField(ImportFieldName, uImportApplicantConsts.APP_EmpRecGUID) ||
                IsImportField(ImportFieldName, uImportConsts.EmpRecGUID) ||
                IsImportField(ImportFieldName, "SUBCONTRECGUID") ||
                ImportFieldType.Equals(fldFormCapCommon.FCA_IT_PLACE, StringComparison.CurrentCultureIgnoreCase) ||
                ImportFieldType.StartsWith(fldFormCapCommon.FCA_IT_PLA_X, StringComparison.CurrentCultureIgnoreCase) ||
                ImportFieldName.EndsWith("_" + uImportPlcConsts.imp_PlaceCode, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsSiteQuestion(string ImportFieldName)
        {
            return IsImportField(ImportFieldName, new string[] { uImportConsts.SITE, uImportApplicantConsts.APP + "_" + uImportConsts.SITE });
        }

        public static bool IsQualPlanQuestion(string ImportFieldName)
        {
            return IsImportField(ImportFieldName, new string[] { uImportConsts.QUALPLAN, uImportApplicantConsts.APP_QualPlan});
        }
    }
}
