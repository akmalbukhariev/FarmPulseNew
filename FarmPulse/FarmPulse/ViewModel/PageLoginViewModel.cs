using FarmPulse.Control;
using FarmPulse.Net;
using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageLoginViewModel : BaseModel
    {
        public string InsuranceNumber { get => GetValue<string>(); set => SetValue(value); }
        public string Password { get => GetValue<string>(); set => SetValue(value); }
        public bool CheckAutoLogin { get => GetValue<bool>(); set => SetValue(value); }
          
        public PageLoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
            InsuranceNumber = "998977";
            Password = "123";
        }

        public ICommand ClickLoginCommand => new Command(ClickLogin);
       
        private async void ClickLogin()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);
            RequestLogin request = new RequestLogin()
            {
                username = InsuranceNumber,
                password = Password,
                langCode = "uz"//AppSettings.GetLanguageCode
            };
            ResponseLogin response = await HttpService.Login(request);
            if (response.result)
            {
                ControlApp.UserInfo = response.userInfo;
                Application.Current.MainPage = new TransitionNavigationPage(new PageMain());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, response.message, RSC.Ok);
            }
            ControlApp.CloseLoadingView();
        } 
    }
}
