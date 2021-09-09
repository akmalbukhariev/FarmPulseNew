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
    public partial class MapViewPage : ContentPage
    {
        public MapViewPage()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Time_Tapped(object sender, EventArgs e)
        {
            ChangeClickBackColor(stackTime);
        }

        private void Image_Tapped(object sender, EventArgs e)
        {
            ChangeClickBackColor(stackImage);
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