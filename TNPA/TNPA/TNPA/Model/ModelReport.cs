using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNPA.Model
{
    public class ModelReport
    {
        public string LinhVucID { get; set; }
        public string MaLinhVuc { get; set; }
        public string TenLinhVuc { get; set; }
        public int TOTAL { get; set; }
        public int TOTAL_DXL { get; set; }
        public int TOTAL_CXL { get; set; }
        //"[{"LinhVucID":"LVI160300000050","MaLinhVuc":"CNTP","TenLinhVuc":"An ninh trật tư","TOTAL":0,"TOTAL_DXL":0,"TOTAL_CXL":0},
    }
}
