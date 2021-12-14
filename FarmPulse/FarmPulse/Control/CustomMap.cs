using FarmPulse.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace FarmPulse.Control
{
    public class CustomMap : Map
    {
        public delegate void MapHasLoadedDel();
        public event MapHasLoadedDel EventMapHasLoaded;
         
        public delegate void SetMapTypeDel(CustomMapType type);
        public event SetMapTypeDel EventSetMapTypeDel;

        public delegate void SetOverlayImageDel();
        public event SetOverlayImageDel EventSetOverlayImageDel;

        public double minLat { get; set; }
        public double minLatLon { get; set; }

        public double maxLat { get; set; }
        public double maxLatLon { get; set; }

        public double minLon { get; set; }
        public double minLonLat { get; set; }

        public double maxLon { get; set; }
        public double maxLonLat { get; set; }

        public float Width = 1;
        public float Height = 1;

        public List<LongLat> Polygon { get; set;}
        public LongLat Ceneter { get; set; }

        public byte[] OverlayImage = new byte[0];
        public enum CustomMapType
        {
            Satellite,
            Hybrid,
            Normal,
            Terrain
        }

        public void MapHasLoaded()
        {
            EventMapHasLoaded?.Invoke();
        }
         
        public void SetMapType(CustomMapType type)
        {
            EventSetMapTypeDel?.Invoke(type);
        }

        public void SetOverlayImage()
        {
            EventSetOverlayImageDel?.Invoke();
        }
    }
}
