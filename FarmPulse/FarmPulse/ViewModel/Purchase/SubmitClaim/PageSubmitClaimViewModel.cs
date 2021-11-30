﻿using FarmPulse.Model;
using FarmPulse.Net;
using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView.Purchase.SubmitClaim
{
    public class PageSubmitClaimViewModel : BaseModel
    {
        #region Properties 
        public string CropType { get => GetValue<string>(); set => SetValue(value); }
        public string AreaTon { get => GetValue<string>(); set => SetValue(value); }
        public string Name { get => GetValue<string>(); set => SetValue(value); }
        public string PhoneNumber { get => GetValue<string>(); set => SetValue(value); }
        public string Description { get => GetValue<string>(); set => SetValue(value); } 

        public FieldInfo SelectedField { get => GetValue<FieldInfo>(); set => SetValue(value); }
        public List<FieldInfo> FieldList { get => GetValue<List<FieldInfo>>(); set => SetValue(value); } 
        #endregion

        public PageSubmitClaimViewModel(INavigation navigation)
        { 
            Navigation = navigation;
            FieldList = new List<FieldInfo>();
        }

        public ICommand ClickSubmitCommand => new Command(Submit);
        public ICommand ClickSubmitedHistoryCommand => new Command(SubmitedHistory);

        /// <summary>
        /// Clean the model.
        /// </summary>
        public void Clean()
        {
            CropType = "";
            AreaTon = ""; 
            PhoneNumber = "";
            Description = "";

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
            else if (string.IsNullOrEmpty(AreaTon)) ok = false; 
            else if (string.IsNullOrEmpty(PhoneNumber)) ok = false;
            else if (string.IsNullOrEmpty(Description)) ok = false;
            else if (SelectedField == null) ok = false;

            return ok;
        }

        public async void GetFields()
        {
            Clean();
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            ResponseField response = await HttpService.GetFieldList("998977");// ControlApp.UserInfo.insuranceNumber);
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

        private async void Submit()
        {
            if (!CheckParam())
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "Please fill the all fields.", RSC.Ok);
                return;
            }
             
            RequestSubmitClaim request = new RequestSubmitClaim()
            {
                username = "998977",
                filedName = SelectedField.name,
                fieldId = SelectedField.fieldId,
                areaTon = AreaTon,
                cropType = CropType,
                farmerName = Name,
                farmerPhone = PhoneNumber,
                description = Description,
                status = "Summited",
                langCode = AppSettings.GetLanguageCode
            };

            ControlApp.ShowLoadingView(RSC.PleaseWait);
            ResponseSubmitClaim response = await HttpService.SubmitClaim(request);
            if (response.result)
            {
                SetTransitionType(TransitionType.SlideFromRight);
                await Navigation.PushAsync(new PageConfirmation());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        private async void SubmitedHistory()
        {
            await Navigation.PushAsync(new Pages.Purchase.SubmitClaim.PageShowSubmitedHistory());
        }
    }
}
