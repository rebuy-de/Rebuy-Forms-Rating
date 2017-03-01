using System;
namespace RebuyFormsRating.Models
{
    public class RatingViewFeedback
    {
        public string Feedback { get; set; }
        public string Email { get; set; }

        public RatingViewFeedback() {
            this.Feedback = string.Empty;
            this.Email = string.Empty;
        }
    }
}
