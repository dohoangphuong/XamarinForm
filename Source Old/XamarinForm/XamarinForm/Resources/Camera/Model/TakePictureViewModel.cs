namespace XamarinForm.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using XamarinForm.Common;

    using Xamarin.Forms;
    using Java.IO;
    public class TakePictureViewModel : ObservableObject
    {
        private ImageSource picture;
        public byte[] bytePicture;
        public File file;

        public ImageSource Picture
        {
            get
            {
                return this.picture;
            }
            set
            {
                if (Equals(value, this.picture))
                {
                    return;
                }
                this.picture = value;
                OnPropertyChanged();
            }
        }

        public ICommand TakePicture { get; set; }
       

        private ICameraProvider cameraProvider;

        public TakePictureViewModel(ICameraProvider cameraProvider)
        {
            if (cameraProvider == null)
            {
                throw new ArgumentNullException("cameraProvider");
            }

            TakePicture = new Command(async () => await TakePictureAsync());
            this.cameraProvider = cameraProvider;
        }

        private async Task TakePictureAsync()
        {
            var photoResult = await cameraProvider.TakePictureAsync();
            var bytePictureCamera = cameraProvider.ConvertByte();

            if (photoResult != null)
            {
                Picture = photoResult.Picture;
            }

            if (bytePictureCamera != null)
            {
                bytePicture = bytePictureCamera;
                file = cameraProvider.FileImage();
            }
        }
    }
}