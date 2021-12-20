using FarmPulse.ModelView;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ViewModel.Purchase.PurchaseInsurance
{
    class PageDetailPurchasedHistoryViewModel : BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string FieldName { get => GetValue<string>(); set => SetValue(value); }
        public string CropName { get => GetValue<string>(); set => SetValue(value); }
        public string Hectars { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerName { get => GetValue<string>(); set => SetValue(value); } 
        public string Status { get => GetValue<string>(); set => SetValue(value); }
        public string StrDate { get => GetValue<string>(); set => SetValue(value); }

        public PageDetailPurchasedHistoryViewModel(SubmitedPurchaseHistoryInfo info,INavigation navigation)
        {
            Title = info.fieldName;
            FieldName = info.fieldName;
            CropName = info.cropName;
            Hectars = info.hectares;
            FarmerName = info.farmerName;
            PhoneNumber = info.phoneNumber;
            Status = info.status;
            StrDate = info.date;

            Navigation = navigation;
        }

        public ICommand ClickOkCommand => new Command(ClickOk);

        public async void ClickOk()
        {
            await Navigation.PopAsync();
        }
    }
}
