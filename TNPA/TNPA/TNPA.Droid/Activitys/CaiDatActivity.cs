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
using System.IO;
using Android.Preferences;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace TNPA.Droid
{
    [Activity(Label = "CaiDatActivity", Theme = "@style/Theme.ActionBar")]
    public class CaiDatActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
            SetContentView(Resource.Layout.caidat);

            var Listview = FindViewById<ListView>(Resource.Id.listaction);
            Listview.Adapter = new CaiDatAdapter(this);
            Listview.ItemClick += OnListItemClick;
        }
        
        protected override void OnPause()
        {
            base.OnPause();
            OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
        }
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = null;
            switch (Config.dictionaryAction.ElementAtOrDefault(e.Position).Key){
                case "ThongTinActivity":
                    intent = new Intent(this, typeof(ThongTinActivity));
                    break;
                case "LichSuActivity":
                    intent = new Intent(this, typeof(LichSuActivity));
                    break;
                case "TroGiupActivity":
                    intent = new Intent(this, typeof(TroGiupActivity));
                    break;
                case "ThongTinUngDungActivity":
                    intent = new Intent(this, typeof(ThongTinUngDungActivity));
                    break;
            }
            
            StartActivity(intent);
        }
    }
}