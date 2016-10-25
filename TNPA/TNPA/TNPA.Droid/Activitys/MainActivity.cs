using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Gms.Common;
using Android.Preferences;

namespace TNPA.Droid
{
	[Activity (Icon = "@drawable/icon",Theme = "@style/Theme.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            OverridePendingTransition(Resource.Animation.trans_fade_in, Resource.Animation.trans_fade_out);
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
                StartActivity("ChartPieActivity");
            };
            btnTroGiup.Click += delegate {
                //StartActivity("CaiDatActivity");
                Intent intent = new Intent(this, typeof(TroGiupActivity));
                //intent.PutExtra("tabName", name);
                StartActivity(intent);
            };
            
            // kiểm tra google service
            if (IsPlayServicesAvailable())
            {
                var intent = new Intent(this, typeof(RegistrationIntentService));
                StartService(intent);
            }

        }
        private void StartActivity(string name)
        {
            Intent intent = new Intent(this, typeof(TabsActivity));
            intent.PutExtra("tabName", name);
            StartActivity(intent);
        }
        protected override void OnPause()
        {
            base.OnPause();
        }
        /// <summary>
        /// Kiểm tra googleplay services
        /// </summary>
        /// <returns></returns>
        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}


