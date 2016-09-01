using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinFormChapter.Models;

namespace XamarinFormChapter.Views
{
    public partial class PageMap : ContentPage
    {
        public PageMap()
        {
            InitializeComponent();
            
            var pin = new CustomPin
            {
                 
                Pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(37.79752, -122.40183),
                    Label = "Xamarin San Francisco Office",
                    Address = "394 Pacific Ave, San Francisco CA",

                },
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin.Pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(10.7731044, 106.6977803), Distance.FromMiles(1.0)));
        }

        private void btnSave_Click(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
