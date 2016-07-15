using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace _1022_Mobile
{
    public partial class PageThemPhanAnh : ContentPage
    {
        Picker pickerDistrict;
        public PageThemPhanAnh()
        {

            Label header = new Label
            {
                Text = "NỘI DUNG PHẢN ÁNH",
                FontSize = 60,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };


            Label lbEmail = new Label()
            {
                Text = "Nội dung phản ánh (*)",
                FontSize = 20,
            };
            Editor editDeatail = new Editor
            {
                Keyboard = Keyboard.Text,
                VerticalOptions = LayoutOptions.FillAndExpand,
                FontSize = 20,
            };
           

            Entry entDiaChi = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "Nhập vị trí",
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

            pickerDistrict = new Picker
            {
                Title = "Quận",
                VerticalOptions = LayoutOptions.Center
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
            //chọn loại quận trong picker
            pickerDistrict.SelectedIndexChanged += pickerDistrictSelectedIndexChanged;
            //get listDistrict
            foreach (DM_QUAN itemlstQuan in Constants.lstDistrict)
            {
                pickerDistrict.Items.Add(itemlstQuan.TenQuan);
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
                    editDeatail,
                    entDiaChi,
                    entDuong,
                    pickerDistrict,
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
            await Navigation.PushModalAsync(new PageThongTinNguoiDung());
        }

        async void btnPreClick(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopModalAsync();
        }

        //async void btnDistrictClick(object sender, EventArgs args)
        //{
        //    TPhanAnhController _TPhanAnhController = new TPhanAnhController();
        //    List<DM_QUAN> lstQuan = _TPhanAnhController.GetQuan();
        //    foreach (DM_QUAN itemlstQuan in lstQuan)
        //    {
        //        pickerDistrict.Items.Add(itemlstQuan.TenQuan);
        //    }

        //}

        async void pickerDistrictSelectedIndexChanged(object sender, EventArgs args)
        {
            if (pickerDistrict.SelectedIndex == -1)
            {
                //entDistrict.Text = pickerDistrict.Items[0];
            }
            else
            {
                //entDistrict.Text = pickerDistrict.Items[pickerDistrict.SelectedIndex];
            }
        }
    }
}
