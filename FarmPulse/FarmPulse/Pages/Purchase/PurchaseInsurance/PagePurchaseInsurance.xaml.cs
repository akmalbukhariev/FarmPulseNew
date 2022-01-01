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

            if (!Control.ControlApp.Instance.InternetOk())
                return;

            model.GetFields();
        }
  
        private void lsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (model.SelectedField != null)
            {
                model.ShowFieldNameBox = false;
                model.TextSelectFieldName = model.SelectedField.name;
                model.CropType = model.SelectedField.cropName;
            }
        }
    }
}