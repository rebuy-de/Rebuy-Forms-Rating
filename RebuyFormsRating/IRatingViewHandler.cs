using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RebuyFormsRating
{
    public interface IRatingViewHandler
    {
        bool IsRated { set; get; }

        int UsesBeforeRating { set; get; }

        int UsageCount { set; get; }

        string VersionNumber { set; get; }

        string RatingMessage { set; get; }

        string RateLaterMessage { set; get; }

        string RateNowMessage { set; get; }

        string DisturbMessage { set; get; }

        Task OpenRatingViewIfNeeded(Page page, string appStoreId, bool ignoreUsageCount = false);
    }
}
