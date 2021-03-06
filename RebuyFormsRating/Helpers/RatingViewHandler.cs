﻿using System;
using System.Threading.Tasks;
using RebuyFormsRating.Common.Services;
using RebuyFormsRating.Models;
using Xamarin.Forms;

namespace RebuyFormsRating.Helpers
{
    public class RatingViewHandler : IRatingViewHandler
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

        public string RatingMessage { set; get; } = "Nimm dir bitte für eine Bewertung einen Moment Zeit! Es dauert nicht länger als eine Minute. Vielen Dank!";
        public string RatingQuestionMessage { set; get; } = "Nutzt du unsere App gerne?";
        public string RatingYes { set; get; } = "Ja";
        public string RatingNo { set; get; } = "Nein";
        public string RateLaterMessage { set; get; } = "Später bewerten";
        public string RateNowMessage { set; get; } = "Jetzt bewerten";
        public string DisturbMessage { set; get; } = "Nein, Danke";
        public string FeedbackTitle { set; get; } = "Sende Feedback";
        public string FeedbackMessage { set; get; } = "Es tut uns leid, dass du mit unserer App unzufrieden bist. Teile uns mit wie wir deine reBuy-Erfahrung verbessern können.";

        public async Task<RatingViewResponse> OpenRatingViewIfNeeded(Page page, string appStoreId, bool ignoreUsageCount = false, bool withLikeQuestion = true)
        {
            var response = new RatingViewResponse(string.Empty);
            if (String.IsNullOrWhiteSpace(VersionNumber) || VersionNumber != DependencyService.Get<IInfoService>().AppVersionCode) {
                resetReminder();
            } else {
                if (!IsRated && UsageCount >= UsesBeforeRating || !IsRated && ignoreUsageCount) {
                    if (withLikeQuestion) {
                        response = await showLikeQuestionActionSheet(page, appStoreId);
                    } else {
                        response = await showStoreRatingActionSheet(page, appStoreId);
                    }
                }
                UsageCount++;
            }

            return response;
        }

        private async Task<RatingViewResponse> showLikeQuestionActionSheet(Page page, string appStoreId)
        {
            var response = new RatingViewResponse(VersionNumber);

            var actionSheet = DependencyService.Get<IActionSheet>();

            var action = await actionSheet.UseActionSheet(
                page,
                RatingQuestionMessage,
                RatingYes,
                RatingNo
            );

            if (action.Equals(RatingYes)) {
                response = await showStoreRatingActionSheet(page, appStoreId);
            } else if (action.Equals(RatingNo)) {
                response = await showFeedbackQuestionActionSheet(page, appStoreId);
            }

            return response;
        }

        private async Task<RatingViewResponse> showFeedbackQuestionActionSheet(Page page, string appStoreId)
        {
            var response = new RatingViewResponse(VersionNumber);

            var actionSheet = DependencyService.Get<IActionSheet>();

            var action = await actionSheet.UseActionSheet(
               page,
               FeedbackMessage,
               FeedbackTitle,
               DisturbMessage
            );

            if (action.Equals(FeedbackTitle)) {
                disableReminder();
                response.ButtonClicked = Enums.RatingViewButtonTypes.feedbacknow;
            } else if (action.Equals(DisturbMessage)) {
                disableReminder();
                response.ButtonClicked = Enums.RatingViewButtonTypes.cancelfeedback;
            }

            return response;
        }

        private async Task<RatingViewResponse> showStoreRatingActionSheet(Page page, string appStoreId)
        {
            var response = new RatingViewResponse(VersionNumber);

            var actionSheet = DependencyService.Get<IActionSheet>();

            var action = await actionSheet.UseActionSheet(
               page,
               RatingMessage,
               RateLaterMessage,
               RateNowMessage,
               DisturbMessage
           );

            if (action.Equals(RateLaterMessage)) {
                hideReminder();
                response.ButtonClicked = Enums.RatingViewButtonTypes.ratelater;
            } else if (action.Equals(RateNowMessage)) {
                rateNow(appStoreId);
                response.ButtonClicked = Enums.RatingViewButtonTypes.ratenow;
            } else if (action.Equals(DisturbMessage)) {
                disableReminder();
                response.ButtonClicked = Enums.RatingViewButtonTypes.cancelrating;
            }

            return response;
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
