using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Toolbar = Android.Support.V7.Widget.Toolbar;
namespace TNPA.Droid
{
	[Activity (MainLauncher = false, Icon = "@drawable/icon",Theme = "@style/Theme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            SetContentView (Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            Button btnThemMoi = FindViewById<Button> (Resource.Id.btnThemMoi);
            Button btnCaiDat = FindViewById<Button>(Resource.Id.btnCaiDat);
            Button btnTraCuu = FindViewById<Button>(Resource.Id.btnTraCuu);
            Button btnThongKe = FindViewById<Button>(Resource.Id.btnThongKe);
            Button btnTroGiup = FindViewById<Button>(Resource.Id.btnTroGiup);
            btnThemMoi.Click += delegate {
                StartActivity("PhanAnhActivity");
            };
            btnCaiDat.Click += delegate {
                StartActivity("CaiDatActivity");
            };
            btnTraCuu.Click += delegate {
                StartActivity("LinhVucActivity");
            };
            btnThongKe.Click += delegate {
                StartActivity("PhanAnhActivity");
            };
            btnTroGiup.Click += delegate {
                StartActivity("CaiDatActivity");
            };
        }
        private void StartActivity(string name)
        {
            Intent intent = new Intent(this, typeof(TabsActivity));
            intent.PutExtra("tabName", name);
            StartActivity(intent);
        }
	}
}


