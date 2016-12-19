using System;
using Foundation;
using RebuyFormsRating.Common.Services;
using RebuyFormsRating.IOS;
using Xamarin.Forms;
using RebuyFormsRating.Common.Services;

[assembly: Dependency(typeof(InfoService))]
namespace RebuyFormsRating.IOS
{
    public class InfoService : IInfoService
    {
        public string AppVersionName {
            get {
                return NSBundle.MainBundle.BundleIdentifier;
            }
        }

        public string AppVersionCode {
            get {
                return NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString();
            }
        }

        public int AppBuildVersionCode {
            get {
                return Int32.Parse(NSBundle.MainBundle.InfoDictionary["CFBundleVersion"].ToString());
            }
        }

        public static void Init()
        {
        }
    }
}
