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
    public class PagePurchaseInsuranceViewModel : BaseModel
    {
        #region Properties 
        public string CropType { get => GetValue<string>(); set => SetValue(value); }
        public string Hectars { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerName { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerPhoneNumber { get => GetValue<string>(); set => SetValue(value); }
        public string ConfirmPhoneNumber { get => GetValue<string>(); set => SetValue(value); } 

        public FieldInfo SelectedField { get => GetValue<FieldInfo>(); set => SetValue(value); }
        public List<FieldInfo> FieldList { get => GetValue<List<FieldInfo>>(); set => SetValue(value); }
        #endregion

        public PagePurchaseInsuranceViewModel(INavigation navigation)
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
            Hectars = "";
            FarmerName = "";
            FarmerPhoneNumber = "";
            ConfirmPhoneNumber = "";

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
            else if (string.IsNullOrEmpty(Hectars)) ok = false;
            else if (string.IsNullOrEmpty(FarmerName)) ok = false;
            else if (string.IsNullOrEmpty(FarmerPhoneNumber)) ok = false;
            else if (string.IsNullOrEmpty(ConfirmPhoneNumber)) ok = false;
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

            if (FarmerPhoneNumber != ConfirmPhoneNumber)
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "Please check the phone number", RSC.Ok);
                return;
            }

            RequestBuyInsurance request = new RequestBuyInsurance()
            {
                fieldId = SelectedField.fieldId,
                fieldName = SelectedField.name,
                cropName = CropType,
                hectars = Hectars,
                farmerName = FarmerName,
                phoneNumber = FarmerPhoneNumber,
                status = "Submited",
                username = ControlApp.UserInfo.insuranceNumber,
                date = DateTime.Now.ToString()
            };

            ControlApp.ShowLoadingView(RSC.PleaseWait);
            ResponseBuyInsurance response = await HttpService.PurchaseInsurance(request);
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
            await Navigation.PushAsync(new Pages.Purchase.PurchaseInsurance.PageShowPurchasedHistory());
        }
    }
}
