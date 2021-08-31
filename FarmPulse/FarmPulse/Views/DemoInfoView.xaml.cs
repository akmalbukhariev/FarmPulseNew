using FarmPulse.Pages;
using System; 

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoInfoView : ContentView
    {
        public DemoInfoView()
        {
            InitializeComponent();
        }

        private async void Demo_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PageDemo());
        }   

        private async void Info_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PageInfo());
        }
    }
}