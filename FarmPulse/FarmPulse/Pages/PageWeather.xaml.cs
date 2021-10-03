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
    public partial class WeatherPage : IPage
    {
        private PageWeatherViewModel model;
        public WeatherPage()
        {
            InitializeComponent();
            model = new PageWeatherViewModel();
            BindingContext = model; 
        }
    }
}