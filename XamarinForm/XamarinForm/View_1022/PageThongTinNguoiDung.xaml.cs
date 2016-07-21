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
        Entry entFullName;
        Entry entEmail;
        Entry entPhone;

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
                Text = "Họ tên (*)",
                FontSize = 20,
            };

            entFullName = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Nhập họ tên",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };


            Label lbEmail = new Label()
            {
                Text = "Email (*)",
                FontSize = 20,
            };

            entEmail = new Entry
            {
                Keyboard = Keyboard.Email,
                Placeholder = "Nhập Email",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Label lbPhone = new Label()
            {
                Text = "Số điện thoại (*)",
                FontSize = 20,
            };

            entPhone = new Entry
            {
                Keyboard = Keyboard.Telephone,
                Placeholder = "Nhập số điện thoại",
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
                    lbPhone,
                    entPhone,
                    btnNext
                }
            };
        }
        async void btnNextClick(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new PageLayAnh());
            //Navigation.InsertPageBefore(new PageLayAnh(), this);
            //await Navigation.PopAsync();

            Constants.phanAnh.NguoiBao_Email = entEmail.Text;
            Constants.phanAnh.NguoiBao_HoTen = entFullName.Text;
            Constants.phanAnh.NguoiBao_DienThoai = entPhone.Text;
            Constants.phanAnh.PortalID = Constants.PortailID;
            Constants.phanAnh.MaKenhTiepNhan = Constants.MaKenhTiepNhan;
            var returnResult = Constants._TPhanAnhController.SendRequestPhanAnh(Constants.phanAnh);
            Constants.phanAnh = new PhanAnhModel();
            await Navigation.PushAsync(new PageLayAnh());
        }
    }
}