using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNPA.Model
{
    public class DmLinhVuc
    {
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
        public string GetImageFromDB { get; set; }
    }
}
