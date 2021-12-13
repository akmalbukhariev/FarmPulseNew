 
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageConfirmationViewModel : BaseModel
    { 
        public PageConfirmationViewModel(INavigation navigation)
        {
            Navigation = navigation; 
        }

        public ICommand ClickStartNewClaimCommand => new Command(StartNewClaim);
        public ICommand ClickBackHomeCommand => new Command(BackToHome);

        private async void StartNewClaim()
        {
            await Navigation.PopAsync();
        }

        private async void BackToHome()
        {
            await Navigation.PopToRootAsync();
        }
    }
}
