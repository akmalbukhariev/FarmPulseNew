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
    public partial class MapViewPage : ContentPage
    {
        private MapViewPageViewModel model;
        public MapViewPage()
        {
            InitializeComponent();
            model = new MapViewPageViewModel();
            BindingContext = model;

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Time_Tapped(object sender, EventArgs e)
        {
            ChangeClickBackColor(stackTime);
            model.ShowTimePeriodBox = true;
        }

        private void Image_Tapped(object sender, EventArgs e)
        {
            ChangeClickBackColor(stackImage);
            model.ShowImages = true;
        }

        private async void ChangeClickBackColor(StackLayout stack)
        {
            stack.BackgroundColor = Color.FromHex("#204D2C");
            await Task.Delay(100);

            stack.BackgroundColor = Color.Transparent;
            await Task.Delay(200);
        }
    }
}