using FarmPulse.Model;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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
        public string Temp { get => GetValue<string>(); set => SetValue(value); }
        public string FeelsLike { get => GetValue<string>(); set => SetValue(value); }
        public string MinTemp { get => GetValue<string>(); set => SetValue(value); } 
        public string MaxTemp { get => GetValue<string>(); set => SetValue(value); } 
        public string Pressure { get => GetValue<string>(); set => SetValue(value); } 
        public string Humidity { get => GetValue<string>(); set => SetValue(value); }
        public string SeaLevel { get => GetValue<string>(); set => SetValue(value); }
        public string GroundLevel { get => GetValue<string>(); set => SetValue(value); }
        public string WindSpeed { get => GetValue<string>(); set => SetValue(value); }
        public string Cloudy { get => GetValue<string>(); set => SetValue(value); }
        public string Rain { get => GetValue<string>(); set => SetValue(value); }
        #endregion

        #region Forecast
            #region Monday
            public string Mon_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Icon { get => GetValue<string>(); set => SetValue(value); }
        #endregion

            #region Tuesday
            public string Tue_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Icon { get => GetValue<string>(); set => SetValue(value); }
        #endregion

            #region Wednesday
            public string Wed_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Icon { get => GetValue<string>(); set => SetValue(value); }
            #endregion

            #region Thursday
            public string Thu_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Icon { get => GetValue<string>(); set => SetValue(value); }
            #endregion

            #region Friday
            public string Fri_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Icon { get => GetValue<string>(); set => SetValue(value); }
            #endregion

            #region Saturday
            public string Sat_Text { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Icon { get => GetValue<string>(); set => SetValue(value); }
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
            Temp = "-";
            FeelsLike = "-";
            MinTemp = "-";
            MaxTemp = "-";
            Pressure = "-";
            Humidity = "-";
            SeaLevel = "-";
            GroundLevel = "-";
            WindSpeed = "-";
            Cloudy = "-";
            #endregion

            #region Forecast
            Mon_Text1 = "-";
            Mon_Text2 = "-";
            Mon_Text3 = "-";
            Mon_Text4 = "-";
            Mon_Text5 = "-"; 

            Tue_Text1 = "-";
            Tue_Text2 = "-";
            Tue_Text3 = "-";
            Tue_Text4 = "-";
            Tue_Text5 = "-";

            Wed_Text1 = "-";
            Wed_Text2 = "-";
            Wed_Text3 = "-";
            Wed_Text4 = "-";
            Wed_Text5 = "-";

            Thu_Text1 = "-";
            Thu_Text2 = "-";
            Thu_Text3 = "-";
            Thu_Text4 = "-";
            Thu_Text5 = "-";

            Fri_Text1 = "-";
            Fri_Text2 = "-";
            Fri_Text3 = "-";
            Fri_Text4 = "-";
            Fri_Text5 = "-";
            #endregion
        }
         
        public async void RefreshModel()
        {
            Control.ControlApp.Instance.AgromonAPI = "b5efce714742cc3aba8062b29f8c86f1";
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            ResponseField response = await HttpService.GetFieldList("998977");// ControlApp.UserInfo.insuranceNumber);
            if (response.result)
            {
                if (response.fields.Count != 0)
                {
                    FieldInfo info = response.fields[0];
                    List<double> lCenter = info.GetCenter();
                    if (lCenter.Count == 2)
                    {
                        String strLatLon = "lat=" + lCenter[1].ToString() + "&lon=" + lCenter[0].ToString() + "&appid=" + Control.ControlApp.Instance.AgromonAPI;
                        ResponseCurrentWeather response1 = await HttpService.GetCurrentWeather(strLatLon);
                        List<ResponseForecastWeather> response2 = await HttpService.GetForecastWeather(strLatLon);

                        #region Current Weather
                        if (response1.main != null)
                        {
                            Temp = response1.main.temp.ToString();
                            FeelsLike = response1.main.feels_like.ToString();
                            MinTemp = response1.main.temp_min.ToString();
                            MaxTemp = response1.main.temp_max.ToString();
                            Pressure = response1.main.pressure.ToString();
                            Humidity = response1.main.humidity.ToString() + "%";
                            SeaLevel = response1.main.sea_level.ToString() + " hPa";
                            GroundLevel = response1.main.grnd_level.ToString() + " hPa";
                        }

                        WindSpeed = response1.wind != null ? response1.wind.speed.ToString() : "-";
                        Cloudy = response1.clouds != null ? response1.clouds.all.ToString() + "%" : "-";
                        Rain = response1.rain != null ? response1.rain._3h.ToString() + "%" : "-";
                        #endregion

                        #region Forecast Weather
                        if (response2.Count != 0)
                        {
                            ResponseForecastWeather wMonday = GetDayOfWeekWeather(response2, DayOfWeek.Monday);
                            ResponseForecastWeather wTuesday = GetDayOfWeekWeather(response2, DayOfWeek.Tuesday);
                            ResponseForecastWeather wWednesday = GetDayOfWeekWeather(response2, DayOfWeek.Wednesday);
                            ResponseForecastWeather wThursday = GetDayOfWeekWeather(response2, DayOfWeek.Thursday);
                            ResponseForecastWeather wFriday = GetDayOfWeekWeather(response2, DayOfWeek.Friday);
                            ResponseForecastWeather wSaturday = GetDayOfWeekWeather(response2, DayOfWeek.Saturday);
                            ResponseForecastWeather wSunday = GetDayOfWeekWeather(response2, DayOfWeek.Sunday);

                            if (wMonday.weather != null && wMonday.weather.Count != 0)
                            {
                                if (wMonday.weather[0].main.Equals(HttpService.Weather_Clear))
                                {
                                    Mon_Icon = "sunny_white";
                                }
                                else if (wMonday.weather[0].main.Equals(HttpService.Weather_Rain))
                                {
                                    Mon_Icon = "rain_white";
                                }
                                else if (wMonday.weather[0].main.Equals(HttpService.Weather_Clouds))
                                {
                                    Mon_Icon = "cloudy";
                                }
                            }

                            if (wTuesday.weather != null && wTuesday.weather.Count != 0)
                            {
                                if (wTuesday.weather[0].main.Equals(HttpService.Weather_Clear))
                                {
                                    Mon_Icon = "sunny_white";
                                }
                                else if (wTuesday.weather[0].main.Equals(HttpService.Weather_Rain))
                                {
                                    Mon_Icon = "rain_white";
                                }
                                else if (wTuesday.weather[0].main.Equals(HttpService.Weather_Clouds))
                                {
                                    Mon_Icon = "cloudy";
                                }
                            }

                            if (wWednesday.weather != null && wWednesday.weather.Count != 0)
                            {
                                if (wWednesday.weather[0].main.Equals(HttpService.Weather_Clear))
                                {
                                    Mon_Icon = "sunny_white";
                                }
                                else if (wWednesday.weather[0].main.Equals(HttpService.Weather_Rain))
                                {
                                    Mon_Icon = "rain_white";
                                }
                                else if (wWednesday.weather[0].main.Equals(HttpService.Weather_Clouds))
                                {
                                    Mon_Icon = "cloudy";
                                }
                            }

                            if (wThursday.weather != null && wThursday.weather.Count != 0)
                            {
                                if (wThursday.weather[0].main.Equals(HttpService.Weather_Clear))
                                {
                                    Mon_Icon = "sunny_white";
                                }
                                else if (wThursday.weather[0].main.Equals(HttpService.Weather_Rain))
                                {
                                    Mon_Icon = "rain_white";
                                }
                                else if (wThursday.weather[0].main.Equals(HttpService.Weather_Clouds))
                                {
                                    Mon_Icon = "cloudy";
                                }
                            }

                            if (wFriday.weather != null && wFriday.weather.Count != 0)
                            {
                                if (wFriday.weather[0].main.Equals(HttpService.Weather_Clear))
                                {
                                    Mon_Icon = "sunny_white";
                                }
                                else if (wFriday.weather[0].main.Equals(HttpService.Weather_Rain))
                                {
                                    Mon_Icon = "rain_white";
                                }
                                else if (wFriday.weather[0].main.Equals(HttpService.Weather_Clouds))
                                {
                                    Mon_Icon = "cloudy";
                                }
                            }

                            if (wSaturday.weather != null && wSaturday.weather.Count != 0)
                            {
                                if (wSaturday.weather[0].main.Equals(HttpService.Weather_Clear))
                                {
                                    Mon_Icon = "sunny_white";
                                }
                                else if (wSaturday.weather[0].main.Equals(HttpService.Weather_Rain))
                                {
                                    Mon_Icon = "rain_white";
                                }
                                else if (wSaturday.weather[0].main.Equals(HttpService.Weather_Clouds))
                                {
                                    Mon_Icon = "cloudy";
                                }
                            }

                            if (wSunday.weather != null && wSunday.weather.Count != 0)
                            {
                                if (wSunday.weather[0].main.Equals(HttpService.Weather_Clear))
                                {
                                    Mon_Icon = "sunny_white";
                                }
                                else if (wSunday.weather[0].main.Equals(HttpService.Weather_Rain))
                                {
                                    Mon_Icon = "rain_white";
                                }
                                else if (wSunday.weather[0].main.Equals(HttpService.Weather_Clouds))
                                {
                                    Mon_Icon = "cloudy";
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        ResponseForecastWeather GetDayOfWeekWeather(List<ResponseForecastWeather> list, DayOfWeek dayOfWeek)
        {
            ResponseForecastWeather result = new ResponseForecastWeather();

            List<ResponseForecastWeather> tList = new List<ResponseForecastWeather>();

            if (dayOfWeek == DayOfWeek.Monday)
            { 
                foreach (ResponseForecastWeather info in list)
                { 
                    if (CheckDayOfWeek(info, DayOfWeek.Monday))
                    {
                        tList.Add(info);
                    }
                }
            }
            else if (dayOfWeek == DayOfWeek.Tuesday)
            {
                foreach (ResponseForecastWeather info in list)
                { 
                    if (CheckDayOfWeek(info, DayOfWeek.Tuesday))
                    {
                        tList.Add(info);
                    }
                } 
            }
            else if (dayOfWeek == DayOfWeek.Wednesday)
            {
                foreach (ResponseForecastWeather info in list)
                {
                    if (CheckDayOfWeek(info, DayOfWeek.Wednesday))
                    {
                        tList.Add(info);
                    }
                }
            }
            else if (dayOfWeek == DayOfWeek.Thursday)
            {
                foreach (ResponseForecastWeather info in list)
                {
                    if (CheckDayOfWeek(info, DayOfWeek.Thursday))
                    {
                        tList.Add(info);
                    }
                }
            }
            else if (dayOfWeek == DayOfWeek.Friday)
            {
                foreach (ResponseForecastWeather info in list)
                {
                    if (CheckDayOfWeek(info, DayOfWeek.Friday))
                    {
                        tList.Add(info);
                    }
                }
            }
            else if (dayOfWeek == DayOfWeek.Saturday)
            {
                foreach (ResponseForecastWeather info in list)
                {
                    if (CheckDayOfWeek(info, DayOfWeek.Saturday))
                    {
                        tList.Add(info);
                    }
                }
            }
            else if (dayOfWeek == DayOfWeek.Sunday)
            {
                foreach (ResponseForecastWeather info in list)
                {
                    if (CheckDayOfWeek(info, DayOfWeek.Sunday))
                    {
                        tList.Add(info);
                    }
                }
            }

            result.main.temp_min = double.MaxValue;
            result.main.temp_max = double.MinValue;

            foreach (ResponseForecastWeather info in tList)
            {
                if (info.weather != null)
                {
                    foreach (Weather item in info.weather)
                    {
                        result.weather.Add(new Weather(item));
                    }
                }

                if (info.main != null)
                {
                    result.main.temp += info.main.temp;
                    result.main.feels_like += info.main.feels_like;
                    result.main.temp_min = Math.Min(result.main.temp_min, info.main.temp_min);
                    result.main.temp_max = Math.Max(result.main.temp_max, info.main.temp_max);
                    result.main.pressure += info.main.pressure;
                    result.main.sea_level += info.main.sea_level;
                    result.main.grnd_level += info.main.grnd_level;
                    result.main.humidity += info.main.humidity;
                    result.main.temp_kf += info.main.temp_kf;
                }

                if (info.wind != null)
                {
                    result.wind.speed += info.wind.speed;
                    result.wind.deg += info.wind.deg;
                    result.wind.gust += info.wind.gust;
                }

                if (info.rain != null)
                {
                    result.rain._3h += info.rain._3h;
                }

                if (info.clouds != null)
                {
                    result.clouds.all += info.clouds.all;
                }
            }

            if (tList.Count != 0)
            {
                result.main.temp = result.main.temp / tList.Count;
                result.main.feels_like = result.main.feels_like / tList.Count;
                result.main.pressure = result.main.pressure / tList.Count;
                result.main.sea_level = result.main.sea_level / tList.Count;
                result.main.grnd_level = result.main.grnd_level / tList.Count;
                result.main.humidity = result.main.humidity / tList.Count;
                result.main.temp_kf = result.main.temp_kf / tList.Count;

                result.wind.speed = result.wind.speed / tList.Count;
                result.wind.deg = result.wind.deg / tList.Count;
                result.wind.gust = result.wind.gust / tList.Count;

                result.rain._3h = result.rain._3h / tList.Count;

                result.clouds.all = result.clouds.all / tList.Count;
            }

            int wMax = 0;
            if (result.weather != null)
            {
                List<Weather> wClear = result.weather.FindAll(x => x.main.Equals(HttpService.Weather_Clear));
                List<Weather> wRain = result.weather.FindAll(x => x.main.Equals(HttpService.Weather_Rain));
                List<Weather> wClouds = result.weather.FindAll(x => x.main.Equals(HttpService.Weather_Clouds));

                if (wClear != null)
                    wMax = wClear.Count;
                
                if (wRain != null)
                    wMax = Math.Max(wMax, wRain.Count);

                if (wClouds != null)
                    wMax = Math.Max(wMax, wClouds.Count);

                if (wClear != null && wMax == wClear.Count)
                {
                    result.weather = wClear;
                }
                else if (wRain != null && wMax == wRain.Count)
                {
                    result.weather = wRain;
                }
                else if (wClouds != null && wMax == wClouds.Count)
                {
                    result.weather = wClouds;
                }
            }

            return result;
        }

        bool CheckDayOfWeek(ResponseForecastWeather info, DayOfWeek dayOfWeek)
        {
            bool result = false;

            DateTime time = ControlApp.UnixTimeStampToDateTime((double)info.dt);
            if (time.DayOfWeek == dayOfWeek)
                result = true;

            return result;
        }
    }
}
