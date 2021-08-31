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

        private INavigation Navigate;

        public LoginPageModelView(INavigation navigation)
        {
            Navigate = navigation;
        }

        public ICommand ClickLoginCommand => new Command(ClickLogin);
       
        private void ClickLogin()
        {
            
        } 
    }
}
