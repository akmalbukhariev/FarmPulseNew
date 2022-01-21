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
        public bool ShowFieldNameBox { get => GetValue<bool>(); set => SetValue(value); }
        public string TextSelectFieldName { get => GetValue<string>(); set => SetValue(value); }

        #region Title yesr property
        public string TitleYear_1 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_2 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_3 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_4 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_5 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_6 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_7 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_8 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_9 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_10 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_11 { get => GetValue<string>(); set => SetValue(value); }
        public string TitleYear_12 { get => GetValue<string>(); set => SetValue(value); }
        #endregion

        #region Year value
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
        #endregion

        public string CropType { get => GetValue<string>(); set => SetValue(value); }

        public FieldInfo SelectedField { get => GetValue<FieldInfo>(); set => SetValue(value); }
        public List<FieldInfo> FieldList { get => GetValue<List<FieldInfo>>(); set => SetValue(value); }
        #endregion

        public PageCropYieldDataViewModel(INavigation navigation)
        { 
            Navigation = navigation;
            FieldList = new List<FieldInfo>();

            TextSelectFieldName = " ";
            InitTitleYear();
        }

        public ICommand ClickSaveCommand => new Command(Save);
        public ICommand ClickSelectFieldCommand => new Command(SelectField);
        public ICommand ClickBackGroundBoxCommand => new Command(ClickBackGroundBox);

        void InitTitleYear()
        {
            int endYear = Date.Year;
            TitleYear_12 = endYear.ToString();
            TitleYear_11 = (endYear - 1).ToString();
            TitleYear_10 = (endYear - 2).ToString();
            TitleYear_9 = (endYear - 3).ToString();
            TitleYear_8 = (endYear - 4).ToString();
            TitleYear_7 = (endYear - 5).ToString();
            TitleYear_6 = (endYear - 6).ToString();
            TitleYear_5 = (endYear - 7).ToString();
            TitleYear_4 = (endYear - 8).ToString();
            TitleYear_3 = (endYear - 9).ToString();
            TitleYear_2 = (endYear - 10).ToString();
            TitleYear_1 = (endYear - 11).ToString();
        }

        /// <summary>
        /// Clean the model.
        /// </summary>
        public void Clean()
        {
            Text_2010 = "";
            Text_2011 = "";
            Text_2012 = "";
            Text_2013 = "";
            Text_2014 = "";
            Text_2015 = "";
            Text_2016 = "";
            Text_2017 = "";
            Text_2018 = "";
            Text_2019 = "";
            Text_2020 = "";
            Text_2021 = "";

            SelectedField = null;
            FieldList.Clear();
        }

        /// <summary>
        /// Check the all parameters before submitting.
        /// </summary>
        /// <returns></returns>
        public bool CheckParam()
        {
            bool ok = true;
            if (string.IsNullOrEmpty(CropType)) ok = false; 
            else if (SelectedField == null) ok = false;

            return ok;
        }

        public async void GetFields()
        {
            Clean();
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            ResponseField response = await HttpService.GetFieldList(ControlApp.UserInfo.insuranceNumber);
            if (response.result)
            {
                FieldList = response.fields;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.FailedGetField}: {response.message}", RSC.Ok);
            }

            ControlApp.CloseLoadingView();

            if (FieldList.Count != 0)
            {
                SelectedField = FieldList[0];
            }
        }

        private void SelectField()
        {
            ShowFieldNameBox = true;
        }

        private void ClickBackGroundBox()
        {
            ShowFieldNameBox = false;
        }

        public async void RefreshModel()
        {
            #region Clean text year
                Text_2010 = "";
                Text_2011 = "";
                Text_2012 = "";
                Text_2013 = "";
                Text_2014 = "";
                Text_2015 = "";
                Text_2016 = "";
                Text_2017 = "";
                Text_2018 = "";
                Text_2019 = "";
                Text_2020 = "";
                Text_2021 = "";
            #endregion
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            RequestCropYieldData request = new RequestCropYieldData()
            {
                username = ControlApp.UserInfo.insuranceNumber,
                langCode = AppSettings.GetLanguageCode,
                fieldId = SelectedField.fieldId
            };

            ResponseCropYieldData response = await HttpService.GetCropYieldData(request);
            if (response.result)
            {
                CropType = response.cropName;
                foreach (CropYieldDataYearInfo item in response.values)
                {
                    switch (item.year.Trim())
                    {
                        case nameof(Text_2010): Text_2010 = item.value; break; //999
                        case nameof(Text_2011): Text_2011 = item.value; break;
                        case nameof(Text_2012): Text_2012 = item.value; break;
                        case nameof(Text_2013): Text_2013 = item.value; break;
                        case nameof(Text_2014): Text_2014 = item.value; break;
                        case nameof(Text_2015): Text_2015 = item.value; break;
                        case nameof(Text_2016): Text_2016 = item.value; break;
                        case nameof(Text_2017): Text_2017 = item.value; break;
                        case nameof(Text_2018): Text_2018 = item.value; break;
                        case nameof(Text_2019): Text_2019 = item.value; break;
                        case nameof(Text_2020): Text_2020 = item.value; break;
                        case nameof(Text_2021): Text_2021 = item.value; break;
                    } 
                } 
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.FailedGetCropYielddata} :{response.message}", RSC.Ok);
            }
             
            ControlApp.CloseLoadingView();
        }

        private async void Save()
        {
            if (!Control.ControlApp.Instance.InternetOk())
                return;

            if (!CheckParam())
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, RSC.FindInsuranceMessage1, RSC.Ok);
                return;
            }

            RequestCropYieldDataSave request = new RequestCropYieldDataSave()
            {
                 fieldId = SelectedField.fieldId,
                 cropName = CropType,
                 username = ControlApp.UserInfo.insuranceNumber
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
                await Navigation.PopAsync(); 
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.SaveCropYielddata} :{response.message}", RSC.Ok);
            } 
        }
    }
}
