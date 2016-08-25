using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinFormChapter.View;

namespace XamarinFormChapter
{
    public partial class App : Application
    {
        //----------------------------------------------------------------------------------------------
        // MainPage = new XamarinFormChapter.MainPage();: 1022
        // MainPage = new NavigationPage(new Page1Xaml());: Tập hợp các page có button pre ở thanh công cụ phía trên: App->Page1Xaml->Page2Xaml->Page3Xaml
        // MainPage = new PageMainMaster(); : Tập hợp các page con của MasterPage
        // MainPage = new NavigationPage(new PageTestTable()): Các page table tap
        // MainPage = new NavigationPage(new PageHome()): Page home của 1022

        //----------------------------------------------------------------------------------------------

        public App()
        {
            //MainPage = new XamarinFormChapter.View.MainPage();
            MainPage = new NavigationPage(new PageHome());
            // MainPage = new NavigationPage(new PageGetListReflect());
            //MainPage = new NavigationPage(new Page1Xaml());
            //MainPage = new PageMainMaster();
            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new PageTestTable());
            //MainPage = new NavigationPage(new PageLayAnh());
            // MainPage = new NavigationPage(new PageListLinhVuc());
            //MainPage = new NavigationPage(new PageListLinhVuc());
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
