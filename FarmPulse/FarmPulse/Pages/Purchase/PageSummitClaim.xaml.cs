using FarmPulse.ModelView;
  
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummitClaimPage : IPage
    {
        private PageSummitClaimViewModel model;
        public SummitClaimPage()
        {
            InitializeComponent();
            model = new PageSummitClaimViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            model.Parent = Parent;
        }
    }
}