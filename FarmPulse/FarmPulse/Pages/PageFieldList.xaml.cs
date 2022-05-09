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
        private bool ForIndexInsurance = false;
        private PageFieldListViewModel model;
        public PageFieldList(bool forIndexInsurance = false)
        {
            InitializeComponent();
            ForIndexInsurance = forIndexInsurance;
            model = new PageFieldListViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Parent = Parent;

            if (!Control.ControlApp.Instance.InternetOk())
                return;

            model.RefreshFieldList();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            if (model.SelectedItem != null)
            {
                model.SetTransitionType(TransitionType.SlideFromRight);
                if (ForIndexInsurance)
                {
                    PageIndexInsurance indexPage = new PageIndexInsurance();
                    indexPage.FieldInfo = model.SelectedItem;
                    await Navigation.PushAsync(indexPage);
                }
                else
                {
                    PageMapView mapPage = new PageMapView();
                    mapPage.FieldInfo = model.SelectedItem;
                    mapPage.InitModel();
                    await Navigation.PushAsync(mapPage);
                    //await Navigation.PushAsync(new PageMapGraphTab(model.SelectedItem));
                }
            }
        }
    }
}