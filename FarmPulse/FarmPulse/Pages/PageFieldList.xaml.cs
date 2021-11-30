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
    public partial class PageFieldList : IPage
    {
        private PageFieldListViewModel model;
        public PageFieldList()
        {
            InitializeComponent();

            model = new PageFieldListViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;
            model.RefreshFieldList();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (model.SelectedItem != null)
            {
                model.SetTransitionType(TransitionType.SlideFromRight);
                await Navigation.PushAsync(new PageMapGraphTab(model.SelectedItem));
            }
        }
    }
}