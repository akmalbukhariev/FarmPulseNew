using System;
using System.Collections.Generic;
using System.Text;

namespace FarmPulse.ModelView
{
    public class IndexInsurancePageViewModel : BaseModel
    {
        public string TitleCotton { get => GetValue<string>(); set => SetValue(value); }
        public string TitleWheat { get => GetValue<string>(); set => SetValue(value); }
        public string ActualYield { get => GetValue<string>(); set => SetValue(value); }
        public string SelectIndexTitle { get => GetValue<string>(); set => SetValue(value); }
        public string SelectedIndexItem { get => GetValue<string>(); set => SetValue(value); }
        public List<string> IndexList { get => GetValue<List<string>>(); set => SetValue(value); }

        public IndexInsurancePageViewModel()
        {
            SelectIndexTitle = "Select index";
            TitleCotton = "Cotton(Nurabad)";
            TitleWheat = "Wheat(Nurabad)";
            ActualYield = "Actual yield";

            IndexList = new List<string>();
            IndexList.Add("Chlorophylle Index");
            IndexList.Add("NDVI Index");
        }
    }
}
