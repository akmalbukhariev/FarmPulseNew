using FarmPulse.ModelView;
  
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummitClaimPage : ContentPage
    {
        private SummitClaimPageViewModel model;
        public SummitClaimPage()
        {
            InitializeComponent();
            model = new SummitClaimPageViewModel();
            BindingContext = model;

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}