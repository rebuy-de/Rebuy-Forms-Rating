using System;
using System.ComponentModel;
using RebuyFormsRating.Common;
using RebuyFormsRating.Common.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace RebuyFormsRating.Models
{
    public class RatingViewViewModel : INotifyPropertyChanged
    {
        private const int usesBeforeRating = 1;

        private bool ratingIsAvailable;
        private Color ratingViewBackgroundColor;
        private Color detailTextColor;
        private Color titleColor;
        private string detailText = "";
        private string title = "";
        private string btnRateText = "";
        private string btnRateLaterText = "";
        private string btnCancelText = "";
        private Color btnRateTextColor;
        private Color btnRateLaterTextColor;
        private Color btnCancelTextColor;
        private Color btnRateColor;
        private Color btnRateLaterColor;
        private Color btnCancelColor;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand Rate { get; private set; }
        public ICommand Cancel { get; private set; }
        public ICommand RateLater { get; private set; }

        public bool RatingIsAvailable { 
            get { return ratingIsAvailable; }
            set {
                ratingIsAvailable = value;
                OnPropertyChanged();
            }
        }

        public Color RatingViewBackgroundColor {
            get { return ratingViewBackgroundColor; }
            set {
                ratingViewBackgroundColor = value;
                OnPropertyChanged();
            }
        }
        
        public Color DetailTextColor { 
            get { return detailTextColor; }
            set {
                detailTextColor = value;
                OnPropertyChanged();
            }
        }

        public Color TitleColor { 
            get { return titleColor; }
            set {
                titleColor = value;
                OnPropertyChanged ();
            }
        }

        public string DetailText {
            get { return detailText; }
            set {
                detailText = value;
                OnPropertyChanged();
            }
        }

        public string Title {
            get { return title; }
            set {
                title = value;
                OnPropertyChanged();
            }
        }

        public string BtnRateText {
            get { return btnRateText; }
            set {
                btnRateText = value;
                OnPropertyChanged();
            }
        }

        public string BtnRateLaterText {
            get { return btnRateLaterText; }
            set {
                btnRateLaterText = value;
                OnPropertyChanged();
            }
        }

        public string BtnCancelText {
            get { return btnCancelText; }
            set {
                btnCancelText = value;
                OnPropertyChanged();
            }
        }

        public Color BtnRateTextColor {
            get { return btnRateTextColor; }
            set {
                btnRateTextColor = value;
                OnPropertyChanged();
            }
        }

        public Color BtnRateLaterTextColor {
            get { return btnRateLaterTextColor; }
            set {
                btnRateLaterTextColor = value;
                OnPropertyChanged();
            }
        }

        public Color BtnCancelTextColor {
            get { return btnCancelTextColor; }
            set {
                btnCancelTextColor = value;
                OnPropertyChanged();
            }
        }

        public Color BtnRateColor {
            get { return btnRateColor; }
            set {
                btnRateColor = value;
                OnPropertyChanged();
            }
        }

        public Color BtnRateLaterColor {
            get { return btnRateLaterColor; }
            set {
                btnRateLaterColor = value;
                OnPropertyChanged();
            }
        }

        public Color BtnCancelColor {
            get { return btnCancelColor; }
            set {
                btnCancelColor = value;
                OnPropertyChanged();
            }
        }

        public bool IsRated {
            get { return Settings.IsRated; }
            set { 
                if (Settings.IsRated == value) {
                    return;
                }

                Settings.IsRated = value;
                OnPropertyChanged();
            }
        }

        public int UsageCount {
            get { return Settings.UsageCount; }
            set { 
                if (Settings.UsageCount == value) {
                    return;
                }

                Settings.UsageCount = value;
                OnPropertyChanged();
            }
        }

        public string VersionNumber {
            get { return Settings.VersionNumber; }
            set { 
                if (Settings.VersionNumber == value) {
                    return;
                }

                Settings.VersionNumber = value;
                OnPropertyChanged();
            }
        }

        public RatingViewViewModel()
        {
            Rate = new Command(openStore, (parameters) => true);
            Cancel = new Command(disableReminder, (parameters) => true);
            RateLater = new Command(hideReminder, (parameters) => true);

            initRatingView();
        }

        private async void initRatingView()
        {
            setDefaultValues();

            if (String.IsNullOrWhiteSpace(VersionNumber)) {
                resetReminder();
            } else if (!VersionNumber.Equals(DependencyService.Get<IInfoService>().AppVersionCode)) {
                resetReminder();
            } else {
                RatingIsAvailable = isShowTime();
                ++UsageCount;
            }
        }

        private void setDefaultValues()
        {
            RatingViewBackgroundColor = Color.White;
            Title = "Bewerten Sie unsere App";
            DetailText = "Sie nutzen unsere App gerne? Dann nehmen Sie sich bitte für eine Bewertung einen Moment Zeit! Es dauert nicht länger als eine Minute. Vielen Dank!";
            DetailTextColor = Color.Black;
            TitleColor = Color.Black;

            BtnRateText = "Jetzt bewerten";
            BtnRateTextColor = Color.Black;
            BtnRateColor = Colors.Orange;

            BtnRateLaterText = "Später bewerten";
            BtnRateLaterTextColor = Color.Black;
            BtnRateLaterColor = Colors.LightGray;

            BtnCancelText = "Nein, danke";
            BtnCancelTextColor = Color.Black;
            BtnCancelColor = Colors.LightGray;
        }

        private bool isShowTime()
        {
            return !IsRated && UsageCount >= usesBeforeRating;
        }

        private void resetReminder()
        {
            UsageCount = 1;
            VersionNumber = DependencyService.Get<IInfoService>().AppVersionCode;
            IsRated = false;
        }

        private void openStore(object parameters)
        {
            IsRated = true;
            openStore();
            RatingIsAvailable = false;
        }

        private void disableReminder(object parameters)
        {
            IsRated = true;
            RatingIsAvailable = false;
        }

        private void hideReminder(object parameters)
        {
            IsRated = false;
            RatingIsAvailable = false;
        }

        private void openStore()
        {
            var ratingservice = DependencyService.Get<IRatingService>();

            if (ratingservice == null) {
                return;
            }

            ratingservice.OpenStore();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) {
                var args = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, args);
            }
        }
    }
}
