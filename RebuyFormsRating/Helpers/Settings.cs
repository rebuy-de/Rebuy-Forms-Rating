using System;
using Xamarin.Forms;

namespace RebuyFormsRating
{
    public static class Settings
    {
        private const string versionNumberKey = "versionNumber";
        private const string usageCountKey = "usageCount";
        private const string isRatedKey = "isRated";

        public static string VersionNumber
        {
            get {
                object number;

                return Application.Current.Properties.TryGetValue(versionNumberKey, out number) ? (string) number : "";
            }
            set { Application.Current.Properties[versionNumberKey] = value; }
        }

        public static int UsageCount
        {
            get { 
                object count;

                return Application.Current.Properties.TryGetValue(usageCountKey, out count) ? (int) count : 1;
            }
            set { Application.Current.Properties[usageCountKey] = value; }
        }

        public static bool IsRated
        {
            get { 
                object rated;

                return Application.Current.Properties.TryGetValue(isRatedKey, out rated) && (bool) rated; 
            }
            set { Application.Current.Properties[isRatedKey] = value; }
        }
    }
}
