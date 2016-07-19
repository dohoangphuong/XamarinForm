using Android.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinForm.Data;
using XamarinForm.Model;

namespace XamarinForm.View
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            
            
        }

        View CreateLoginForm()
        {
            var usernameEntry = new Entry { Placeholder = "Username" };
            var passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true
            };

            //var t = new StackLayout { Cch = { } };

            return new StackLayout
            {
                Children = {
                    usernameEntry,
                    passwordEntry
                }
            };
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            count++;
            ((Button)sender).Text =
                String.Format("{0} click{1}!", count, count == 1 ? "" : "s");
           

            TPhanAnhController _TPhanAnhController = new TPhanAnhController();
            List<DM_QUAN> lstQuan = _TPhanAnhController.GetQuan();
            Constants.lstDistrict = lstQuan;
        }

        async void OnButtonPhanAnhClicked(object sender, EventArgs args)
        {
            Button btn = (Button)sender;
            if(btn.ClassId == "btnThemPhanAnh")
            {
                Constants.lstDistrict = null;
                Constants.lstDistrict = (List <DM_QUAN> )Constants._TPhanAnhController.GetQuan();
                await Navigation.PushAsync(new PageThemPhanAnh());
            }
            if (btn.ClassId == "btnDanhSach")
            {
                await Navigation.PushModalAsync(new DanhSachPage());
            }
           
        }

        /// <summary>
        /// Nhấn vào item trên ListView
        /// </summary>
        /// gán DM_QUAN quan = (DM_QUAN)e.Item; cái này nhận được khi nhấn
        /// <param name="sender"></param>
        /// <param name="e">Khi tác động vào bản sẽ trả về</param>
        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            Debug.WriteLine("Tapped: " + e.Item);
            DM_QUAN quan = (DM_QUAN)e.Item;
            Debug.WriteLine("Tapped item: " + quan.QuanID + " - " + quan.TenQuan);
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

    }
}
