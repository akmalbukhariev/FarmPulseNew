using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ModelView.Purchase
{
    public class PageInfoViewModel : BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string InfoText { get => GetValue<string>(); set => SetValue(value); }

        public PageInfoViewModel(INavigation navigation, string title)
        {
            Navigation = navigation;
            Title = title;
        }
    }
}
