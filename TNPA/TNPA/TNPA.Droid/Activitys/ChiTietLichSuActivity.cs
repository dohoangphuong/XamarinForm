using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Support.V4.View;
using Android.Support.V7.App;
using TNPA.Model;
using Newtonsoft.Json;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace TNPA.Droid
{
    [Activity(Theme = "@style/Theme.ActionBar")]
    public class ChiTietLichSuActivity : AppCompatActivity
    {
        private int _position;
        private int _total;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.chitietphananh);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);

            SupportActionBar.Title = Resources.GetString(Resource.String.chitietphananh);
            var json = Intent.GetStringExtra("dsPhanAnh");
            _position = Intent.GetIntExtra("Position", 0);
            _total = Intent.GetIntExtra("totalItem", 0);

            var phanAnh = JsonConvert.DeserializeObject<List<string>>(json);
            PhanAnh[] model = new PhanAnh[_total];
            for (int i = 0; i < phanAnh.Count; i++)
            {
                model[i] = new PhanAnh() { PhanAnhKenhKhacID = phanAnh[i] };
            }
            new ChiTietPhanAnh(this, _position, model).Execute(json);
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
        private class ChiTietPhanAnh : AsyncTask<string, PhanAnh, ListResult>
        {
            private LinhVucService _service = new LinhVucService();
            private PhanAnh[] _items;
            private Activity _activity;
            private int _position;
            private ChiTietPhanAnhAdapter adapter;
            ViewPager _viewpages;
            public ChiTietPhanAnh(Activity activity, int position, PhanAnh[] items)
            {
                _activity = activity;
                _position = position;
                _items = items;
            }

            protected override void OnPreExecute()
            {
                base.OnPreExecute();
                adapter = new ChiTietPhanAnhAdapter(_activity, _items);
                _viewpages = _activity.FindViewById<ViewPager>(Resource.Id.viewPager);
                _viewpages.Adapter = adapter;
                _viewpages.CurrentItem = _position;
            }
            protected override ListResult RunInBackground(params string[] @params)
            {
                var phanAnh = JsonConvert.DeserializeObject<List<string>>(@params[0]);

                for (int i = 0; i < phanAnh.Count; i++)
                {
                    // Nếu trang hiện tại chưa có dữ liệu thì ưu tiên lấy dữ liệu trước
                    if (string.IsNullOrEmpty(_items[_viewpages.CurrentItem].NoiDungPhanAnh))
                    {
                        PublishProgress(_service.GetChiTietLichSu(phanAnh[_viewpages.CurrentItem], Config.PortalID.ToString()).Result);
                    }
                    if (string.IsNullOrEmpty(_items[i].NoiDungPhanAnh))// Kiểm tra dữ liệu đã được lấy về trước đó chưa
                        PublishProgress(_service.GetChiTietLichSu(phanAnh[i], Config.PortalID.ToString()).Result);
                }
                return new ListResult();
            }

            protected override void OnProgressUpdate(params PhanAnh[] values)
            {
                base.OnProgressUpdate(values);

                if (values != null && values[0] != null)
                {
                    int index = adapter.GetPositonByPhanAnhKenhKhac(values[0].PhanAnhKenhKhacID);
                    _items[index] = values[0];
                    if (_viewpages.CurrentItem == index)
                    {
                        adapter.NotifyDataSetChanged();
                    }
                }
            }
            protected override void OnPostExecute(ListResult result)
            {
                base.OnPostExecute(result);
                adapter.NotifyDataSetChanged();
            }
        }
    }
}