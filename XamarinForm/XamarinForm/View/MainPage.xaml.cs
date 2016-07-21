using Android.OS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinForm.Data;
using XamarinForm.Model;

namespace XamarinForm.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //View CreateLoginForm()
        //{
        //    var usernameEntry = new Entry { Placeholder = "Username" };
        //    var passwordEntry = new Entry
        //    {
        //        Placeholder = "Password",
        //        IsPassword = true
        //    };

        //    //var t = new StackLayout { Cch = { } };

        //    return new StackLayout
        //    {
        //        Children = {
        //            usernameEntry,
        //            passwordEntry
        //        }
        //    };
        //}


        async void OnButtonPhanAnhClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PageThemPhanAnh());
        }
    }
}
