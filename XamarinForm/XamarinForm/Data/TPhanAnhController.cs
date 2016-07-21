﻿using System;
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

        public List<DM_PHUONG> GetTown(string iIdDistrict)
        {
            try
            {
                CustomController _CustomController = new CustomController();
                string apiBaseUri = Constants.apiBaseUri + "/API/DmPhuong/Get?portalId=0" + "&quanId=" + iIdDistrict;
                var rs = _CustomController.GetRequest<DM_PHUONG>(_CustomController.GetAPIToken(), apiBaseUri);
                return (List<DM_PHUONG>)rs.ClassResult;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PhanAnhModel> SendRequestPhanAnh(PhanAnhModel iPhanAnh)
        {
            try
            {
                CustomController _CustomController = new CustomController();
                string apiBaseUri = "http://192.168.1.250:8088/API/TPhanAnhKenhKhac";
                var rs = _CustomController.PostRequest<PhanAnhModel>(_CustomController.GetAPIToken(), apiBaseUri, iPhanAnh);
                return (List < PhanAnhModel > )rs.ClassResult;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}