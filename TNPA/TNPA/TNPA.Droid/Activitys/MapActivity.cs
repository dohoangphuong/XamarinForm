using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using static Android.Gms.Maps.GoogleMap;

namespace TNPA.Droid
{
    [Activity(Label = "MapActivity")]
    public class MapActivity : Activity
    {
        private GoogleMap _map;
        private MapFragment _mapFragment;
        private static LatLng location = new LatLng(10.8421601, 106.7465938);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);
            SetContentView(Resource.Layout.map);
            // Gán vị trí cho map
            location = new LatLng(Intent.Extras.GetDouble("Latitude", Config.Latitude), Intent.Extras.GetDouble("Longitude", Config.Longitude));
            InitMapFragment();
            Button btnReturn = FindViewById<Button>(Resource.Id.btnReturn);
            btnReturn.Click += returnIntent;
        }
        private void InitMapFragment()
        {
            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;
            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeNormal)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }
        }
        protected override void OnResume()
        {
            base.OnResume();
            if (SetupMapIfNeeded())
            {
                _map.MyLocationEnabled = true;
                _map.MapClick += googleMap_MapClick;
            }
        }
        protected override void OnPause()
        {
            base.OnPause();
            OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
            _map.MyLocationEnabled = false;
        }

        private bool SetupMapIfNeeded()
        {
            if (_map == null)
            {
                _map = _mapFragment.Map;
                if (_map != null)
                {
                    _map = _mapFragment.Map;
                    _map.MyLocationEnabled = true;
                    _map.MapClick += googleMap_MapClick;
                    setMarker(location);
                    CameraUpdate cameraUpdate = CameraUpdateFactory.NewLatLngZoom(location, 15);
                    _map.MoveCamera(cameraUpdate);
                }
                return false;
            }
            return true;
        }
        /// <summary>
        /// Gán marker
        /// </summary>
        /// <param name="location"></param>
        private void setMarker(LatLng location)
        {
            if (_map != null)
            {
                _map.Clear();// Xóa các marker trước
                MarkerOptions markerOpt1 = new MarkerOptions();
                markerOpt1.SetPosition(location);
                markerOpt1.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
                _map.AddMarker(markerOpt1);
            }
        }

        private void googleMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            location = e.Point;
            setMarker(location); // Hiện trị marker tại vị trí được chọn
        }
        /// <summary>
        /// Gửi dữ liệu trở về màn hình phản ánh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void returnIntent(object sender, EventArgs eventArgs)
        {
            Intent returnIntent = new Intent(this, typeof(PhanAnhActivity));
            returnIntent.PutExtra("Latitude", location.Latitude);
            returnIntent.PutExtra("Longitude", location.Longitude);
            SetResult(Result.Ok, returnIntent);// Gán trạng thái ok cho kết quả trả về
            Finish();
        }
    }
}