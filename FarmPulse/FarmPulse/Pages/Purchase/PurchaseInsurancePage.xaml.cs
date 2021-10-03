using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FarmPulse.ModelView;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PurchaseInsurancePage : IPage
    {
        private PagePurchaseInsuranceViewModel model;

        public PurchaseInsurancePage()
        {
            InitializeComponent();
            model = new PagePurchaseInsuranceViewModel(Navigation);
            BindingContext = model; 
        }
    }
}