using FarmPulse.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFindPassword : IPage
    {
        private PageFindPasswordViewModel model;
        public PageFindPassword()
        {
            InitializeComponent();
            model = new PageFindPasswordViewModel(Navigation);
            BindingContext = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.GetCountrys();
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == pickCountry)
            {
                if (model.SelectedCountry != null)
                    model.GetRegions();
            }
            else if (sender == pickRegion)
            {
                if (model.SelectedRegion != null)
                    model.GetDistricts();
            }
        }
    }
}