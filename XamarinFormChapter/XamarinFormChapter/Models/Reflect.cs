using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormChapter.Models
{
    public class Reflect
    {
        public Reflect(int iID, string iName, string iDetail, Image iTileImage)
        {
            this.ID = iID;
            this.Name = iName;
            this.Detail = iDetail;
            this.TileImage = iTileImage;
        }

        public Reflect(int iID, string iName, string iDetail, Image iTileImage, string iSourceImage)
        {
            this.ID = iID;
            this.Name = iName;
            this.Detail = iDetail;
            this.TileImage = iTileImage;
            this.SourceImage = iSourceImage;
        }

        public int ID { get; set; }
        public string Name { private set; get; }
        public string Detail { private set; get; }
        public Image TileImage { private set; get ; }
        public string SourceImage { private set; get; }
    };
}
