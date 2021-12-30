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
    public partial class PageLanguage : IPage
    {
        private PageLanguageViewModel model;
        
        public PageLanguage(bool showNavigationView = false)
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

        private void lsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (model.SelectedLanguage != null)
            {
                model.ShowBox = false;
                model.ShowSelectLanguage = true;
                model.TextSelectLanguage = model.SelectedLanguage.Name;
            }
        }
    }
}