using FarmPulse.Net;
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
    public partial class PageDemo : IPage
    {
        public PageDemo()
        {
            InitializeComponent(); 
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ControlApp.ShowLoadingView(RSC.PleaseWait);
            ResponseDemo response = await HttpService.GetDemoVidieoUrl();
            if (response.result)
            {
                image.IsVisible = false;
                webView.IsVisible = true;
                webView.Source = response.demoVideoUrl;
            }
            else
            {
                image.IsVisible = true;
                webView.IsVisible = false;
                await DisplayAlert(RSC.Error, response.message, RSC.Ok);
            }
            ControlApp.CloseLoadingView();
        }
    }
}