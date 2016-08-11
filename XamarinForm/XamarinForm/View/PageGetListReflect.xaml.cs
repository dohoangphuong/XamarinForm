using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinForm.Models;

namespace XamarinForm.View
{
    public partial class PageGetListReflect : ContentPage
    {
        public PageGetListReflect()
        {
            // InitializeComponent();
            //Padding = new Thickness(20, 40, 20, 20);
            this.Padding = new Thickness(10, Device.OnPlatform(30, 0, 0), 30, 50);
            int fMax = 30;
            var toolbarItem = new ToolbarItem
            {
                Text = "Danh sách phản ánh"
            };

            var listDist = Constants._TPhanAnhController.GetListReflect();
            Label header = new Label
            {
                Text = "DANH SÁCH PHẢN ÁNH",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Define some data.
            List<Reflect> listReflect = new List<Reflect>();
            foreach (var fdist in listDist)
            {
                string fDetail = fdist.NoiDungPhanAnh, fName= fdist.NguoiBao_HoTen;
                if (fDetail != null && fDetail.Length > fMax)
                {
                    fDetail = fdist.NoiDungPhanAnh.Substring(0, fMax) + "...";
                }
                if (fName != null && fName.Length > fMax)
                {
                    fName = fdist.NguoiBao_HoTen.Substring(0, fMax) + "...";
                }
                listReflect.Add(new Reflect(fName, fDetail, null));
            }

            // Create the ListView.
            ListView listView = new ListView
            {
                //setting
                Header = "Phản ánh",
                ItemsSource = listReflect,


                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                    {
                        // Create views with bindings for displaying each property.
                        Label lbName = new Label
                        {
                            TextColor = Color.FromHex("#3297E9"),
                            FontAttributes = FontAttributes.Bold,
                        };
                        lbName.SetBinding(Label.TextProperty, "Name");

                        Label lbDetail = new Label
                        {
                            FontAttributes = FontAttributes.Bold,
                        };
                        lbDetail.SetBinding(Label.TextProperty, "Detail");

                        BoxView boxView = new BoxView();

                        // boxView.SetBinding(Image., "FavoriteColor");                      

                        //BoxView boxView = new BoxView();
                        //boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                        // Return an assembled ViewCell.
                        return new ViewCell
                        {
                            View = new StackLayout
                            {

                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                              //  boxView,
                                new StackLayout
                                {
                                    VerticalOptions = LayoutOptions.Center,
                                    Spacing = 0,
                                    Children =
                                    {
                                        lbName,
                                        lbDetail,
                                    }
                                }
                                }
                            }
                        };
                    })
            };

            listView.ItemSelected += ListView_ItemSelected;
            listView.RowHeight = 70;
            listView.SeparatorColor = Color.Green;
            //listView.HasUnevenRows = false;

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    listView
                }
            };
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}