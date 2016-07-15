using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace _1022_Mobile
{
    public partial class PageThongTinNguoiDung : ContentPage
    {
        public PageThongTinNguoiDung()
        {

            Label header = new Label
            {
                Text = "THÔNG TIN CÁ NHÂN",
                FontSize = 60,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };


            Label lbEmail = new Label()
            {
                Text = "Email (*)",
                FontSize = 20,
            };
            Entry entEmail = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "Nhập Email",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Entry entHoTen = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Nhập họ tên",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Entry entDiaChi = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Nhập địa chỉ",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Entry entDuong = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Nhập đường",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Entry entQuan = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Vui lòng chọn quận ",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };
            Entry entPhuong = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Vui lòng chọn phường",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Button btnTiepTuc = new Button
            {
                Text = "Tiếp tục",
                FontSize = 20,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            btnTiepTuc.Clicked += btnTiepTucClick;

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    //--------------------
                    //Màn hình nội dung phản ánh
                    lbEmail,
                    entEmail,
                    entHoTen,
                    entDiaChi,
                    entDuong,
                    entQuan,
                    entPhuong,
                    btnTiepTuc
                }
            };
        }
        async void btnTiepTucClick(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new PageLayAnh());
            //Navigation.InsertPageBefore(new PageLayAnh(), this);
            //await Navigation.PopAsync();
            await Navigation.PushModalAsync(new PageLayAnh());
        }

        async void btnPreClick(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new PageThemPhanAnh(), this);
            await Navigation.PopModalAsync();
        }
    }
}