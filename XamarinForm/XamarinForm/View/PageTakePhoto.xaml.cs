using Java.IO;
using System;
using System.IO;
using System.Reflection;

using Xamarin.Forms;
using XamarinForm.Common;
using XamarinForm.Model;
using XamarinForm.Models;
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
            Constants.phanAnh = new PhanAnhModel();

            Constants.phanAnh.NoiDungPhanAnh = "Cháy nhà quá trời luon ba con";
            Constants.phanAnh.Duong = "Paster";
            Constants.phanAnh.NguoiBao_Email = "hp.codoc@yahoo.com";
            Constants.phanAnh.NguoiBao_HoTen = "Hoàng Phương";
            Constants.phanAnh.NguoiBao_Duong = "Hàm Nghi";
            Constants.phanAnh.NguoiBao_DienThoai = "0168687929";
            Constants.phanAnh.PortalID = Constants.PortailID;
            Constants.phanAnh.MaKenhTiepNhan = Constants.MaKenhTiepNhan;
            
            //var returnResult = Constants._TPhanAnhController.SendRequestPhanAnh(Constants.phanAnh);
            //-----
            FILEDINHKEM fileDinhKemModel = new FILEDINHKEM();
            byte[] byteStream = soureCamera.bytePicture;
            fileDinhKemModel.arrByte = byteStream;
            fileDinhKemModel.FileName = "abc2345.jpg";
            fileDinhKemModel.FielUrl = "Upload/PhanAnh/";
            fileDinhKemModel.FileExtension = "jpg";
            Constants.phanAnh.FileDinhKem.Add(fileDinhKemModel);
            var returnResult = Constants._TPhanAnhController.SendRequestPhanAnh(Constants.phanAnh);
            //var result = Constants._TPhanAnhController.RequestServer(Constants.phanAnh);
            int a = 3;

            ////  var avc = soureCamera.bytePicture;
            ////File file = (File)soureCamera.file;
            //// soureCamera.F

            ////---------------------------------------------------------------
            //// FILEDINHKEM fileDinhKemModel = new FILEDINHKEM();
            ////Filw file = HttpContext.Current.Request.Files[i];

            ////long fileSize = file.Length();
            ////string fileName = file.Name;
            ////string mimeType = file.ContentType;
            ////System.IO.Stream fileContent = file.InputStream;
            //// if (fileSize > 0)
            ////{

            ////   DateTime CurrenTime = DateTime.Now;
            ////string pathFile = ftpServer + CurrenTime.Year.ToString();
            ////  fileName = CurrenTime.ToString("HH mm ss") + "_" + fileName;
            ////  fileName = fileName.Replace(" ", "-");
            //byte[] byteStream = soureCamera.bytePicture;
            ////fileContent.Read(byteStream, 0, byteStream.Length);

            ////pathFile = pathFile.Substring(pathFile.IndexOf(ftpServer) + ftpServer.Length);
            ////pathFile = PhanAnhFolderPath;

            //// Luu vao CSDL
            //fileDinhKemModel.arrByte = byteStream;
            //fileDinhKemModel.FileName = "abc";
            //fileDinhKemModel.FielUrl = "Upload/PhanAnh//2016/TONGDAI1022/TRUOC";
            //fileDinhKemModel.FileExtension = "jpg";
            ////       fileDinhKem.FileName = fileName;
            ////fileDinhKem.FielUrl = pathFile;
            //// fileDinhKem.FileExtension = Path.GetExtension(fileName).Substring(1);


            //var result = Constants._TPhanAnhController.RequestServer(fileDinhKemModel);

            //// await Navigation.PushModalAsync(new MainPage());
            ////}
        }
    }
}