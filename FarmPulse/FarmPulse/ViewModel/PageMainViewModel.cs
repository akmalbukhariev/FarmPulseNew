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
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new FieldListPage());
        }

        /// <summary>
        /// Crop Insurance
        /// </summary>
        async void Insurance()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new PurchasePage());
        }

        /// <summary>
        /// Weather Information
        /// </summary>
        async void WeatherInfo()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new WeatherPage());
        }
    }
}
