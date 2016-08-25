using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormChapter.Data;
using XamarinFormChapter.Models;

namespace XamarinFormChapter
{
    public static class Constants
    {
        public static string apiBaseUri = "http://192.168.1.250:8088/";
        public static string userName = "hp.codoc@yahoo.com.vn";
        public static string password = "P@ssw0rd";

        public static TPhanAnhController _TPhanAnhController = new TPhanAnhController();
        public static PhanAnhModel phanAnh = new PhanAnhModel();
        public static int PortailID = 0;
        public static string MaKenhTiepNhan = "MOBILE";
        public static List<DM_QUAN> lstDistrict;
        public static List<DM_PHUONG> lstTown;
    }
}
