using FCA.Models;
using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCA.Helpers
{
    public static class CodeLists
    {
        public static Dictionary<string, string> MakeCodeList(DBCustomFormQuestion question, ref bool MultiCode)
        {
            MultiCode = false;
            //Call base...
            Dictionary<string, string> answers = BaseCodeList.MakeCodeList(question, ref MultiCode);

            //Nothing found in base, handle special cases
            if (answers == null)
            {
                answers = new Dictionary<string, string>();

                //If else because switch requires const strings...
                if (FieldNameHelper.IsOfficerQuestion(question.ImportFieldName))
                {
                    string officerType = DBOfficer.GetOfficerTypeCode(question.ImportFieldName.ToUpper());
                    if (!string.IsNullOrEmpty(officerType))
                    {
                        List<DBOfficer> officers = Task.Run(() => DBOfficer.GetOfficerByType(officerType)).Result;

                        foreach (DBOfficer o in officers)
                        {
                            answers.Add(o.Officer, o.Surname + ", " + o.Firstname);
                        }
                    }
                }
                else if (FieldNameHelper.IsOrganisationQuestion(question.ImportFieldName, question.ImportFieldType))
                {
                    List<DBOrganisation> orgs = null;
                    if (question.ImportFieldType.StartsWith(fldFormCapCommon.FCA_IT_PLA_X, StringComparison.CurrentCultureIgnoreCase))
                    {
                        string sRole = question.ImportFieldType.Substring(question.ImportFieldType.Length - 1);
                        orgs = Task.Run(() => App.DB.GetOrganisations(sRole)).Result;
                    }
                    else
                    {
                        orgs = Task.Run(() => App.DB.GetOrganisations()).Result;
                    }

                    if (orgs != null && orgs.Count > 0)
                    {
                        foreach (var org in orgs)
                        {
                            answers.Add(org.RecGUID, org.Name);
                        }
                    }
                }
                else if (FieldNameHelper.IsSiteQuestion(question.ImportFieldName))
                {
                    List<DBSite> sites = Task.Run(() => App.DB.GetSites()).Result;

                    if (sites != null && sites.Count > 0)
                    {
                        foreach (var site in sites)
                        {
                            answers.Add(site.Site, site.Description);
                        }
                    }
                }
                else if (FieldNameHelper.IsQualPlanQuestion(question.ImportFieldName))
                {
                    List<DBQualPlan> plans = Task.Run(() => App.DB.GetQualPlans()).Result;

                    if (plans != null && plans.Count > 0)
                    {
                        foreach (var plan in plans)
                        {
                            answers.Add(plan.PlanCode, plan.Title);
                        }
                    }
                }
            }

            return answers;
        }
    }
}
