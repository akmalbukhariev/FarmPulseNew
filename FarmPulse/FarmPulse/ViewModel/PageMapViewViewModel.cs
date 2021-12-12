﻿using FarmPulse.Control;
using FarmPulse.Model;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageMapViewViewModel : BaseModel
    {
        public ObservableCollection<SatelliteData> Data { get; } 

        public bool ShowTimePeriodBox { get => GetValue<bool>(); set => SetValue(value); }
        public bool ShowImages { get => GetValue<bool>(); set => SetValue(value); }
        public Color BtnSatelliteTextColor { get => GetValue<Color>(); set => SetValue(value); }
        public Color BtnHybridTextColor { get => GetValue<Color>(); set => SetValue(value); }
        public Color BtnNormalTextColor { get => GetValue<Color>(); set => SetValue(value); }
        public Color BtnTerrainTextColor { get => GetValue<Color>(); set => SetValue(value); }
        public DateTime StartDate { get => GetValue<DateTime>(); set => SetValue(value); }
        public DateTime EndDate { get => GetValue<DateTime>(); set => SetValue(value); }
        public SatelliteData SelectedItem { get => GetValue<SatelliteData>(); set => SetValue(value); }

        public CustomMap CustomMap;

        private MapPolygonInfo PolygonInfo { get; set; }

        private Dictionary<string, string> SatelliteImages = new Dictionary<string, string>();
        public PageMapViewViewModel(FieldInfo fieldInfo)
        {
            PolygonInfo = new MapPolygonInfo();
            PolygonInfo.Polygon = new List<LongLat>();
             
            this.FieldInfo = fieldInfo;
            ShowTimePeriodBox = false;
            Data = new ObservableCollection<SatelliteData>();

            BtnSatelliteTextColor = Color.Black;
            BtnHybridTextColor = Color.Black;
            BtnNormalTextColor = Color.Red;
            BtnTerrainTextColor = Color.Black;
            
            #region For the test
            //Data.Add(new SatelliteData()
            //{
            //    Date = "2021.03.12",
            //    ImagePath = "https://samples.agromonitoring.com/image/1.0/02059768a00/5ac22f004b1ae4000b5b97cf?appid=b1b15e88fa797225412429c1c50c122a1"
            //});

            //Data.Add(new SatelliteData()
            //{
            //    Date = "2021.04.10",
            //    ImagePath = "http://api.agromonitoring.com/image/1.0/16061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            //});

            //Data.Add(new SatelliteData()
            //{
            //    Date = "2021.03.09",
            //    ImagePath = "http://api.agromonitoring.com/image/1.0/16061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            //});

            //Data.Add(new SatelliteData()
            //{
            //    Date = "2021.02.08",
            //    ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            //});
            //Data.Add(new SatelliteData()
            //{
            //    Date = "2021.02.08",
            //    ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            //});
            //Data.Add(new SatelliteData()
            //{
            //    Date = "2021.02.08",
            //    ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            //});
            //Data.Add(new SatelliteData()
            //{
            //    Date = "2021.02.08",
            //    ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            //});
            //Data.Add(new SatelliteData()
            //{
            //    Date = "2021.02.08",
            //    ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            //});
            //Data.Add(new SatelliteData()
            //{
            //    Date = "2021.02.08",
            //    ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            //});
            #endregion

            StartDate = DateTime.Now.AddDays(-20);
            EndDate = DateTime.Now;
        }

        public ICommand ClickBackBoxCommand => new Command(ClickBack);
        public ICommand ClickBackShowImageBoxCommand => new Command(ClickBackShowImageBox);
        public ICommand ClickTimeBoxOkCommand => new Command(ClickTimeBoxOk);
        public ICommand ClickMapTypeCommand => new Command<string>(ClickMapType);

        private void ClickBack()
        {
            ShowTimePeriodBox = false;
        }

        private void ClickBackShowImageBox()
        {
            ShowImages = false;
        }

        private async void ClickTimeBoxOk()
        {
            ShowTimePeriodBox = false;
            RequestGetSatelliteImagesInfo request = new RequestGetSatelliteImagesInfo()
            {
                start = ControlApp.DateTimeToUnixTimestamp(StartDate).ToString(),
                end = ControlApp.DateTimeToUnixTimestamp(EndDate).ToString(),
                polyid = this.FieldInfo.fieldId
            };

            List<ResponseSatelliteImagesInfo> responseImage = await HttpService.GetSatelliteImagesInfo(request);
            ResponsePolygon responsePolygon = await HttpService.GetPolygonInfo(request.polyid);

            if (string.IsNullOrEmpty(responsePolygon.id))
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, responsePolygon.message, RSC.Ok);
                ControlApp.CloseLoadingView();
                return;
            }

            PolygonInfo.minLat = double.MaxValue;
            PolygonInfo.minLon = double.MaxValue;

            PolygonInfo.maxLat = double.MinValue;
            PolygonInfo.maxLon = double.MinValue;

            foreach (List<List<double>> point in responsePolygon.geo_json.geometry.coordinates)
            {
                foreach (List<double> p in point)
                {
                    LongLat lonlat = new LongLat();
                    lonlat.Longitude = p[0];
                    lonlat.Latitude = p[1];

                    PolygonInfo.Polygon.Add(lonlat);

                    if (PolygonInfo.minLat >= lonlat.Latitude)
                    {
                        PolygonInfo.minLat = lonlat.Latitude;
                        PolygonInfo.minLatLon = lonlat.Longitude;
                    }

                    if (PolygonInfo.minLon >= lonlat.Longitude)
                    {
                        PolygonInfo.minLon = lonlat.Longitude;
                        PolygonInfo.minLonLat = lonlat.Latitude;
                    }

                    if (PolygonInfo.maxLat <= lonlat.Latitude)
                    {
                        PolygonInfo.maxLat = lonlat.Latitude;
                        PolygonInfo.maxLatLon = lonlat.Longitude;
                    }

                    if (PolygonInfo.maxLon <= lonlat.Longitude)
                    {
                        PolygonInfo.maxLon = lonlat.Longitude;
                        PolygonInfo.maxLonLat = lonlat.Latitude;
                    }
                }
            }

            PolygonInfo.area = responsePolygon.area;
            PolygonInfo.Position = new LongLat(responsePolygon.center[1], responsePolygon.center[0]);

            List<string> tempList = new List<string>();
            for (int i = 0; i < responseImage.Count; i++)
            {
                if (responseImage[i].image == null) continue;

                string imDate = ControlApp.UnixTimeStampToDateTime((double)(responseImage[i].dt)).ToString("yyyy-MM-dd");

                if (!SatelliteImages.ContainsKey(imDate))
                {
                    SatelliteImages.Add(imDate, responseImage[i].image.ndvi);
                    tempList.Add(imDate);
                }
            }
        }

        private void ClickMapType(string type)
        {
            if (CustomMap == null) return;

            switch (type)
            {
                case "Satellite":
                    BtnSatelliteTextColor = Color.Red;
                    BtnHybridTextColor = Color.Black;
                    BtnNormalTextColor = Color.Black;
                    BtnTerrainTextColor = Color.Black;
                    CustomMap.SetMapType(CustomMap.CustomMapType.Satellite); 
                    break;
                case "Hybrid":
                    BtnSatelliteTextColor = Color.Black;
                    BtnHybridTextColor = Color.Red;
                    BtnNormalTextColor = Color.Black;
                    BtnTerrainTextColor = Color.Black;
                    CustomMap.SetMapType(CustomMap.CustomMapType.Hybrid); 
                    break;
                case "Normal":
                    BtnSatelliteTextColor = Color.Black;
                    BtnHybridTextColor = Color.Black;
                    BtnNormalTextColor = Color.Red;
                    BtnTerrainTextColor = Color.Black;
                    CustomMap.SetMapType(CustomMap.CustomMapType.Normal); 
                    break;
                case "Terrain":
                    BtnSatelliteTextColor = Color.Black;
                    BtnHybridTextColor = Color.Black;
                    BtnNormalTextColor = Color.Black;
                    BtnTerrainTextColor = Color.Red;
                    CustomMap.SetMapType(CustomMap.CustomMapType.Terrain); 
                    break;
            }
        } 
    }
}
