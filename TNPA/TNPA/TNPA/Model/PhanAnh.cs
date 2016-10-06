using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TNPA.Model
{
    public class PhanAnh
    {
        public string PhanAnhKenhKhacID { get; set; }

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
        public List<files> lstFileDinhKem { get; set; }

        public PhanAnh()
        {
            lstFileDinhKem = new List<files>();
            Active = true;
        }


        public string thoiGian
        {
            get
            {
                return NgayNhan + " " + GioNhan;
            }
        }
        public string diaChi
        {
            get
            {
                return SoNha + " " + TenPhuong + " " + TenQuan;
            }
        }
        public string tieuDe
        {
            get
            {
                if (NoiDungPhanAnh.Length > 100)
                    return NoiDungPhanAnh.Substring(0, 100) + "...";
                else
                    return NoiDungPhanAnh;
            }
        }
        public files thumbnails { get; set; }

        public byte[] thumbnail
        {
            get
            {
                if (thumbnails != null)
                {
                    return thumbnails.FileContent;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
