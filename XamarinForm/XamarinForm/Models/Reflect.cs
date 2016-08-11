using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinForm.Models
{
    class Reflect
    {
        public Reflect(string iName, string iDetail, Image iFavoriteColor)
        {
            this.Name = iName;
            this.Detail = iDetail;
            this.FavoriteColor = iFavoriteColor;
        }

        public string Name { private set; get; }

        public string Detail { private set; get; }

        public Image FavoriteColor { private set; get; }
    };
}
