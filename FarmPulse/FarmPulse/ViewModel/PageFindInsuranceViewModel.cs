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
    class PageFindInsuranceViewModel : BaseModel
    {  
        public PageFindInsuranceViewModel(INavigation navigation)
        {
            Navigation = navigation; 
        }

        public ICommand ClickOkCommand => new Command(ClickOk);
         
        private async void ClickOk()
        {
            if (SelectedDistrict == null || string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Date))
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, RSC.FindInsuranceMessage1, RSC.Ok);
                return;
            }

            ControlApp.ShowLoadingView(RSC.PleaseWait);
            RequestFindInsurance request = new RequestFindInsurance()
            {
                birthday = Date,
                phoneNumber = PhoneNumber,
                districtId = SelectedDistrict.id.ToString(),
                langCode = AppSettings.GetLanguageCode
            };

            ResponseFindInsurance response = await HttpService.FindInsurance(request);
            if (response.result)
            {
                string description = $"{RSC.YourInsuranceNumber} {response.insurance}";
                ControlApp.ShowNotification(description, RSC.InsuranceNumber);
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
