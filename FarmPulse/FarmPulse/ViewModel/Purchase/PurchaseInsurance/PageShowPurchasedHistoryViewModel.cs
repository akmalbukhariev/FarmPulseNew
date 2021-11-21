using FarmPulse.Interface;
using FarmPulse.ModelView;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ViewModel.Purchase.PurchaseInsurance
{
    class PageShowPurchasedHistoryViewModel : BaseModel
    {
        public ObservableCollection<SubmitedPurchaseHistoryInfo> DataList { get; set; }
        public SubmitedPurchaseHistoryInfo SelectedItem { get; set; }

        public PageShowPurchasedHistoryViewModel(INavigation navigation)
        {
            Navigation = navigation;
            DataList = new ObservableCollection<SubmitedPurchaseHistoryInfo>();

            #region For the test
            //SubmitedPurchaseHistoryInfo item1 = new SubmitedPurchaseHistoryInfo()
            //{
            //    fieldId = "13",
            //    fieldName = "Gallazor",
            //    cropName = "Paxta",
            //    hectars = "12",
            //    farmerName = "Ikrom",
            //    phoneNumber = "9989056897425",
            //    status = "purchased",
            //    statusTextWidth = DependencyService.Get<ICalculateTextWidth>().calculateWidth("purchased") + 6
            //};

            //SubmitedPurchaseHistoryInfo item2 = new SubmitedPurchaseHistoryInfo()
            //{
            //    fieldId = "14",
            //    fieldName = "Gallazor",
            //    cropName = "Bug'doy",
            //    hectars = "18",
            //    farmerName = "Zafar",
            //    phoneNumber = "9989012356497",
            //    status = "purchased",
            //    statusTextWidth = DependencyService.Get<ICalculateTextWidth>().calculateWidth("purchased") + 6
            //};

            //SubmitedPurchaseHistoryInfo item3 = new SubmitedPurchaseHistoryInfo()
            //{
            //    fieldId = "15",
            //    fieldName = "Gulzor",
            //    cropName = "Nuxot",
            //    hectars = "18",
            //    farmerName = "Abdulloh",
            //    phoneNumber = "9989032651875",
            //    status = "purchased",
            //    date = "2021.03.05",
            //    statusTextWidth = DependencyService.Get<ICalculateTextWidth>().calculateWidth("purchased") + 6
            //};

            //DataList.Add(item1);
            //DataList.Add(item2);
            //DataList.Add(item3);
            #endregion
        }

        public async void GetSubmitedHistory()
        {
            DataList.Clear();

            ControlApp.ShowLoadingView(RSC.PleaseWait);

            ResponsePurchasedHistory response = await HttpService.GetPurchasedHistory("998977");//ControlApp.UserInfo.insuranceNumber);
            if (response.result)
            {
                foreach (SubmitedPurchaseHistoryInfo item in response.purchases)
                {
                    SubmitedPurchaseHistoryInfo newItem = new SubmitedPurchaseHistoryInfo(item);
                    newItem.statusTextWidth = DependencyService.Get<ICalculateTextWidth>().calculateWidth(item.status) + 6;
                    DataList.Add(newItem);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }
    }
}
