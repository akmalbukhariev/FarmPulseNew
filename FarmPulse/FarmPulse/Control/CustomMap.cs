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

        public delegate void DrawPolygonDel();
        public event DrawPolygonDel EventDrawPolygonDel;

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

        public void DrawPolygon()
        {
            EventDrawPolygonDel?.Invoke();
        }
    }
}
