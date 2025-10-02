using System;
using System.Windows;

namespace XBOXACHOVERLAY
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Optional: Initialize database or preload modules
            try
            {
                Logging.AchievementsLogger.LogEvent(0, "AppStartup", "System", "Startup");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup logging failed: {ex.Message}", "Startup Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}