
using FarmPulse.Control;
using FarmPulse.ModelView;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FarmPulse.Pages
{
    public partial class PageMain : IPage
    {
        PageMainViewModel model;
        public PageMain()
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

        private async void Setting_Tapped(object sender, System.EventArgs e)
        {
            ControlApp.Vibrate();
            ClickAnimationView((Image)sender);

            await Navigation.PushAsync(new Pages.PageSetting());
        }

        private async void Logout_Tapped(object sender, System.EventArgs e)
        {
            ControlApp.Vibrate();
            ClickAnimationView((Image)sender);

            bool res = await Application.Current.MainPage.DisplayAlert(RSC.LogOut, RSC.LogOutMessage, RSC.Ok, RSC.Cancel);
            if (res)
            {
                Preferences.Set("AutoLogin", "");
                ControlApp.SystemStatus = LogInOut.LogOut;
                Application.Current.MainPage = new TransitionNavigationPage(new PageLogin());
            }
        }
    }
}
