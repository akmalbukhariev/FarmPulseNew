using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
