using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class CropYieldDataPageViewModel : BaseModel
    {
        public string Title { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2010 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2011 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2012 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2013 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2014 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2015 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2016 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2017 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2018 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2019 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2020 { get => GetValue<string>(); set => SetValue(value); }
        public string Text_2021 { get => GetValue<string>(); set => SetValue(value); }
        public string FieldTitle { get => GetValue<string>(); set => SetValue(value); }
        public string CropTitle { get => GetValue<string>(); set => SetValue(value); }
        public string SaveButtonText { get => GetValue<string>(); set => SetValue(value); }
        public List<string> FieldList { get => GetValue<List<string>>(); set => SetValue(value); }
        public List<string> CropList { get => GetValue<List<string>>(); set => SetValue(value); }

        public CropYieldDataPageViewModel()
        {
            Title = "Crop yield data";
            FieldTitle = "Select the field";
            CropTitle = "Select the crop";
            SaveButtonText = "Save and Next";
        }

        public ICommand ClickSaveCommand => new Command(Save);

        private void Save()
        {
            
        }
    }
}
