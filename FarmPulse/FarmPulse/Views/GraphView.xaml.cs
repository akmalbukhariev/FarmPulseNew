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

                var list = (List<GraphViewData>)newValue;
                foreach (GraphViewData item in list)
                {
                    ChartEntry chartEntry = new ChartEntry(5);
                    var color = String.Format("#{0:X6}", "007A43");
                    chartEntry.Color = SKColor.Parse(color);
                    chartEntry.ValueLabel = item.value;
                    chartEntry.Label = item.year;
                    chartEntry.TextColor = SKColor.Parse(color);

                    chartDataList.Add(chartEntry);
                }

                control.chart.Chart = new BarChart { Entries = chartDataList };
            }
        }
        #endregion

        //List<ChartEntry> chartCotton = new List<ChartEntry>();
        //List<ChartEntry> chartWheat = new List<ChartEntry>();

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