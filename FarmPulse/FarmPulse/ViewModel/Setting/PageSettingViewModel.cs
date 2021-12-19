using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageSettingViewModel : BaseModel
    { 
        public PageSettingViewModel(INavigation navigation)
        {
            Navigation = navigation; 
        }
    }
}
