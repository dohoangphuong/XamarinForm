using System;

namespace XamarinFormChapter.Models
{
    public class DM_PHUONG
    {
        public string PhuongID { get; set; }

        public string MaPhuong { get; set; }

        public string TenPhuong { get; set; }

        public string QuanID { get; set; }

        public bool Active { get; set; }

        public int? PortalID { get; set; }

        public int? NguoiTao { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? NguoiCapNhat { get; set; }

        public DateTime? NgayCapNhat { get; set; }

    }
}
