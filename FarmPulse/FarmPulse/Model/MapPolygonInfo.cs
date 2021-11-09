using System;
using System.Collections.Generic;
using System.Text;

namespace FarmPulse.Model
{
    public class MapPolygonInfo
    {
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
        public byte[] OverlayImage = new byte[0];

        public string polygonId { get; set; }
        public List<double> center { get; set; }
        public double area { get; set; }

        public LongLat Position { get; set; }
        public List<LongLat> Polygon { get;  set; }
    }
}
