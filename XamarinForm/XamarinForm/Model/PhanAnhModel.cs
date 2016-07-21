using System;
using System.Collections.Generic;

namespace XamarinForm.Model
{
    public class PhanAnhModel
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

        public bool Active { get; set; }

        public int? PortalID { get; set; }

        public List<FILEDINHKEM> FileDinhKem { get; set; }
    }
}
