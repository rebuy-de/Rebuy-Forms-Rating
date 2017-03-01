using System;
using RebuyFormsRating.Enums;
using Xamarin.Forms;

namespace RebuyFormsRating.Models
{
    public class RatingViewResponse
    {
        public string Version { set; get; }
        public string FeedbackText { set; get; }
        public string Platform { set; get; }
        public string UserEmail { set; get; }
        public RatingViewButtonTypes ButtonClicked { set; get; }

        public RatingViewResponse(string version) {
            Version = version;
            Platform = Device.OnPlatform("iOS", "Android", "Windows");
            ButtonClicked = RatingViewButtonTypes.none;
            FeedbackText = string.Empty;
        }
    }
}
