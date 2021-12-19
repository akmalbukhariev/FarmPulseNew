using FarmPulse.ModelView;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ViewModel
{
    class PageFindPasswordViewModel : BaseModel
    { 
        public string Insurance { get => GetValue<string>(); set => SetValue(value); }  

        public PageFindPasswordViewModel(INavigation navigation)
        {
            Navigation = navigation; 
        }

        public ICommand ClickOkCommand => new Command(ClickOk);
  
        private async void ClickOk()
        { 
            if (SelectedDistrict == null || string.IsNullOrEmpty(Insurance) || string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Date))
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, RSC.FindInsuranceMessage1, RSC.Ok);
                return;
            }

            ControlApp.ShowLoadingView(RSC.PleaseWait);
            RequestFindPassword request = new RequestFindPassword()
            {
                insurance = Insurance,
                birthday = Date,
                phoneNumber = PhoneNumber,
                districtId = SelectedDistrict.id.ToString(),
                langCode = AppSettings.GetLanguageCode
            };

            ResponseFindPassword response = await HttpService.FindPassword(request);
            if (response.result)
            {
                string description = $"{RSC.YourPassword} {response.password}";
                ControlApp.ShowNotification(description, RSC.Password);
                await Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, RSC.FindInsuranceMessage2, RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }
    }
}
