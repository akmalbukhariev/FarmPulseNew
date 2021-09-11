using FarmPulse.ModelView;
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
    public partial class CropYieldDataPage : ContentPage
    {
        private CropYieldDataPageViewModel model;
        public CropYieldDataPage()
        {
            InitializeComponent();
            InitPage();

            model = new CropYieldDataPageViewModel();
            BindingContext = model;

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void InitPage()
        {
            lbText.Text = "Please, enter the crop yield information in \n order to compare with insurance index \n values. Use ton/ha units.";
        }
    }
}