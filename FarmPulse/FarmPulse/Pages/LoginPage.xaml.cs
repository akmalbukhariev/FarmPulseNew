
using FarmPulse.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    { 
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginPageModelView(Navigation);
        }

        private void AutoLogin_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

        }

        private void FindLabel_Tapped(object sender, System.EventArgs e)
        {

        }
    }
}