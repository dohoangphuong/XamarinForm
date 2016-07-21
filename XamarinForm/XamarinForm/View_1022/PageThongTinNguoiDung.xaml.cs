using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinForm.Views
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

            pickerDistrict = new Picker
            {
                Title = "Vui lòng chọn quận",
                VerticalOptions = LayoutOptions.Center
            };

            pickerTown = new Picker
            {
                Title = "Vui lòng chọn phường",
                VerticalOptions = LayoutOptions.Center,
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
            //chọn loại quận trong picker
            pickerDistrict.SelectedIndexChanged += pickerDistrictSelectedIndexChanged;
            //chọn loại phường trong picker
            pickerTown.SelectedIndexChanged += pickerTownSelectedIndexChanged;
            //get listDistrict
            if (Constants.lstDistrict.Count > 0)
            {
                foreach (DM_QUAN itemlstQuan in Constants.lstDistrict)
                {
                    pickerDistrict.Items.Add(itemlstQuan.TenQuan);
                }
            }
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
                    pickerDistrict,
                    pickerTown,
                    btnTiepTuc
                }
            };
        }
        async void btnTiepTucClick(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new PageLayAnh());
            //Navigation.InsertPageBefore(new PageLayAnh(), this);
            //await Navigation.PopAsync();
            await Navigation.PushAsync(new PageLayAnh());
        }
        async void pickerDistrictSelectedIndexChanged(object sender, EventArgs args)
        {
            if (pickerDistrict.SelectedIndex == -1)
            {
                pickerDistrict.SelectedIndex = 0;
                //entDistrict.Text = pickerDistrict.Items[0];
            }
            else
            {
                //entDistrict.Text = pickerDistrict.Items[pickerDistrict.SelectedIndex];
            }

            Constants.lstTown = null;
            //get list town is id of district
            Constants.lstTown = Constants._TPhanAnhController.GetTown(Constants.lstDistrict[pickerDistrict.SelectedIndex].QuanID);
        }

        async void pickerTownSelectedIndexChanged(object sender, EventArgs args)
        {
            if (pickerTown.SelectedIndex == -1)
            {
                pickerTown.SelectedIndex = 0;
                //entDistrict.Text = pickerDistrict.Items[0];
            }
            else
            {
                //entDistrict.Text = pickerDistrict.Items[pickerDistrict.SelectedIndex];
            }
        }
    }
}