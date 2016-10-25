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

namespace TNPA.Droid
{
    [Activity(Icon = "@drawable/icon", Theme = "@style/Theme.NoActionBar")]
    public class ThongTinUngDungActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.thongtinungdung);
            // Create your application here
        }
    }
}