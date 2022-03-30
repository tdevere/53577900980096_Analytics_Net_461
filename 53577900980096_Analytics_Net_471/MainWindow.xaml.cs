using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;

namespace _53577900980096_Analytics_Net_471
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ProductVersion = "2.0.1.1";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendEvent(string eventMsg,
            [CallerMemberName] string caller = null, 
            [CallerFilePath] string callingFilePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Debug.WriteLine("SendEvent");
            Dictionary<string, string> eventProperties = new Dictionary<string, string>();
            Analytics.TrackEvent(eventMsg, eventProperties);
        }

        private void btnSendEvent_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("btnSendEvent_Click");
            SendEvent("btnSendEvent_Click");                        
        }


        private void btnTEST1_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("btnTEST1_Click");
            SendEvent("btnTEST1_Click");            
            GetAppVersion();
        }

        protected string GetAppVersion()
        {
            Debug.WriteLine("GetAppVersion");            
            SendEvent("GetAppVersion");
            try
            {
                SendEvent($"System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion {System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()} ");
            }
            catch (Exception ex)
            {
                SendEvent($"GetAppVersion CurrentVersion Failed: {ex.Message}");
            }
                        
            try
            {
                SendEvent($"System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed {System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed} ");
            }
            catch (Exception ex)
            {
                SendEvent($"GetAppVersion IsNetworkDeployed Failed: {ex.Message}");
            }

            try
            {
                SendEvent($"AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName {AppDomain.CurrentDomain.SetupInformation.TargetFrameworkName} ");
            }
            catch (Exception ex)
            {
                SendEvent($"GetAppVersion TargetFrameworkName Failed: {ex.Message}");
            }

#if NET45          
            Analytics.TrackEvent("NET45");
            Debug.WriteLine("NET45");

#elif NET461
            Analytics.TrackEvent("NET461");
            Debug.WriteLine("NET461");

#elif NET471
            Analytics.TrackEvent("NET471");
             Debug.WriteLine("NET471");

#elif NET472
            Analytics.TrackEvent("NET472");
            Debug.WriteLine("NET472");

#else
#error Target Framework not supported

#endif
            
            
            return ProductVersion;
        }
    }
}
