
using FarmPulse.ModelView;
using Xamarin.Forms;

namespace FarmPulse.Pages
{
    public partial class PageMain : IPage
    {
        PageMainViewModel model;
        public PageMain()
        {
            InitializeComponent();
            
            model = new PageMainViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        { 
            base.OnAppearing();
            model.Parent = Parent;
        }
    }
}
