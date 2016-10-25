using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TNPA.Droid
{
    public static class Config
    {
        // Giá trị mặc định cho map
        public static readonly double Latitude = 10.7765229;
        public static readonly double Longitude = 106.698802;

        // Hoạt động của trang phản ánh ( mở map, mở camera, mở thư viện ảnh, cài đặt)
        public enum Active{Map, TakeAPicture, TakeAGallery , Caidat};

        // Định dạng tên hình được lưu vào máy sau khi chụp từ camera màn hình phản ánh
        public static readonly string ImageName = "TNPA_{0}.png";

        // Thông tin mặc định của phản ánh
        public static readonly string MaKenhTiepNhan = "MOBILE";
        public static readonly string MaNguonTiepNhan = "1022";
        public static readonly int PortalID = 0;
        public static readonly bool Actives = true;

        // Số dòng dữ liệu mỗi trang
        public static readonly int PageSize = 15;

        // String Format 
        public static readonly string NguoiPhanAnh = "Người phản ánh: {0}";
        public static readonly string ThoiGianPhanAnh = "Thời gian phản ánh: {0}";
        public static readonly string DiaDiemPhanAnh = "Địa điểm phản ánh: {0}";
        public static readonly string TieuDeXuLy = "Phản hồi từ: {0}";


        // Preferences values
        public static readonly string GCMToken = "GCMToken";
        public static readonly string GCMTopic = "GCMTopic";
        public static readonly string REGISTRATION_COMPLETE = "registrationComplete";
        public static readonly string HoTen = "HoTen";
        public static readonly string SDT = "SDT";
        public static readonly string Email = "Email";
        public static readonly string DiaChi = "DiaChi";
        
        // SenderID dùng cho GCM
        public static readonly string GCMSENDER_ID = "630051300432";
        
        // Nội dung thông báo khi có tin nhắn từ GCM
        public static readonly string Notification = "Có phản ánh mới được xử lý";

        public static readonly string NoiDungDangXuLy = "Phản ánh đang trong quá trình xử lý";

        // Link lấy ảnh từ server
        public static readonly string UrlGetImage = "http://192.168.1.20:8088/api/TPhanAnhKenhKhac/Get?pathFile=";

        //Report
        public static readonly string scrReportDuLieu = "CHƯA CÓ DỮ LIỆU PHẢN ÁNH";

        public static readonly Dictionary<string, string> dictionaryAction = new Dictionary<string, string>()
        {
            { "ThongTinActivity","Thông tin tài khoản"},
            { "LichSuActivity","Lịch sử phản ánh"},
            { "TroGiupActivity", "Hướng dẫn sử dụng"},
            { "ThongTinUngDungActivity", "Thông tin ứng dụng"},
        };
    }
}