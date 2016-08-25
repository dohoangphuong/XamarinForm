using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinForm.Models;

namespace XamarinForm.View
{
    public partial class PageThongTinNguoiDung : ContentPage
    {
        Label lbMessageError;
        Entry entFullName;
        Entry entEmail;
        Entry entPhone;

        public PageThongTinNguoiDung()
        {
            Padding = new Thickness(20, 40, 20, 20);
            //Icon = "hamburger.png";
            Title = "Thông tin người dùng";
            var toolbarItem = new ToolbarItem
            {
                Text = "Tiếp tục"
            };
            toolbarItem.Clicked += ToolbarItem_Clicked;
            ToolbarItems.Add(toolbarItem);

            Label header = new Label
            {
                Text = "THÔNG TIN CÁ NHÂN",
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
                //Placeholder = "Nhập họ tên",
                Text="Hoàng Phương",
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
                //Placeholder = "Nhập Email",
                Text="hp@gmail.com",
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
                //Placeholder = "Nhập số điện thoại",
                Text="0123456789",
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
                    lbMessageError,
                    lbFullName,
                    entFullName,
                    lbEmail,
                    entEmail,
                    lbPhone,
                    entPhone,
                  //  btnNext
                }
            };
        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new PageLayAnh());
            //Navigation.InsertPageBefore(new PageLayAnh(), this);
            //await Navigation.PopAsync();
            if (entEmail.Text == null || entFullName.Text == null || entPhone.Text == null)
            {
                lbMessageError.Text = "* Vui lòng nhập đầy đủ";
            }
            else
            {
                if (entEmail.Text.Trim() == "" || entFullName.Text.Trim() == "" || entPhone.Text.Trim() == "")
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

                    await Navigation.PushAsync(new PageLayAnh());
                }
            }
        }

        async void btnNextClick(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new PageLayAnh());
            //Navigation.InsertPageBefore(new PageLayAnh(), this);
            //await Navigation.PopAsync();
            if (entEmail.Text == null || entFullName.Text == null || entPhone.Text == null)
            {
                lbMessageError.Text = "* Vui lòng nhập đầy đủ";
            }
            else
            {
                if (entEmail.Text.Trim() == "" || entFullName.Text.Trim() == "" || entPhone.Text.Trim() == "")
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
                   
                    await Navigation.PushAsync(new PageLayAnh());
                }
            }
        }
    }
}