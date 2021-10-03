using System;
using System.Collections.Generic;
using System.Text;

namespace FarmPulse.ModelView
{
    public class PageWeatherViewModel : BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string Title1 { get => GetValue<string>(); set => SetValue(value); }
        public string DateNow { get => GetValue<string>(); set => SetValue(value); }
        public string CurrentlyWeather { get => GetValue<string>(); set => SetValue(value); }
        public string Forecast { get => GetValue<string>(); set => SetValue(value); }

        #region Currently
        public string Item1_Text1 { get => GetValue<string>(); set => SetValue(value); }
        public string Item1_Text2 { get => GetValue<string>(); set => SetValue(value); }
        public string Item2_Text1 { get => GetValue<string>(); set => SetValue(value); }
        public string Item2_Text2 { get => GetValue<string>(); set => SetValue(value); }
        public string Item3_Text1 { get => GetValue<string>(); set => SetValue(value); }
        public string Item3_Text2 { get => GetValue<string>(); set => SetValue(value); }
        public string Item4_Text1 { get => GetValue<string>(); set => SetValue(value); }
        public string Item4_Text2 { get => GetValue<string>(); set => SetValue(value); }
        public string Item5_Text1 { get => GetValue<string>(); set => SetValue(value); }
        public string Item5_Text2 { get => GetValue<string>(); set => SetValue(value); }
        #endregion

        #region Forecast
            #region Monday
            public string Mon_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text5 { get => GetValue<string>(); set => SetValue(value); }
            #endregion

            #region Tuesday
            public string Tue_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text5 { get => GetValue<string>(); set => SetValue(value); }
            #endregion
        
            #region Wednesday
            public string Wed_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text5 { get => GetValue<string>(); set => SetValue(value); }
            #endregion
        
            #region Thursday
            public string Thu_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text5 { get => GetValue<string>(); set => SetValue(value); }
            #endregion
        
            #region Friday
            public string Fri_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text5 { get => GetValue<string>(); set => SetValue(value); }
            #endregion
        #endregion

        public PageWeatherViewModel()
        {
            Title = "Weather";
            Title1 = "Hella";
            DateNow = DateTime.Now.ToString("hh:mm tt");
            CurrentlyWeather = "Currently weather";
            Forecast = "Forecast";

            #region Current weather
            Item1_Text1 = "Rain 3 h";
            Item1_Text2 = "0 1/m2";
            Item2_Text1 = "Rain Today";
            Item2_Text2 = "0 1/m2";
            Item3_Text1 = "Snow Yestarday";
            Item3_Text2 = "0 1/m2";
            Item4_Text1 = "Wind speed";
            Item4_Text2 = "0 m/s";
            Item5_Text1 = "Air temperature";
            Item5_Text2 = "16.6 C";
            #endregion

            #region Forecast
            Mon_Text = "Mon";
            Mon_Text1 = "23/08/2021";
            Mon_Text2 = "18 C";
            Mon_Text3 = "10 C";
            Mon_Text4 = "4.6 m/s";
            Mon_Text5 = "0.2 l/m2";

            Tue_Text = "Tue";
            Tue_Text1 = "24/08/2021";
            Tue_Text2 = "18 C";
            Tue_Text3 = "10 C";
            Tue_Text4 = "3.4 m/s";
            Tue_Text5 = "0 l/m2";

            Wed_Text = "Wed";
            Wed_Text1 = "25/08/2021";
            Wed_Text2 = "5 C";
            Wed_Text3 = "0 C";
            Wed_Text4 = "5.4 m/s";
            Wed_Text5 = "0.8 l/m2";

            Thu_Text = "Thu";
            Thu_Text1 = "26/08/2021";
            Thu_Text2 = "11 C";
            Thu_Text3 = "5 C";
            Thu_Text4 = "3.9 m/s";
            Thu_Text5 = "0.2 l/m2";

            Fri_Text = "Fri";
            Fri_Text1 = "27/08/2021";
            Fri_Text2 = "15 C";
            Fri_Text3 = "10 C";
            Fri_Text4 = "4.4 m/s";
            Fri_Text5 = "0 l/m2";
            #endregion
        }
    }
}
