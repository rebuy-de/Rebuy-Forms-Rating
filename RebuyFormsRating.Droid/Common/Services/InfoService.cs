using System;
using Android.Content.PM;
using RebuyFormsRating.Common.Services;
using RebuyFormsRating.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(InfoService))]
namespace RebuyFormsRating.Droid
{
    public class InfoService : IInfoService 
    {
        public string AppVersionName { 
            get {
                return getPackageManager().PackageName;
            }
        }

        public int AppBuildVersionCode {
            get {
                return getPackageManager().VersionCode;
            }
        }

        public string AppVersionCode {
            get {
                return getPackageManager().VersionName;
            }
        }

        private static PackageInfo getPackageManager()
        {
            var context = Forms.Context;
            return context.PackageManager.GetPackageInfo(context.PackageName, 0);
        }
    }
}
