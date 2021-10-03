using FarmPulse.Control;
using FarmPulse.Pages;
using System; 

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemoInfoView : ContentView
    {
        public Element PageParent { get; set; }

        public DemoInfoView()
        {
            InitializeComponent();
        }

        private async void Demo_Tapped(object sender, EventArgs e)
        {
            Slidestyle();
            await Navigation.PushAsync(new PageDemo());
        }   

        private async void Info_Tapped(object sender, EventArgs e)
        {
            Slidestyle();
            await Navigation.PushAsync(new PageInfo());
        }

        void Slidestyle()
        {
            if (PageParent == null) return;

            var transitionNavigationPage = PageParent as TransitionNavigationPage;
            transitionNavigationPage.TransitionType = TransitionType.SlideFromRight;
        }
    }
}