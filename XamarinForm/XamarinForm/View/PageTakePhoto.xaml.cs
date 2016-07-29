using System;
using System.IO;
using System.Reflection;

using Xamarin.Forms;
using XamarinForm.Common;
using XamarinForm.ViewModels;

namespace XamarinForm.View
{
    public partial class PageTakePhoto : ContentPage
    {
        TakePictureViewModel soureCamera;
        public PageTakePhoto()
        {
            InitializeComponent();
            soureCamera = new TakePictureViewModel(DependencyService.Get<ICameraProvider>());
            BindingContext = soureCamera;
        }

        async void btnSaveClick(object sender, EventArgs e)
        {
            // Byte[] abc = imgShow.To
            imgLoad.Source = imgShow.Source;
            var avc = soureCamera.bytePicture;

            // await Navigation.PushModalAsync(new MainPage());
        }
    }
}