using System;
using System.Collections.Generic;
using System.Linq;
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
            if(_CustomService == null)
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
        public async Task<ListResult> GetListPhanAnhByLinhVuc(List<DmLinhVuc> fLinhVuc, int PageIndex, int PageSize)
        {
            try
            {
                PhanAnhSearch searchModel = new PhanAnhSearch() { linhvuc = fLinhVuc, PageIndex = PageIndex, PageSize = PageSize };
                return await _CustomService.PostRequest<PhanAnh>("API/TPhanAnh/GetForMobile", searchModel);
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
                string apiBaseUri = "API/TPhanAnhKenhKhac/Insert";
                var rs = _CustomService.PostRequest(_CustomService.GetAPIToken(), apiBaseUri, iPhanAnh);
                return await rs;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
