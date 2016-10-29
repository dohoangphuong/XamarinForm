using Foundation;
using System;
using System.Collections.Generic;
using TNPA.Model;
using UIKit;

namespace TNPA.iOS
{
    public partial class PhanAnhController : UIViewController
    {
        
        private PhanAnh resultPhanAnh;
        private LinhVucService _service = new LinhVucService();
        public PhanAnhController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            btnGui.TouchUpInside += BtnBieuDo_TouchUpInside;

                        
        }

        private async void BtnBieuDo_TouchUpInside(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNoiDung.Text.Trim()) || string.IsNullOrEmpty(txtVitri.Text.Trim()))
            {
                UIAlertView alert = new UIAlertView()
                {
                    Title = "Thông báo",
                    Message = "Vui lòng nhập đầy đủ thông tin trước khi gởi đi"
                };
                alert.AddButton("OK");
                alert.Show();
            }
            else
            {
                resultPhanAnh = new PhanAnh();

                resultPhanAnh.lstFileDinhKem = new List<Files>();
                resultPhanAnh.Active = Configs.Active;
                resultPhanAnh.PortalID = Configs.PortalID;
                resultPhanAnh.MaKenhTiepNhan = Configs.MaKenhTiepNhan;

                resultPhanAnh.Duong = txtVitri.Text;
                resultPhanAnh.NoiDungPhanAnh = txtNoiDung.Text;

                resultPhanAnh.NguoiBao_HoTen = "Do Hoang Phuong";
                resultPhanAnh.NguoiBao_DienThoai = "012345678";
                resultPhanAnh.NguoiBao_Email = "ABc@gmai.com";
                resultPhanAnh.NguoiBao_Duong = "120 Paster, Q.1";

                var result = await _service.SendRequestPhanAnh(resultPhanAnh);
                if (result == null)
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Thông báo",
                        Message = "Phản ánh chưa được gửi đi, vui lòng kiểm tra lại."
                    };
                    alert.AddButton("OK");
                    alert.Show();
                }
                else
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Thông báo",
                        Message = "Phản ánh đã được gửi thành công."
                    };
                    alert.AddButton("OK");
                    alert.Show();
                }
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        protected void GuiPhanAnh()
        {
            //btnMap = FindViewById<Button>(Resource.Id.btnGetMap);
            //btnGui = FindViewById<Button>(Resource.Id.btnGui);
            //txtVitri = FindViewById<EditText>(Resource.Id.txtViTri);
            //txtNoiDung = FindViewById<EditText>(Resource.Id.txtNoiDung);
            //_addressText = FindViewById<EditText>(Resource.Id.txtViTri);
            //imageLayout = FindViewById<LinearLayout>(Resource.Id.imageLayout);

            //if (IsThereAnAppToTakePictures())// Kiểm tra hình 
            //{
            //    CreateDirectoryForPictures();// Tạo đường dẫn hình
            //    imageLayout.Visibility = ViewStates.Gone;// Ẩn view hình khi chưa có hình

            //    // Tạo sự kiện gọi dialog chọn hình
            //    Button button = FindViewById<Button>(Resource.Id.btnCamera);
            //    button.Click += CallImage;
            //}

            //btnMap.Click += OpenMap;
            //txtVitri.FocusChange += checkFocus;
            //txtNoiDung.FocusChange += checkFocus;

            //btnGui.Visibility = ViewStates.Gone;// mới vào ẩn nút gửi

            // Sau khi nhập đầy đủ thông tin nhấp vào màn hình để hiện nút gửi
            //LinearLayout scrolllayout = FindViewById<LinearLayout>(Resource.Id.scrolllayout);
            //scrolllayout.Click += checkView;
            //RelativeLayout mainlayout = FindViewById<RelativeLayout>(Resource.Id.mainlayout);
            //mainlayout.Click += checkView;

            // Gửi phản ánh
            btnGui.TouchUpInside += async (sender, arg) =>
            {
                if (string.IsNullOrEmpty(txtNoiDung.Text.Trim()) || string.IsNullOrEmpty(txtVitri.Text.Trim()))
                {
                    // modellP1.Title = Config.scrReportDuLieu;
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Thông báo",
                        Message = "Vui lòng nhập đầy đủ thông tin trước khi gởi đi"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                }
                else
                {
                    //Intent intent = new Intent(this, typeof(ThongTinActivity));
                    //StartActivityForResult(intent, (int)Config.Active.Caidat);
                    resultPhanAnh.Duong = txtVitri.Text;
                    resultPhanAnh.NoiDungPhanAnh = txtNoiDung.Text;
                    resultPhanAnh.NguoiBao_HoTen = "Do Hoang Phuong";
                    resultPhanAnh.NguoiBao_DienThoai = "012345678";
                    resultPhanAnh.NguoiBao_Email = "ABc@gmai.com";
                    resultPhanAnh.NguoiBao_Duong = "120 Paster, Q.1";

                    var result = await _service.SendRequestPhanAnh(resultPhanAnh);
                    if (result == null)
                    {
                        UIAlertView alert = new UIAlertView()
                        {
                            Title = "Thông báo",
                            Message = "Phản ánh chưa được gửi đi, vui lòng kiểm tra lại."
                        };
                        alert.AddButton("OK");
                        alert.Show();
                    }
                }
            };

            // Hiện dialog tìm vị trí hiện tại
           // progress = ProgressDialog.Show(this, Resources.GetString(Resource.String.vuilongcho), Resources.GetString(Resource.String.timvitri), true);
        }
    }
}