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
    public partial class PageCropYieldData : IPage
    {
        private PageCropYieldDataViewModel model;

        public PageCropYieldData()
        {
            InitializeComponent();  

            model = new PageCropYieldDataViewModel(Navigation);
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
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            if (model.SelectedField != null)
            {
                model.TextSelectFieldName = model.SelectedField.name;
                model.ShowFieldNameBox = false;
                model.CropType = model.SelectedField.cropName;
                model.RefreshModel();
            }
        }
    }
}