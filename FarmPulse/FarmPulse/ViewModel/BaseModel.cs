using FarmPulse.Control;
using FarmPulse.Model;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel; 
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class BaseModel : INotifyPropertyChanged
    {
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<Net.Region> Regions { get; set; }
        public ObservableCollection<District> Districts { get; set; }

        public Country SelectedCountry { get => GetValue<Country>(); set => SetValue(value); }
        public Net.Region SelectedRegion { get => GetValue<Net.Region>(); set => SetValue(value); }
        public District SelectedDistrict { get => GetValue<District>(); set => SetValue(value); }

        public DateTime Date { get => GetValue<DateTime>(); set => SetValue(value); }
        public string PhoneNumber { get => GetValue<string>(); set => SetValue(value); }

        protected BaseModel()
        {
            Countries = new ObservableCollection<Country>();
            Regions = new ObservableCollection<Net.Region>();
            Districts = new ObservableCollection<District>();

            Date = DateTime.Now;
        }

        public FieldInfo FieldInfo { get; set; }
        protected ControlApp ControlApp => ControlApp.Instance;
        protected INavigation Navigation { get; set; }
        public Element Parent { get; set; }

        private Dictionary<string, object> PropertyList;

        public event PropertyChangedEventHandler PropertyChanged;

        protected T GetValue<T>([CallerMemberName] string propertyName = "")
        {
            if (PropertyList == null)
                PropertyList = new Dictionary<string, object>();

            if (!PropertyList.ContainsKey(propertyName))
                return default;

            return (T)PropertyList[propertyName];
        }

        protected void SetValue(object value, [CallerMemberName] string propertyName = "")
        {
            if (PropertyList == null)
                PropertyList = new Dictionary<string, object>();

            if (PropertyList.ContainsKey(propertyName))
            {
                if (PropertyList[propertyName] == value) return;

                PropertyList[propertyName] = value;
            }
            else
            {
                PropertyList.Add(propertyName, value);
            }

            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetTransitionType(TransitionType transitionType)
        {
            if (Parent == null) return;

            var transitionNavigationPage = Parent as TransitionNavigationPage;
            if (transitionNavigationPage != null)
                transitionNavigationPage.TransitionType = transitionType;
        }

        public async void GetCountrys()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);
            ResponseCountries response = await HttpService.GetCountrys();
            if (response.result)
            {
                foreach (Country item in response.countries)
                {
                    Countries.Add(new Country(item));
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.FailedGetCountry} :{response.message}", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        public async void GetRegions()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);
            ResponseRegions response = await HttpService.GetRegions(SelectedCountry.id.ToString());
            if (response.result)
            {
                foreach (Net.Region item in response.regions)
                {
                    Regions.Add(new Net.Region(item));
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.FailedGetRegion} :{response.message}", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        public async void GetDistricts()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);
            ResponseDistrict response = await HttpService.GetDistricts(SelectedRegion.id.ToString());
            if (response.result)
            {
                foreach (District item in response.districts)
                {
                    Districts.Add(new District(item));
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.FailedGetDistrict} :{response.message}", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }
    }
}
