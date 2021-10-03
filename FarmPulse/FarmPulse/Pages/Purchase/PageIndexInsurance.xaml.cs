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
    public partial class IndexInsurancePage : IPage
    {
        private PageIndexInsuranceViewModel model;
        public IndexInsurancePage()
        {
            InitializeComponent();
            model = new PageIndexInsuranceViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}