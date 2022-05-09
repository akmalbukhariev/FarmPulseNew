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

        protected async void ClickAnimationView<T>(T view) where T : View
        {
            await view.ScaleTo(0.8, 200);
            await view.ScaleTo(1, 200, Easing.SpringOut);
        }
    }
}
