using FarmPulse.ModelView;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmPulse.ViewModel.Purchase.SubmitClaim
{
    class PageDetailSubmitedHistoryViewModel : BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string FieldName { get => GetValue<string>(); set => SetValue(value); }
        public string CropType { get => GetValue<string>(); set => SetValue(value); }
        public string AreaTonHa { get => GetValue<string>(); set => SetValue(value); }
        public string FarmerName { get => GetValue<string>(); set => SetValue(value); }
        public string PhoneNumber { get => GetValue<string>(); set => SetValue(value); }
        public string Description { get => GetValue<string>(); set => SetValue(value); }
        public PageDetailSubmitedHistoryViewModel(SubmitedClaimHistoryInfo info)
        {
            Title = info.fieldName;
            FieldName = info.fieldName;
            CropType = info.cropType;
            AreaTonHa = info.areaTon;
            FarmerName = info.farmerName;
            PhoneNumber = info.farmerPhone;
            Description = info.description;
        }
    }
}
