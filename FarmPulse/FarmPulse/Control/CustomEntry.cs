﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.Control
{
    public class CustomEntry : Entry
    {
        public Color TextColorForIOS { get; set; }

        public CustomEntry()
        {
            TextColorForIOS = Color.Black;
        }
    }
}
