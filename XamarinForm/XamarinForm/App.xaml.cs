﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinForm.View;

namespace XamarinForm
{
    public partial class App : Application
    {
        //----------------------------------------------------------------------------------------------
        // MainPage = new XamarinForm.MainPage();: 1022
        // MainPage = new NavigationPage(new Page1Xaml());: Tập hợp các page có button pre ở thanh công cụ phía trên: App->Page1Xaml->Page2Xaml->Page3Xaml
        // MainPage = new PageMainMaster(); : Tập hợp các page con của MasterPage
        // 


        //----------------------------------------------------------------------------------------------

        public App()
        {
            //MainPage = new XamarinForm.View.MainPage();
            MainPage = new NavigationPage(new MainPage());

            //MainPage = new NavigationPage(new Page1Xaml());
            //MainPage = new PageMainMaster();
            //MainPage = new NavigationPage(new PageTakePhoto());
            //MainPage = new NavigationPage(new PageThemPhanAnh());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
