using FarmPulse.Control;
using FarmPulse.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSetting : IPage
    {
        private PageSettingViewModel model;
        public PageSetting()
        {
            InitializeComponent();
            model = new PageSettingViewModel(Navigation);
            BindingContext = model; 
        }

        private async void TableCell_Tapped(object sender, EventArgs e)
        {
            model.Parent = Parent;
            model.SetTransitionType(TransitionType.SlideFromRight);

            if (sender == cellDemo)
            {
                await Navigation.PushAsync(new PageDemo());
            }
            else if (sender == cellLanguage)
            {
                await Navigation.PushAsync(new PageLanguage(false));
            }
            else if (sender == cellAbout)
            {
                await Navigation.PushAsync(new PageInfo());
            }
        } 

        private async void BtnLogOut_Clicked(object sender, EventArgs e)
        {
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