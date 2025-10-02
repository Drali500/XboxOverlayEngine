using System.Windows;

namespace XBOXACHOVERLAY
{
    public static class OverlayDispatcher
    {
        public static void TriggerAchievementPopup(string game, string achievement)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var overlay = new MainWindow();
                overlay.SetAchievement(game, achievement);
                overlay.Show();
            });
        }
    }
}