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
            public string Mon_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Mon_Icon { get => GetValue<string>(); set => SetValue(value); }
            #endregion

            #region Tuesday 
            public string Tue_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Tue_Icon { get => GetValue<string>(); set => SetValue(value); }
            #endregion

            #region Wednesday 
            public string Wed_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Wed_Icon { get => GetValue<string>(); set => SetValue(value); }
            #endregion

            #region Thursday 
            public string Thu_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Thu_Icon { get => GetValue<string>(); set => SetValue(value); }
            #endregion

            #region Friday 
            public string Fri_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Fri_Icon { get => GetValue<string>(); set => SetValue(value); }
            #endregion

            #region Saturday 
            public string Sat_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Sat_Icon { get => GetValue<string>(); set => SetValue(value); }
        #endregion

            #region Sunday 
            public string Sun_Text1 { get => GetValue<string>(); set => SetValue(value); }
            public string Sun_Text2 { get => GetValue<string>(); set => SetValue(value); }
            public string Sun_Text3 { get => GetValue<string>(); set => SetValue(value); }
            public string Sun_Text4 { get => GetValue<string>(); set => SetValue(value); }
            public string Sun_Text5 { get => GetValue<string>(); set => SetValue(value); }
            public string Sun_Icon { get => GetValue<string>(); set => SetValue(value); }
            #endregion
        #endregion

        public PageWeatherViewModel()
        {
            Title = ControlApp.UserInfo.region;
            
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
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            ResponseField response = await HttpService.GetFieldList(ControlApp.UserInfo.insuranceNumber);
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
                            Temp = Math.Round(response1.main.temp - 273.15, 2).ToString() + " °C";
                            FeelsLike = Math.Round(response1.main.feels_like - 273.15, 2).ToString() + " °C";
                            MinTemp = Math.Round(response1.main.temp_min - 273.15, 2).ToString() + " °C";
                            MaxTemp = Math.Round(response1.main.temp_max - 273.15, 2).ToString() + " °C";
                            Pressure = response1.main.pressure.ToString() + " hPa";
                            Humidity = response1.main.humidity.ToString() + "%";
                            SeaLevel = response1.main.sea_level.ToString() + " hPa";
                            GroundLevel = response1.main.grnd_level.ToString() + " hPa";
                        }

                        WindSpeed = response1.wind != null ? response1.wind.speed.ToString() + " m/s" : "-";
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

                            Mon_Icon = SetIcon(wMonday);
                            Tue_Icon = SetIcon(wTuesday);
                            Wed_Icon = SetIcon(wWednesday);
                            Thu_Icon = SetIcon(wThursday);
                            Fri_Icon = SetIcon(wFriday);
                            Sat_Icon = SetIcon(wSaturday);
                            Sun_Icon = SetIcon(wSunday);
                             
                            #region Monday
                            Mon_Text1 = wMonday.dt == 0 ? "-" : ControlApp.UnixTimeStampToDateTime((double)wMonday.dt).ToString("dd/MM/yyyy");
                            Mon_Text2 = wMonday.main.temp_max.ToString() + " °C";
                            Mon_Text3 = wMonday.main.temp_min.ToString() + " °C";
                            Mon_Text4 = wMonday.wind.speed.ToString() + " m/s";
                            Mon_Text5 = wMonday.rain._3h.ToString();
                            #endregion

                            #region Tuesday
                            Tue_Text1 = wTuesday.dt == 0 ? "-" : ControlApp.UnixTimeStampToDateTime((double)wTuesday.dt).ToString("dd/MM/yyyy");
                            Tue_Text2 = wTuesday.main.temp_max.ToString() + " °C";
                            Tue_Text3 = wTuesday.main.temp_min.ToString() + " °C";
                            Tue_Text4 = wTuesday.wind.speed.ToString() + " m/s";
                            Tue_Text5 = wTuesday.rain._3h.ToString();
                            #endregion

                            #region Wednesday
                            Wed_Text1 = wWednesday.dt == 0 ? "-" : ControlApp.UnixTimeStampToDateTime((double)wWednesday.dt).ToString("dd/MM/yyyy");
                            Wed_Text2 = wWednesday.main.temp_max.ToString() + " °C";
                            Wed_Text3 = wWednesday.main.temp_min.ToString() + " °C";
                            Wed_Text4 = wWednesday.wind.speed.ToString() + " m/s";
                            Wed_Text5 = wWednesday.rain._3h.ToString();
                            #endregion

                            #region Thursday
                            Thu_Text1 = wThursday.dt == 0 ? "-" : ControlApp.UnixTimeStampToDateTime((double)wThursday.dt).ToString("dd/MM/yyyy");
                            Thu_Text2 = wThursday.main.temp_max.ToString() + " °C";
                            Thu_Text3 = wThursday.main.temp_min.ToString() + " °C";
                            Thu_Text4 = wThursday.wind.speed.ToString() + " m/s";
                            Thu_Text5 = wThursday.rain._3h.ToString();
                            #endregion

                            #region Friday
                            Fri_Text1 = wFriday.dt == 0 ? "-" : ControlApp.UnixTimeStampToDateTime((double)wFriday.dt).ToString("dd/MM/yyyy");
                            Fri_Text2 = wFriday.main.temp_max.ToString() + " °C";
                            Fri_Text3 = wFriday.main.temp_min.ToString() + " °C";
                            Fri_Text4 = wFriday.wind.speed.ToString() + " m/s";
                            Fri_Text5 = wFriday.rain._3h.ToString();
                            #endregion

                            #region Saturday
                            Sat_Text1 = wSaturday.dt == 0 ? "-" : ControlApp.UnixTimeStampToDateTime((double)wSaturday.dt).ToString("dd/MM/yyyy");
                            Sat_Text2 = wSaturday.main.temp_max.ToString() + " °C";
                            Sat_Text3 = wSaturday.main.temp_min.ToString() + " °C";
                            Sat_Text4 = wSaturday.wind.speed.ToString() + " m/s";
                            Sat_Text5 = wSaturday.rain._3h.ToString();
                            #endregion

                            #region Sunday
                            Sun_Text1 = wSunday.dt == 0 ? "-" : ControlApp.UnixTimeStampToDateTime((double)wSunday.dt).ToString("dd/MM/yyyy");
                            Sun_Text2 = wSunday.main.temp_max.ToString() + " °C";
                            Sun_Text3 = wSunday.main.temp_min.ToString() + " °C";
                            Sun_Text4 = wSunday.wind.speed.ToString() + " m/s";
                            Sun_Text5 = wSunday.rain._3h.ToString();
                            #endregion

                        }
                        #endregion
                    }
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.FailedGetField} :{response.message}", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        ResponseForecastWeather GetDayOfWeekWeather(List<ResponseForecastWeather> list, DayOfWeek dayOfWeek)
        {
            List<ResponseForecastWeather> tList = new List<ResponseForecastWeather>();

            foreach (ResponseForecastWeather info in list)
            {
                if (CheckDayOfWeek(info, dayOfWeek))
                {
                    tList.Add(info);
                }
            }
             
            ResponseForecastWeather result = new ResponseForecastWeather();

            if (tList.Count != 0)
            {
                result.main.temp_min = double.MaxValue;
                result.main.temp_max = double.MinValue;
            }

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
                result.dt = tList[0].dt;
                result.main.temp = Math.Round((result.main.temp / tList.Count) - 273.15, 2);
                result.main.feels_like = result.main.feels_like / tList.Count;
                result.main.temp_max = Math.Round(result.main.temp_max - 273.15, 2);
                result.main.temp_min = Math.Round(result.main.temp_min - 273.15, 2);
                result.main.pressure = result.main.pressure / tList.Count;
                result.main.sea_level = result.main.sea_level / tList.Count;
                result.main.grnd_level = result.main.grnd_level / tList.Count;
                result.main.humidity = result.main.humidity / tList.Count;
                result.main.temp_kf = result.main.temp_kf / tList.Count;

                result.wind.speed = Math.Round(result.wind.speed / tList.Count, 2);
                result.wind.deg = result.wind.deg / tList.Count;
                result.wind.gust = result.wind.gust / tList.Count;

                result.rain._3h = Math.Round(result.rain._3h / tList.Count, 2);

                result.clouds.all = (int)Math.Round((double)(result.clouds.all / tList.Count), 2);
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

        string SetIcon(ResponseForecastWeather wether)
        {
            string dayOfIcon = "";
            if (wether.weather != null && wether.weather.Count != 0)
            {
                if (wether.weather[0].main.Equals(HttpService.Weather_Clear))
                {
                    dayOfIcon = "sunny_white";
                }
                else if (wether.weather[0].main.Equals(HttpService.Weather_Rain))
                {
                    dayOfIcon = "rain_white";
                }
                else if (wether.weather[0].main.Equals(HttpService.Weather_Clouds))
                {
                    dayOfIcon = "cloudy";
                }
            }

            return dayOfIcon;
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
