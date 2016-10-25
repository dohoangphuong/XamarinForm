using System;
using System.Collections.Generic;
using System.Globalization;

namespace TNPA.Model
{
    public class PhanAnh
    {
        public string PhanAnhID { get; set; }

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

        public List<Files> lstFileDinhKem { get; set; }

        public string NoiDungXuLy { get; set; }

        public string QuyTrinhID { get; set; }

        public DmDonVi GetDonViChuyenFromDB { get; set; }

        public DmDonVi GetDonViNhanFromDB { get; set; }

        public string thoiGian
        {
            get
            {
                DateTime dateTime = DateTime.ParseExact(GioNhan, "HH:mm:ss",
                                        CultureInfo.InvariantCulture);
                return dateTime.ToString("HH:mm")+ " " + NgayNhan.Value.ToString("dd /MM/yyy");
            }
        }
        public string diaChi
        {
            get
            {
                return ToTitleCase(SoNha + " " + Duong + " " + TenPhuong + " " + TenQuan).Replace(Environment.NewLine, " ");
            }
        }
        public string tieuDe
        {
            get
            {
                NoiDungPhanAnh = ToTitleCase(NoiDungPhanAnh);

                if (NoiDungPhanAnh.Length > 100)
                    return NoiDungPhanAnh.Substring(0, 100) + "...";
                else
                    return NoiDungPhanAnh;
            }
        }
        public Files thumbnails { get; set; }

        public byte[] thumbnail
        {
            get
            {
                if (thumbnails != null)
                {
                    return thumbnails.arrByte;
                }
                else
                {
                    return null;
                }
            }
        }
        // viet hoa chua cai dau
        private string ToTitleCase(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
    }
}
