using FarmPulse.Model;
using FarmPulse.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageFieldListViewModel : BaseModel
    {
        public ObservableCollection<FieldInfo> Data { get; }

        public bool IsRefreshing { get => GetValue<bool>(); set => SetValue(value); }
        public FieldInfo SelectedItem { get => GetValue<FieldInfo>(); set => SetValue(value); }
        
        public PageFieldListViewModel(INavigation navigation)
        {
            Data = new ObservableCollection<FieldInfo>();
            Navigation = navigation;

            #region
            //Data.Add(new FieldInfo()
            //{ 
            //    name = "Field1",
            //    suiv_name = "O.Vodiy va Ok bulok"
            //});

            //Data.Add(new FieldInfo()
            //{ 
            //    name = "Field2",
            //    suiv_name = "Fergana"
            //});
            #endregion 
        }

        public ICommand ClickRefreshCommand => new Command(RefreshFieldList);

        public async void RefreshFieldList()
        {
            ControlApp.ShowLoadingView(RSC.PleaseWait);

            Data.Clear();
            ResponseField response = await HttpService.GetFieldList(ControlApp.UserInfo.insuranceNumber);
            if (response.result)
            {   
                foreach (FieldInfo item in response.fields)
                {
                    Data.Add(new FieldInfo(item));
                }
            }
            else 
            {
                await Application.Current.MainPage.DisplayAlert(RSC.Error, $"{RSC.FailedGetField}: {response.message}", RSC.Ok);
            }
            ControlApp.CloseLoadingView();
            IsRefreshing = false;
        }
    }
}
