using System;
using System.Data.SQLite;

namespace XBOXACHOVERLAY.Logging
{
    public static class AchievementsLogger
    {
        private static readonly string ConnectionString = "Data Source=achievements.db;Version=3;";

        public static void LogAchievement(string source, string game, string title, string description)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO Achievements (Source, Game, Title, Description, Timestamp) VALUES (@source, @game, @title, @description, @timestamp)", connection);
                command.Parameters.AddWithValue("@source", source);
                command.Parameters.AddWithValue("@game", game);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@timestamp", DateTime.UtcNow);
                command.ExecuteNonQuery();
            }
        }

        public static void LogEvent(int achievementId, string context, string tag, string eventType)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand("INSERT INTO AchievementEvents (AchievementId, Context, Tag, EventType, Timestamp) VALUES (@id, @context, @tag, @type, @timestamp)", connection);
                command.Parameters.AddWithValue("@id", achievementId);
                command.Parameters.AddWithValue("@context", context);
                command.Parameters.AddWithValue("@tag", tag);
                command.Parameters.AddWithValue("@type", eventType);
                command.Parameters.AddWithValue("@timestamp", DateTime.UtcNow);
                command.ExecuteNonQuery();
            }
        }
    }
}