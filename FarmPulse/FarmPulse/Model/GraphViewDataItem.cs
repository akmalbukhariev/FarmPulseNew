﻿using FarmPulse.ModelView;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmPulse.Model
{
    public class GraphViewDataItem :  BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string IndexMeanValue { get => GetValue<string>(); set => SetValue(value); }
        public string MetricsName { get => GetValue<string>(); set => SetValue(value); }
        public List<GraphViewData> ValueList { get => GetValue<List<GraphViewData>>(); set => SetValue(value); }
        public List<List<GraphViewData>> ValueListForMultiple { get => GetValue<List<List<GraphViewData>>>(); set => SetValue(value); }

        public GraphViewDataItem()
        {
            this.ValueList = new List<GraphViewData>();
            this.ValueListForMultiple = new List<List<GraphViewData>>();
        }
    }
}
