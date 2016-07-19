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
                Text = "LẤY ẢNH",
                FontSize = 60,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Button btnUsingCamera = new Button
            {
                Text = "Máy Ảnh",
                FontSize = 20,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            btnUsingCamera.Clicked += btnUsingCameraClick;

            Button btnOpenImage = new Button
            {
                Text = "Mở Ảnh",
                FontSize = 20,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
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
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
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

        async void btnPreClick(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new PageThongTinNguoiDung(), this);
            await Navigation.PopModalAsync();
        }
    }
}
