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
    public partial class PurchasePage : IPage
    {
        private PagePurchaseViewModel model;
        public PurchasePage()
        {
            InitializeComponent();
            model = new PagePurchaseViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;
        }
    }
}