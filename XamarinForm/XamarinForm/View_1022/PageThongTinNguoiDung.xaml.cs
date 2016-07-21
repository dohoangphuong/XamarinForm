using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinForm.Model;

namespace XamarinForm.View
{
    public partial class PageThongTinNguoiDung : ContentPage
    {
        Picker pickerDistrict;
        Picker pickerTown;
        public PageThongTinNguoiDung()
        {
            Label header = new Label
            {
                Text = "THÔNG TIN CÁ NHÂN",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Label lbFullName = new Label()
            {
                Text = "Nhập họ tên (*)",
                FontSize = 20,
            };

            Entry entFullName = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Nhập họ tên",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };


            Label lbEmail = new Label()
            {
                Text = "Nhập Email (*)",
                FontSize = 20,
            };

            Entry entEmail = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "Nhập Email",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Label lbAddres = new Label()
            {
                Text = "Nhập địa chỉ người dùng (*)",
                FontSize = 20,
            };

            Entry entAddres = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Nhập địa chỉ",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Button btnNext = new Button
            {
                Text = "Tiếp tục",
                FontSize = 20,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            btnNext.Clicked += btnNextClick;

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    //--------------------
                    //Màn hình nội dung phản ánh
                    lbFullName,
                    entFullName,
                    lbEmail,
                    entEmail,
                    lbAddres,
                    entAddres,
                    btnNext
                }
            };
        }
        async void btnNextClick(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new PageLayAnh());
            //Navigation.InsertPageBefore(new PageLayAnh(), this);
            //await Navigation.PopAsync();
            await Navigation.PushAsync(new PageLayAnh());
        }
    }
}