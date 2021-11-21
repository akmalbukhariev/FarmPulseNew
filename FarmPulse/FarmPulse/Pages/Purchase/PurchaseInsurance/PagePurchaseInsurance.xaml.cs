using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FarmPulse.ModelView;

namespace FarmPulse.Pages.Purchase.PurchaseInsurance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePurchaseInsurance : IPage
    {
        private PagePurchaseInsuranceViewModel model;

        public PagePurchaseInsurance()
        {
            InitializeComponent();
            model = new PagePurchaseInsuranceViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.GetFields();
        }

        private void pickField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (model.SelectedField != null)
                model.CropType = model.SelectedField.cropName;
        }
    }
}