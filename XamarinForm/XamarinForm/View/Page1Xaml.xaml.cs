using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinForm.View
{
    public partial class Page1Xaml : ContentPage
    {
        //----------------------------------------------------------------------------------------------
        // Tập hợp các page có button pre ở thanh công cụ phía trên: App->Page1Xaml->Page2Xaml->Page3Xaml
        //----------------------------------------------------------------------------------------------
        public Page1Xaml()
        {
            InitializeComponent();
        }

        async void OnNextPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2Xaml());
        }
    }
}
