using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using XamarinForm.Model;

namespace XamarinForm.Data
{
    public class TPhanAnhController
    {
        public List<DM_QUAN> GetQuan()
        {
            try
            {
                CustomController _CustomController = new CustomController();
                string apiBaseUri = "http://192.168.1.250:8088/API/DmQuan/Get?portalId=0";
                var rs = _CustomController.GetRequest<DM_QUAN>(_CustomController.GetAPIToken(), apiBaseUri);
                return (List<DM_QUAN>)rs.ClassResult;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}