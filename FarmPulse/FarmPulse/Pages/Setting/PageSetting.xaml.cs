using FarmPulse.ModelView;
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
    public partial class SettingPage : IPage
    {
        private PageSettingViewModel model;
        public SettingPage()
        {
            InitializeComponent();
            model = new PageSettingViewModel(Navigation);
            BindingContext = model; 
        }

        private async void TableCell_Tapped(object sender, EventArgs e)
        {
            model.Parent = Parent;
            model.SetTransitionType(TransitionType.SlideFromRight);

            if (sender == cellDemo)
            {
                await Navigation.PushAsync(new PageDemo());
            }
            else if (sender == cellLanguage)
            {
                await Navigation.PushAsync(new LanguagePage(true));
            }
            else if (sender == cellAbout)
            {
                await Navigation.PushAsync(new PageInfo());
            }
        }

        private void CellLanguage_Tapped(object sender, EventArgs e)
        {

        }

        private void CellAbout_Tapped(object sender, EventArgs e)
        {

        }

        private void BtnLogOut_Clicked(object sender, EventArgs e)
        {

        }
    }
}