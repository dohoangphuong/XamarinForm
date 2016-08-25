using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinFormChapter.Models;

namespace XamarinFormChapter.View
{
    public partial class PageThemPhanAnh : ContentPage
    {
        Editor editDeatail;
        Entry entAddres;

        public PageThemPhanAnh()
        {
            Padding = new Thickness(20, 40, 20, 20);
            var toolbarItem = new ToolbarItem
            {
                Text = "Tiếp tục"
            };
            toolbarItem.Clicked += ToolbarItem_Clicked;
            ToolbarItems.Add(toolbarItem);
            //Icon = "hamburger.png";
            Title = "Thêm phản ánh";
            Label header = new Label
            {
                Text = "NỘI DUNG PHẢN ÁNH",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Label lbAddres = new Label()
            {
                Text = "Vị trí sự cố (*)",
                FontSize = 20,
            };
            entAddres = new Entry
            {
                Keyboard = Keyboard.Text,
                //Placeholder = "Nhập vị trí",
                Text = "12 Paster, Q1",
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
                //Placeholder = "Nhập nội dung phản ánh",
                Text = "Cháy nhà nè ba con cô bác",
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
                    lbAddres,
                    entAddres,
                    lbDeatail,
                    editDeatail,
                  //  btnNext
                }
            };

        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Constants.phanAnh = new PhanAnhModel();
            Constants.phanAnh.NoiDungPhanAnh = editDeatail.Text; ;
            Constants.phanAnh.Duong = entAddres.Text;
            await Navigation.PushAsync(new PageThongTinNguoiDung());
        }

        async void btnNextClick(object sender, EventArgs e)
        {
            Constants.phanAnh = new PhanAnhModel();
            Constants.phanAnh.NoiDungPhanAnh = editDeatail.Text; ;
            Constants.phanAnh.Duong = entAddres.Text;
            
            await Navigation.PushAsync(new PageThongTinNguoiDung());
        }
    }
}
