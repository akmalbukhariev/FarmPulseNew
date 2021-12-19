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
        public ObservableCollection<GraphViewDataItem> DataList { get => GetValue<ObservableCollection<GraphViewDataItem>>(); set => SetValue(value); }

        public MetricsInfo SelectedMetrics { get => GetValue<MetricsInfo>(); set => SetValue(value); }
        public List<MetricsInfo> MetricsList { get => GetValue<List<MetricsInfo>>(); set => SetValue(value); }
 
        public PageIndexInsuranceViewModel(INavigation navigation)
        {   
            Navigation = navigation;
            DataList = new ObservableCollection<GraphViewDataItem>();
        }

        public ICommand ClickCropYieldCommand => new Command(CropYield);

        public async void GetIndexList()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);
            ResponseMetricsList response = await HttpService.GetMetricsList();
            if (response.result)
            {
                MetricsList = response.list;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.FailedGetIndex}: {response.message}", RSC.Ok);
            }

            ControlApp.CloseLoadingView();

            if (MetricsList.Count != 0)
            {
                SelectedMetrics = MetricsList[0];
            }
        }

        public async void RefreshGraphViewData(string fieldId)
        {
            DataList.Clear();
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            RequestGraphViewInfo request = new RequestGraphViewInfo()
            {
                fieldId = fieldId,
                metricId = SelectedMetrics.sequence.ToString()
            };

            ResponseGraphView response = await HttpService.GetGraphyViewInfo(request);
            if (response.result)
            {
                ObservableCollection<GraphViewDataItem> tempList = new ObservableCollection<GraphViewDataItem>();
                GraphViewInfo cropYieldInfo = new GraphViewInfo();
                foreach (GraphViewInfo info in response.values)
                {
                    if (info.chartInfoList.Count != 0 && info.name != "cropYield")
                    {
                        GraphViewDataItem newItem = new GraphViewDataItem();
                        newItem.Title = info.cropName;
                        newItem.IndexMeanValue = RSC.IndexMeanValue;
                        newItem.ValueListForMultiple.Add(info.chartInfoList);

                        tempList.Add(newItem);
                    }
                    else if (info.name == "cropYield")
                    {
                        cropYieldInfo = info;
                    }
                }

                for (int i = 0; i < tempList.Count; i++)
                {
                    if (tempList[i].Title.Equals(cropYieldInfo.cropName))
                    {
                        tempList[i].ValueListForMultiple.Add(cropYieldInfo.chartInfoList);
                    }
                }

                DataList = tempList;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.FailedGetGraphData} : {response.message}", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        private async void CropYield()
        {
            SetTransitionType(TransitionType.SlideFromRight);
            await Navigation.PushAsync(new PageCropYieldData());
        }
    }
}
