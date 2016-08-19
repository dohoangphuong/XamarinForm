using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using XamarinForm.Models;

namespace XamarinForm.Data
{
    public class TPhanAnhController
    {
        CustomController _CustomController = new CustomController();
        public List<DM_QUAN> GetDistrict()
        {
            try
            {
                string apiBaseUri = Constants.apiBaseUri + "API/DmQuan/Get?portalId=0";
                var rs = _CustomController.GetRequest<DM_QUAN>(_CustomController.GetAPIToken(), apiBaseUri);
                return (List<DM_QUAN>)rs.ClassResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DM_PHUONG> GetWard(string iIdDistrict)
        {
            try
            {
                string apiBaseUri = Constants.apiBaseUri + "API/DmPhuong/Get?portalId=0" + "&quanId=" + iIdDistrict;
                var rs = _CustomController.GetRequest<DM_PHUONG>(_CustomController.GetAPIToken(), apiBaseUri);
                return (List<DM_PHUONG>)rs.ClassResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PhanAnhModel> GetListReflect(List<DM_LINHVUC> fLinhVuc)
        {
            try
            {
                //searchModel = new TPhanAnhSearchModel(Poral.Mvc.Models.Common.GetFirstOfMonth(), DateTime.Now, "", "", true, "", User.UserID, "", "", "1", pIndex, dsLV);
                TPhanAnhSearchModel searchModel = new TPhanAnhSearchModel(null, null, "", "", true, "", -1, "", "", "1", 0, fLinhVuc);

                string apiBaseUri = Constants.apiBaseUri + "API/TPhanAnh/GetAll";
                var rs = _CustomController.PostRequest<PhanAnhModel>(_CustomController.GetAPIToken(), apiBaseUri, searchModel);
                return (List<PhanAnhModel>)rs.ClassResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UpdateResult SendRequestPhanAnh(PhanAnhModel iPhanAnh)
        {
            try
            {
                string apiBaseUri = Constants.apiBaseUri + "API/TPhanAnhKenhKhac/Insert";
                var rs = _CustomController.PostRequest(_CustomController.GetAPIToken(), apiBaseUri, iPhanAnh);
                return rs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DM_LINHVUC> GetListLinhVuc()
        {
            try
            {
                var lstLinhVuc = (List<DM_LINHVUC>)_CustomController.GetRequest<DM_LINHVUC>(_CustomController.GetAPIToken(), "/API/DmLinhVuc/Get/?portalId=0").ClassResult;
                return lstLinhVuc;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}