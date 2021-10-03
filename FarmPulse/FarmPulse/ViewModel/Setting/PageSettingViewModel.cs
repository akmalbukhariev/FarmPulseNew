using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageSettingViewModel : BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string Demo { get => GetValue<string>(); set => SetValue(value); }
        public string Language { get => GetValue<string>(); set => SetValue(value); }
        public string About { get => GetValue<string>(); set => SetValue(value); }

        public PageSettingViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Title = "Setting";
            Demo = "Demo";
            Language = "Language";
            About = "About";
        }
    }
}
