using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinFormChapter.Models;

namespace XamarinFormChapter.Views
{
    public class PageMaps : ContentPage
    {
        Double  dbLatitude =0, dbLong=0;
        public PageMaps()
        {
            var customMap = new CustomMap
            {
                MapType = MapType.Street,
                WidthRequest = App.ScreenWidth,
                HeightRequest = App.ScreenHeight
            };

            Search(); 

            var pin = new CustomPin
            {
                Pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(dbLatitude, dbLong),
                    Label = "Xamarin San Francisco Office",
                    Address = "394 Pacific Ave, San Francisco CA"
                },
                Id = "Xamarin",
                Url = "http://xamarin.com/about/"
            };

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin.Pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(dbLatitude, dbLong), Distance.FromMiles(1.0)));

           
            //Giao diện
            Content = customMap;


        }

        public async void Search()
        {
            Geocoder geoCoder;

            geoCoder = new Geocoder();
            string address = "Ha Noi";
            var approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);
            foreach (var position in approximateLocations)
            {
                dbLatitude = position.Latitude;
                dbLong = position.Longitude;
               // geocodedOutputLabel.Text += position.Latitude + ", " + position.Longitude + "\n";
            }
        }
    }
}