using System;
using System.Collections.Generic;
using System.Text;

namespace FarmPulse.Model
{
    public class LongLat : IEquatable<LongLat>
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LongLat(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public LongLat()
        {
            Init();
        }

        public void Init()
        {
            this.Latitude = 0.0;
            this.Longitude = 0.0;
        }

        public void Copy(LongLat other)
        {
            this.Latitude = other.Latitude;
            this.Longitude = other.Longitude;
        }

        public bool Equals(LongLat other)
        {
            if (Latitude != other.Latitude) return false;
            if (Longitude != other.Longitude) return false;

            return true;
        }
    }
}
