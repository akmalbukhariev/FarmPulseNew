using FarmPulse.Control;
using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class LoginPageModelView : BaseModel
    {
        public bool CheckAutoLogin { get => GetValue<bool>(); set => SetValue(value); }
          
        public LoginPageModelView(INavigation navigation)
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
