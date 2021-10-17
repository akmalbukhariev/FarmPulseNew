﻿using FarmPulse.Model;
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
        public DateTime StartDate { get => GetValue<DateTime>(); set => SetValue(value); }
        public DateTime EndDate { get => GetValue<DateTime>(); set => SetValue(value); }
        public SatelliteData SelectedItem { get => GetValue<SatelliteData>(); set => SetValue(value); }

        public PageMapViewViewModel()
        {
            ShowTimePeriodBox = false;
            Data = new ObservableCollection<SatelliteData>();

            Data.Add(new SatelliteData()
            {
                Date = "2021.03.12",
                ImagePath = "https://samples.agromonitoring.com/image/1.0/02059768a00/5ac22f004b1ae4000b5b97cf?appid=b1b15e88fa797225412429c1c50c122a1"
            });

            Data.Add(new SatelliteData()
            {
                Date = "2021.04.10",
                ImagePath = "http://api.agromonitoring.com/image/1.0/16061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            });

            Data.Add(new SatelliteData()
            {
                Date = "2021.03.09",
                ImagePath = "http://api.agromonitoring.com/image/1.0/16061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            });

            Data.Add(new SatelliteData()
            {
                Date = "2021.02.08",
                ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            });
            Data.Add(new SatelliteData()
            {
                Date = "2021.02.08",
                ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            });
            Data.Add(new SatelliteData()
            {
                Date = "2021.02.08",
                ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            });
            Data.Add(new SatelliteData()
            {
                Date = "2021.02.08",
                ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            });
            Data.Add(new SatelliteData()
            {
                Date = "2021.02.08",
                ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            });
            Data.Add(new SatelliteData()
            {
                Date = "2021.02.08",
                ImagePath = "http://api.agromonitoring.com/image/1.0/12061219380/6067f8f389177086818f03bc?appid=b5efce714742cc3aba8062b29f8c86f1"
            });

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

        private void ClickTimeBoxOk()
        {
            ShowTimePeriodBox = false;
        }

        private void ClickMapType(string type)
        {
            switch (type)
            {
                case "Satellite": break;
                case "Hybrid": break;
                case "Normal": break;
                case "Terrain": break;
            }
        }
    }
}