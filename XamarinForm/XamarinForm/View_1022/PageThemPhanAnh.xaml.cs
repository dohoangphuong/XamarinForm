using Android.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinForm.Model;

namespace XamarinForm.View
{
    public partial class PageThemPhanAnh : ContentPage
    {
        Label lbMessageError;
        Entry entFullName;
        Entry entEmail;
        Entry entPhone;
        Editor editDeatail;
        Entry entAddres;

        public PageThemPhanAnh()
        {
            Padding = new Thickness(20, 40, 20, 20);
            //Icon = "hamburger.png";
            Title = "Thêm phản ánh";
            Label header = new Label
            {
                Text = "NỘI DUNG PHẢN ÁNH",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            lbMessageError = new Label()
            {
                FontSize = 20,
                TextColor = Color.Red,
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
            
            Label lbAddres = new Label()
            {
                Text = "Vị trí sự cố (*)",
                FontSize = 20,
            };
            entAddres = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Nhập vị trí",
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };

            Label lbDeatail = new Label()
            {
                Text = "Nội dung phản ánh (*)",
                FontSize = 20,
            };
            editDeatail = new Editor
            {
                Keyboard = Keyboard.Text,
                VerticalOptions = LayoutOptions.FillAndExpand,
                FontSize = 20,
            };



            Button btnNext = new Button
            {
                Text = "Tiếp tục",
                FontSize = 20,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                //BorderWidth = 1,
                //HorizontalOptions = LayoutOptions.Center,
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
                    lbMessageError,
                    lbFullName,
                    entFullName,
                    lbEmail,
                    entEmail,
                    lbPhone,
                    entPhone,
                    //--------------------
                    //Màn hình nội dung phản ánh
                    lbAddres,
                    entAddres,
                    lbDeatail,
                    editDeatail,
                    btnNext
                }
            };

        }
        async void btnNextClick(object sender, EventArgs e)
        {
            if (entEmail.Text == null || entFullName.Text == null || entPhone.Text == null || editDeatail.Text == null || entAddres.Text == null)
            {
                lbMessageError.Text = "* Vui lòng nhập đầy đủ";
            }
            else
            {
                if (entEmail.Text.Trim() == "" || entFullName.Text.Trim() == "" || entPhone.Text.Trim() == "" || editDeatail.Text.Trim() == "" || entAddres.Text.Trim() == "")
                {
                    lbMessageError.Text = "* Vui lòng nhập đầy đủ";
                }
                else
                {
                    lbMessageError.Text = "";
                    Constants.phanAnh.NguoiBao_Email = entEmail.Text;
                    Constants.phanAnh.NguoiBao_HoTen = entFullName.Text;
                    Constants.phanAnh.NguoiBao_DienThoai = entPhone.Text;
                    Constants.phanAnh.PortalID = Constants.PortailID;
                    Constants.phanAnh.MaKenhTiepNhan = Constants.MaKenhTiepNhan;
                    //Nội dung phản ánh
                    Constants.phanAnh.NoiDungPhanAnh = editDeatail.Text; ;
                    Constants.phanAnh.Duong = entAddres.Text;

                    await Navigation.PushAsync(new PageTakePhoto());
                }
            }
        }
    }
}