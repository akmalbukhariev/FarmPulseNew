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
    public partial class PageConfirmation : IPage
    {
        private PageConfirmationViewModel model;
        public PageConfirmation()
        {
            InitializeComponent();
            InitPage();
            model = new PageConfirmationViewModel(Navigation);
            BindingContext = model; 
        }

        private void InitPage()
        {
            //lbTitle1.Text = "Your application has been submitted \n successfully.";
            //lbTitle2.Text = "Please note: The insurance agent as sson as \n will get in touch within 5 business days.";
        }
    }
}