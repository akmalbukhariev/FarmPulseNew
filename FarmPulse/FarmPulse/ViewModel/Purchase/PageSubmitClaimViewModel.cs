using FarmPulse.Model;
using FarmPulse.Net;
using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageSubmitClaimViewModel : BaseModel
    {
        #region Properties 
        public string CropType { get => GetValue<string>(); set => SetValue(value); }
        public string AreaTon { get => GetValue<string>(); set => SetValue(value); }
        public string Name { get => GetValue<string>(); set => SetValue(value); }
        public string PhoneNumber { get => GetValue<string>(); set => SetValue(value); }
        public string Description { get => GetValue<string>(); set => SetValue(value); }
        public string SubmitButtonText { get => GetValue<string>(); set => SetValue(value); }

        public FieldInfo selectedField { get => GetValue<FieldInfo>(); set => SetValue(value); }
        public List<FieldInfo> FieldList { get => GetValue<List<FieldInfo>>(); set => SetValue(value); } 
        #endregion

        public PageSubmitClaimViewModel(INavigation navigation)
        {
            //Title = "Summit your claim";
            //FarmerFieldNameText = "Farmer field name";
            //CropTypeText = "Crop type";
            //AreaTonText = "Area ton/ha";
            //FarmerNameSurnameText = "Farmer Name and Surname";
            //FarmerPhoneNumberText = "Farmer Phone number";
            //DescriptionClaimText = "Description the claim";
            //SubmitButtonText = "Submit";

            Navigation = navigation;
        }

        public ICommand ClickSubmitCommand => new Command(Submit);
        public ICommand ClickSubmitedHistoryCommand => new Command(SubmitedHistory);

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

        private async void Submit()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            RequestSubmitClaim request = new RequestSubmitClaim()
            {
                username = ControlApp.UserInfo.insuranceNumber,
                filedName = selectedField.name,
                fieldId = selectedField.field_id,
                areaTon = AreaTon,
                cropType = CropType,
                farmerName = Name,
                farmerPhone = PhoneNumber,
                description = Description,
                status = "Summited",
                langCode = AppSettings.GetLanguageCode
            };

            ResponseSubmitClaim response = await HttpService.SubmitClaim(request);
            if (response.result)
            {
                SetTransitionType(TransitionType.SlideFromRight);
                await Navigation.PushAsync(new ConfirmationPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        private async void SubmitedHistory()
        {
            
        }
    }
}
