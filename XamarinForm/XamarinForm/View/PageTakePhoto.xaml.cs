using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinForm.Common;
using XamarinForm.ViewModels;

namespace XamarinForm.View
{
    public partial class PageTakePhoto : ContentPage
    {
        public PageTakePhoto()
        {
           
            InitializeComponent();
            BindingContext = new TakePictureViewModel(DependencyService.Get<ICameraProvider>());
        }
    }
}
