using FarmPulse.ViewModel.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages.Purchase
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
        }
    }
}