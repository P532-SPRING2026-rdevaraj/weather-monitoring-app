using Avalonia.Controls;
using WeatherMonitoring.UI.Models;
using WeatherMonitoring.UI.Displays;

namespace WeatherMonitoring.UI
{
    public partial class StatisticsWindow : Window
    {
        private StatisticsDisplay statisticsDisplay;

        public StatisticsWindow(WeatherData weatherData)
        {
            InitializeComponent();

            statisticsDisplay = new StatisticsDisplay(weatherData);
            statisticsDisplay.OnStatisticsUpdated = UpdateUI;

            statisticsDisplay.Update();
        }

        private void UpdateUI(double avg, double max, double min)
        {
            AvgTempText.Text = $"Average Temperature: {avg:F1} °C";
            MaxTempText.Text = $"Maximum Temperature: {max} °C";
            MinTempText.Text = $"Minimum Temperature: {min} °C";
        }
    }
}
