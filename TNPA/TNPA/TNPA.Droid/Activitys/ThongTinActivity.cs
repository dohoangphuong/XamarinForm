using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Preferences;

namespace TNPA.Droid
{
    [Activity(Theme = "@style/Theme.ActionBar")]
    public class ThongTinActivity : AppCompatActivity
    {
        ISharedPreferences prefs;
        EditText txtHoTen, txtSdt, txtDiaChi, txtEmail;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
            SetContentView(Resource.Layout.thongtin);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.Title = Resources.GetString(Resource.String.caidattitle);

            txtHoTen = FindViewById<EditText>(Resource.Id.txtHoTen);
            txtSdt = FindViewById<EditText>(Resource.Id.txtSdt);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtDiaChi = FindViewById<EditText>(Resource.Id.txtDiaChi);
            Button btnGui = FindViewById<Button>(Resource.Id.btnGui);
            btnGui.Click += saveFile;

            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            txtHoTen.Text = prefs.GetString(Config.HoTen, "");
            txtSdt.Text = prefs.GetString(Config.SDT, "");
            txtDiaChi.Text = prefs.GetString(Config.DiaChi, "");
            txtEmail.Text = prefs.GetString(Config.Email, "");
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();
            return base.OnOptionsItemSelected(item);
        }
        protected override void OnPause()
        {
            base.OnPause();
            OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
        }
        private void saveFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text.Trim()) || string.IsNullOrEmpty(txtEmail.Text.Trim()) || string.IsNullOrEmpty(txtSdt.Text.Trim()) || string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                Toast.MakeText(this, Resource.String.nhapthieu, ToastLength.Short).Show();
            }
            else
            {
                // Lưu thông tin cài đặt
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString(Config.HoTen, txtHoTen.Text);
                editor.PutString(Config.SDT, txtSdt.Text);
                editor.PutString(Config.Email, txtEmail.Text);
                editor.PutString(Config.DiaChi, txtDiaChi.Text);
                editor.Commit();
                SetResult(Result.Ok, null);
                Finish();
            }
        }
    }
}