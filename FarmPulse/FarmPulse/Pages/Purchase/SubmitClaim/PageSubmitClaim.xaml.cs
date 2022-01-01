using FarmPulse.ModelView;
using FarmPulse.ModelView.Purchase.SubmitClaim;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages.Purchase.SubmitClaim
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageSubmitClaim : IPage
    {
        private PageSubmitClaimViewModel model;
        public PageSubmitClaim()
        {
            InitializeComponent();
            model = new PageSubmitClaimViewModel(Navigation);
            BindingContext = model; 
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); 
            model.Parent = Parent;

            if (!Control.ControlApp.Instance.InternetOk())
                return;

            model.GetFields();
        }
         
        private void lsView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (model.SelectedField != null)
            {
                model.ShowFieldNameBox = false;
                model.TextSelectFieldName = model.SelectedField.name;
                model.CropType = model.SelectedField.cropName;
            }
        }
    }
}