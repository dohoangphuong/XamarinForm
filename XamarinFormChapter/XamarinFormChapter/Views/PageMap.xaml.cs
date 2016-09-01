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
        Double dbLatitude = 10.772088, dbLong = 106.698419;
        CustomPin pin;
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
        /*<!--<Entry x:Name="entSearch" Text="Hà Nội" TextColor="White" BackgroundColor="Maroon"
             RelativeLayout.YConstraint="{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=0,Constant=40}"
             RelativeLayout.XConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width, Factor=0.1, Constant=0}"
             RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width,Factor=0.8,Constant=0}"
             Rela--><!--tiveLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=0,Constant=50}" />-->
        <!--<Button Text="Search" x:Name="btnSearch" Clicked="btnSearch_Click"
             RelativeLayout.YConstraint="{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=0,Constant=80}"
             RelativeLayout.XConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width, Factor=0.1, Constant=0}"
             RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent, Property=Width,Factor=0.8,Constant=0}"
             RelativeLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent, Property=Height, Factor=0,Constant=50}" />-->
           */
        public void btnSearch_Click(object sender, EventArgs e)
        {
            Search(entSearch.Text);
        }

        public async void Search(string fSourSearch)
        {
            Geocoder geoCoder;

            geoCoder = new Geocoder();
            string address = fSourSearch;
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
                        Label = fSourSearch,
                        Address = fSourSearch,
                    },
                    Id = fSourSearch,
                    Url = "http://xamarin.com/about/"
                };

                customMap.CustomPins = new List<CustomPin> { pin };
                customMap.Pins.Add(pin.Pin);
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(dbLatitude, dbLong), Distance.FromMiles(1.0)));

            }

        }
    }
}
