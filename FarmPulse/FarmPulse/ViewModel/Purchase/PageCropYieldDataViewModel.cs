using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageCropYieldDataViewModel : BaseModel
    {
        #region Properties 
        public string Text_2010 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2011 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2012 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2013 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2014 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2015 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2016 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2017 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2018 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2019 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2020 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2021 { get => GetValue<string>(); set => SetValue(value); }

        public string SelectedFieldItem { get => GetValue<string>(); set => SetValue(value); }
        public string SelectedCropItem { get => GetValue<string>(); set => SetValue(value); }

        public List<string> FieldList { get => GetValue<List<string>>(); set => SetValue(value); }
        public List<string> CropList { get => GetValue<List<string>>(); set => SetValue(value); }
        #endregion

        public PageCropYieldDataViewModel(INavigation navigation)
        { 
            Navigation = navigation;
        }

        public ICommand ClickSaveCommand => new Command(Save);

        public async void GetFields()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            RequestField request = new RequestField()
            {
                username = ControlApp.UserInfo.insuranceNumber,
                langCode = AppSettings.GetLanguageCode
            };

            ResponseField response = await HttpService.GetFieldList(ControlApp.UserInfo.insuranceNumber);
            if (response.result)
            {
                RequestCrop requestCrop = new RequestCrop()
                {
                    username = ControlApp.UserInfo.insuranceNumber,
                    langCode = AppSettings.GetLanguageCode
                };

                //ResponseCrop responseCrop = await HttpService.GetCrops(requestCrop);
                //if (responseCrop.result)
                //{
                //    CropList = responseCrop.list;
                //}
                //else
                //{
                //    await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
                //}
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);    
            }

            ControlApp.CloseLoadingView();
        }

        public async void RefreshModel()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            RequestCropYieldData request = new RequestCropYieldData()
            {
                username = ControlApp.UserInfo.insuranceNumber,
                langCode = AppSettings.GetLanguageCode
            };

            ResponseCropYieldData response = await HttpService.GetCropYieldData(request);
            if (response.result)
            {
                FieldList = response.fieldList;
                CropList = response.cropList;
                SelectedFieldItem = response.selectedField;
                SelectedCropItem = response.selectedCrop;

                Text_2010 = response.Text_2010;
                Text_2011 = response.Text_2011;
                Text_2012 = response.Text_2012;
                Text_2013 = response.Text_2013;
                Text_2014 = response.Text_2014;
                Text_2015 = response.Text_2015;
                Text_2016 = response.Text_2016;
                Text_2017 = response.Text_2017;
                Text_2018 = response.Text_2018;
                Text_2019 = response.Text_2019;
                Text_2020 = response.Text_2020;
                Text_2021 = response.Text_2021;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }
             
            ControlApp.CloseLoadingView();
        }

        private async void Save()
        {
            RequestCropYieldDataSave request = new RequestCropYieldDataSave()
            {
                fieldName = SelectedFieldItem,
                cropName = SelectedCropItem,

                Text_2010 = this.Text_2010,
                Text_2011 = this.Text_2011,
                Text_2012 = this.Text_2012,
                Text_2013 = this.Text_2013,
                Text_2014 = this.Text_2014,
                Text_2015 = this.Text_2015,
                Text_2016 = this.Text_2016,
                Text_2017 = this.Text_2017,
                Text_2018 = this.Text_2018,
                Text_2019 = this.Text_2019,
                Text_2020 = this.Text_2020,
                Text_2021 = this.Text_2021
            };

            ResponseCropYieldDataSave response = await HttpService.SaveCropYieldData(request);
            if (response.result)
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Success, "", RSC.Ok);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }

            await Navigation.PopAsync();
        }
    }
}
