using Java.IO;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Xamarin.Forms;
using XamarinForm.Common;
using XamarinForm.Models;
using XamarinForm.ViewModels;

namespace XamarinForm.View
{
    public partial class PageLayAnh : ContentPage
    {
        TakePictureViewModel soureCamera;
        
        public PageLayAnh()
        {
            InitializeComponent();
            soureCamera = new TakePictureViewModel(DependencyService.Get<ICameraProvider>());
            BindingContext = soureCamera;
        }

        async void btnSaveClick(object sender, EventArgs e)
        {
            try
            {
                DateTime CurrenTime = DateTime.Now;
                string fileName;

                //Nội dung phản ánh
                //Constants.phanAnh.NoiDungPhanAnh = "Cháy nhà quá trời luon ba con";
                //Constants.phanAnh.Duong = "Paster";
                //Constants.phanAnh.NguoiBao_Email = "hp.codoc@yahoo.com";
                //Constants.phanAnh.NguoiBao_HoTen = "Hoàng Phương";
                //Constants.phanAnh.NguoiBao_Duong = "Hàm Nghi";
                //Constants.phanAnh.NguoiBao_DienThoai = "0168687929";
                //Constants.phanAnh.PortalID = Constants.PortailID;
                //Constants.phanAnh.MaKenhTiepNhan = Constants.MaKenhTiepNhan;

                //File đính kèm
                FILEDINHKEM fileDinhKemModel = new FILEDINHKEM();
                byte[] byteStream = soureCamera.bytePicture;
                fileDinhKemModel.arrByte = byteStream;
                //Lấy tên công thêm giờ giây phút            
                fileName = CurrenTime.ToString("HH mm ss") + "_" + soureCamera.file.Name;
                fileName = fileName.Replace(" ", "-");
                fileDinhKemModel.FileName = fileName;
                fileDinhKemModel.FileExtension = Path.GetExtension(soureCamera.file.Name).Substring(1);
                fileDinhKemModel.FielUrl = "Upload/PhanAnh/";

                Constants.phanAnh.lstFileDinhKem.Add(fileDinhKemModel);
                var returnResult = Constants._TPhanAnhController.SendRequestPhanAnh(Constants.phanAnh);

                //quay lại
                Constants.phanAnh = new PhanAnhModel();
                Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                await Navigation.PopToRootAsync();
            }
            catch
            {
                lbMessageError.Text = "Phản ánh của bạn chưa được gửi đi";
                //Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                //await Navigation.PopToRootAsync();
            }
        }
    }
}