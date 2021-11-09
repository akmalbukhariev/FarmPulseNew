using FarmPulse.Net;
using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageSummitClaimViewModel : BaseModel
    {
        #region Properties
        //public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerFieldNameText { get => GetValue<string>(); set => SetValue(value); }
        public string CropTypeText { get => GetValue<string>(); set => SetValue(value); }
        public string AreaTonText { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerNameSurnameText { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerPhoneNumberText { get => GetValue<string>(); set => SetValue(value); }
        public string DescriptionClaimText { get => GetValue<string>(); set => SetValue(value); } 
        public string CropType { get => GetValue<string>(); set => SetValue(value); }
        public string AreaTon { get => GetValue<string>(); set => SetValue(value); }
        public string Name { get => GetValue<string>(); set => SetValue(value); }
        public string PhoneNumber { get => GetValue<string>(); set => SetValue(value); }
        public string Description { get => GetValue<string>(); set => SetValue(value); }
        public string SubmitButtonText { get => GetValue<string>(); set => SetValue(value); }

        public List<string> FieldList { get => GetValue<List<string>>(); set => SetValue(value); }
        public List<string> CropList { get => GetValue<List<string>>(); set => SetValue(value); }
        #endregion

        public PageSummitClaimViewModel(INavigation navigation)
        {
            //Title = "Summit your claim";
            FarmerFieldNameText = "Farmer field name";
            CropTypeText = "Crop type";
            AreaTonText = "Area ton/ha";
            FarmerNameSurnameText = "Farmer Name and Surname";
            FarmerPhoneNumberText = "Farmer Phone number";
            DescriptionClaimText = "Description the claim";
            SubmitButtonText = "Submit";

            Navigation = navigation;
        }

        public ICommand ClickSubmitCommand => new Command(Submit);

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

                ResponseCrop responseCrop = await HttpService.GetCrops();
                if (responseCrop.result)
                {
                    //CropList = responseCrop.list;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        private async void Submit()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new ConfirmationPage());
        }
    }
}
