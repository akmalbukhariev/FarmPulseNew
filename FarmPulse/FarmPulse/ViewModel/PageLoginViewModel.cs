using FarmPulse.Control;
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
        }

        public ICommand ClickLoginCommand => new Command(ClickLogin);
       
        private void ClickLogin()
        { 
            Application.Current.MainPage = new TransitionNavigationPage(new MainPage());
        } 
    }
}
