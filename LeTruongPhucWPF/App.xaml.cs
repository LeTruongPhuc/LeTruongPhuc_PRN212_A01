﻿using System.Windows;

namespace LeTruongPhucWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoginWindow login = new LoginWindow();
            login.Show();
        }
    }
}