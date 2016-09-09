using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinFormChapter.Models;
using XamarinFormChapter.Views;

//[assembly: Dependency(typeof(PageMap))]
namespace XamarinFormChapter.Views
{
    public partial class PageMap : ContentPage//, IModelMap
    {
        Double dbLatitude = 10.772088, dbLong = 106.698419;
        CustomPin pin;

        private static PageMap instance;
        public static PageMap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageMap();
                }
                return instance;
            }
        }

        public PageMap(string iSoureSearch)
        {
            InitializeComponent();
            entSearch.Text = iSoureSearch;
            pin = new CustomPin
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
        public PageMap()
        {
            InitializeComponent();

            pin = new CustomPin
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
        
        public void btnSearch_Click(object sender, EventArgs e)
        {
            Search(entSearch.Text);
            SearchSetMarker(entSearch.Text);
            //Search(entSearch.Text);
            //Nhớ sửa lại bỏ //
            //PageThemPhanAnh.entAddres.Text = entSearch.Text;
        }

        public async void Search(string fSourSearch)
        {
            if (fSourSearch.Trim() != "")
            {
                Geocoder geoCoder;

                geoCoder = new Geocoder();
                string address = fSourSearch;
                var approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);
                var position = approximateLocations.ElementAt(0);
                //foreach (var position in approximateLocations)
                {
                    dbLatitude = position.Latitude;
                    dbLong = position.Longitude;

                    pin = new CustomPin
                    {
                        Pin = new Pin
                        {
                            Type = PinType.Place,
                            Position = new Position(dbLatitude, dbLong),
                            Label = "Vị trí phản ánh",
                            Address = fSourSearch,
                        },
                        Id = dbLatitude.ToString() + dbLong.ToString(),
                        Url = "http://xamarin.com/about/"
                    };
                    customMap.CustomPins = new List<CustomPin> { pin };
                    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(dbLatitude, dbLong), Distance.FromMiles(1.0)));


                }
            }
        }
        public async void SearchSetMarker(string fSourSearch)
        {
            if (fSourSearch.Trim() != "")
            {
                Geocoder geoCoder;

                geoCoder = new Geocoder();
                string address = fSourSearch;
                var approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);
                var position = approximateLocations.ElementAt(0);
                //foreach (var position in approximateLocations)
                {
                    dbLatitude = position.Latitude;
                    dbLong = position.Longitude;

                    pin = new CustomPin
                    {
                        Pin = new Pin
                        {
                            Type = PinType.Place,
                            Position = new Position(dbLatitude, dbLong),
                            Label = "Vị trí phản ánh",
                            Address = fSourSearch,
                        },
                        Id = dbLatitude.ToString() + dbLong.ToString(),
                        Url = "http://xamarin.com/about/"
                    };
                    customMap.CustomPins = new List<CustomPin> { pin };
                    //customMap.Pins.RemoveAt(0);
                    customMap.Pins.Add(pin.Pin);

                }
            }
        }

        public Position GetPositionMap()
        {
            return new Position(dbLatitude, dbLong);
        }

        public void SetPositionMap(Position iPosition)
        {
            //Search2(iPosition);
            SearchSetMarker2(iPosition);
        }

        public async void Search2(Position iPosition)
        {
          //  if (fSourSearch.Trim() != "")
            {
                Geocoder geoCoder;

                geoCoder = new Geocoder();
                var approximateLocations = await geoCoder.GetAddressesForPositionAsync(iPosition);
                var position = approximateLocations.ElementAt(0);
                //foreach (var position in approximateLocations)
                {
                    dbLatitude = iPosition.Latitude;
                    dbLong = iPosition.Longitude;

                    pin = new CustomPin
                    {
                        Pin = new Pin
                        {
                            Type = PinType.Place,
                            Position = new Position(dbLatitude, dbLong),
                            Label = "Vị trí phản ánh",
                            Address = position,
                        },
                        Id = dbLatitude.ToString() + dbLong.ToString(),
                        Url = "http://xamarin.com/about/"
                    };
                    customMap.CustomPins = new List<CustomPin> { pin };
                    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(dbLatitude, dbLong), Distance.FromMiles(1.0)));
                }
            }
        }
        public async void SearchSetMarker2(Position iPosition)
        {
           // if (fSourSearch.Trim() != "")
            {
                Geocoder geoCoder;

                geoCoder = new Geocoder();
                var approximateLocations = await geoCoder.GetAddressesForPositionAsync(iPosition);
                var position = approximateLocations.ElementAt(0);
                //foreach (var position in approximateLocations)
                {
                    dbLatitude = iPosition.Latitude;
                    dbLong = iPosition.Longitude;

                    pin = new CustomPin
                    {
                        Pin = new Pin
                        {
                            Type = PinType.Place,
                            Position = new Position(dbLatitude, dbLong),
                            Label = "Vị trí phản ánh",
                            Address = position,
                        },
                        Id = dbLatitude.ToString() + dbLong.ToString(),
                        Url = "http://xamarin.com/about/"
                    };
                    customMap.CustomPins = new List<CustomPin> { pin };
                    //customMap.Pins.RemoveAt(0);
                    customMap.Pins.Add(pin.Pin);

                }
            }
        }
    }
}
