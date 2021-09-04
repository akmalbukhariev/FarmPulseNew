using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class MainPageModelView :  BaseModel
    { 
        public MainPageModelView(INavigation navigation)
        {
            Navigation = navigation;
        }

        public ICommand ClickMonitorCommand => new Command(Monitoring);
        public ICommand ClickInsuranceCommand => new Command(Insurance);
        public ICommand ClickInformationCommand => new Command(Information);

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
        void Insurance()
        {
            
        }

        /// <summary>
        /// Weather Information
        /// </summary>
        void Information()
        {
            
        }
    }
}
