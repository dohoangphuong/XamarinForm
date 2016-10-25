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
using Android.Support.V7.App;
using System.Threading.Tasks;

namespace TNPA.Droid
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
    public class SplashActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }
        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() =>
            {
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                Task.Delay(1000).Wait(); // Simulate a bit of startup work.
            });

            startupWork.Start();
        }
    }
}