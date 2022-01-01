using FarmPulse.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMapGraphTab : Xamarin.Forms.TabbedPage
    {
        public PageMapGraphTab(FieldInfo fieldInfo)
        {
            InitializeComponent();

            lbTitle.Text = fieldInfo.name;
            mapPage.FieldInfo = fieldInfo;
            graphPage.FieldInfo = fieldInfo;

            mapPage.InitModel();
            graphPage.InitModel();

            //On<Android>().SetBarItemColor(Color.Red);           // Unselected image+text color
            //On<Android>().SetBarSelectedItemColor(Color.White); // Selected image+text color

            ((NavigationPage)Xamarin.Forms.Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#598E6F");
        }
    }
}