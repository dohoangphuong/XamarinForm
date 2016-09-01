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
        Double dbLatitude = 10.772088, dbLong = 106.698419;
        CustomMap customMap;
        CustomPin pin;

        public PageMaps()
        {
            customMap = new CustomMap
            {
                MapType = MapType.Street,
                WidthRequest = App.ScreenWidth,
                HeightRequest = App.ScreenHeight
            };

            

            //pin = new CustomPin
            //{
            //    Pin = new Pin
            //    {
            //        Type = PinType.Place,
            //        Position = new Position(dbLatitude, dbLong),
            //        Label = "Xamarin San Francisco Office",
            //        Address = "394 Pacific Ave, San Francisco CA"
            //    },
            //    Id = "Xamarin",
            //    Url = "http://xamarin.com/about/"
            //};

            //customMap.CustomPins = new List<CustomPin> { pin };
            //customMap.Pins.Add(pin.Pin);
            //customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(dbLatitude, dbLong), Distance.FromMiles(1.0)));


            ////Giao diện
            ////this.Content = new StackLayout
            ////{
            ////    Children =
            ////    {
            ////        customMap
            ////    }
            ////};
            //Content = customMap;
            Search();

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

                pin = new CustomPin
                {
                    Pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(dbLatitude, dbLong),
                        Label = "Hà Nội",
                        Address = "394 Pacific Ave, San Francisco CA"
                    },
                    Id = "Hà Nội",
                    Url = "http://xamarin.com/about/"
                };

                customMap.CustomPins = new List<CustomPin> { pin };
                customMap.Pins.Add(pin.Pin);
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(dbLatitude, dbLong), Distance.FromMiles(1.0)));


                //Giao diện
                //this.Content = new StackLayout
                //{
                //    Children =
                //    {
                //        customMap
                //    }
                //};
                //Content = customMap;
                //Content += new TextCell();
            }
        }
    }
}