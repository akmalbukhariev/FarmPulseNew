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
    public partial class MapGraphTabPage : TabbedPage
    {
        public MapGraphTabPage()
        {
            InitializeComponent();

            //NavigationPage.SetHasBackButton(this, false);
            //NavigationPage.SetHasNavigationBar(this, false);

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#598E6F");
        }
    }
}