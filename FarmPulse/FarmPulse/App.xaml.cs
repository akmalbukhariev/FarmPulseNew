﻿using System;
using Xamarin.Forms;

using FarmPulse.Pages;
using FarmPulse.Control;

namespace FarmPulse
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TransitionNavigationPage(new LanguagePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
