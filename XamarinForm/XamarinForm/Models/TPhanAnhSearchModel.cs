using System;
using System.Collections.Generic;

namespace XamarinForm.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class TPhanAnhSearchModel
    {
        public TPhanAnhSearchModel() { }

        public TPhanAnhSearchModel(DateTime? FromDate, DateTime? ToDate, string SearchKey, string LoaiPhanAnhID, bool AllDate,
            string DonViNhanID, int NguoiNhanID, string MaTinhTrang, string OrderBy, string Active, int PageIndex, List<DM_LINHVUC> linhvuc)
        {
            this.FromDate = FromDate;
            this.ToDate = ToDate;
            this.SearchKey = SearchKey;
            this.LoaiPhanAnhID = LoaiPhanAnhID;
            this.AllDate = AllDate;
            this.DonViNhanID = DonViNhanID;
            this.NguoiNhanID = NguoiNhanID;
            this.MaTinhTrang = MaTinhTrang;
            this.OrderBy = OrderBy;
            this.Active = Active;
            this.PageIndex = PageIndex;
            this.linhvuc = linhvuc;
        }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SearchKey { get; set; }
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
        public List<DM_LINHVUC> linhvuc { get; set; }
    }
}