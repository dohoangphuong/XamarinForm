using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinForm.View
{
    public partial class PageLayAnh : ContentPage
    {
        public PageLayAnh()
        {
            Label header = new Label
            {
                Text = "HÌNH ẢNH PHẢN ÁNH",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Button btnUsingCamera = new Button
            {
                Text = "Máy Ảnh",
                FontSize = 20,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 7,
                VerticalOptions = LayoutOptions.Center
            };
            btnUsingCamera.Clicked += btnUsingCameraClick;

            Button btnOpenImage = new Button
            {
                Text = "Mở Ảnh",
                FontSize = 20,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 7,
                VerticalOptions = LayoutOptions.Center
            };
            btnOpenImage.Clicked += btnOpenImageClick;

            Image imgMyImage = new Image
            {

            };

            Button btnSave = new Button
            {
                Text = "Hoàn Tất",
                FontSize = 20,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 7,
                VerticalOptions = LayoutOptions.Center
            };
            btnSave.Clicked += btnSaveClick;

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    btnUsingCamera,
                    btnOpenImage,
                    imgMyImage,
                    btnSave
                }
            };
        }

        async void btnUsingCameraClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        async void btnOpenImageClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }

        async void btnSaveClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}
