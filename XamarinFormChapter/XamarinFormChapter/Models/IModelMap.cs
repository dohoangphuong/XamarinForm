using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace XamarinFormChapter.Models
{
    public interface IModelMap
    {
        Position GetPositionMap();
        void SetPositionMap(Position iPosition);
    }
}
