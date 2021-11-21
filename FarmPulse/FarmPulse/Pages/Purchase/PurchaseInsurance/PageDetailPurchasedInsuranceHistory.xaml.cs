using FarmPulse.Net;
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
    public partial class PageDetailPurchasedInsuranceHistory : IPage
    {
        private PageDetailPurchasedHistoryViewModel model;
        public PageDetailPurchasedInsuranceHistory(SubmitedPurchaseHistoryInfo info)
        {
            InitializeComponent();
            model = new PageDetailPurchasedHistoryViewModel(info, Navigation);
            BindingContext = model;
        }
    }
}