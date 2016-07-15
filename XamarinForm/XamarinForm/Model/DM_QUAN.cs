using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinForm.Model
{
    public class DM_QUAN
    {        
        public string QuanID { get; set; }
        public string MaQuan { get; set; }
        public string TenQuan { get; set; }
        public bool Active { get; set; }
        public int? PortalID { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? NguoiCapNhat { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public override string ToString()
        {
            return TenQuan;
            //return base.ToString();
        }
        
    }
}
