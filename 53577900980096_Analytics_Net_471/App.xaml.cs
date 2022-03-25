using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;


namespace _53577900980096_Analytics_Net_471
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppCenter.LogLevel = LogLevel.Verbose;
            AppCenter.Start("d11d553d-509d-478b-ae75-162d0e7f5d65",
                   typeof(Analytics));
            Analytics.TrackEvent("OnStartup");
            base.OnStartup(e);
        }
    }
}
