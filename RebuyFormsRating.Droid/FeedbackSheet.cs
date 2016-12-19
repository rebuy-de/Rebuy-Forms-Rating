using System;
using Xamarin.Forms;
using RebuyFormsRating.Droid;
using System.Threading.Tasks;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using System.Collections.Generic;
using RebuyFormsRating.Common.Services;

[assembly: Dependency(typeof(FeedbackSheet))]
namespace RebuyFormsRating.Droid
{
    public class FeedbackSheet : IFeedbackSheet
    {
        private TaskCompletionSource<String> tcs = null;
        private String strCancel;
        private String strSend;
        private AlertDialog dialog = null;
        private Android.Views.View customFeedbackSheet = null;

        public Task<String> UseFeedbackSheet(Page page, String title, String message, String send, String cancel)
        {
            if (tcs != null) {
                tcs.Task.Dispose();
            }

            tcs = new TaskCompletionSource<string>();
            strCancel = cancel;
            strSend = send;

            try {
                var act = (Activity)Forms.Context;
                if (act != null) {
                    createDialog(title, message);
                    if (dialog != null) {
                        dialog.Show();
                    }
                }
            } catch (Exception) {
            }

            return tcs.Task;
        }


        private void createDialog(string title, string message)
        {
            var adb = new AlertDialog.Builder(Forms.Context);
            var inflater = LayoutInflater.FromContext(Forms.Context);

            customFeedbackSheet = inflater.Inflate(Resource.Layout.CustomFeedbackSheet, null);
            customFeedbackSheet.SetBackgroundColor(Color.White.ToAndroid());

            var tv = (TextView)customFeedbackSheet.FindViewById(Resource.Id.feedbackTitle);
            if (tv != null) {
                tv.Text = title;
            }

            var tt = (TextView)customFeedbackSheet.FindViewById(Resource.Id.feedbackMessage);
            if (tt != null) {
                tt.Text = message;
            }

            var bv = (Android.Widget.Button)customFeedbackSheet.FindViewById(Resource.Id.feedbackDialogButtonSend);
            if (bv != null) {
                bv.Text = strSend;
                bv.Click += bv_click;
            }

            var bv_r = (Android.Widget.Button)customFeedbackSheet.FindViewById(Resource.Id.feedbackDialogButtonCancel);
            if (bv_r != null) {
                bv_r.Text = strCancel;
                bv_r.Click += bv_click;
            }
            adb.SetView(customFeedbackSheet);


            adb.SetCancelable(false);

            dialog = adb.Create();
        }

        void bv_click(object sender, EventArgs e)
        {
            var bv = sender as Android.Widget.Button;
            if (bv != null) {
                var s = bv.Text;
                if (String.Equals(s, strSend)) {
                    var tv = (EditText)customFeedbackSheet?.FindViewById(Resource.Id.feedbackText);

                    tcs.TrySetResult(tv?.EditableText.ToString());
                }
                dialog.Dismiss();
            }
        }
    }
}
