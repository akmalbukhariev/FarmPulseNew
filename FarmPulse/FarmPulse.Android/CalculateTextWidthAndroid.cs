using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using FarmPulse.Interface;
using FarmPulse.Droid;
using Android.Graphics;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(CalculateTextWidthAndroid))]

namespace FarmPulse.Droid
{
    public class CalculateTextWidthAndroid : ICalculateTextWidth
    {
        public double calculateWidth(string text)
        {
            Android.Graphics.Rect bounds = new Android.Graphics.Rect();
            TextView textView = new TextView(Forms.Context);
            textView.Paint.GetTextBounds(text, 0, text.Length, bounds);
            var length = bounds.Width();
            return length / Android.Content.Res.Resources.System.DisplayMetrics.ScaledDensity;
        }

        /* For the iOS
        public double calculateWidth (string text)
        {
            uiLabel = new UILabel ();
            uiLabel.Text = text;
            length = uiLabel.Text.StringSize (uiLabel.Font);
            return length.Width;
        }
        */
    }
}