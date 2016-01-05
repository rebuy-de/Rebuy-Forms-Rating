﻿using System;
using RebuyFormsRating.Common.Services;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;

namespace RebuyFormsRating.Models
{
    public class RatingViewHandler
    {
        public bool IsRated {
            get { return Settings.IsRated; }
            set { Settings.IsRated = value; }
        }

        public int UsesBeforeRating { set; get; } = 1;

        public int UsageCount {
            get { return Settings.UsageCount; }
            set { Settings.UsageCount = value; }
        }

        public string VersionNumber {
            get { return Settings.VersionNumber; }
            set { Settings.VersionNumber = value; }
        }

        public string RatingMessage { set; get; } = "Sie nutzen unsere App gerne? Dann nehmen Sie sich bitte für eine Bewertung einen Moment Zeit! Es dauert nicht länger als eine Minute. Vielen Dank!";
        public string RateLaterMessage { set; get; } = "Später bewerten";
        public string RateNowMessage { set; get; } = "Jetzt bewerten";
        public string DisturbMessage { set; get; } = "Nein, danke";

        public void OpenRatingViewIfNeeded(string appStoreId)
        {
            if (String.IsNullOrWhiteSpace(VersionNumber) || VersionNumber != DependencyService.Get<IInfoService>().AppVersionCode) {
                resetReminder();
            } else {
                if (!IsRated && UsageCount >= UsesBeforeRating) {
                    showActionSheet(appStoreId);
                }

                UsageCount++;
            }
        }

        private async Task showActionSheet(string appStoreId)
        {
            var action = await UserDialogs.Instance.ActionSheetAsync(
                RatingMessage,
                RateLaterMessage,
                null,
                RateNowMessage,
                DisturbMessage
            );

            if (action.Equals(RateLaterMessage)) {
                hideReminder();
            } else if (action.Equals(RateNowMessage)) {
                rateNow(appStoreId);
            } else if (action.Equals(DisturbMessage)) {
                disableReminder();
            }
        }

        private void resetReminder()
        {
            UsageCount = 1;
            VersionNumber = DependencyService.Get<IInfoService>().AppVersionCode;
            IsRated = false;
        }

        private void rateNow(string appStoreId)
        {
            IsRated = true;
            openStore(appStoreId);
        }

        private void disableReminder()
        {
            IsRated = true;
        }

        private void hideReminder()
        {
            IsRated = false;
        }

        private void openStore(string appStoreId)
        {
            var ratingservice = DependencyService.Get<IRatingService>();

            if (ratingservice == null) {
                return;
            }

            if (Device.OS == TargetPlatform.iOS) {
                ratingservice.OpenStore(appStoreId);
            } else {
                ratingservice.OpenStore("");
            }
        }
    }
}
