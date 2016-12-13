using System;
using Android.Content;
using RebuyFormsRating.Common.Services;
using RebuyFormsRating.Droid;
using Xamarin.Forms;
using AndroidApplication = Android.App.Application;
using AndroidUri = Android.Net.Uri;
using SystemUri = System.Uri;

[assembly: Dependency(typeof(RatingService))]
namespace RebuyFormsRating.Droid
{
    public class RatingService : IRatingService
    {
        public void OpenStore(string appStoreId)
        {
            var uri = AndroidUri.Parse(String.Format("{0}{1}", "market://details?id=", AndroidApplication.Context.PackageName));
            var intent = new Intent(Intent.ActionView, uri);
            intent.SetFlags(ActivityFlags.NewTask);
            Forms.Context.StartActivity(intent);
        }
    }
}
