using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinForm.Models;

namespace XamarinForm.View
{
    public partial class PageListLinhVuc : ContentPage
    {
        List<DM_LINHVUC> listPhanAnhModel = new List<DM_LINHVUC>();
        public PageListLinhVuc()
        {
            // InitializeComponent();
            //Padding = new Thickness(20, 40, 20, 20);
            this.Padding = new Thickness(10, Device.OnPlatform(30, 0, 0), 30, 50);
            int fMax = 30;
            Title = "Danh sách phản ánh";

            listPhanAnhModel = Constants._TPhanAnhController.GetListLinhVuc();
            Label header = new Label
            {
                Text = "DANH SÁCH PHẢN ÁNH",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Define some data.
            List<Reflect> listReflect = new List<Reflect>();
            for (int i = 0; i < listPhanAnhModel.Count(); i++)
            {
                string fDetail="";
                if (listPhanAnhModel[i].TenLinhVuc != null)
                {
                    fDetail = listPhanAnhModel[i].TenLinhVuc;
                }
                listReflect.Add(new Reflect(i, "123", fDetail, null));
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

        async private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Reflect RelectSelect = (Reflect)e.SelectedItem;
            //await Navigation.PushAsync(new PageDetailReflect(RelectSelect, listPhanAnhModel[RelectSelect.ID]));
        }
    }
}