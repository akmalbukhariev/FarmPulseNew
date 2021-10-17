using FarmPulse.Control;
using FarmPulse.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms; 

namespace FarmPulse.Pages
{
    public class IPage : ContentPage
    {
        public FieldInfo FieldInfo { get; set; }
        protected ControlApp ControlApp => ControlApp.Instance;
        public IPage()
        {
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
