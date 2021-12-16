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
    public partial class PageGraphView : IPage
    {
        private PageGraphViewViewModel model;
        public PageGraphView()
        {
            InitializeComponent(); 
        }

        public void InitModel()
        {
            model = new PageGraphViewViewModel();
            BindingContext = model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;

            if (!Control.ControlApp.Instance.InternetOk())
                return;
            
            model.GetIndexList();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            if (model.SelectedMetrics != null)
            {
                model.RefreshGraphViewData(FieldInfo.fieldId);
            }
        }
    }
}