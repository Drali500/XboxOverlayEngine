using XBOXACHOVERLAY.Notifications;
using XBOXACHOVERLAY.Logging;

namespace XBOXACHOVERLAY.Listeners
{
    public static class AchievementListeners
    {
        public static void OnAchievementUnlocked(string source, string game, string title, string description = "")
        {
            string message = $"{title} in {game} via {source}";
            LatestNotificationManagedComponent.Trigger(message);
            AchievementsLogger.LogAchievement(source, game, title, description);
        }

        public static void OnAchievementEvent(int achievementId, string context, string tag, string eventType)
        {
            AchievementsLogger.LogEvent(achievementId, context, tag, eventType);
        }
    }
}