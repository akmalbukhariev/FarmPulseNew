using FarmPulse.ModelView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ViewModel
{
    class PageFindPasswordViewModel : BaseModel
    {
        public string Insurance { get => GetValue<string>(); set => SetValue(value); }
        public string Date { get => GetValue<string>(); set => SetValue(value); }
        public string PhoneNumber { get => GetValue<string>(); set => SetValue(value); }
        public string District { get => GetValue<string>(); set => SetValue(value); }

        public PageFindPasswordViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
    }
}
