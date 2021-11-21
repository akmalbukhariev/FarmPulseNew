using FarmPulse.Model;
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
 
        public FieldInfo selectedField { get => GetValue<FieldInfo>(); set => SetValue(value); }
        public List<FieldInfo> FieldList { get => GetValue<List<FieldInfo>>(); set => SetValue(value); }
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
                FieldList = response.fields;
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
                foreach (CropYieldDataYearInfo item in response.values)
                {
                    switch (item.year.Trim())
                    {
                        case nameof(Text_2010): Text_2010 = item.year; break;
                        case nameof(Text_2011): Text_2011 = item.year; break;
                        case nameof(Text_2012): Text_2012 = item.year; break;
                        case nameof(Text_2013): Text_2013 = item.year; break;
                        case nameof(Text_2014): Text_2014 = item.year; break;
                        case nameof(Text_2015): Text_2015 = item.year; break;
                        case nameof(Text_2016): Text_2016 = item.year; break;
                        case nameof(Text_2017): Text_2017 = item.year; break;
                        case nameof(Text_2018): Text_2018 = item.year; break;
                        case nameof(Text_2019): Text_2019 = item.year; break;
                        case nameof(Text_2020): Text_2020 = item.year; break;
                        case nameof(Text_2021): Text_2021 = item.year; break;
                    } 
                } 
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
                 fieldId = selectedField.fieldId,
                 cropName = "" 
            };
            request.values = new List<CropYieldDataYearInfo>();
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2010), Text_2010));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2011), Text_2011));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2012), Text_2012));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2013), Text_2013));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2014), Text_2014));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2015), Text_2015));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2016), Text_2016));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2017), Text_2017));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2018), Text_2018));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2019), Text_2019));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2020), Text_2020));
            request.values.Add(new CropYieldDataYearInfo(nameof(Text_2021), Text_2021));

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
