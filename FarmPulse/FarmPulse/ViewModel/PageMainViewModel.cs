using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageMainViewModel :  BaseModel
    { 
        public string CropMonitoring { get => GetValue<string>(); set => SetValue(value); }
        public string CropInsurance { get => GetValue<string>(); set => SetValue(value); }
        public string WeatherInformation { get => GetValue<string>(); set => SetValue(value); }
        public PageMainViewModel(INavigation navigation)
        {
            Navigation = navigation;

            CropMonitoring = "Crop Monitoring";
            CropInsurance = "Crop Insurance";
            WeatherInformation = "Weather Information"; 
        }

        public ICommand ClickMonitorCommand => new Command(Monitoring);
        public ICommand ClickInsuranceCommand => new Command(Insurance);
        public ICommand ClickWeatherInformationCommand => new Command(WeatherInfo);

        /// <summary>
        /// Crop Monitoring
        /// </summary>
        async void Monitoring()
        {
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new PageFieldList());
        }

        /// <summary>
        /// Crop Insurance
        /// </summary>
        async void Insurance()
        {
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new PagePurchase());
        }

        /// <summary>
        /// Weather Information
        /// </summary>
        async void WeatherInfo()
        {
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new PageWeather());
        }
    }
}
