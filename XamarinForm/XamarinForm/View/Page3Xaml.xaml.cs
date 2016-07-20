using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinForm.View
{
    public partial class Page3Xaml : ContentPage
    {
        //----------------------------------------------------------------------------------------------
        // Tập hợp các page có button pre ở thanh công cụ phía trên: App->Page1Xaml->Page2Xaml->Page3Xaml
        //----------------------------------------------------------------------------------------------
        public Page3Xaml()
        {
            InitializeComponent();
        }
        async void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnRootPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        void OnInsertPageButtonClicked(object sender, EventArgs e)
        {
            var page2a = Navigation.NavigationStack.FirstOrDefault(p => p.Title == "Page 2a");
            if (page2a == null)
            {
               // Navigation.InsertPageBefore(new Page2aXaml(), this);
            }
        }

        void OnRemovePageButtonClicked(object sender, EventArgs e)
        {
            var page2 = Navigation.NavigationStack.FirstOrDefault(p => p.Title == "Page 2");
            if (page2 != null)
            {
                Navigation.RemovePage(page2);
            }
        }
    }
}