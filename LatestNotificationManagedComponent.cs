using Microsoft.Toolkit.Uwp.Notifications;

namespace XBOXACHOVERLAY.Notifications
{
    public static class LatestNotificationManagedComponent
    {
        public static void Trigger(string message)
        {
            new ToastContentBuilder()
                .AddText("Achievement Unlocked")
                .AddText(message)
                .Show();
        }
    }
}
