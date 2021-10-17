using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace FarmPulse
{
    public class AppSettings
    {
        public static string Language = "Language";

        private static AppSettings _instance = null;
  
        public static void SetLanguage(string strLanguage)
        {
            Preferences.Set(Language, strLanguage);
        }

        public static string GetLanguage()
        {
            return Preferences.Get(Language, "");
        }

        public static string GetLanguageCode
        {
            get
            {
                string strCode = string.Empty;
                switch (GetLanguage())
                {
                    case Constant.Uzbek: strCode = "uz"; break;
                    case Constant.English: strCode = "en"; break;
                    case Constant.Russian: strCode = "ru"; break;
                    case Constant.Mongol: strCode = "mn"; break;
                }

                return strCode;
            }
        } 
    }
}
