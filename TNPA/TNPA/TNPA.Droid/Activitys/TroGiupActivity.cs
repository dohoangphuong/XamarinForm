
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace TNPA.Droid
{
    [Activity(Theme = "@style/Theme.ActionBar")]
    public class TroGiupActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.trogiup);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
            // Create your application here
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.Title = Resources.GetString(Resource.String.trogiuptitle);
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
    }
}