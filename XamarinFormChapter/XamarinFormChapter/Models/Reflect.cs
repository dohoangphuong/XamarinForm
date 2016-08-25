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
        public Reflect(int iID, string iName, string iDetail, Image iFavoriteColor)
        {
            this.ID = iID;
            this.Name = iName;
            this.Detail = iDetail;
            this.FavoriteColor = iFavoriteColor;
        }

        public int ID { get; set; }
        public string Name { private set; get; }
        public string Detail { private set; get; }
        public Image FavoriteColor { private set; get; }
    };
}
