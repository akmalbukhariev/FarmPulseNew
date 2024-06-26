﻿
using FarmPulse.Interface;
using FarmPulse.ModelView;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ViewModel.Purchase.SubmitClaim
{
    class PageShowSubmitedHistoryViewModel : BaseModel
    { 
        public ObservableCollection<SubmitedClaimHistoryInfo> DataList { get; set; }
        public SubmitedClaimHistoryInfo SelectedItem { get; set; }
        public PageShowSubmitedHistoryViewModel(INavigation navigation)
        {
            Navigation = navigation;
            DataList = new ObservableCollection<SubmitedClaimHistoryInfo>();

            #region For the test
            //SubmitedClaimHistoryInfo item1 = new SubmitedClaimHistoryInfo()
            //{
            //    sequence = 1,
            //    username = "998977",
            //    fieldId = 13,
            //    fieldName = "Gallazor",
            //    cropType = "1",
            //    areaTon = "1",
            //    farmerName = "Sherqo'zi",
            //    farmerPhone = "998977988989",
            //    description = "This is Bla Bla Bla Claim",
            //    status = "Submited",
            //    date = "2021.11.13",
            //    statusTextWidth = DependencyService.Get<ICalculateTextWidth>().calculateWidth("Submited") + 6
            //};

            //SubmitedClaimHistoryInfo item2 = new SubmitedClaimHistoryInfo()
            //{
            //    sequence = 1,
            //    username = "998977",
            //    fieldId = 13,
            //    fieldName = "Chorshanbe",
            //    cropType = "1",
            //    areaTon = "1",
            //    farmerName = "Sherqo'zi",
            //    farmerPhone = "998977988989",
            //    description = "This is Bla Bla Bla Claim",
            //    status = "Submited",
            //    date = "2022.05.26",
            //    statusTextWidth = DependencyService.Get<ICalculateTextWidth>().calculateWidth("Submited") + 6
            //};

            //SubmitedClaimHistoryInfo item3 = new SubmitedClaimHistoryInfo()
            //{
            //    sequence = 1,
            //    username = "998977",
            //    fieldId = 13,
            //    fieldName = "Kitab",
            //    cropType = "1",
            //    areaTon = "1",
            //    farmerName = "Sherqo'zi",
            //    farmerPhone = "998977988989",
            //    description = "This is Bla Bla Bla Claim",
            //    status = "Submited",
            //    date = "2022.05.26",
            //    statusTextWidth = DependencyService.Get<ICalculateTextWidth>().calculateWidth("Submited") + 6
            //};

            //SubmitedClaimHistoryInfo item4 = new SubmitedClaimHistoryInfo()
            //{
            //    sequence = 1,
            //    username = "998977",
            //    fieldId = 13,
            //    fieldName = "Miraki",
            //    cropType = "1",
            //    areaTon = "1",
            //    farmerName = "Sherqo'zi",
            //    farmerPhone = "998977988989",
            //    description = "This is Bla Bla Bla Claim",
            //    status = "Submited",
            //    date = "2022.05.26",
            //    statusTextWidth = DependencyService.Get<ICalculateTextWidth>().calculateWidth("Submited") + 6
            //};

            //DataList.Add(item1);
            //DataList.Add(item2);
            //DataList.Add(item3);
            //DataList.Add(item4);
            #endregion
        }
        
        public async void GetSubmitedHistory()
        {
            DataList.Clear();

            ControlApp.ShowLoadingView(RSC.PleaseWait);

            ResponseSubmitedClaimHistory response = await HttpService.GetSubmitedClaims(ControlApp.UserInfo.insuranceNumber);
            if (response.result)
            {
                foreach (SubmitedClaimHistoryInfo item in response.claims)
                {
                    SubmitedClaimHistoryInfo newItem = new SubmitedClaimHistoryInfo(item);
                    newItem.statusTextWidth = DependencyService.Get<ICalculateTextWidth>().calculateWidth(item.status) + 6;
                     
                    if (newItem.status == Constant.Submited)
                        newItem.statusColor = Color.Orange;
                    else if (newItem.status == Constant.Approved)
                        newItem.statusColor = Color.Green;
                    else if (newItem.status == Constant.Rejected)
                        newItem.statusColor = Color.Red;

                    DataList.Add(newItem);
                }
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.SubmitedGetHistoryFailed} :{response.message}", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }
    }
}
