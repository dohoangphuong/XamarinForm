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

namespace TNPA.Droid
{
    [Activity(Label = "CaiDatActivity")]
    public class CaiDatActivity : Activity
    {
        ISharedPreferences prefs;
        EditText txtHoTen, txtSdt, txtDiaChi;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
            SetContentView(Resource.Layout.caidat);
            txtHoTen = FindViewById<EditText>(Resource.Id.txtHoTen);
            txtSdt = FindViewById<EditText>(Resource.Id.txtSdt);
            txtDiaChi = FindViewById<EditText>(Resource.Id.txtDiaChi);
            Button btnGui = FindViewById<Button>(Resource.Id.btnGui);
            btnGui.Click += saveFile;

            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            txtHoTen.Text = prefs.GetString("hoten", "");
            txtSdt.Text = prefs.GetString("sdt", "");
            txtDiaChi.Text = prefs.GetString("diachi", "");
        }
        protected override void OnPause()
        {
            base.OnPause();
            OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
        }
        private void saveFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text.Trim()) || string.IsNullOrEmpty(txtSdt.Text.Trim()) || string.IsNullOrEmpty(txtDiaChi.Text.Trim()))
            {
                Toast.MakeText(this, Resource.String.nhapthieu, ToastLength.Short).Show();
            }
            else
            {
                ISharedPreferencesEditor editor = prefs.Edit();
                editor.PutString("hoten", txtHoTen.Text);
                editor.PutString("sdt", txtSdt.Text);
                editor.PutString("diachi", txtDiaChi.Text);
                editor.Commit();
                SetResult(Result.Ok, null);
                Finish();
            }
        }
    }
}