
using FarmPulse.ModelView;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private LoginPageModelView model;
        public LoginPage()
        {
            InitializeComponent();
            
            model = new LoginPageModelView(Navigation);
            BindingContext = model;

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;
        }

        private async void AutoLogin_CheckedChanged(object sender, CheckedChangedEventArgs e)
        { 
            if (!model.CheckAutoLogin) return;

            bool res = await DisplayAlert("자동로그인", "자동로그인을 하시면 다음부터 회원아이디와 비밀번호를 입력하실 필요가 없습니다.자동로그인을 사용하시겠습니까? ", "확인", "취소");
            if (!res)
            {
                model.CheckAutoLogin = false;
                //Preferences.Set("AutoLogin", "");
                return;
            }
        }

        private void LabelFind_Tapped(object sender, System.EventArgs e)
        { 
            ChangeClickBackColor(lbFindPassword); 
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