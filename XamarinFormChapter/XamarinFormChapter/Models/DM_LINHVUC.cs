namespace XamarinFormChapter.Models
{
    using System;

    public class DM_LINHVUC
    {
        public DM_LINHVUC() { }

        public bool Active { get; set; }
        public string GhiChu { get; set; }
        public string LinhVucID { get; set; }
        public string MaLinhVuc { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiCapNhat { get; set; }
        public int? NguoiTao { get; set; }
        public int? PortalID { get; set; }
        public string TenLinhVuc { get; set; }
        public String GetImageFromDB { get; set; }
    }
}
