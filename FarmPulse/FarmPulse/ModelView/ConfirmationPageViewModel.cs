 
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class ConfirmationPageViewModel : BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string Title1 { get => GetValue<string>(); set => SetValue(value); }
        public string Title2 { get => GetValue<string>(); set => SetValue(value); }
        public string StartNewClaimButtonText { get => GetValue<string>(); set => SetValue(value); }
        public string BackToHomeButtonText { get => GetValue<string>(); set => SetValue(value); }
        public ConfirmationPageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Title = "Confirmation";
            Title1 = "Your application has been submitted \n successfully.";
            Title2 = "Please note: The insurance agent as sson as \n will get in touch within 5 business days.";
            StartNewClaimButtonText = "Start New Claim";
            BackToHomeButtonText = "Back to Home Screen";
        }

        public ICommand ClickStartNewClaimCommand => new Command(StartNewClaim);
        public ICommand ClickBackHomeCommand => new Command(BackToHome);

        private void StartNewClaim()
        {
            
        }

        private void BackToHome()
        {
            
        }
    }
}
