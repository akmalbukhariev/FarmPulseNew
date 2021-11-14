using FarmPulse.Net; 
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
    public partial class PageDetailSubmitedClaimHistory : IPage
    {
        private PageDetailSubmitedHistoryViewModel model;
        public PageDetailSubmitedClaimHistory(SubmitedClaimHistoryInfo info)
        {
            InitializeComponent();
            model = new PageDetailSubmitedHistoryViewModel(info);
            BindingContext = model;
        } 
    }
}