using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.Model
{
    public class SatelliteData :  FarmPulse.ModelView.BaseModel
    {
        public string Date { get => GetValue<string>(); set => SetValue(value); }
        public string ImagePath { get => GetValue<string>(); set => SetValue(value); } 
    }
}
