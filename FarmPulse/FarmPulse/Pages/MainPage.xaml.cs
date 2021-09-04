
using FarmPulse.ModelView;
using Xamarin.Forms;

namespace FarmPulse.Pages
{
    public partial class MainPage : ContentPage
    {
        MainPageModelView model;
        public MainPage()
        {
            InitializeComponent();
            
            model = new MainPageModelView(Navigation);
            BindingContext = model;

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        { 
            base.OnAppearing();
            model.Parent = Parent;
        }
    }
}
