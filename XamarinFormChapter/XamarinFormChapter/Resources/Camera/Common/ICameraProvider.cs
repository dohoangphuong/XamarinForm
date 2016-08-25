namespace XamarinFormChapter.Common
{
    using Java.IO;
    using System.Threading.Tasks;

    public interface ICameraProvider
    {
        Task<CameraResult> TakePictureAsync();
        //Convert image to byte array
        byte[] ConvertByte();
        File FileImage();
    }
}