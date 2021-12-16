using FarmPulse.ViewModel;
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
    public partial class PageFindInsurance : IPage
    {
        private PageFindInsuranceViewModel model;
        public PageFindInsurance()
        {
            InitializeComponent();
            model = new PageFindInsuranceViewModel(Navigation);
        }
    }
}