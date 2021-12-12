using FarmPulse.Model;
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
    public partial class PageMapGraphTab : TabbedPage
    {
        public PageMapGraphTab(FieldInfo fieldInfo)
        {
            InitializeComponent();

            lbTitle.Text = fieldInfo.name;
            mapPage.FieldInfo = fieldInfo;
            graphPage.FieldInfo = fieldInfo;

            mapPage.InitModel();
            graphPage.InitModel();
              
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#598E6F");
        }
    }
}