using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TNPA.Model;

namespace TNPA
{
    public class LinhVucService
    {
        private readonly CustomService _CustomService;

        public LinhVucService()
        {
            if (_CustomService == null)
                _CustomService = new CustomService();
        }
        public async Task<ListResult> GetListLinhVuc()
        {
            try
            {
                return await _CustomService.GetRequest<DmLinhVuc>("/API/DmLinhVuc/Get/?portalId=0").ConfigureAwait(false);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ListResult> GetListPhanAnhByLinhVuc(List<DmLinhVuc> fLinhVuc,string searchKey, int PageIndex, int PageSize)
        {
            try
            {
                PhanAnhSearch searchModel = new PhanAnhSearch() { linhvuc = fLinhVuc, PageIndex = PageIndex, PageSize = PageSize,SearchKey = searchKey };
                return await _CustomService.PostRequest<PhanAnh>("API/TPhanAnh/GetForMobile", searchModel);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<ListResult> GetListPhanAnhLichSu(string searchKey, string maNguonTiepNhan,string maKenhTiepNhan, int PageIndex, int PageSize)
        {
            try
            {
                PhanAnhSearch searchModel = new PhanAnhSearch() {  MaKenhTiepNhan= maKenhTiepNhan,MaNguonTiepNhan = maNguonTiepNhan, PageIndex = PageIndex, PageSize = PageSize, SearchKey = searchKey };
                return await _CustomService.PostRequest<PhanAnh>("API/TPhanAnh/GetForMobileByEmail", searchModel);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<PhanAnh> GetChiTietPhanAnh(string phananhID,string PortalID)
        {
            try
            {
                //await Task.Delay(5000);
                return (PhanAnh)await _CustomService.GetRequestToObject<PhanAnh>("/API/TPhanAnh/GetByIDForMobile?PortalID="+PortalID + "&PhanAnhID=" + phananhID);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<PhanAnh> GetChiTietLichSu(string PhanAnhKenhKhachID, string PortalID)
        {
            try
            {
                //await Task.Delay(5000);
                return (PhanAnh)await _CustomService.GetRequestToObject<PhanAnh>("/API/TPhanAnh/GetByIDForMobileHistory?PortalID=" + PortalID + "&PhanAnhKenhKhachID=" + PhanAnhKenhKhachID);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<UpdateResult> SendRequestPhanAnh(PhanAnh iPhanAnh)
        {
            try
            {
                string token = _CustomService.GetAPIToken();
                string apiBaseUri = "API/TPhanAnhKenhKhac/Insert";
                var rs = await _CustomService.PostRequest(token, apiBaseUri, iPhanAnh);
                return rs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Lấy thông tin thống kê
         public async Task<List<ModelReport>> GetListPhanAnhThongKe(DateTime dtStart, DateTime dtEnd)
        {
            try
            {
                //kiểm tra trước tránh trường hợp code hay nơi nào gửi nhầm ngày bắt đầu lớn hơn ngày kết thúc
                if (dtStart > dtEnd)
                    dtEnd = dtStart;
                var str = await _CustomService.GetRequestToObject<string>("/API/Report/ExecuteReport?FromDate=" + dtStart.ToString("dd/MM/yyyy") + "&ToDate=" + dtEnd.ToString("dd/MM/yyyy") + "&LinhVucID=" + null + "&PortalId=0");
                return JsonConvert.DeserializeObject<List<ModelReport>>(str.ToString());
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<byte[]> getData(string filePath)
        {
            var str = await _CustomService.GetFile("/api/TPhanAnhKenhKhac/Download?pathFile=" + filePath);
            return str;
        }
    }
}
