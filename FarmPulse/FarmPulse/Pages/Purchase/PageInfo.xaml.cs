﻿using FarmPulse.ModelView.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmPulse.Pages.Purchase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : IPage
    {
        private PageInfoViewModel model;
        public InfoPage(string title)
        {
            InitializeComponent(); 
            model = new PageInfoViewModel(Navigation, title);
            BindingContext = model; 
        }
    }
}