using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinForm.Data;
using XamarinForm.Model;

namespace XamarinForm
{
    public partial class PagePickerDatabase : ContentPage
    {
        //-------------------------------------------------------------------------------
        //Picker
        //-------------------------------------------------------------------------------
        Button btnDistrict;
        Picker pickerDistrict;
        Entry entDistrict;

        public PagePickerDatabase()
        {

            btnDistrict = new Button
            {
                Text = "Quan",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            //Picker
            Label header = new Label
            {
                Text = "Picker",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            //----------------------------------------------------------------------------
            //Chu y
            //----------------------------------------------------------------------------
            //HorizontalOptions: Theo chiều X
            //VerticalOptions: Theo chiều Y

            pickerDistrict = new Picker
            {
                Title = "Quận",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            entDistrict = new Entry
            {
                Keyboard = Keyboard.Text,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            //chọn loại quận trong picker
            pickerDistrict.SelectedIndexChanged += pickerDistrictSelectedIndexChanged;
            //get listDistrict
            btnDistrict.Clicked += btnDistrictClick;

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    btnDistrict,
                    entDistrict,
                    pickerDistrict,
                }
            };

        }

        //-------------------------------------------------------------------------------
        ////Picker
        ////-------------------------------------------------------------------------------
        View CreateLoginForm()
        {
            var usernameEntry = new Entry { Placeholder = "Username" };
            var passwordEntry = new Entry
            {
                Placeholder = "Password",
                IsPassword = true
            };
            

            return new StackLayout
            {
                Children = {
                    usernameEntry,
                    passwordEntry
                }
            };
        }

        async void btnDistrictClick(object sender, EventArgs args)
        {
            TPhanAnhController _TPhanAnhController = new TPhanAnhController();
            List<DM_QUAN> lstQuan = _TPhanAnhController.GetQuan();
            foreach (DM_QUAN itemlstQuan in lstQuan)
            {
                pickerDistrict.Items.Add(itemlstQuan.TenQuan);
            }

        }

        async void pickerDistrictSelectedIndexChanged(object sender, EventArgs args)
        {
            if (pickerDistrict.SelectedIndex == -1)
            {
                entDistrict.Text = pickerDistrict.Items[0];
            }
            else
            {
                entDistrict.Text = pickerDistrict.Items[pickerDistrict.SelectedIndex];
            }
        }
    }
}