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

[assembly: Dependency(typeof(ActionSheet))]
namespace RebuyFormsRating.Droid
{
    public class ActionSheet : IActionSheet
    {
        private TaskCompletionSource<String> tcs = null;
        private String strCancel;
        private AlertDialog dialog = null;

        public Task<String> UseActionSheet(Page p, String title, String cancel, params String[] buttons)
        {
            if (tcs != null) {
                tcs.Task.Dispose();
            }

            tcs = new TaskCompletionSource<string>();
            strCancel = cancel;

            try {
                var act = (Activity)Forms.Context;
                if (act != null) {
                    createDialog(title, cancel, buttons);
                    if (dialog != null) {
                        dialog.Show();
                    }
                }
            } catch (Exception) {
            }

            return tcs.Task;
        }

        private void createDialog(string title, string cancel, params string[] buttons)
        {
            var list = new List<string>(buttons);
            list.Add(cancel);

            var adb = new AlertDialog.Builder(Forms.Context);
            var inflater = LayoutInflater.FromContext(Forms.Context);

            if (list.Count == 2) {
                var v = inflater.Inflate(Resource.Layout.CustomAlertSheet, null);
                v.SetBackgroundColor(Color.White.ToAndroid());

                var tv = (TextView)v.FindViewById(Resource.Id.qmessage);
                if (tv != null) {
                    tv.Text = title;
                }

                var bv = (Android.Widget.Button)v.FindViewById(Resource.Id.dialogButtonLeft);
                if (bv != null) {
                    bv.Text = list[0];
                    bv.Click += bv_click;
                }

                var bv_r = (Android.Widget.Button)v.FindViewById(Resource.Id.dialogButtonRight);
                if (bv_r != null) {
                    bv_r.Text = list[1];
                    bv_r.Click += bv_click;
                }
                adb.SetView(v);
            } else {
                var v = inflater.Inflate(Resource.Layout.CustomActionSheet, null);
                v.SetBackgroundColor(Color.White.ToAndroid());

                var tv = (TextView)v.FindViewById(Resource.Id.message);
                if (tv != null) {
                    tv.Text = title;
                }

                var lv = (Android.Widget.ListView)v.FindViewById(Resource.Id.actionList);
                if (lv != null) {
                    var strAdapter = new ArrayAdapter(Forms.Context.ApplicationContext, Resource.Layout.TextViewItem, list);
                    lv.Adapter = strAdapter;
                    lv.ItemClick += lv_ItemClick;
                }

                adb.SetView(v);
            }

            adb.SetCancelable(false);

            dialog = adb.Create();
        }

        void lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var lv = sender as Android.Widget.ListView;
            if (lv != null) {
                var s = lv.GetItemAtPosition(e.Position).ToString();
                if (!String.IsNullOrEmpty(s)) {
                    dialog.Dismiss();
                    tcs.TrySetResult(s);
                }
            }
        }

        void bv_click(object sender, EventArgs e)
        {
            var bv = sender as Android.Widget.Button;
            if (bv != null) {
                var s = bv.Text;
                if (!String.IsNullOrEmpty(s)) {
                    dialog.Dismiss();
                    tcs.TrySetResult(s);
                }
            }
        }

        private void OnItemSelect(Object sender, DialogClickEventArgs e)
        {
            tcs.TrySetResult(strCancel);
            dialog.Dismiss();
        }
    }
}
