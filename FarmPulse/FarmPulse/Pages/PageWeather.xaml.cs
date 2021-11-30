using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FarmPulse.ModelView;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageWeather : IPage
    {
        private PageWeatherViewModel model;
        public PageWeather()
        {
            InitializeComponent();
            model = new PageWeatherViewModel();
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;
            model.RefreshModel();
        }
    }
}