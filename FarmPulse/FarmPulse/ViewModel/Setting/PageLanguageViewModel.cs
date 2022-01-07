using FarmPulse.Control;
using FarmPulse.Model;
using FarmPulse.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageLanguageViewModel : BaseModel
    { 
        public bool ShowBox { get => GetValue<bool>(); set => SetValue(value); }
        public bool ShowSelectLanguage { get => GetValue<bool>(); set => SetValue(value); }
        public string TextSelectLanguage { get => GetValue<string>(); set => SetValue(value); }
        public LanguageInfo SelectedLanguage { get => GetValue<LanguageInfo>(); set => SetValue(value); }
        
        public List<LanguageInfo> LanguageList { get => GetValue<List<LanguageInfo>>(); set => SetValue(value); }

        public PageLanguageViewModel(INavigation navigation)
        {  
            LanguageList = new List<LanguageInfo>() { new LanguageInfo("Узбек"), 
                                                      new LanguageInfo("Русский"), 
                                                      new LanguageInfo("English"), 
                                                      new LanguageInfo("Монгол") };

            ShowBox = false;
            ShowSelectLanguage = true;
            TextSelectLanguage = RSC.SelectLanguage;
        }

        public ICommand ClickBackGroundBoxCommand => new Command(ClickBackGroundBox);
        public ICommand ClickSelectCommand => new Command(ClickSelect); 
        public ICommand ClickSaveCommand => new Command(ClickSave);

        private void ClickBackGroundBox()
        {
            ShowBox = false;
            ShowSelectLanguage = true;
        }

        private void ClickSelect()
        {
            ShowBox = true;
            ShowSelectLanguage = false;
        }
          
        private async void ClickSave()
        {
            if (SelectedLanguage == null)
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, RSC.PleaseSelectLanguage, RSC.Ok);
                return;
            }

            string strLanguage = GetLatinLanguageName(SelectedLanguage.Name);
            var language = CultureInfo.GetCultures(CultureTypes.NeutralCultures).ToList().First(element => element.EnglishName.Contains(strLanguage));
            Thread.CurrentThread.CurrentUICulture = language;
            AppResource.Culture = language;

            AppSettings.SetLanguage(strLanguage);
            Preferences.Set("AutoLogin", "");

            ControlApp.SystemStatus = LogInOut.LogOut;
            Application.Current.MainPage = new TransitionNavigationPage(new Pages.PageLogin());
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
