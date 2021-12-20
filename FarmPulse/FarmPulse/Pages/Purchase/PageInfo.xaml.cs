using FarmPulse.ModelView.Purchase;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages.Purchase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInfo : IPage
    {
        public enum PageId
        {
            P_None,
            P_Insurance,
            P_Estimate,
            P_Cover,
            P_Faq
        }

        private PageId pageId = PageId.P_None;

        private PageInfoViewModel model;
        public PageInfo(PageId pId)
        {
            InitializeComponent();
            pageId = pId;

            model = new PageInfoViewModel(Navigation, "");
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
             
            switch (pageId)
            {
                case PageId.P_Insurance: 
                    webView.Source = GetUrl("Insurance");
                    navigation.Text = RSC.Insurance;
                    break;
                case PageId.P_Estimate: 
                    webView.Source = GetUrl("EstimateRate");
                    navigation.Text = RSC.EstimateRate;
                    break;
                case PageId.P_Cover: 
                    webView.Source = GetUrl("Cover");
                    navigation.Text = RSC.Cover;
                    break;
                case PageId.P_Faq: 
                    webView.Source = GetUrl("Faq");
                    navigation.Text = RSC.FAQ;
                    break;
            }
        }

        private string GetUrl(string strId)
        {
            string strUrl = string.Empty;

            if (AppSettings.GetLanguageCode == AppSettings.LanUz)
            {
                strUrl = $"{HttpService.INFO_HTML}{strId}_uz.html";
            }
            else if (AppSettings.GetLanguageCode == AppSettings.LanEn)
            {
                strUrl = $"{HttpService.INFO_HTML}{strId}_en.html";
            }
            else if (AppSettings.GetLanguageCode == AppSettings.LanRu)
            {
                strUrl = $"{HttpService.INFO_HTML}{strId}_ru.html";
            }
            else if (AppSettings.GetLanguageCode == AppSettings.LanMn)
            {
                strUrl = $"{HttpService.INFO_HTML}{strId}_mn.html";
            }

            return strUrl.Trim();
        }
    }
}