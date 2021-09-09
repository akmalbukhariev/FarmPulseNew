using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace FarmPulse.Control
{
    public class CustomMap : Map
    {
        public enum CustomMapType
        {
            Satellite,
            Hybrid,
            Normal,
            Terrain
        }
    }
}
