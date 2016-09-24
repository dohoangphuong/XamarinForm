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
    [Activity(Label = "ListViewActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public class ListViewActivity : Activity
    {
        ListView listView;
        List<TableItem> tableItems = new List<TableItem>();
        protected override void OnCreate(Bundle bundle)
        {
           
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PageTraCuu); // loads the HomeScreen.axml as this activity's view

            TableItem table = new TableItem();
            table.Heading = "Phuong";
            table.SubHeading = "Noi dung";
            table.ImageResourceId = (int)Resource.Drawable.logo;
            tableItems.Add(table);
            listView = FindViewById<ListView>(Resource.Id.List); // get reference to the ListView in the layout
                                                                 // populate the listview with data
            listView.Adapter = new AdapterActivity(this, tableItems);
            listView.ItemClick += OnListItemClick;  // to be defined
        }
        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var t = tableItems[e.Position];
            Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
        }
    }
}