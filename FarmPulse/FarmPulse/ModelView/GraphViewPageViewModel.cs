using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class GraphViewPageViewModel : BaseModel
    {
        public string TitleCotton { get => GetValue<string>(); set => SetValue(value); }
        public string TitleWheat { get => GetValue<string>(); set => SetValue(value); }
        public string IndexMeanValue { get => GetValue<string>(); set => SetValue(value); }
        public string SelectIndexTitle { get => GetValue<string>(); set => SetValue(value); }
        public string SelectedIndexItem { get => GetValue<string>(); set => SetValue(value); }
        public List<string> IndexList { get => GetValue<List<string>>(); set => SetValue(value); }

        public GraphViewPageViewModel()
        {
            IndexList = new List<string>();

            SelectIndexTitle = "Select index";

            TitleCotton = "Cotton(Nurabad)";
            TitleWheat = "Wheat(Nurabad)";
            IndexMeanValue = "Index mean value";

            IndexList.Add("Chlorophylle Index");
            IndexList.Add("NDVI Index");
        } 
    }
}
