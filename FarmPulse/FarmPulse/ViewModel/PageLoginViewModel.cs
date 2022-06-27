using FarmPulse.Control;
using FarmPulse.Net;
using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
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
            //InsuranceNumber = "12345";
            //Password = "1234";
        }

        public ICommand ClickLoginCommand => new Command(ClickLogin);
       
        public async void ClickLogin()
        {
            if (!ControlApp.Instance.InternetOk())
                return;

            ControlApp.ShowLoadingView(RSC.PleaseWait);
            RequestLogin request = new RequestLogin()
            {
                username = InsuranceNumber,
                password = Password,
                langCode = AppSettings.GetLanguageCode
            };
            ResponseLogin response = await HttpService.Login(request);
            if (response.result)
            {
                ControlApp.UserInfo = response.userInfo;
                ControlApp.SystemStatus = LogInOut.LogIn;
                Application.Current.MainPage = new TransitionNavigationPage(new PageMain());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, RSC.LoginMessage, RSC.Ok);
            }
            ControlApp.CloseLoadingView();

            if (CheckAutoLogin)
                Preferences.Set("AutoLogin", $"{InsuranceNumber}/{Password}");
            else
                Preferences.Set("AutoLogin", "");
        } 
    }
}
