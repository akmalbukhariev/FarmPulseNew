using FarmPulse.Model;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageGraphViewViewModel : BaseModel
    {
        public ObservableCollection<GraphViewDataItem> DataList { get; set; } 
        public MetricsInfo SelectedMetrics { get => GetValue<MetricsInfo>(); set => SetValue(value); }
        public List<MetricsInfo> MetricsList { get => GetValue<List<MetricsInfo>>(); set => SetValue(value); }
         
        public PageGraphViewViewModel()
        {
            DataList = new ObservableCollection<GraphViewDataItem>();

            GraphViewData data = new GraphViewData();
            data.year = "2010";
            data.value = "12";
            GraphViewDataItem item1 = new GraphViewDataItem();
            item1.Title = "AAAAAAAAAA";
            item1.IndexMeanValue = RSC.IndexMeanValue;
            item1.ValueList.Add(data);
            item1.ValueList.Add(data);
            item1.ValueList.Add(data);
            item1.ValueList.Add(data);

            GraphViewDataItem item2 = new GraphViewDataItem();
            item2.Title = "BBBBBB";
            item2.IndexMeanValue = RSC.IndexMeanValue;
            item2.ValueList.Add(data);
            item2.ValueList.Add(data);
            item2.ValueList.Add(data);

            GraphViewDataItem item3 = new GraphViewDataItem();
            item3.Title = "CCCCCCCC";
            item3.IndexMeanValue = RSC.IndexMeanValue;
            item3.ValueList.Add(data);
            item3.ValueList.Add(data);
            item3.ValueList.Add(data);

            GraphViewDataItem item4 = new GraphViewDataItem();
            item4.Title = "XXXXXXXXXXXXX";
            item4.IndexMeanValue = RSC.IndexMeanValue;
            item4.ValueList.Add(data);
            item4.ValueList.Add(data);
            item4.ValueList.Add(data);
            item4.ValueList.Add(data);
            item4.ValueList.Add(data);

            DataList.Add(item1);
            DataList.Add(item2);
            DataList.Add(item3);
            DataList.Add(item4);
        }

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
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }

        public async void RefreshGraphViewData(string fieldId)
        {
            return;
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            RequestGraphViewInfo request = new RequestGraphViewInfo()
            {
                fieldId = fieldId,
                metricId = SelectedMetrics.sequence.ToString()
            };

            ResponseGraphView response = await HttpService.GetGraphyViewInfo(request);
            if (response.result)
            {
                foreach (GraphViewInfo info in response.values)
                {
                    if (info.chartInfoList.Count != 0)
                    {
                        GraphViewDataItem newItem = new GraphViewDataItem();
                        newItem.Title = info.cropName;
                        newItem.IndexMeanValue = RSC.IndexMeanValue;
                        newItem.ValueList = info.chartInfoList;

                        DataList.Add(newItem);
                    }
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
