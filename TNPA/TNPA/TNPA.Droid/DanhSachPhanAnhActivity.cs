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
using Newtonsoft.Json;
using TNPA.Model;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;

namespace TNPA.Droid
{
    [Activity(Theme = "@style/Theme.ActionBar")]
    public class DanhSachPhanAnhActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.phananh);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
            
            var json = Intent.GetStringExtra("dsLinhVuc");
            var linhvuc = JsonConvert.DeserializeObject<DmLinhVuc>(json);
            SupportActionBar.Title = linhvuc.TenLinhVuc;
            new getListTask(this).Execute(linhvuc);
        }
        protected override void OnPause()
        {
            base.OnPause();
            OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }
        private class getListTask : AsyncTask<DmLinhVuc, DmLinhVuc, ListResult>
        {
            private LinhVucService _service = new LinhVucService();
            private Activity _activity;
            private ListView _listView;
            private LinearLayout _layout;
            private List<PhanAnh> _items;
            private DmLinhVuc linhvuc;
            private int pageIndex = 1;
            private int totalItem = 0;
            private int pageSize = 5;
            private PhanhAnhAdapter adapter;
            public getListTask(Activity activity)
            {
                _activity = activity;
            }
            protected override void OnPreExecute()
            {
                base.OnPreExecute();
                _listView = _activity.FindViewById<ListView>(Resource.Id.List);
                _layout = _activity.FindViewById<LinearLayout>(Resource.Id.progressbar_view);
                _listView.ItemClick += OnListItemClick;
                
                _listView.ScrollStateChanged += (o, e) =>
                {
                    if(e.ScrollState == ScrollState.Idle)
                    {
                        if (_listView.LastVisiblePosition >= _items.Count - 2 && totalItem > _items.Count)
                        {
                            pageIndex += 1;
                            loadmore();
                        }
                    }
                };
            }
            protected override ListResult RunInBackground(params DmLinhVuc[] @params)
            {
                List<DmLinhVuc> list = new List<DmLinhVuc>();
                linhvuc = @params[0];
                list.Add(linhvuc);
                return _service.GetListPhanAnhByLinhVuc(list, pageIndex, pageSize).Result;
            }
            protected override void OnPostExecute(ListResult result)
            {
                base.OnPostExecute(result);
                _layout.Visibility = ViewStates.Invisible;
                _items = (List<PhanAnh>)result.ClassResult;
                totalItem = result.PagingResult.TotalCount;
                adapter = new PhanhAnhAdapter(_activity, _items);
                _listView.SetAdapter(adapter);
            }
            private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                
                Intent intent = new Intent(_activity, typeof(ChiTietPhanAnhActivity));
                var json = JsonConvert.SerializeObject(_items);
                intent.PutExtra("dsPhanAnh", json);
                _activity.StartActivity(intent);
            }
            private async void loadmore()
            {
                List<DmLinhVuc> list = new List<DmLinhVuc>();
                list.Add(linhvuc);
                var result = await _service.GetListPhanAnhByLinhVuc(list, pageIndex, pageSize);
                int position = _items.Count - 1;
                _items.AddRange((List<PhanAnh>)result.ClassResult);
                adapter.NotifyDataSetChanged();
                //_listView.SetAdapter(new PhanhAnhAdapter(_activity, _items));
            }
        }
    }
}