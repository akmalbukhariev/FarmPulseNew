using FarmPulse.ViewModel.Purchase.PurchaseInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages.Purchase.PurchaseInsurance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageShowPurchasedHistory : IPage
    {
        private PageShowPurchasedHistoryViewModel model;
        public PageShowPurchasedHistory()
        {
            InitializeComponent();
            model = new PageShowPurchasedHistoryViewModel(Navigation);
            BindingContext = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;
            model.GetSubmitedHistory();
        }

        private async void Purchased_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (model.SelectedItem != null)
            {
                model.SetTransitionType(TransitionType.SlideFromRight);
                await Navigation.PushAsync(new PageDetailPurchasedInsuranceHistory(model.SelectedItem));
            }
        }
    }
}