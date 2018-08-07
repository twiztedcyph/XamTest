using Pellcomp.Vs.Mobile.FormCaptureApp.lib;

namespace XamTest.Helpers
{
    public class DebugOptions
    {
        public static string DebugKey = "debug_options";
        public bool Debug { get; set; }
        public bool SyncSettings { get; set; } = true;
        public bool SyncPlans { get; set; } = true;
        public bool SyncSites { get; set; } = true;
        public bool SyncOfficers { get; set; } = true;
        public bool SyncPickLists { get; set; } = true;
        public bool SyncOrgs { get; set; } = true;
        public bool GetCustomForms { get; set; } = true;
        public bool UpdateFormOwnership { get; set; } = true;
        public bool DownloadUserReviews { get; set; } = true;
        public bool UploadForms { get; set; } = true;
        public bool ClearUnwantedForms { get; set; } = true;
        public bool DownloadForms { get; set; } = true;


        public bool ProcessSync(bool OptionSetting)
        {
            if (!Debug)
            {
                return true;
            }
            else
            {
                return OptionSetting;
            }
        }

        public void Refresh()
        {
            Debug = Settings.GetBool(oPICSConfig.cfgKey_FCA_Debug_Mode, false);
            if (Debug)
            {
                Settings.SaveDebugOptions();
            }
        }
    }
}
