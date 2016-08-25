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
            this.Padding = new Thickness(10, Device.OnPlatform(30, 0, 0), 30, 50);
            int fMax = 70;
            Title = "Danh sách lĩnh vực";

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
                string fLinhVuc = listPhanAnhModel[i].TenLinhVuc;

                if (listPhanAnhModel[i].TenLinhVuc != null && listPhanAnhModel[i].TenLinhVuc.Length > fMax)
                {
                    fLinhVuc = listPhanAnhModel[i].TenLinhVuc.Substring(0, fMax) + "...";
                }
                if (listPhanAnhModel[i].GetImageFromDB != null)
                {
                    var imageSource = new Image();
                    imageSource.Source = listPhanAnhModel[i].GetImageFromDB;
                    listReflect.Add(new Reflect(i, "", fLinhVuc, imageSource));
                }
                else
                    listReflect.Add(new Reflect(i, "", fLinhVuc, null));
            }

            // Create the ListView.
            ListView listView = new ListView
            {
                //setting
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
                    Image imageTile = new Image();
                    imageTile.SetBinding(Image.SourceProperty, "FavoriteColor");
                    return new ViewCell
                    {
                        View = new StackLayout
                        {

                            Orientation = StackOrientation.Horizontal,
                            Children =
                                {
                              //  boxView,
                              imageTile,
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

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                   // header,
                    listView
                }
            };
        }

        async private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Reflect RelectSelect = (Reflect)e.SelectedItem;
            await Navigation.PushAsync(new PageGetListReflect(RelectSelect, listPhanAnhModel[RelectSelect.ID]));
        }
    }
}