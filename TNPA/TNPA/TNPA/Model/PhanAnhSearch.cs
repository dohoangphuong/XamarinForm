using System;
using System.Collections.Generic;

namespace TNPA.Model
{
    public class PhanAnhSearch
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SearchKey { get; set; }
        public string MaNguonTiepNhan { get; set; }
        public string MaKenhTiepNhan { get; set; }
        public string LoaiPhanAnhID { get; set; }
        public bool AllDate { get; set; }
        public string DonViNhanID { get; set; }
        public int? NguoiNhanID { get; set; }
        public string MaTinhTrang { get; set; }
        public string OrderBy { get; set; }
        public string Active { get; set; }
        public int PageIndex { get; set; }
        public int PortalId { get; set; }
        public int PageSize { get; set; }
        public List<DmLinhVuc> linhvuc { get; set; }
    }
}
