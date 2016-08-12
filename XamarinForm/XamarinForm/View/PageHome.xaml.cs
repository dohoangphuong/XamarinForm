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
            Grid grid = new Grid
            {
                Padding = new Thickness(50, 50, 50, 70),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions=LayoutOptions.CenterAndExpand,

                RowDefinitions =//dòng
                {
                    new RowDefinition { Height = new GridLength(200, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength(200, GridUnitType.Absolute) },
                },
                ColumnDefinitions =//cột
                {
                    new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute)},
                    new ColumnDefinition { Width = new GridLength(50, GridUnitType.Absolute) },
                    new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) }
                }
            };

            grid.Children.Add(new Label
            {
                Text = "Grid",
                BackgroundColor = Color.Green,
               // FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
               // HorizontalOptions = LayoutOptions.Center
            }, 0,0);

            grid.Children.Add(new Label
            {
                Text = "Autosized cell",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            }, 0, 1);
            grid.Children.Add(new Label
            {
                Text = "1",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            }, 0, 2);

            grid.Children.Add(new BoxView
            {
                Color = Color.Silver,
                //HeightRequest = 0
            }, 1, 0);

           
         
            grid.Children.Add(new Label
            {
                Text = "Fixed 100x100",
                TextColor = Color.Aqua,
                BackgroundColor = Color.Red,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            }, 1, 1);

            grid.Children.Add(new Label
            {
                Text = "Autosized cell",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            }, 1, 2);

            grid.Children.Add(new Label
            {
                Text = "Autosized cell",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            }, 2, 0);
            grid.Children.Add(new Label
            {
                Text = "Autosized cell",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            }, 2, 1);
            grid.Children.Add(new Label
            {
                Text = "Autosized cell",
                TextColor = Color.White,
                BackgroundColor = Color.Blue
            }, 2, 2);
            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = grid;
        }
    }
}