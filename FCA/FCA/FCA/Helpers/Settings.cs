using Newtonsoft.Json;
using Pellcomp.Vs.Mobile.FormCaptureApp.lib;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace XamTest.Helpers
{
    public static class Settings
    {
        public const string MIN_SUPPORTED_VERSION = "3.1.1.0";
        public const string ALIAS_PREFIX = "FCINSTANCE__";
        private static readonly string USERNAME_KEY = "username_key";
        private static readonly string PASSWORD_KEY = "password_key";
        private static readonly string OFFICER_CODE_KEY = "officer_code_key";
        private static readonly string FULLNAME_KEY = "fullname_key";
        private static readonly string USERSITES_KEY = "user_sites_key";
        private static readonly string EMAIL_KEY = "email_key";
        private static readonly string WIFI_ONLY_KEY = "wifi_only_key";
        private static readonly string WEBSERVICE_URL_KEY = "webservice_url_key";
        private static readonly string WEBSERVICE_VER_KEY = "webservice_ver_key";
        private static readonly string WEBSERVICE_TOKEN_KEY = "webservice_token_key";
        private static readonly string LOGGED_IN_KEY = "logged_in_key";
        private static readonly string LASTTIME_BASE_DATA_SYNC = "lasttime_base_data_sync";
        private static readonly string CLEAR_USERNAME_KEY = "clear_username_key";
        private static readonly string NEW_LOGIN_KEY = "new_login_key";

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        private static DebugOptions _debugOptions;
        public static DebugOptions DebugOptions
        {
            get
            {
                if (_debugOptions == null)
                {
                    _debugOptions = GetDebugOptions();
                }
                return _debugOptions;
            }
        }

        public static void SaveDebugOptions()
        {
            AppSettings.AddOrUpdateValue(DebugOptions.DebugKey, JsonConvert.SerializeObject(_debugOptions));
        }

        private static DebugOptions GetDebugOptions()
        {
            string serialisedDebugOptions = AppSettings.GetValueOrDefault(DebugOptions.DebugKey, "");
            if (!string.IsNullOrEmpty(serialisedDebugOptions))
            {
                return JsonConvert.DeserializeObject<DebugOptions>(serialisedDebugOptions);
            }
            else
            {
                return new DebugOptions();
            }
        }

        public static string GetString(string key, string _default)
        {
            return AppSettings.GetValueOrDefault(key, _default);
        }

        public static void SetString(string key, string _value)
        {
            AppSettings.AddOrUpdateValue(key, _value);
        }

        public static bool GetBool(string key, bool _default)
        {
            return AppSettings.GetValueOrDefault(key, _default);
        }

        public static void SetBool(string key, bool _value)
        {
            AppSettings.AddOrUpdateValue(key, _value);
        }

        public static int GetInt(string key, int _default)
        {
            return AppSettings.GetValueOrDefault(key, _default);
        }

        public static void SetDateTime(string key, DateTime _value)
        {
            AppSettings.AddOrUpdateValue(key, _value);
        }

        public static DateTime GetDateTime(string key, DateTime _default)
        {
            return AppSettings.GetValueOrDefault(key, _default);
        }

        public static void SetInt(string key, int _value)
        {
            AppSettings.AddOrUpdateValue(key, _value);
        }

        public static string UserName
        {
            get
            {
                return GetString(USERNAME_KEY, string.Empty);
            }
            set
            {
                SetString(USERNAME_KEY, value);
            }
        }

        public static string Password
        {
            get
            {
                return GetString(PASSWORD_KEY, string.Empty);
            }
            set
            {
                SetString(PASSWORD_KEY, value);
            }
        }

        public static string OfficerCode
        {
            get
            {
                return GetString(OFFICER_CODE_KEY, string.Empty);
            }
            set
            {
                SetString(OFFICER_CODE_KEY, value);
            }
        }
        public static string UserSites
        {
            get
            {
                return GetString(USERSITES_KEY, string.Empty);
            }
            set
            {
                SetString(USERSITES_KEY, value);
            }
        }
        public static string FullName
        {
            get
            {
                return GetString(FULLNAME_KEY, string.Empty);
            }
            set
            {
                SetString(FULLNAME_KEY, value);
            }
        }

        public static string EmailAddress
        {
            get
            {
                return GetString(EMAIL_KEY, string.Empty);
            }
            set
            {
                SetString(EMAIL_KEY, value);
            }
        }

        public static bool WifiOnly
        {
            get
            {
                return GetBool(WIFI_ONLY_KEY, false);
            }
            set
            {
                SetBool(WIFI_ONLY_KEY, value);
            }
        }

        public static string WebServiceURL
        {
            get
            {
                return GetString(WEBSERVICE_URL_KEY, string.Empty);
            }
            set
            {
                SetString(WEBSERVICE_URL_KEY, value);
            }
        }

        public static string WebServiceVersion
        {
            get
            {
                return GetString(WEBSERVICE_VER_KEY, string.Empty);
            }
            set
            {
                SetString(WEBSERVICE_VER_KEY, value);
            }
        }

        private static bool ServiceVersionGreaterThan(string Ver)
        {
            Version ServVer = new Version(WebServiceVersion);
            Version CompVer = new Version(Ver);
            return CompVer.CompareTo(ServVer) == -1;
        }

        public enum ServiceFeatures
        {
            MinimumVersion,
            ApprovedCRMActivityForms,
            ContactPreferences
        }

        public static bool ServiceSupports(ServiceFeatures SupportedFeature)
        {
            switch (SupportedFeature)
            {
                case ServiceFeatures.MinimumVersion:
                    {
                        return ServiceVersionGreaterThan(Settings.MIN_SUPPORTED_VERSION);
                    }
                case ServiceFeatures.ApprovedCRMActivityForms:
                    {
                        return ServiceVersionGreaterThan("3.1.3.0");
                    }
                case ServiceFeatures.ContactPreferences:
                    {
                        return ServiceVersionGreaterThan("3.1.4.0");
                    }
                default:
                    {
                        return false;
                    };
            }
        }

        public static string AuthToken
        {
            get
            {
                return GetString(WEBSERVICE_TOKEN_KEY, string.Empty);
            }
            set
            {
                SetString(WEBSERVICE_TOKEN_KEY, value);
            }
        }

        public static bool LoggedIn
        {
            get
            {
                return GetBool(LOGGED_IN_KEY, false);
            }
            set
            {
                SetBool(LOGGED_IN_KEY, value);
            }
        }

        public static DateTime LastBaseDataSync
        {
            get
            {
                return Convert.ToDateTime(GetString(LASTTIME_BASE_DATA_SYNC, DateTime.MinValue.ToString()));
            }
            set
            {
                SetString(LASTTIME_BASE_DATA_SYNC, value.ToString());
            }
        }

        public static bool IsNewLogin
        {
            get
            {
                return GetBool(NEW_LOGIN_KEY, true);
            }
            set
            {
                SetBool(NEW_LOGIN_KEY, value);
            }
        }

        public static string ClearUsername
        {
            get { return GetString(CLEAR_USERNAME_KEY, ""); }
            set { SetString(CLEAR_USERNAME_KEY, value); }
        }

        public static bool Orgs_AllowCreate
        {
            get { return GetBool(oPICSConfig.cfgKey_FCA_Orgs_AllowCreate, true); }
            set { SetBool(oPICSConfig.cfgKey_FCA_Orgs_AllowCreate, value); }
        }

        public static string Orgs_StatusForNew
        {
            get { return GetString(oPICSConfig.cfgKey_FCA_Orgs_StatusForNew, fldOrgs.CStatusLive); }
            set { SetString(oPICSConfig.cfgKey_FCA_Orgs_StatusForNew, value); }
        }
    }
}
