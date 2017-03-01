using System;
using System.Threading.Tasks;
using RebuyFormsRating.Models;
using Xamarin.Forms;

namespace RebuyFormsRating.Common.Services
{
    public interface IFeedbackSheet
    {
        Task<RatingViewFeedback> UseFeedbackSheet(Page page, String title, String message, String emailinvalid, String send, String cancel);
    }
}
