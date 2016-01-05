using System;
using Xamarin.Forms;
using RebuyFormsRating.Models;

namespace RatingViewSample
{
    public class App : Application
    {
        public App()
        {
            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            var ratingViewHandler = new RatingViewHandler() {
                UsesBeforeRating = 2
            };
            //The parameter is only a default apple appStoreId
            ratingViewHandler.OpenRatingViewIfNeeded("100000");
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

