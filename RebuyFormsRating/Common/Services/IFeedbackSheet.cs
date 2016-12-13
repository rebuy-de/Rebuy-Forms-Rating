using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RebuyFormsRating.Common.Services
{
    public interface IFeedbackSheet
    {
        Task<String> UseFeedbackSheet(Page page, String title, String message, String send, String cancel);
    }
}
