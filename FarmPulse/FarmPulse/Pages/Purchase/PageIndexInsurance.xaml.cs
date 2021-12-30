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
    public partial class PageIndexInsurance : IPage
    {
        private PageIndexInsuranceViewModel model;
        public PageIndexInsurance()
        {
            InitializeComponent();
            model = new PageIndexInsuranceViewModel(Navigation);
            BindingContext = model;  
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;
            
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            model.FieldInfo = FieldInfo;
            model.GetIndexList();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            if (model.SelectedMetrics != null)
            {
                model.ShowBox = false;
                model.TextSelectMetrics = model.SelectedMetrics.name;
                model.RefreshGraphViewData(FieldInfo.fieldId);
            }
        }
    }
}