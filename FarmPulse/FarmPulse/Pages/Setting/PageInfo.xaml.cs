using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FarmPulse.Net;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInfo : IPage
    {
        public PageInfo()
        {
            InitializeComponent(); 
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ControlApp.ShowLoadingView(RSC.PleaseWait);
            ResponseAboutInfo response = await HttpService.GetInfoAboutApp();
            if (response.result)
            {
                var source = new HtmlWebViewSource();
                source.Html = response.strInfoText;
                webView.Source = source;
            }
            else
            {
                await DisplayAlert(RSC.Error, response.message, RSC.Ok);
            }
            ControlApp.CloseLoadingView();
        }
    }
}