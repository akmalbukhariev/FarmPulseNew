 
using FarmPulse.ModelView;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ViewModel.Purchase
{
    class PageShowSubmitedHistoryViewModel : BaseModel
    {
        public ObservableCollection<SubmitedClaimHistoryInfo> DataList { get; set; }

        public PageShowSubmitedHistoryViewModel(INavigation navigation)
        {
            Navigation = navigation;
            DataList = new ObservableCollection<SubmitedClaimHistoryInfo>();

            SubmitedClaimHistoryInfo item1 = new SubmitedClaimHistoryInfo()
            {
                sequence = 1,
                username = "998977",
                fieldId = 13,
                fieldName = "Gallazor",
                cropType = "1",
                areaTon = "1",
                farmerName = "Sherqo'zi",
                farmerPhone = "998977988989",
                description = "This is Bla Bla Bla Claim",
                status = "submitter",
                date = "2021.11.13"
            };

            SubmitedClaimHistoryInfo item2 = new SubmitedClaimHistoryInfo()
            {
                sequence = 1,
                username = "998977",
                fieldId = 13,
                fieldName = "Chorshanbe",
                cropType = "1",
                areaTon = "1",
                farmerName = "Sherqo'zi",
                farmerPhone = "998977988989",
                description = "This is Bla Bla Bla Claim",
                status = "submitter",
                date = "2022.05.26"
            };

            SubmitedClaimHistoryInfo item3 = new SubmitedClaimHistoryInfo()
            {
                sequence = 1,
                username = "998977",
                fieldId = 13,
                fieldName = "Kitab",
                cropType = "1",
                areaTon = "1",
                farmerName = "Sherqo'zi",
                farmerPhone = "998977988989",
                description = "This is Bla Bla Bla Claim",
                status = "submitter",
                date = "2022.05.26"
            };

            SubmitedClaimHistoryInfo item4 = new SubmitedClaimHistoryInfo()
            {
                sequence = 1,
                username = "998977",
                fieldId = 13,
                fieldName = "Miraki",
                cropType = "1",
                areaTon = "1",
                farmerName = "Sherqo'zi",
                farmerPhone = "998977988989",
                description = "This is Bla Bla Bla Claim",
                status = "submitter",
                date = "2022.05.26"
            };

            DataList.Add(item1);
            DataList.Add(item2);
            DataList.Add(item3);
            DataList.Add(item4);
        }
    }
}
