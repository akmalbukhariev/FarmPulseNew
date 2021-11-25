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
          
        public string SelectIndexTitle { get => GetValue<string>(); set => SetValue(value); } 
        public MetricsInfo SelectedMetrics { get => GetValue<MetricsInfo>(); set => SetValue(value); }
        public List<MetricsInfo> MetricsList { get => GetValue<List<MetricsInfo>>(); set => SetValue(value); }
         
        public PageGraphViewViewModel()
        {
            DataList = new ObservableCollection<GraphViewDataItem>();
            //IndexList = new List<string>(); 
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
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            RequestGraphViewInfo request = new RequestGraphViewInfo()
            {
                fieldId = fieldId,
                metricId = SelectedMetrics.sequence.ToString()
            };

            ResponseGraphView response = await HttpService.GetGraphyViewInfo(request);
            if (response.result)
            {

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, "", RSC.Ok);
            }

            ControlApp.CloseLoadingView();
        }
    }
}
