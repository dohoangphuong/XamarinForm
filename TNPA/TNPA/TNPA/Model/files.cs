using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TNPA.Model
{
    public class files
    {
        public int FileID { get; set; }

        public string FileName { get; set; }

        public string Type { get; set; }

        public string PhanAnhID { get; set; }

        public string QuyTrinhID { get; set; }

        public string FileUrl { get; set; }

        public string FileExtension { get; set; }

        public byte[] arrByte { get; set; }

        public byte[] FileContent { get; set; }
    }
}
