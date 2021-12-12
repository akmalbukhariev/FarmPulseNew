using FarmPulse.Pages;
using FarmPulse.Pages.Purchase; 
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PagePurchaseViewModel : BaseModel
    { 
        public PagePurchaseViewModel(INavigation navigation)
        {
            Navigation = navigation; 
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
            //await Navigation.PushAsync(new PageInfo("Insurance"));
        }

        /// <summary>
        /// Index insurance
        /// </summary>
        private async void ClickIndexInsurance()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new PageFieldList(true));
        }

        /// <summary>
        /// Estimate rates
        /// </summary>
        private async void ClickEstimate()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            //await Navigation.PushAsync(new PageInfo("Estimate"));
        }

        /// <summary>
        /// Cover
        /// </summary>
        private async void ClickCover()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            //await Navigation.PushAsync(new PageInfo("Cover"));
        }

        /// <summary>
        /// Submitting Claim
        /// </summary>
        private async void ClickSubmitClaim()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new Pages.Purchase.SubmitClaim.PageSubmitClaim());
        }

        /// <summary>
        /// FAQ
        /// </summary>
        private async void ClickFAQ()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            //await Navigation.PushAsync(new PageInfo("FAQ"));
        }

        /// <summary>
        /// Buy Now
        /// </summary>
        private async void ClickBuy()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new Pages.Purchase.PurchaseInsurance.PagePurchaseInsurance());
        }
    }
}
