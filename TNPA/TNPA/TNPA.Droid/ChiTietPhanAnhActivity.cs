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
using Android.Support.V4.View;
using Java.Util.Zip;
using Android.Support.V7.App;
using TNPA.Model;
using Newtonsoft.Json;

namespace TNPA.Droid
{
    [Activity(Label = "ChiTietPhanAnhActivity", Theme = "@style/Theme.ActionBar")]
    public class ChiTietPhanAnhActivity : AppCompatActivity, ViewPager.IOnPageChangeListener
    {
        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            throw new NotImplementedException();
        }

        public void OnPageScrollStateChanged(int state)
        {
            throw new NotImplementedException();
        }

        public void OnPageSelected(int position)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.chitietphananh);
            var json = Intent.GetStringExtra("dsPhanAnh");
            var phanAnh = JsonConvert.DeserializeObject<List<PhanAnh>>(json);

            ViewPager _viewpager = FindViewById<ViewPager>(Resource.Id.viewPager);
            ChiTietPhanAnhAdapter _adapter = new ChiTietPhanAnhAdapter(this, _viewpager, phanAnh, SupportFragmentManager);
            _viewpager.Adapter = _adapter;
        }
    }
}