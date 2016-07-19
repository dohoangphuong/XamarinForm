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
        Picker pickerDistrict;
        Picker pickerTown;
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
                //FontSize = 20,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                //BorderWidth = 1,
                //HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.CenterAndExpand
            };

            btnTiepTuc.Clicked += btnTiepTucClick;
            //chọn loại quận trong picker
            pickerDistrict.SelectedIndexChanged += pickerDistrictSelectedIndexChanged;
            //chọn loại phường trong picker
            pickerTown.SelectedIndexChanged += pickerTownSelectedIndexChanged;

            //get listDistrict
            if (Constants.lstDistrict.Count > 0)
            {
                foreach (DM_QUAN itemlstDistrict in Constants.lstDistrict)
                {
                    pickerDistrict.Items.Add(itemlstDistrict.TenQuan);
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
                    editDeatail,
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
            await Navigation.PushAsync(new PageThongTinNguoiDung());
        }
        
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

            Constants.lstTown = null;
            Constants.lstTown = Constants._TPhanAnhController.GetTown(Constants.lstDistrict[pickerDistrict.SelectedIndex].QuanID);

            //get listTown

            Log.Warn("aaaaaaaaaaaaaaaaaaaaaaaaaaaa", Constants.lstTown.Count.ToString());
            if (Constants.lstTown.Count > 0)
            {
                foreach (DM_PHUONG itemlstTown in Constants.lstTown)
                {
                    pickerDistrict.Items.Add(itemlstTown.TenPhuong);
                }
            }


        }

        async void pickerTownSelectedIndexChanged(object sender, EventArgs args)
        {
            if (pickerTown.SelectedIndex == -1)
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
