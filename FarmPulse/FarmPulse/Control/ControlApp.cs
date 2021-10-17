using Acr.UserDialogs;
using FarmPulse.Net;
using System; 
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FarmPulse.Control
{
    public class ControlApp
    { 
        private bool _closeLoadingView = false; 
        public bool AppStarting { get; set; }
        public bool AppOnResume { get; set; }
        public bool AppOnSleep { get; set; }
        public string UserId { get; set; }
  
        public UserInfo UserInfo { get; set; }

        private static ControlApp _instance = null;

        private ControlApp()
        {
           
        }

        public static ControlApp Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ControlApp();
                }

                return _instance;
            }
        }

        public bool IsInternetConnectionOk
        {
            get
            {
                bool ok = false;

                var current = Connectivity.NetworkAccess;

                if (current == NetworkAccess.Internet)
                {
                    ok = true;
                }

                return ok;
            }
        }

        public bool InternetOk()
        {
            if (!IsInternetConnectionOk)
            {
                UserDialogs.Instance.Alert(RSC.NoInternet, RSC.Internet, RSC.Ok);
                return false;
            }

            return true;
        }

        public async void ShowLoadingView(string msg = "Please wait...", int closeAfter = 10)
        {
            _closeLoadingView = false;
            CheckShowingTimeOfLoading(closeAfter);

            await Task.Run(() =>
            {
                using (UserDialogs.Instance.Loading(msg, null, null, true, MaskType.Black))
                {
                    while (true)
                    {
                        if (_closeLoadingView)
                            break;
                    }
                }
            });
        }

        /// <summary>
        /// Close loading message window.
        /// </summary>
        public void CloseLoadingView()
        {
            _closeLoadingView = true;
        }

        /// <summary>
        /// Make sure the message loading window is no longer than '' seconds, then close it.
        /// </summary>
        private void CheckShowingTimeOfLoading(int seconds)
        {
            Device.StartTimer(TimeSpan.FromSeconds(seconds), () =>
            {
                if (!_closeLoadingView)
                {
                    CloseLoadingView();
                }

                return false; // True = Repeat again, False = Stop the timer
            });
        } 
    }
}
