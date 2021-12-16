using System;
using Xamarin.Forms;

using FarmPulse.Pages;
using FarmPulse.Control;
using FarmPulse.Resources;
using FarmPulse.Pages.Purchase;
using FarmPulse.Pages.Purchase.SubmitClaim;
using FarmPulse.Pages.Purchase.PurchaseInsurance;
using System.Threading;
using System.Globalization;

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
        }

        protected override void OnStart()
        {
            ControlApp.Instance.AppStarting = true;
            ControlApp.Instance.AppOnResume = false;
            ControlApp.Instance.AppOnSleep = false;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;

            string strLanguage = AppSettings.GetLanguage();
            if (strLanguage == string.Empty)
            {
                MainPage = new TransitionNavigationPage(new PageLanguage());
            }
            else
            {
                AppSettings.SetLanguage(strLanguage);

                switch (ControlApp.Instance.SystemStatus)
                {
                    case LogInOut.LogIn:
                        MainPage = new TransitionNavigationPage(new PageFieldList());
                        break;
                    case LogInOut.LogOut:
                        MainPage = new TransitionNavigationPage(new PageLogin());
                        break;
                }
            }
        }

        protected override void OnSleep()
        {
            ControlApp.Instance.AppOnSleep = true;
        }

        protected override void OnResume()
        {
            ControlApp.Instance.AppOnResume = true;
        }
    }
}
