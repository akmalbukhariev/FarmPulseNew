using FarmPulse.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class PageFieldListViewModel : BaseModel
    {
        public ObservableCollection<FieldInfo> Data { get; }

        public FieldInfo SelectedItem { get => GetValue<FieldInfo>(); set => SetValue(value); }
        
        public PageFieldListViewModel(INavigation navigation)
        {
            Data = new ObservableCollection<FieldInfo>();
            Navigation = navigation;

            Data.Add(new FieldInfo()
            {
                FieldName= "Field Name",
                WUA_Village = "WUA/Village",
                FieldNameText = "Field1",
                WUA_VillageText ="O.Vodiy va Ok bulok"
            });

            Data.Add(new FieldInfo()
            {
                FieldName = "Field Name",
                WUA_Village = "WUA/Village",
                FieldNameText = "Field2",
                WUA_VillageText = "Fergana"
            });
        }
    }
}
