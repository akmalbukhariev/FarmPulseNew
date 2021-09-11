using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PurchaseInsurancePageViewModel : BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string Title1 { get => GetValue<string>(); set => SetValue(value); }
        public List<string> FieldNameList { get => GetValue<List<string>>(); set => SetValue(value); }
        public string FieldNameText { get => GetValue<string>(); set => SetValue(value); }
        public string CropTypeText { get => GetValue<string>(); set => SetValue(value); }
        public string HectarsText { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerNameText { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerPhoneNumberText { get => GetValue<string>(); set => SetValue(value); }
        public string ConfirmPhoneNumberText { get => GetValue<string>(); set => SetValue(value); }
         
        public string CropType { get => GetValue<string>(); set => SetValue(value); }
        public string Hectars { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerName { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerPhoneNumber { get => GetValue<string>(); set => SetValue(value); }
        public string ConfirmPhoneNumber { get => GetValue<string>(); set => SetValue(value); } 
        public string SubmitButtonText { get => GetValue<string>(); set => SetValue(value); }

        public PurchaseInsurancePageViewModel(INavigation navigation)
        {
            Navigation = navigation;

            FieldNameList = new List<string>();

            Title = "Purchase an insurance";
            Title1 = "Make an request";
            FieldNameText = "Farmer field name";
            CropTypeText = "Crop type";
            HectarsText = "Hectars";
            FarmerNameText = "Farmer Name and Surname";
            FarmerPhoneNumberText = "Farmer phone nnumber";
            ConfirmPhoneNumberText = "Confirm phone number";
            SubmitButtonText = "Submit";
        }

        public ICommand ClickSubmitCommand => new Command(Submit);

        private void Submit()
        {
            
        }
    }
}
