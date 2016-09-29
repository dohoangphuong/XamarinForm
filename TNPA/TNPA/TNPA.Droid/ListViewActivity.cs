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
    [Activity(Label = "ListViewActivity", MainLauncher = false, Icon = "@drawable/icon")]
    public class ListViewActivity : Activity
    {
        ListView listView;
        List<TableItem> tableItems = new List<TableItem>();
        protected override void OnCreate(Bundle bundle)
        {
           
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PageTraCuu); // loads the HomeScreen.axml as this activity's view

            
            List<string> listString = new List<string>{ "Phương", "Hoàng", "Bông", "Hoa" };
            for (int i = 0; i < listString.Count(); i++)
            {
                TableItem table = new TableItem();
                table.Name = listString[i];
                table.ImageSource = "Noi dung";
                table.ImageResourceId = (int)Resource.Drawable.Icon;
                tableItems.Add(table);
            }
            listView = FindViewById<ListView>(Resource.Id.List); // get reference to the ListView in the layout
                                                                 // populate the listview with data
            listView.Adapter = new AdapterActivity(this, tableItems);
            listView.ItemClick += OnListItemClick;  // to be defined
        }
        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = tableItems[e.Position];
            Android.Widget.Toast.MakeText(this, t.Name, Android.Widget.ToastLength.Short).Show();
        }
    }
}