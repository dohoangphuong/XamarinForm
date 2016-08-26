using Android;
using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinFormChapter.Models;

namespace XamarinFormChapter.View
{
    public partial class PageGetListReflect : ContentPage
    {
        List<PhanAnhModel> listPhanAnhModel=new List<PhanAnhModel>();
        public PageGetListReflect()
        {
        }
        public PageGetListReflect(Reflect fReject, DM_LINHVUC fLinhVuc)
        { 
            // InitializeComponent();
            //Padding = new Thickness(20, 40, 20, 20);
            this.Padding = new Thickness(10, Device.OnPlatform(30, 10, 0), 30, 50);
            int fMax = 30;
            Title = "Danh sách phản ánh";

            //Vẫn còn thiếu xót trong việc lọc theo lĩnh vực
            var iLinhVuc = new List<DM_LINHVUC>();
            iLinhVuc.Add(fLinhVuc);
            listPhanAnhModel = Constants._TPhanAnhController.GetListReflect(iLinhVuc);
            Label header = new Label
            {
                Text = "DANH SÁCH PHẢN ÁNH",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            string fPathImage;
            
            // Define some data.
            List<Reflect> listReflect = new List<Reflect>();
            
            for (int i = 0; i < listPhanAnhModel.Count(); i++)
            {
                string fDetail = listPhanAnhModel[i].NoiDungPhanAnh, fName = listPhanAnhModel[i].NguoiBao_HoTen;
                if (fDetail != null && fDetail.Length > fMax)
                {
                    fDetail = listPhanAnhModel[i].NoiDungPhanAnh.Substring(0, fMax) + "...";
                }
                if (fName != null && fName.Length > fMax)
                {
                    fName = listPhanAnhModel[i].NguoiBao_HoTen.Substring(0, fMax) + "...";
                }

                if(listPhanAnhModel[i].lstFileDinhKem.Count()>0)
                {
                        //imageTileRe = new Image { Aspect = Aspect.AspectFit };
                        //imageTileRe.Source = ImageSource.FromUri(new Uri("https://scontent-hkg3-1.xx.fbcdn.net/v/t1.0-9/14051607_1336980602986320_3749886989887332520_n.jpg?oh=f9d24708db3532f01ba0493cee34b3c8&oe=5840999E"));// "https://xamarin.com/content/images/pages/forms/example-app.png"));
                        if (listPhanAnhModel[i].lstFileDinhKem[0].FileName.Length > 3)
                            fPathImage = Constants.sourceImageUri + listPhanAnhModel[i].lstFileDinhKem[0].FielUrl + " / " + listPhanAnhModel[i].lstFileDinhKem[0].FileName;
                    else
                        fPathImage = "icon.png";
                }
                else
                {
                    fPathImage = "icon.png";  
                }

                listReflect.Add(new Reflect(i, fName, fDetail, null, fPathImage));
            }

            // Create the ListView.
            ListView listView = new ListView
            {
                //setting
                Header = fReject.Detail,
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

                        Image imageTile = new Image
                        {
                            Aspect = Aspect.AspectFit,
                            HeightRequest = 40,
                        };
                        imageTile.SetBinding(Image.SourceProperty, "SourceImage");                        

                        // Return an assembled ViewCell.
                        return new ViewCell
                        {
                            View = new StackLayout
                            {

                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                              imageTile,
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
                  //  header,
                    listView
                }
            };
        }

        async private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Reflect RelectSelect = (Reflect)e.SelectedItem;
            await Navigation.PushAsync(new PageDetailReflect(RelectSelect, listPhanAnhModel[RelectSelect.ID]));
        }    
    }
}
