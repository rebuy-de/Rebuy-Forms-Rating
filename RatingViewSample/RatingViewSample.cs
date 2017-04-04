using System;
using Xamarin.Forms;
using RebuyFormsRating.Models;
using RebuyFormsRating.Helpers;

namespace RatingViewSample
{
    public class App : Application
    {
        Label FeedbackText;

        public App()
        {
            FeedbackText = new Label {
                Text = "Welcome to Xamarin Forms Rating",
                HorizontalTextAlignment = TextAlignment.Center
            };

            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        FeedbackText
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            var ratingViewHandler = new RatingViewHandler {
                UsesBeforeRating = 1
            };
            //The parameter is the page and a default apple appStoreId
            var feedback = ratingViewHandler.OpenRatingViewIfNeeded(MainPage, "100000", false, true);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
