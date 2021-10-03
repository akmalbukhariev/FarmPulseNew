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
    public partial class GraphViewPage : IPage
    {
        private PageGraphViewViewModel model;
        public GraphViewPage()
        {
            InitializeComponent();
            model = new PageGraphViewViewModel();
            BindingContext = model; 
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(model.SelectedIndexItem))
            {
                
            }
        }
    }
}