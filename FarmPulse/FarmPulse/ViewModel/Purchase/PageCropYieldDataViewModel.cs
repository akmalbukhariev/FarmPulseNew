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
        public string TextYear_1 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_2 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_3 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_4 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_5 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_6 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_7 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_8 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_9 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_10 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_11 { get => GetValue<string>(); set => SetValue(value); }
        public string TextYear_12 { get => GetValue<string>(); set => SetValue(value); }
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
            TextYear_1 = "";
            TextYear_2 = "";
            TextYear_3 = "";
            TextYear_4 = "";
            TextYear_5 = "";
            TextYear_6 = "";
            TextYear_7 = "";
            TextYear_8 = "";
            TextYear_9 = "";
            TextYear_10 = "";
            TextYear_11 = "";
            TextYear_12 = "";

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
                TextYear_1 = "";
                TextYear_2 = "";
                TextYear_3 = "";
                TextYear_4 = "";
                TextYear_5 = "";
                TextYear_6 = "";
                TextYear_7 = "";
                TextYear_8 = "";
                TextYear_9 = "";
                TextYear_10 = "";
                TextYear_11 = "";
                TextYear_12 = "";
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
                    if (item.year.Trim() == $"Text_{TitleYear_1}")      TextYear_1 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_2}") TextYear_2 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_3}") TextYear_3 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_4}") TextYear_4 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_5}") TextYear_5 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_6}") TextYear_6 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_7}") TextYear_7 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_8}") TextYear_8 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_9}") TextYear_9 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_10}") TextYear_10 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_11}") TextYear_11 = item.value;
                    else if (item.year.Trim() == $"Text_{TitleYear_12}") TextYear_12 = item.value;
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
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_1}", TextYear_1));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_2}", TextYear_2));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_3}", TextYear_3));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_4}", TextYear_4));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_5}", TextYear_5));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_6}", TextYear_6));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_7}", TextYear_7));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_8}", TextYear_8));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_9}", TextYear_9));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_10}", TextYear_10));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_11}", TextYear_11));
            request.values.Add(new CropYieldDataYearInfo($"Text_{TitleYear_12}", TextYear_12));

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
