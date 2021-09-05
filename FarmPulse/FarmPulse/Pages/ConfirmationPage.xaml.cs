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
    public partial class ConfirmationPage : ContentPage
    {
        public ConfirmationPage()
        {
            InitializeComponent();
            InitPage();

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void InitPage()
        {
            lbTitle1.Text = "Your application has been submitted \n successfully.";
            lbTitle2.Text = "Please note: The insurance agent as sson as \n will get in touch within 5 business days.";
        }
    }
}