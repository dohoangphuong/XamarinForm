using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using XamarinForm.Model;
using XamarinForm.Models;

namespace XamarinForm.Data
{
    public class TPhanAnhController
    {
        CustomController _CustomController = new CustomController();
        public List<DM_QUAN> GetQuan()
        {
            try
            {
                string apiBaseUri = "http://192.168.1.250:8088/API/DmQuan/Get?portalId=0";
                var rs = _CustomController.GetRequest<DM_QUAN>(_CustomController.GetAPIToken(), apiBaseUri);
                return (List<DM_QUAN>)rs.ClassResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DM_PHUONG> GetTown(string iIdDistrict)
        {
            try
            {
                string apiBaseUri = Constants.apiBaseUri + "/API/DmPhuong/Get?portalId=0" + "&quanId=" + iIdDistrict;
                var rs = _CustomController.GetRequest<DM_PHUONG>(_CustomController.GetAPIToken(), apiBaseUri);
                return (List<DM_PHUONG>)rs.ClassResult;
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
                string apiBaseUri = "http://192.168.1.250:8088/API/TPhanAnhKenhKhac";
                var rs = _CustomController.PostRequest(_CustomController.GetAPIToken(), apiBaseUri, iPhanAnh);
                return rs;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UpdateResult RequestServer(PhanAnhModel iOject)
        {
            try
            {
                string apiBaseUri = "http://192.168.1.250:8088/API/TPhanAnhKenhKhac";
                var rs = _CustomController.PostRequest(_CustomController.GetAPIToken(), apiBaseUri, iOject);
                return rs;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}