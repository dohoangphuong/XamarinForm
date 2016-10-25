using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNPA.Model;

namespace TNPA.Model
{
    public class ShowPhanAnhModel
    {
        public string PhanAnhKenhKhacID { get; set; }

        public string PhanAnhID { get; set; }

        public string MaNguonTiepNhan { get; set; }

        public string MaKenhTiepNhan { get; set; }

        public string NoiDungPhanAnh { get; set; }

        public string SoNha { get; set; }

        public string Duong { get; set; }

        public string PhuongID { get; set; }

        public string QuanID { get; set; }

        public string NguoiBao_HoTen { get; set; }

        public string NguoiBao_SoNha { get; set; }

        public string NguoiBao_Duong { get; set; }

        public string NguoiBao_PhuongID { get; set; }

        public string NguoiBao_QuanID { get; set; }

        public string NguoiBao_Email { get; set; }

        public string NguoiBao_DienThoai { get; set; }

        public string TenLinhVuc { get; set; }

        public string LoaiPhanAnhID { get; set; }

        public string LinhVucID { get; set; }

        public DateTime? NgayNhan { get; set; }

        public string GioNhan { get; set; }

        public DateTime? NgayGioHoanTat { get; set; }

        public string TenPhuong { get; set; }

        public string TenQuan { get; set; }

        public bool Active { get; set; }

        public int? PortalID { get; set; }

        public List<Files> lstFileDinhKem { get; set; }

        public DM_DONVI GetDonViFromDB { get; set; }
    }
    public class DM_DONVI
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
