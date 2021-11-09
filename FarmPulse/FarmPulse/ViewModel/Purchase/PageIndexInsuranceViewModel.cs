using FarmPulse.Model;
using FarmPulse.Net;
using FarmPulse.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageIndexInsuranceViewModel : BaseModel
    {
        public ObservableCollection<GraphViewDataItem> DataList { get; set; }
        public string Title { get => GetValue<string>(); set => SetValue(value); } 
        public string SelectIndexTitle { get => GetValue<string>(); set => SetValue(value); }
        public string SelectedIndexItem { get => GetValue<string>(); set => SetValue(value); } 
        public List<string> IndexList { get => GetValue<List<string>>(); set => SetValue(value); }
        
        private ResponseIndexList responseIndex = null;
        public PageIndexInsuranceViewModel(INavigation navigation)
        {  
            IndexList = new List<string>(); 

            Navigation = navigation;
        }

        public ICommand ClickCropYieldCommand => new Command(CropYield);

        public async void GetIndexList()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);
            responseIndex = await HttpService.GetIndexList();
            if (responseIndex.result)
            {
                foreach (IndexInfo item in responseIndex.list)
                {
                    IndexList.Add(item.indexName);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }
            ControlApp.CloseLoadingView();
        }

        public async void RefreshGraphViewData(string indexName, string fieldId)
        {
            IndexInfo tempInfo = responseIndex.list.Find(x => x.indexName == indexName);
            RequestGraphViewInfo request = new RequestGraphViewInfo()
            {
                field_id = fieldId,
                sequence = tempInfo == null ? "" : tempInfo.indexName,
                username = ControlApp.UserInfo.insuranceNumber,
                langCode = AppSettings.GetLanguageCode
            };

            ControlApp.ShowLoadingView(RSC.PleaseWait);
            ResponseGraphView response = await HttpService.GetGraphyViewInfo(request);
            if (response.result)
            {
                foreach (GraphViewInfo item in response.list)
                {
                    GraphViewDataItem newItem = new GraphViewDataItem();
                    newItem.Title = item.cropName;
                    newItem.IndexMeanValue = RSC.IndexMeanValue;

                    foreach (GraphViewData info in item.chartInfoList)
                    {
                        newItem.ValueList.Add(new GraphViewData(info));
                    }

                    DataList.Add(newItem);
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, response.message, RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        private async void CropYield()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new CropYieldDataPage());
        }
    }
}
