using System;
using Xamarin.Forms;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace RebuyFormsRating
{
    public static class Settings
    {
        private const string versionNumberKey = "versionNumber";
        private const string usageCountKey = "usageCount";
        private const string isRatedKey = "isRated";

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static string VersionNumber
        {
            get { return AppSettings.GetValueOrDefault<string>(versionNumberKey, ""); }
            set { AppSettings.AddOrUpdateValue(versionNumberKey, value); }
        }

        public static int UsageCount
        {
            get { return AppSettings.GetValueOrDefault(usageCountKey, 1); }
            set { AppSettings.AddOrUpdateValue(usageCountKey, value); }
        }

        public static bool IsRated
        {
            get { return AppSettings.GetValueOrDefault(isRatedKey, false); }
            set { AppSettings.AddOrUpdateValue(isRatedKey, value); }
        }
    }
}
