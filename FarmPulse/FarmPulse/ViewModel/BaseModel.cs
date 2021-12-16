﻿using FarmPulse.Control;
using FarmPulse.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace FarmPulse.ModelView
{
    public class BaseModel : INotifyPropertyChanged
    { 
        protected FieldInfo FieldInfo { get; set; }
        protected ControlApp ControlApp => ControlApp.Instance;
        protected INavigation Navigation { get; set; }
        public Element Parent { get; set; }

        private Dictionary<string, object> PropertyList;

        public event PropertyChangedEventHandler PropertyChanged;

        protected T GetValue<T>([CallerMemberName] string propertyName = "")
        {
            if (PropertyList == null)
                PropertyList = new Dictionary<string, object>();

            if (!PropertyList.ContainsKey(propertyName))
                return default;

            return (T)PropertyList[propertyName];
        }

        protected void SetValue(object value, [CallerMemberName] string propertyName = "")
        {
            if (PropertyList == null)
                PropertyList = new Dictionary<string, object>();

            if (PropertyList.ContainsKey(propertyName))
            {
                if (PropertyList[propertyName] == value) return;

                PropertyList[propertyName] = value;
            }
            else
            {
                PropertyList.Add(propertyName, value);
            }

            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetTransitionType(TransitionType transitionType)
        {
            if (Parent == null) return;

            var transitionNavigationPage = Parent as TransitionNavigationPage;
            if (transitionNavigationPage != null)
                transitionNavigationPage.TransitionType = transitionType;
        }
    }
}
