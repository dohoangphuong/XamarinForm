using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinFormChapter.Models;

namespace XamarinFormChapter.View
{
    public partial class PageDetailReflect : ContentPage
    {
        public PageDetailReflect()
        {}

        public PageDetailReflect(Reflect fReflect, PhanAnhModel fPhanAnhModel)
        {
            Padding = new Thickness(20, 40, 20, 20);
            //Icon = "hamburger.png";
            Title = "Chi tiết phản ánh";

            Label header = new Label
            {
                Text = "CHI TIẾT PHẢN ÁNH",
                FontSize = 30,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Label lbType= new Label
            {
                FontSize = 25,
                TextColor = Color.FromHex("#ff4000"),
                FontAttributes = FontAttributes.Bold,
            };
            if (fPhanAnhModel.NguoiBao_HoTen != null)
                lbType.Text = fPhanAnhModel.TenLinhVuc.ToUpper();

            Label lbName = new Label
            {
                FontSize = 16,
                TextColor = Color.FromHex("#3297E9"),
                FontAttributes = FontAttributes.Italic,
            };
            if (fPhanAnhModel.NguoiBao_HoTen != null)
                lbName.Text = "Người phản ánh: " + fPhanAnhModel.NguoiBao_HoTen;

            Label lbAddres = new Label
            {
                FontSize = 16,
                FontAttributes = FontAttributes.Italic,
            };
            if (fPhanAnhModel.Duong != null)
            {
                lbAddres.Text = "Địa chỉ: " + fPhanAnhModel.Duong;
            }
            Label lbTitleDetail = new Label()
            {
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                Text = "Nội dung:",
                TextColor = Color.FromHex("#3297E9"),
            };

            Label lbDetail = new Label();
            if (fPhanAnhModel.NoiDungPhanAnh != null)
            {
                lbDetail.Text = fPhanAnhModel.NoiDungPhanAnh;
            }


            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    //--------------------
                    lbType,
                    lbName,
                    lbAddres,
                    lbTitleDetail,
                    lbDetail,
                }
            };
        }
    }
}
