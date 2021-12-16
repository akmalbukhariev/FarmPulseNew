using FarmPulse.ViewModel.Purchase;
using FarmPulse.ViewModel.Purchase.SubmitClaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages.Purchase.SubmitClaim
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageShowSubmitedHistory : IPage
    {
        private PageShowSubmitedHistoryViewModel model;
        public PageShowSubmitedHistory()
        {
            InitializeComponent();
            model = new PageShowSubmitedHistoryViewModel(Navigation);
            BindingContext = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;
            
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            model.GetSubmitedHistory();
        }

        private async void ClaimList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            if (model.SelectedItem != null)
            {
                model.SetTransitionType(TransitionType.SlideFromRight);
                await Navigation.PushAsync(new PageDetailSubmitedClaimHistory(model.SelectedItem));
            }
        }
    }
}