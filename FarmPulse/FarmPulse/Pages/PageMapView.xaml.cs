using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FarmPulse.ModelView;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapViewPage : IPage
    {
        private PageMapViewViewModel model;
        public MapViewPage()
        {
            InitializeComponent();
            model = new PageMapViewViewModel(base.FieldInfo);
            BindingContext = model; 
        }

        private void Time_Tapped(object sender, EventArgs e)
        {
            ChangeClickBackColor(stackTime);
            model.ShowTimePeriodBox = true;
        }

        private void Image_Tapped(object sender, EventArgs e)
        {
            ChangeClickBackColor(stackImage);
            model.ShowImages = true;
        }

        private async void ChangeClickBackColor(StackLayout stack)
        {
            stack.BackgroundColor = Color.FromHex("#204D2C");
            await Task.Delay(100);

            stack.BackgroundColor = Color.Transparent;
            await Task.Delay(200);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                if (model.SelectedItem != null)
                {
                    model.ShowImages = false;
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}