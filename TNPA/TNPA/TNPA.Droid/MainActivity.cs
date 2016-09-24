using System;

using Android.App;
using Android.Widget;
using Android.OS;

namespace TNPA.Droid
{
	[Activity (Label = "TNPA.Droid", MainLauncher = false, Icon = "@drawable/icon")]
	public class MainActivity : Activity
    {
        public static double ScreenHeight;
        public static double ScreenWidth;
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.PageHome);

			// Get our button from the layout resource,
			// and attach an event to it
			Button btnThemMoi = FindViewById<Button> (Resource.Id.btnThemMoi);
            Button btnTraCuu = FindViewById<Button>(Resource.Id.btnTraCuu);

            btnThemMoi.Click += delegate {
                //button.Text = string.Format ("{0} clicks!", count++);
                StartActivity(typeof(TabPageActivity));
            };

            btnTraCuu.Click += delegate {
                //button.Text = string.Format ("{0} clicks!", count++);
                StartActivity(typeof(ListViewActivity));
            };
        }
	}
}


