using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNPA.Model
{
    public class DmDonVi
    {
        public string DonViID { get; set; }

        public string MaDonVi { get; set; }

        public string TenDonVi { get; set; }

        public string LinhVucID { get; set; }

        public string LoaiDonVi { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string TongDai { get; set; }

        public string DiaBanPhuTrach { get; set; }

        public string Long { get; set; }

        public string Lat { get; set; }

        public string ParentID { get; set; }

        public int? CapDonVi { get; set; }

        public bool Isleaf { get; set; }

        public bool Active { get; set; }

        public int? PortalID { get; set; }

        public int? NguoiTao { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? NguoiCapNhat { get; set; }

        public DateTime? NgayCapNhat { get; set; }
    }
}
