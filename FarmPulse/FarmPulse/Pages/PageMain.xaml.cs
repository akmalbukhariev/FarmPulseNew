
using FarmPulse.ModelView;
using Xamarin.Forms;

namespace FarmPulse.Pages
{
    public partial class MainPage : IPage
    {
        PageMainViewModel model;
        public MainPage()
        {
            InitializeComponent();
            
            model = new PageMainViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        { 
            base.OnAppearing();
            model.Parent = Parent;
        }
    }
}
