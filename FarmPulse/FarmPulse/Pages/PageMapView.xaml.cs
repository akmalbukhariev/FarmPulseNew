﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FarmPulse.ModelView;
using FarmPulse.Model;
using System.Globalization;

namespace FarmPulse.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMapView : IPage
    {
        private PageMapViewViewModel model;
        public PageMapView()
        {
            InitializeComponent();
            mapView.EventMapHasLoaded += MapView_EventMapHasLoaded;
        }
         
        public void InitModel()
        {
            model = new PageMapViewViewModel(base.FieldInfo);
            model.CustomMap = mapView;
            BindingContext = model;
        }

        private void MapView_EventMapHasLoaded()
        {
            List<double> lCenter = FieldInfo.GetCenter();
            if (lCenter.Count == 2)
                mapView.Ceneter = new LongLat(lCenter[1], lCenter[0]);
            //mapView.SetMapType(Control.CustomMap.CustomMapType.Normal);
            mapView.Polygon = FieldInfo.String2LongLatList(); 
        }
         
        private void Time_Tapped(object sender, EventArgs e)
        {
            ChangeClickBackColor(stackTime);
            model.ShowTimePeriodBox = true;
            model.ShowBackBoxView = true;
        }

        private async void Image_Tapped(object sender, EventArgs e)
        {
            ChangeClickBackColor(stackImage);

            if (model.Data.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, RSC.ThereIsNotIMage, RSC.Ok);
                return;
            }

            model.ShowImages = true;
            model.ShowBackBoxView = true;
        }

        private async void ChangeClickBackColor(StackLayout stack)
        {
            stack.BackgroundColor = Color.FromHex("#204D2C");
            await Task.Delay(100);

            stack.BackgroundColor = Color.Transparent;
            await Task.Delay(200);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (model.SelectedItem != null)
            {
                model.ShowImages = false;
                model.ShowBackBoxView = false;
                model.DownloadSatelliteImage();
            }
        }
    }
}