using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class LanguagePageModelView : BaseModel
    {
         
        private INavigation Navigation;

        public LanguagePageModelView(INavigation navigation)
        {
            Navigation = navigation;
        }

        public ICommand ClickSaveCommand => new Command(ClickSave);

        private void ClickSave()
        {
            
        }
    }
}
