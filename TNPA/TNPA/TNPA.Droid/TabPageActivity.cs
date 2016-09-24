using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TNPA.Droid
{
    //[Activity (Label = "HelloTabsICS", MainLauncher = true)]
    [Activity(Label = "TabPageActivity")]
    public class TabPageActivity : Activity
    {
        private static TabPageActivity instance;
        public static TabPageActivity Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TabPageActivity();
                }
                return instance;
            }
        }
        
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.PageMainTab);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            AddTab("GÓP Ý", Resource.Drawable.gopy, new TabFragment(Resource.Layout.PageGopy));
            AddTab("TRA CỨU", Resource.Drawable.tracuu, new TabFragment(Resource.Layout.PageTraCuu));
            AddTab("THỐNG KÊ", Resource.Drawable.thongke, new TabFragment(Resource.Layout.PageThongKe));

            if (bundle != null)
                this.ActionBar.SelectTab(this.ActionBar.GetTabAt(bundle.GetInt("tab")));            
        }
     

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

            base.OnSaveInstanceState(outState);
        }
        
        void AddTab (string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab ();
            tab.SetCustomView(Resource.Layout.PageTab);
            tab.CustomView.FindViewById<ImageView>(Resource.Id.tab_icon).SetImageResource(iconResourceId);
            tab.CustomView.FindViewById<TextView>(Resource.Id.tab_text).Text = tabText;

            //tab.SetText(tabText);
            //tab.SetIcon (iconResourceId);


            // must set event handler before adding tab
            tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                    e.FragmentTransaction.Remove(fragment);         
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };
            tab.TabUnselected += delegate(object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Remove(view);
            };
            
            this.ActionBar.AddTab (tab);
        }
        
        class TabFragment : Fragment
        {
            int PageView;
            public TabFragment(int fPageView)
            {
                PageView = fPageView;
            }
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);
                var view = inflater.Inflate(PageView, container, false);

                return view;
            }
        }
    }
}


