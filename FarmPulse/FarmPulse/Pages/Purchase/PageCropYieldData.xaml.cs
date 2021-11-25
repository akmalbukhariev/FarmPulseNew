using FarmPulse.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CropYieldDataPage : IPage
    {
        private PageCropYieldDataViewModel model;
        public CropYieldDataPage()
        {
            InitializeComponent();
            InitPage();

            model = new PageCropYieldDataViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.GetFields();
        }

        private void InitPage()
        {
            lbText.Text = "Please, enter the crop yield information in \n order to compare with insurance index \n values. Use ton/ha units.";
        }

        private void pickField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (model.SelectedField != null)
            {
                model.CropType = model.SelectedField.cropName;
                model.RefreshModel();
            }
        }
    }
}