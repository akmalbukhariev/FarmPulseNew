using FarmPulse.Model;
using FarmPulse.Net;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FarmPulse.Control;
 

namespace FarmPulse.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphView : ContentView
    {
        #region Region
        public static readonly BindableProperty RegionProperty =
            BindableProperty.Create(nameof(Region),
                                    typeof(string),
                                    typeof(GraphView),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: RegionPropertyChanged);

        public string Region
        {
            get { return (string)GetValue(RegionProperty); }
            set { SetValue(RegionProperty, value); }
        }

        private static void RegionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (GraphView)bindable;
            if (control != null)
                control.lbRegion.Text = newValue.ToString();
        }
        #endregion

        #region Mean value
        public static readonly BindableProperty MeanValueProperty =
            BindableProperty.Create(nameof(MeanValue),
                                    typeof(string),
                                    typeof(GraphView),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: MeanValuePropertyChanged);

        public string MeanValue
        {
            get { return (string)GetValue(MeanValueProperty); }
            set { SetValue(MeanValueProperty, value); }
        }

        private static void MeanValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (GraphView)bindable;
            if (control != null)
                control.lbMeanValue.Text = newValue.ToString();
        }
        #endregion

        #region Item Source
        public static readonly BindableProperty ItemSourceProperty =
            BindableProperty.Create(nameof(ItemSource),
                                    typeof(List<GraphViewData>),
                                    typeof(GraphView),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: ItemSourcePropertyChanged);

        public List<GraphViewData> ItemSource
        {
            get { return (List<GraphViewData>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        private static void ItemSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (GraphView)bindable;
            if (control != null)
            {
                List<ChartEntry> chartDataList = new List<ChartEntry>();
                List<ChartEntry> chartNdviDataList = new List<ChartEntry>();

                var list = (List<GraphViewData>)newValue;
                
                if (list.Count == 0) return;

                foreach (GraphViewData item in list)
                {
                    if (string.IsNullOrEmpty(item.value)) continue;

                    ChartEntry chartEntry = new ChartEntry(float.Parse(item.value));
                    var color = String.Format("#{0:X6}", "007A43");
                    chartEntry.Label = item.year.Replace("Text_","");
                    chartEntry.ValueLabel = item.value;
                    chartEntry.Color = SKColor.Parse(color);
                    chartEntry.TextColor = SKColor.Parse(color);

                    chartDataList.Add(chartEntry);
                }
  
                FarmBarChart farmBarChart = new FarmBarChart()
                {
                    NdviEntires = chartDataList,
                    LabelTextSize = 18f,
                    LabelOrientation = Orientation.Vertical,
                    IsAnimated = false
                };

                control.chart.Chart = farmBarChart; 
            }
        }
        #endregion

        #region Itrem source for multiple chart
        public static readonly BindableProperty ItemSourceForMultipleProperty =
            BindableProperty.Create(nameof(ItemSourceForMultiple),
                                    typeof(List<List<GraphViewData>>),
                                    typeof(GraphView),
                                    defaultBindingMode: BindingMode.TwoWay,
                                    propertyChanged: ItemSourceForMultiplePropertyChanged);

        public List<List<GraphViewData>> ItemSourceForMultiple
        {
            get { return (List<List<GraphViewData>>)GetValue(ItemSourceForMultipleProperty); }
            set { SetValue(ItemSourceForMultipleProperty, value); }
        }

        private static void ItemSourceForMultiplePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (GraphView)bindable;
            if (control != null)
            {
                List<ChartEntry> chartDataList = new List<ChartEntry>();
                List<ChartEntry> chartYieldDataList = new List<ChartEntry>();

                var list = (List<List<GraphViewData>>)newValue;

                if (list.Count == 0) return;

                foreach (GraphViewData item in list[0])
                {
                    if (string.IsNullOrEmpty(item.value)) continue;

                    ChartEntry chartEntry = new ChartEntry(float.Parse(item.value));
                    var color = String.Format("#{0:X6}", "548235");
                    chartEntry.Label = item.year.Replace("Text_", "");
                    chartEntry.ValueLabel = item.value;
                    chartEntry.Color = SKColor.Parse(color);
                    chartEntry.TextColor = SKColor.Parse(color);

                    chartDataList.Add(chartEntry);
                }

                if (list.Count == 2)
                {
                    foreach (GraphViewData item in list[1])
                    {
                        if (string.IsNullOrEmpty(item.value)) continue;

                        ChartEntry chartEntry = new ChartEntry(float.Parse(item.value));//8FAADC
                        var color1 = String.Format("#{0:X6}", "8FAADC");
                        chartEntry.Label = item.year.Replace("Text_", "");
                        chartEntry.ValueLabel = item.value;
                        chartEntry.Color = SKColor.Parse(color1);
                        chartEntry.TextColor = SKColors.Black;

                        chartYieldDataList.Add(chartEntry);
                    }
                }

                FarmLineChart farmBarLineChart = new FarmLineChart()
                {
                    NdviEntires = chartDataList,
                    YieldEntires = chartYieldDataList,
                    LabelTextSize = 17f,
                    LabelOrientation = Orientation.Vertical,
                    IsAnimated = false
                };

                control.chart.Chart = farmBarLineChart; 
            }
        }
        #endregion

        public GraphView()
        {
            InitializeComponent();

            //ChartEntry chartEntry1 = new ChartEntry(5);
            //var color = String.Format("#{0:X6}", "007A43");
            //chartEntry1.Color = SKColor.Parse(color);
            //chartEntry1.ValueLabel = "5";
            //chartEntry1.Label = "200";
            //chartEntry1.TextColor = SKColor.Parse(color);

            //ChartEntry chartEntry2 = new ChartEntry(4); 
            //chartEntry2.Color = SKColor.Parse(color);
            //chartEntry2.ValueLabel = "4";
            //chartEntry2.Label = "200";
            //chartEntry2.TextColor = SKColor.Parse(color);

            //ChartEntry chartEntry3 = new ChartEntry(3);
            //chartEntry3.Color = SKColor.Parse(color);
            //chartEntry3.ValueLabel = "3";
            //chartEntry3.Label = "200";
            //chartEntry3.TextColor = SKColor.Parse(color);

            //ChartEntry chartEntry4 = new ChartEntry(2);
            //chartEntry4.Color = SKColor.Parse(color);
            //chartEntry4.ValueLabel = "2";
            //chartEntry4.Label = "200";
            //chartEntry4.TextColor = SKColor.Parse(color);

            //chartCotton.Add(chartEntry1);
            //chartCotton.Add(chartEntry2);
            //chartCotton.Add(chartEntry3);
            //chartCotton.Add(chartEntry4);

            //chart.Chart = new BarChart { Entries = chartCotton };
        }
    }
}