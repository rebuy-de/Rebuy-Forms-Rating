using System;
using System.Threading.Tasks;
using RebuyFormsRating.Common.Services;
using RebuyFormsRating.IOS;
using RebuyFormsRating.Models;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(FeedbackSheet))]
namespace RebuyFormsRating.IOS
{
    public class FeedbackSheet : IFeedbackSheet
    {
        private TaskCompletionSource<RatingViewFeedback> tcs = null;
        private String strCancel;
        private String strSend;
        private UIAlertView dialog = null;

        public async Task<RatingViewFeedback> UseFeedbackSheet(Page page, string title, string message, string emailinvalidmessage, string send, string cancel)
        {
            if (tcs != null) {
                tcs.Task.Dispose();
            }

            tcs = new TaskCompletionSource<RatingViewFeedback>();
            strCancel = cancel;
            strSend = send;

            try {
                createDialog(title);
                if (dialog != null) {
                    dialog.Show();

                    dialog.GetTextField(0).Frame = new CoreGraphics.CGRect(0, 0, 300, 400);
                }
            } catch (Exception) {
            }

            return await tcs.Task;
        }
        private void createDialog(string title)
        {
            dialog = new UIAlertView {
                Title = title,
                AlertViewStyle = UIAlertViewStyle.PlainTextInput
            };

            dialog.GetTextField(0).Frame = new CoreGraphics.CGRect(100, 100, 300, 400);
            dialog.AddButton(strSend);
            dialog.AddButton(strCancel);

            dialog.Clicked += bv_click;
        }

        void bv_click(object sender, EventArgs e)
        {
            var bv = e as UIButtonEventArgs;
            if (bv != null) {
                var feedback = new RatingViewFeedback();
                if (bv.ButtonIndex == 0) {
                    var tv = dialog.GetTextField(0);
                    feedback.Feedback = tv?.Text;
                }

                tcs.TrySetResult(feedback);
            }
        }
    }
}
