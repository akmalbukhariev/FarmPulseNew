using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PurchasePageModelView : BaseModel
    {
        public string Purchase { get => GetValue<string>(); set => SetValue(value); }
        public string Insurance { get => GetValue<string>(); set => SetValue(value); }
        public string IndexInsurance { get => GetValue<string>(); set => SetValue(value); }
        public string EstimateRates { get => GetValue<string>(); set => SetValue(value); }
        public string Cover { get => GetValue<string>(); set => SetValue(value); }
        public string SubmittingClaim { get => GetValue<string>(); set => SetValue(value); }
        public string FAQ { get => GetValue<string>(); set => SetValue(value); }
        public string ButtonBuyText { get => GetValue<string>(); set => SetValue(value); }
        public PurchasePageModelView(INavigation navigation)
        {
            Navigation = navigation;

            Purchase = "Purchase";
            Insurance = "Insurance";
            IndexInsurance = "Index insurance";
            EstimateRates = "Estimate rates";
            Cover = "Cover";
            SubmittingClaim = "Submitting Claim";
            FAQ = "FAQ";
            ButtonBuyText = "BUY NOW";
        }

        public ICommand ClickInsuranceCommand => new Command(ClickInsurance);
        public ICommand ClickIndexInsuranceCommand => new Command(ClickIndexInsurance);
        public ICommand ClickEstimateCommand => new Command(ClickEstimate);
        public ICommand ClickCoverCommand => new Command(ClickCover);
        public ICommand ClickSubmitClaimCommand => new Command(ClickSubmitClaim);
        public ICommand ClickFAQCommand => new Command(ClickFAQ);
        public ICommand ClickBuyCommand => new Command(ClickBuy);

        /// <summary>
        /// Insurance
        /// </summary>
        private async void ClickInsurance()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            //await Navigation.PushAsync()
        }

        /// <summary>
        /// Index insurance
        /// </summary>
        private async void ClickIndexInsurance()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            //await Navigation.PushAsync()
        }

        /// <summary>
        /// Estimate rates
        /// </summary>
        private async void ClickEstimate()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            //await Navigation.PushAsync()
        }

        /// <summary>
        /// Cover
        /// </summary>
        private async void ClickCover()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            //await Navigation.PushAsync()
        }

        /// <summary>
        /// Submitting Claim
        /// </summary>
        private async void ClickSubmitClaim()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            //await Navigation.PushAsync()
        }

        /// <summary>
        /// FAQ
        /// </summary>
        private async void ClickFAQ()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            //await Navigation.PushAsync()
        }

        /// <summary>
        /// Buy Now
        /// </summary>
        private async void ClickBuy()
        {
             
        }
    }
}
