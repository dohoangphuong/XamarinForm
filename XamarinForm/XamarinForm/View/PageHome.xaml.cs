using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinForm.View
{
    public partial class PageHome : ContentPage
    {
        public PageHome()
        {
            Title = "Home Page";
            Image imageBanner = new Image
            {
                Source = "banner.jpg",
            };

            Button btnAddReflect = new Button
            {
                Text = "THÊM PHẢN ÁNH",
                FontAttributes = FontAttributes.Bold,
                FontSize = 15,
                BackgroundColor = Color.FromHex("#3297E9"),
            };
            btnAddReflect.Clicked += btnAddReflect_Clicked;

            Button btnShowReflect=new Button
            {
                Text = "TRA CỨU PHẢN ÁNH",
                FontAttributes = FontAttributes.Bold,
                FontSize = 15,
                BackgroundColor = Color.FromHex("#3297E9"),
            };
            btnShowReflect.Clicked += BtnShowReflect_Clicked;

            Button btnReport = new Button
            {
                Text = "THỐNG KÊ",
                FontAttributes = FontAttributes.Bold,
                FontSize = 15,
                BackgroundColor = Color.FromHex("#3297E9"),

            };
            btnReport.Clicked += BtnReport_Clicked;

            Button btnHelp = new Button
            {
                Text = "GIÚP ĐỠ",
                FontAttributes = FontAttributes.Bold,
                FontSize = 15,
                BackgroundColor = Color.FromHex("#3297E9"),
            };
            btnHelp.Clicked += BtnHelp_Clicked;

            Grid grid = new Grid
            {
              //  Padding = new Thickness(10, 10, 10, 20),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions=LayoutOptions.CenterAndExpand,

                RowDefinitions =//dòng
                {
                    new RowDefinition { Height = new GridLength(70, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(30, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(70, GridUnitType.Absolute) },
                },
                ColumnDefinitions =//cột
                {
                    new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute)},
                    new ColumnDefinition { Width = new GridLength(30, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) }
                }
            };

            grid.Children.Add(btnAddReflect, 0,0);
            grid.Children.Add(btnReport, 0, 2);
            grid.Children.Add(btnShowReflect, 2, 0);
            grid.Children.Add(btnHelp, 2, 2);
            grid.Children.Add(new Label(), 0, 1);
            grid.Children.Add(new Label(), 1, 0);
            grid.Children.Add(new Label(), 1, 1);
            grid.Children.Add(new Label(), 1, 2);
            grid.Children.Add(new Label(), 2, 1);
            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    imageBanner,
                    grid,
                }
            };
        }

        private async void BtnHelp_Clicked(object sender, EventArgs e)
        {
          
        }

        private async void BtnReport_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnShowReflect_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageListLinhVuc());
        }

        private async void btnAddReflect_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageThemPhanAnh());
        }
    }
}