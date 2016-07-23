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

            Label lbAddres= new Label()
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
                    lbDeatail,
                    editDeatail,
                    lbAddres,
                    entAddres,
                    btnNext
                }
            };

        }
        async void btnNextClick(object sender, EventArgs e)
        {
            Constants.phanAnh = new PhanAnhModel();
            Constants.phanAnh.NoiDungPhanAnh = editDeatail.Text; ;
            Constants.phanAnh.Duong = entAddres.Text;
            
            //phanAnh.NoiDungPhanAnh = "Cháy nhà";
            //phanAnh.Duong = "Paster";
            //phanAnh.NguoiBao_Email = "hp.codoc@yahoo.com";
            //phanAnh.NguoiBao_HoTen = "Hoàng Phương";
            //phanAnh.NguoiBao_Duong = "Hàm Nghi";
            //phanAnh.PortalID = Constants.PortailID;
            //phanAnh.MaKenhTiepNhan = Constants.MaKenhTiepNhan;
            //var returnResult = Constants._TPhanAnhController.SendRequestPhanAnh(phanAnh);

            //var text = MyEntry.Text;

            await Navigation.PushAsync(new PageThongTinNguoiDung());
        }
    }
}
