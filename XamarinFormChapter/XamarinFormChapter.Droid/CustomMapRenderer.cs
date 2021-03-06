﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Widget;
using XamarinFormChapter.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using XamarinFormChapter.Models;
using XamarinFormChapter;
using MonoTouch.MapKit;
using MonoTouch.UIKit;
using XamarinFormChapter.Views;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace XamarinFormChapter.Droid
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        GoogleMap map;
        private CustomPin customPins;
        bool isDrawn;
        bool ClickTitle = false;
        private Marker MapMarkerAll;


        //Search
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                map.InfoWindowClick -= OnInfoWindowClick;
                map.MapClick -= googleMap_MapClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                customPins = formsMap.CustomPins;
                ((MapView)Control).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            map.InfoWindowClick += OnInfoWindowClick;
            if (map != null)
                map.MapClick += googleMap_MapClick;
            map.SetInfoWindowAdapter(this);
        }

        void googleMap_MapClick(object sender, GoogleMap.MapClickEventArgs e)
        {
            map.Clear();
            PageMap s = PageMap.Instance;
            s.SetPositionMap(new Position(e.Point.Latitude, e.Point.Longitude));
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn && !ClickTitle)
            {
                map.Clear();
                if (MapMarkerAll != null)
                    MapMarkerAll.Remove();

                //Add Pin into map
                var marker = new MarkerOptions();
                marker.SetPosition(new LatLng(customPins.Pin.Position.Latitude, customPins.Pin.Position.Longitude));
                marker.SetTitle(customPins.Pin.Label);
                marker.SetSnippet(customPins.Pin.Address);
                marker.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed));

                MapMarkerAll = map.AddMarker(marker);
                //--------------------------------------
                isDrawn = true;
            }
            else
            {
                if (e.PropertyName.Equals("VisibleRegion") && isDrawn && !ClickTitle)
                {
                    var fNewCustomPins = (CustomMap)sender;

                    if (fNewCustomPins.CustomPins.Id != customPins.Id)
                    {
                        customPins = fNewCustomPins.CustomPins;
                    }

                    map.Clear();
                    if (MapMarkerAll != null)
                        MapMarkerAll.Remove();

                    //Add Pin into map
                    var marker = new MarkerOptions();
                    marker.SetPosition(new LatLng(customPins.Pin.Position.Latitude, customPins.Pin.Position.Longitude));
                    marker.SetTitle(customPins.Pin.Label);
                    marker.SetSnippet(customPins.Pin.Address);
                    marker.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueRed));
                    //marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
                    //marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));

                    MapMarkerAll = map.AddMarker(marker);
                    //customPins = fNewCustomPins.CustomPins;
                }
            }
            ClickTitle = false;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (changed)
            {
                isDrawn = false;
                ClickTitle = false;
            }
        }

        void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin == null)
            {
                throw new Exception("Custom pin not found");
            }

            if (!string.IsNullOrWhiteSpace(customPin.Url))
            {
                var url = Android.Net.Uri.Parse(customPin.Url);
                var intent = new Intent(Intent.ActionView, url);
                intent.AddFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetCustomPin(marker);
                if (customPin == null)
                {
                    throw new Exception("Custom pin not found");
                }

                if (customPin.Id == "Xamarin")
                {
                    view = inflater.Inflate(Resource.Layout.XamarinMapInfoWindow, null);
                }
                else
                {
                    view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                }

                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }
                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = marker.Snippet;
                }
                ClickTitle = true;

                return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        CustomPin GetCustomPin(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);

            if (customPins.Pin.Position == position)
            {
                return customPins;
            }
            else
            {
                customPins.Pin.Position = position;
                customPins.Pin.Address = annotation.Title;
                customPins.Pin.Label = "Vị trí phản ánh";
                // MapMarkerAll = annotation;
                customPins.Id = annotation.Id;
                return customPins;
            }
            return null;
        }
    }
}

