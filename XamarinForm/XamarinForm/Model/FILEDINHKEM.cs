using System;

namespace XamarinForm.Model
{
    public class FILEDINHKEM
    {
        public int FileID { get; set; }
        
        public string FileName { get; set; }
        
        public string Type { get; set; }
        
        public string PhanAnhID { get; set; }
        
        public string QuyTrinhID { get; set; }
        
        public string FielUrl { get; set; }
        
        public string FileExtension { get; set; }

        public byte[] arrByte { get; set; }
    }
}
