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

            #region For the test
            //GraphViewDataItem item1 = new GraphViewDataItem();
            //item1.Title = "AAAAAAAAAA";
            //item1.IndexMeanValue = RSC.IndexMeanValue;
            //item1.ValueList.Add(new GraphViewData() { year = "2010", value = "20" });
            //item1.ValueList.Add(new GraphViewData() { year = "2011", value = "5" });
            //item1.ValueList.Add(new GraphViewData() { year = "2012", value = "40" });
            //item1.ValueList.Add(new GraphViewData() { year = "2013", value = "10" });
            //item1.ValueList.Add(new GraphViewData() { year = "2014", value = "8" });
            //item1.ValueList.Add(new GraphViewData() { year = "2015", value = "20" });
            //item1.ValueList.Add(new GraphViewData() { year = "2016", value = "40" });
            //item1.ValueList.Add(new GraphViewData() { year = "2017", value = "5" });
            //item1.ValueList.Add(new GraphViewData() { year = "2018", value = "15" });

            //GraphViewDataItem item2 = new GraphViewDataItem();
            //item2.Title = "BBBBBB";
            //item2.IndexMeanValue = RSC.IndexMeanValue;
            //item2.ValueList.Add(new GraphViewData() { year = "2010", value = "13" });
            //item2.ValueList.Add(new GraphViewData() { year = "2011", value = "25" });
            //item2.ValueList.Add(new GraphViewData() { year = "2012", value = "50" });
            //item2.ValueList.Add(new GraphViewData() { year = "2013", value = "35" });

            //GraphViewDataItem item3 = new GraphViewDataItem();
            //item3.Title = "CCCCCCCC";
            //item3.IndexMeanValue = RSC.IndexMeanValue;
            //item3.ValueList.Add(new GraphViewData() { year = "2010", value = "18" });
            //item3.ValueList.Add(new GraphViewData() { year = "2011", value = "5" });
            //item3.ValueList.Add(new GraphViewData() { year = "2012", value = "7" });
            //item3.ValueList.Add(new GraphViewData() { year = "2013", value = "60" });

            //GraphViewDataItem item4 = new GraphViewDataItem();
            //item4.Title = "XXXXXXXXXXXXX";
            //item4.IndexMeanValue = RSC.IndexMeanValue;
            //item4.ValueList.Add(new GraphViewData() { year = "2010", value = "45" });
            //item4.ValueList.Add(new GraphViewData() { year = "2011", value = "25" });
            //item4.ValueList.Add(new GraphViewData() { year = "2012", value = "40" });
            //item4.ValueList.Add(new GraphViewData() { year = "2013", value = "23" });

            //DataList.Add(item1);
            //DataList.Add(item2);
            //DataList.Add(item3);
            //DataList.Add(item4);
            #endregion
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
                foreach (GraphViewInfo info in response.values)
                {
                    if (info.chartInfoList.Count != 0 && info.name != "cropYeild")
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
