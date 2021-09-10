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
    public partial class IndexInsurancePage : ContentPage
    {
        private IndexInsurancePageViewModel model;
        public IndexInsurancePage()
        {
            InitializeComponent();
            model = new IndexInsurancePageViewModel();
            BindingContext = model;

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}