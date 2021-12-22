
using Acr.UserDialogs;
using FarmPulse.ModelView;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLogin : IPage
    {
        bool appeared = false;

        private PageLoginViewModel model;

        public PageLogin()
        {
            InitializeComponent();
            
            model = new PageLoginViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!ControlApp.AppStarting) return;
            ControlApp.AppStarting = false;

            appeared = false;
            model.CheckAutoLogin = false;
            string[] ll = Preferences.Get("AutoLogin", "").Split('/');
            if (ll.Length == 2)
            {
                model.InsuranceNumber = ll[0];
                model.Password = ll[1];
                model.ClickLogin();
                model.CheckAutoLogin = true;
            }

            appeared = true;

            model.Parent = Parent;
            demoInfoView.Parent = Parent;
        }

        private async void AutoLogin_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!appeared) return;

            if (!model.CheckAutoLogin) return;

            bool res = await DisplayAlert(RSC.AutoLogin, RSC.AutoLogMessage, RSC.Ok, RSC.Cancel);
            if (!res)
            {
                model.CheckAutoLogin = false;
                Preferences.Set("AutoLogin", "");
                return;
            }
        }

        private async void LabelFind_Tapped(object sender, System.EventArgs e)
        { 
            ChangeClickBackColor(lbFindPassword);

            var choices = new[] { RSC.FindInsuracne, RSC.FindPassword }; 
            var choice = await DisplayActionSheet(RSC.FindInsurancePassword, RSC.Cancel, null, choices);
            if (!string.IsNullOrEmpty(choice) && (choice == RSC.FindInsuracne || choice == RSC.FindPassword))
            {
                model.SetTransitionType(TransitionType.SlideFromRight);

                if (choice.Equals(RSC.FindInsuracne))
                {
                    await Navigation.PushAsync(new PageFindInsurance());
                }
                else
                {
                    await Navigation.PushAsync(new PageFindPassword());
                }
            }
        }

        private async void ChangeClickBackColor(Label label)
        {
            label.TextColor = Color.White;
            await Task.Delay(100);

            label.TextColor = Color.FromHex("#007A43");
            await Task.Delay(200);
        } 
    }
}