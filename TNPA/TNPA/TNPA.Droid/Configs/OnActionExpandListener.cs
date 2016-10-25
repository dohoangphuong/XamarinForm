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
using Android.Support.V4.View;

namespace TNPA.Droid
{
    public class OnActionExpandListener : Java.Lang.Object, MenuItemCompat.IOnActionExpandListener
    {

        public class MenuItemEventArg : EventArgs
        {
            public IMenuItem MenuItem { get; set; }
            public bool Handled { get; set; }

            public MenuItemEventArg()
            {
                Handled = false;
            }
        }
        public delegate void MenuItemEventHandler(object sender, MenuItemEventArg e);

        public event MenuItemEventHandler MenuItemCollaspe;
        public event MenuItemEventHandler MenuItemActionExpand;

        public bool OnMenuItemActionCollapse(IMenuItem item)
        {
            if (MenuItemCollaspe != null)
            {
                MenuItemEventArg e = new MenuItemEventArg();
                e.MenuItem = item;
                MenuItemCollaspe(this, e);
                return e.Handled;
            }
            return true;
        }

        public bool OnMenuItemActionExpand(IMenuItem item)
        {
            if (MenuItemActionExpand != null)
            {
                MenuItemEventArg e = new MenuItemEventArg();
                e.MenuItem = item;
                MenuItemActionExpand(this, e);
                return e.Handled;
            }
            return true;
        }
    }
}