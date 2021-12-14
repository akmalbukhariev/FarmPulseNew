using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FarmPulse.Control;
using FarmPulse.Droid.Renderers;
using FarmPulse.Model;
using Java.Util.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using static FarmPulse.Control.CustomMap;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]

namespace FarmPulse.Droid.Renderers
{
    [Obsolete]
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        private GoogleMap _googleMap;
        private CustomMap _customMap;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _customMap = (CustomMap)e.NewElement;

                if (_customMap != null)
                {
                    _customMap.EventSetMapTypeDel += EventClickMapType;
                    _customMap.EventSetOverlayImageDel += EventSetOverlayImageDel;
                }

                ((MapView)Control).GetMapAsync(this);
            }
        }
         
        private void DrawPolygonDel()
        {
            if (_googleMap == null) return;

            MoveMap();

            if (_customMap.Polygon.Count != 0)
            {
                PolygonOptions option = new PolygonOptions();
                option.InvokeFillColor(0x66FF0000);

                foreach (LongLat var in _customMap.Polygon)
                {
                    option.Add(new LatLng(var.Latitude, var.Longitude));
                }

                #region
                //MarkerOptions markerOpt = new MarkerOptions();
                //markerOpt.SetPosition(new LatLng(fieldData.Position.Latitude, fieldData.Position.Longitude));
                //markerOpt.SetTitle(fieldData.FieldName);
                //_googleMap.AddMarker(markerOpt);
                #endregion

                _googleMap.AddPolygon(option);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            _googleMap = googleMap;
            InitGoogleMap();
            if (_customMap != null)
            {
                _customMap.MapHasLoaded();
                DrawPolygonDel();
            }
        }

        private void InitGoogleMap()
        {
            _googleMap.UiSettings.CompassEnabled = true;
            _googleMap.SetInfoWindowAdapter(this);
            _googleMap.UiSettings.ZoomControlsEnabled = true;
            //_googleMap.UiSettings.ZoomGesturesEnabled = true;
            //_googleMap.UiSettings.TiltGesturesEnabled = true;
            _googleMap.UiSettings.MyLocationButtonEnabled = true;
            //_googleMap.UiSettings.MapToolbarEnabled = true;
        }

        private void EventClickMapType(CustomMapType type)
        {
            if (_googleMap == null) return;

            switch (type)
            {
                case CustomMapType.Hybrid:
                    if (_googleMap.MapType != GoogleMap.MapTypeHybrid)
                        _googleMap.MapType = GoogleMap.MapTypeHybrid;
                    break;
                case CustomMapType.Normal:
                    if (_googleMap.MapType != GoogleMap.MapTypeNormal)
                        _googleMap.MapType = GoogleMap.MapTypeNormal;
                    break;
                case CustomMapType.Terrain:
                    if (_googleMap.MapType != GoogleMap.MapTypeTerrain)
                        _googleMap.MapType = GoogleMap.MapTypeTerrain;
                    break;
                case CustomMapType.Satellite:
                    if (_googleMap.MapType != GoogleMap.MapTypeSatellite)
                        _googleMap.MapType = GoogleMap.MapTypeSatellite;
                    break;
            }
        }

        private void EventSetOverlayImageDel()
        {
            if (_customMap.OverlayImage.Length == 0) return;

            _googleMap.Clear();
            Bitmap bmp = BitmapFactory.DecodeByteArray(_customMap.OverlayImage, 0, _customMap.OverlayImage.Length);
            BitmapDescriptor image = BitmapDescriptorFactory.FromBitmap(bmp);

            GroundOverlayOptions groundOverlayOptions = new GroundOverlayOptions();
            groundOverlayOptions.Anchor(0, 1);
            groundOverlayOptions.PositionFromBounds(new LatLngBounds(new LatLng(_customMap.minLat, _customMap.minLon), new LatLng(_customMap.maxLat, _customMap.maxLon)));
            groundOverlayOptions.InvokeImage(image);

            _googleMap.AddGroundOverlay(groundOverlayOptions);
        }
          
        private void MoveMap()
        {
            LatLng location = new LatLng(_customMap.Ceneter.Latitude, _customMap.Ceneter.Longitude);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom((float)11.5);
            //builder.Bearing(155);
            //builder.Tilt(65);

            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            _googleMap.MoveCamera(cameraUpdate);
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Context.LayoutInflaterService) as Android.Views.LayoutInflater;

            if (inflater != null)
            {
                //Android.Views.View view;

                //var customPin = GetCustomPin(marker);
                //if (customPin == null)
                //{
                //    throw new Exception("Custom pin not found");
                //}

                //view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);

                //var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                //var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

                //if (infoTitle != null)
                //{
                //    infoTitle.Text = marker.Title;
                //}
                //if (infoSubtitle != null)
                //{
                //    infoSubtitle.Text = marker.Snippet;
                //}

                //return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        #region Helper
        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);

        //    if (e.PropertyName.Equals("VisibleRegion") && !_isDrawn)
        //    {
        //        _map.Clear();

        //        foreach (var pin in _customPins)
        //        {
        //            var marker = new MarkerOptions();

        //            marker.SetPosition(new LatLng(pin.Pin.Position.Latitude, pin.Pin.Position.Longitude));

        //            marker.SetTitle(pin.Pin.Label);

        //            marker.SetSnippet(pin.Pin.Address);

        //            //marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));

        //            _map.AddMarker(marker);
        //        }

        //        _isDrawn = true;
        //    }
        //}

        //protected override void OnLayout(bool changed, int l, int t, int r, int b)
        //{
        //    base.OnLayout(changed, l, t, r, b);

        //    if (changed)
        //    {
        //        _isDrawn = false;
        //    }
        //}

        //void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        //{
        //    var customPin = GetCustomPin(e.Marker);

        //    if (customPin == null)
        //    {
        //        throw new Exception("Custom pin not found");
        //    }

        //    if (!string.IsNullOrWhiteSpace(customPin.Url))
        //    {
        //        var url = Android.Net.Uri.Parse(customPin.Url);

        //        var intent = new Intent(Intent.ActionView, url);

        //        intent.AddFlags(ActivityFlags.NewTask);

        //        Android.App.Application.Context.StartActivity(intent);
        //    }
        //} 

        //CustomPin GetCustomPin(Marker annotation)
        //{
        //    var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);

        //    foreach (var pin in _customPins)
        //    {
        //        if (pin.Pin.Position == position)
        //        {
        //            return pin;
        //        }
        //    }
        //    return null;
        //}
        #endregion
    }
}