using System.Windows.Threading;
using System;
using System.Windows;
using Newtonsoft.Json;
using XBOXACHOVERLAY; // Ensure this matches your namespace

namespace XBOXACHOVERLAY
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ParseMockToken();
        }

        private void ParseMockToken()
        {
            string mockJson = @"
            {
              ""IssueInstant"": ""2025-09-26T08:35:00.000Z"",
              ""NotAfter"": ""2025-09-26T10:35:00.000Z"",
              ""Token"": ""eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.mocked.xbox.token"",
              ""DisplayClaims"": {
                ""xui"": [
                  {
                    ""uhs"": ""1234567890123456"",
                    ""gtg"": ""AliXOE"",
                    ""xid"": ""2814670000000000""
                  }
                ]
              }
            }";

            try
            {
                var tokenResponse = JsonConvert.DeserializeObject<XboxTokenResponse>(mockJson);
                Console.WriteLine($"Gamertag: {tokenResponse.DisplayClaims.xui[0].gtg}");
                Console.WriteLine($"User ID: {tokenResponse.DisplayClaims.xui[0].xid}");
                Console.WriteLine($"Expires: {tokenResponse.NotAfter}");

                SetAchievement("Signed In", $"Welcome, {tokenResponse.DisplayClaims.xui[0].gtg}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token parsing failed: {ex.Message}");
                SetAchievement("Token Error", "Could not parse token");
            }
        }

        private void TriggerButton_Click(object sender, RoutedEventArgs e)
        {
            SetAchievement("Game Title: Halo Infinite", "Achievement Unlocked: Spartan Legend");
        }

        public void SetAchievement(string gameTitle, string achievementName)
        {
            GameTitle.Text = gameTitle;
            AchievementName.Text = achievementName;

            // Auto-hide after 5 seconds
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += (s, e) =>
            {
                this.Hide(); // Or use this.Close() if you want to shut down
                timer.Stop();
            };
            timer.Start();
        }
    }
}