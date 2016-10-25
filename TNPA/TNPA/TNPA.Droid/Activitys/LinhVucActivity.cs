using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using TNPA.Model;
using Android.Views.Animations;
using Newtonsoft.Json;
using Android.Support.V7.App;
using Android.Support.V4.Widget;

namespace TNPA.Droid
{
    [Activity(Theme = "@style/Theme.ActionBar")]
    public class LinhVucActivity : Activity
    {
        ListView _listView;
        AsyncTask<string, DmLinhVuc, ListResult> tasks;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
            SetContentView(Resource.Layout.linhvuc);
            Title = Resources.GetString(Resource.String.tracuu);
            tasks = new getListTask(this).Execute("greg");
            _listView = FindViewById<ListView>(Resource.Id.List);
            _listView.ItemClick += OnListItemClick;
        }
        protected override void OnPause()
        {
            base.OnPause();
            OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            LinhVucAdapter adapter = (LinhVucAdapter)_listView.Adapter;
            var item = adapter[(e.Position)];

            Intent intent = new Intent(this, typeof(DanhSachPhanAnhActivity));
            var json = JsonConvert.SerializeObject(item);
            intent.PutExtra("dsLinhVuc", json);
            StartActivity(intent);
        }
        private class getListTask : AsyncTask<string, DmLinhVuc, ListResult>
        {
            private LinhVucService _service = new LinhVucService();
            private Activity _activity;
            private ListView _listView;
            private LinearLayout _layout;
            private List<DmLinhVuc> _items;
            public getListTask(Activity activity)
            {
                _activity = activity;
            }
            protected override void OnPreExecute()
            {
                base.OnPreExecute();
                _listView = _activity.FindViewById<ListView>(Resource.Id.List);
                _layout = _activity.FindViewById<LinearLayout>(Resource.Id.progressbar_view);
            }
            protected override ListResult RunInBackground(params string[] @params)
            {
                return _service.GetListLinhVuc().Result;
            }
            protected override void OnPostExecute(ListResult result)
            {
                base.OnPostExecute(result);
                _layout.Visibility = ViewStates.Invisible;
                if (result != null)
                {
                    _items = (List<DmLinhVuc>)result.ClassResult;
                    _listView.Adapter = new LinhVucAdapter(_activity, _items);
                }
                else
                {
                    Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(_activity);
                    alert.SetTitle(_activity.Resources.GetString(Resource.String.loi));
                    alert.SetMessage(_activity.Resources.GetString(Resource.String.loidata));
                    alert.SetNegativeButton(_activity.Resources.GetString(Resource.String.dongy), (senderAlert, args) =>
                    {
                        Dispose();
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();

                }
            }
        }
    }
}