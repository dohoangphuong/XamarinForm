using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using System;

namespace TNPA.Droid
{
    [Activity(Theme = "@style/Theme.ActionBar")]
    public class TabsActivity : TabActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.tabs);

           

            Title = Resources.GetString(Resource.String.app_name_full);
            CreateTab(typeof(LinhVucActivity), "LinhVucActivity", Resources.GetString(Resource.String.tracuu), Resource.Drawable.ic_tab_tracuu);
            CreateTab(typeof(PhanAnhActivity), "PhanAnhActivity", Resources.GetString(Resource.String.phananh), Resource.Drawable.ic_tab_phananh);
            CreateTab(typeof(LinhVucActivity), "sessions", Resources.GetString(Resource.String.thongke), Resource.Drawable.ic_tab_thongke);
            CreateTab(typeof(CaiDatActivity), "CaiDatActivity", Resources.GetString(Resource.String.caidat), Resource.Drawable.ic_tab_caidat);
            CreateTab(typeof(LinhVucActivity), "sessions", Resources.GetString(Resource.String.trogup), Resource.Drawable.ic_tab_trogiup);
            TabHost.SetCurrentTabByTag(Intent.Extras.GetString("tabName"));
            TabWidget.GetChildAt(TabHost.CurrentTab).SetBackgroundColor(Color.ParseColor("#1464b4"));
            TabHost.TabChanged += (object sender, TabHost.TabChangeEventArgs e) =>
            {
                var strings =TabHost.CurrentTabTag;
                for(int i =0; i< TabWidget.ChildCount; i++)
                {
                    TabWidget.GetChildAt(i).SetBackgroundColor(Color.ParseColor("#f7f7f7"));
                }
                TabWidget.GetChildAt(TabHost.CurrentTab).SetBackgroundColor(Color.ParseColor("#1464b4"));
            };
        }

        private void CreateTab(Type activityType, string tag, string label, int drawableId)
        {
            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);

            var spec = TabHost.NewTabSpec(tag);
            var drawableIcon = Resources.GetDrawable(drawableId);
            spec.SetIndicator("", drawableIcon);
            
            spec.SetContent(intent);
            
            TabHost.AddTab(spec);
        }
    }
}