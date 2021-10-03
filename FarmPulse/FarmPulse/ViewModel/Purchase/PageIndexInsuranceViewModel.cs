using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageIndexInsuranceViewModel : BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string TitleCotton { get => GetValue<string>(); set => SetValue(value); }
        public string TitleWheat { get => GetValue<string>(); set => SetValue(value); }
        public string ActualYield { get => GetValue<string>(); set => SetValue(value); }
        public string SelectIndexTitle { get => GetValue<string>(); set => SetValue(value); }
        public string SelectedIndexItem { get => GetValue<string>(); set => SetValue(value); }
        public string AddCropyield { get => GetValue<string>(); set => SetValue(value); }
        public List<string> IndexList { get => GetValue<List<string>>(); set => SetValue(value); }

        public PageIndexInsuranceViewModel(INavigation navigation)
        {
            Title = "INDEX INSURANCE";
            SelectIndexTitle = "Select index";
            TitleCotton = "Cotton(Nurabad)";
            TitleWheat = "Wheat(Nurabad)";
            ActualYield = "Actual yield";
            AddCropyield = "Add crop yield";

            IndexList = new List<string>();
            IndexList.Add("Chlorophylle Index");
            IndexList.Add("NDVI Index");

            Navigation = navigation;
        }

        public ICommand ClickCropYieldCommand => new Command(CropYield);

        private async void CropYield()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new CropYieldDataPage());
        }
    }
}
