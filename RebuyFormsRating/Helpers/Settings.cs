// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace RebuyFormsRating.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings {
            get {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;
        private const string versionNumberKey = "versionNumber";
        private const string usageCountKey = "usageCount";
        private const string isRatedKey = "isRated";

        #endregion

        public static string GeneralSettings {
            get {
                return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
            }
            set {
                AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
            }
        }

        public static string VersionNumber {
            get {
                return AppSettings.GetValueOrDefault<string>(versionNumberKey, "");
            }
            set {
                AppSettings.AddOrUpdateValue(versionNumberKey, value);
            }
        }

        public static int UsageCount {
            get {
                return AppSettings.GetValueOrDefault(usageCountKey, 1); 
            }
            set {
                AppSettings.AddOrUpdateValue(usageCountKey, value);
            }
        }

        public static bool IsRated {
            get {
                return AppSettings.GetValueOrDefault(isRatedKey, false);
            }
            set {
                AppSettings.AddOrUpdateValue(isRatedKey, value);
            }
        }
    }
}
