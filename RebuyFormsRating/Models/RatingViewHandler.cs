using System;
using System.ComponentModel;
using RebuyFormsRating.Common;
using RebuyFormsRating.Common.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RebuyFormsRating.Models
{
    public class RatingViewHandler
    {
        private const int usesBeforeRating = 1;
        private bool ratingIsAvailable;

        public bool IsRated {
            get { return Settings.IsRated; }
            set { 
                if (Settings.IsRated == value) {
                    return;
                }

                Settings.IsRated = value;
            }
        }

        public int UsageCount {
            get { return Settings.UsageCount; }
            set { 
                if (Settings.UsageCount == value) {
                    return;
                }

                Settings.UsageCount = value;
            }
        }

        public string VersionNumber {
            get { return Settings.VersionNumber; }
            set { 
                if (Settings.VersionNumber == value) {
                    return;
                }

                Settings.VersionNumber = value;
            }
        }

		public void CheckOpenRatingView()
		{
			if (String.IsNullOrWhiteSpace(VersionNumber)) {
				resetReminder();
			} else if (!VersionNumber.Equals(DependencyService.Get<IInfoService>().AppVersionCode)) {
				resetReminder();
			} else {
				if (!IsRated && UsageCount >= usesBeforeRating) {
					showActionSheet();
				}

				++UsageCount;
			}
		}

		private async Task showActionSheet()
		{
			Debug.WriteLine("ActionTTTTTIIIIIIMMMMMEEEEE");
			var action = await UserDialogs.Instance.ActionSheetAsync(
				"Sie nutzen unsere App gerne? Dann nehmen Sie sich bitte für eine Bewertung einen Moment Zeit! Es dauert nicht länger als eine Minute. Vielen Dank!",
				"Später bewerten",
				null,
				"Jetzt bewerten",
				"Nein, danke"
			);
			if (action.Equals("Später bewerten")) {
				hideReminder();
			} else if (action.Equals("Jetzt bewerten")) {
				rateNow();
			} else if (action.Equals("Nein, danke")) {
				disableReminder();
			}
			Debug.WriteLine("Action: " + action);
		}

        private void resetReminder()
        {
            UsageCount = 1;
            VersionNumber = DependencyService.Get<IInfoService>().AppVersionCode;
            IsRated = false;
        }

        private void rateNow()
        {
            IsRated = true;
            openStore();
        }

        private void disableReminder()
        {
            IsRated = true;
        }

        private void hideReminder()
        {
            IsRated = false;
        }

        private void openStore()
        {
            var ratingservice = DependencyService.Get<IRatingService>();

            if (ratingservice == null) {
                return;
            }

			if (Device.OS == TargetPlatform.iOS) {
				ratingservice.OpenStore("1000000");
			} else {
				ratingservice.OpenStore("");
			}   
        }
    }
}
