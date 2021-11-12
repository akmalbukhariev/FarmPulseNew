using System;
using Xamarin.Forms;

using FarmPulse.Pages;
using FarmPulse.Control;
using FarmPulse.Resources;

namespace FarmPulse
{
    internal class RSC : AppResource
    {
  
    }
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
             
            MainPage = new TransitionNavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
