﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class LanguagePageModelView : BaseModel
    {
        public string SelectedLanguage { get => GetValue<string>(); set => SetValue(value); }
        public string SelectLanguageTitle { get => GetValue<string>(); set => SetValue(value); }
        public string SaveButtonText { get => GetValue<string>(); set => SetValue(value); }
        public List<string> LanguageList { get => GetValue<List<string>>(); set => SetValue(value); }

        public LanguagePageModelView(INavigation navigation)
        {
            Navigation = navigation;
            SelectLanguageTitle = "Select Language";
            SaveButtonText = "Save";
            LanguageList = new List<string>() { "Узбек", "Русский", "English" }; 
        }

        public ICommand ClickSaveCommand => new Command(ClickSave);

        private void ClickSave()
        {
            
        }
    }
}
