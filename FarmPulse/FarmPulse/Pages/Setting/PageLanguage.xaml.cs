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
    public partial class LanguagePage : IPage
    {
        private PageLanguageViewModel model;
        
        public LanguagePage(bool showNavigationView = false)
        {
            InitializeComponent();

            navigationView.IsVisible = showNavigationView;

            model = new PageLanguageViewModel(Navigation);
            BindingContext = model; 
        }
          
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;
            demoInfoView.PageParent = Parent;
        }
    }
}