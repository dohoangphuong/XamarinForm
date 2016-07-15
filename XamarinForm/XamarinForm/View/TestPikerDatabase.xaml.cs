using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace _1022_Mobile.Views
{
    public partial class TestPikerDatabase : ContentPage
    {
        //-------------------------------------------------------------------------------
        //Picker
        //-------------------------------------------------------------------------------
        // Dictionary to get Color from color name.
        Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua },         { "Black", Color.Black },
            { "Blue", Color.Blue },         { "Fuchsia", Color.Fuchsia },
            { "Gray", Color.Gray },         { "Green", Color.Green },
            { "Lime", Color.Lime },         { "Maroon", Color.Maroon },
            { "Navy", Color.Navy },         { "Olive", Color.Olive },
            { "Purple", Color.Purple },     { "Red", Color.Red },
            { "Silver", Color.Silver },     { "Teal", Color.Teal },
            { "White", Color.White },       { "Yellow", Color.Yellow },

        };

        public TestPikerDatabase()
        {
            
            Button btnDistrict = new Button
            {
                Text = "Quan",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            ListView lstDistrict = new ListView
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            //
            // Button 

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

            Picker picker = new Picker
            {
                Title = "Color",

                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            foreach (string colorName in nameToColor.Keys)
            {
                picker.Items.Add(colorName);
            }

            // Create BoxView for displaying picked Color
            //Tạo 1 cái hộp màu sau khi chọn màu trong picker
            BoxView boxView = new BoxView
            {
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            picker.SelectedIndexChanged += (sender, args) =>
            {
                if (picker.SelectedIndex == -1)
                {
                    boxView.Color = Color.Default;
                }
                else
                {
                    string colorName = picker.Items[picker.SelectedIndex];
                    boxView.Color = nameToColor[colorName];
                }
            };

            // Build the page.
            new StackLayout
            {
                Children =
                {
                    header,
                    btnDistrict,
                    lstDistrict,
                    picker,
                    boxView
                }
            };
            
        }

        //-------------------------------------------------------------------------------
        //Picker
        //-------------------------------------------------------------------------------
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
            TPhanAnhController _TPhanAnhController = new TPhanAnhController();
            List<DM_QUAN> lstQuan = _TPhanAnhController.GetQuan();
            listView.ItemsSource = lstQuan;
            //await Navigation.PushModalAsync(new ThemPhanAnhPage());

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
           // Debug.WriteLine("Tapped: " + e.Item);
            DM_QUAN quan = (DM_QUAN)e.Item;
          //  Debug.WriteLine("Tapped item: " + quan.QuanID + " - " + quan.TenQuan);
            ((ListView)sender).SelectedItem = null; // de-select the row
        }

    }
}
