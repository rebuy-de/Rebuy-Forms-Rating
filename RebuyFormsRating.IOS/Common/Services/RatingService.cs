using System;
using Foundation;
using RebuyFormsRating.Common.Services;
using RebuyFormsRating.IOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(RatingService))]
namespace RebuyFormsRating.IOS
{
	public class RatingService : IRatingService
	{
		public void OpenStore(string appStoreId)
		{
			if (string.IsNullOrWhiteSpace(appStoreId)){
				return;
			}

			UIApplication.SharedApplication.OpenUrl(new NSUrl("itms-apps://itunes.apple.com/app/id" + appStoreId));
		}
	}
}