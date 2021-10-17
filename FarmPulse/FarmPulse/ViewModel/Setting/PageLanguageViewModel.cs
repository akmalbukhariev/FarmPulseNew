using FarmPulse.Control;
using FarmPulse.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageLanguageViewModel : BaseModel
    { 
        public string SelectedLanguage { get => GetValue<string>(); set => SetValue(value); }
        
        public List<string> LanguageList { get => GetValue<List<string>>(); set => SetValue(value); }

        public PageLanguageViewModel(INavigation navigation)
        {  
            LanguageList = new List<string>() { "Узбек", "Русский", "English", "Монгол" }; 
        }

        public ICommand ClickSaveCommand => new Command(ClickSave);

        private void ClickSave()
        {
            if (!string.IsNullOrEmpty(SelectedLanguage))
            {
                string strLanguage = GetLatinLanguageName(SelectedLanguage);
                var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().First(element => element.EnglishName.Contains(strLanguage));
                Thread.CurrentThread.CurrentUICulture = language;
                AppResource.Culture = language;
            }

            Application.Current.MainPage = new TransitionNavigationPage(new Pages.LoginPage());
        }

        private string GetLatinLanguageName(string strLanguage)
        {
            string strResult = string.Empty;
            if (strLanguage == "Узбек")
            {
                strResult = "Uzbek";
            }
            else if (strLanguage == "Русский")
            {
                strResult = "Russian";
            }
            else if (strLanguage == "English")
            {
                strResult = strLanguage;
            }
            else if (strLanguage == "Монгол")
            {
                strResult = "Mongolian";
            }

            return strResult;
        }
    }
}
