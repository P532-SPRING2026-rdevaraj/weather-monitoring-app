using WeatherMonitoring.UI.Models;

namespace WeatherMonitoring.UI.Displays
{
    public class StatisticsDisplay : IDisplayElement
    {
        private WeatherData weatherData;

        public System.Action<double, double, double>? OnStatisticsUpdated;

        public StatisticsDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterDisplay(this);
        }

        public void Update()
        {
            double currentTemp = weatherData.GetTemperature();

            double averageTemp = currentTemp;
            double maxTemp = currentTemp + 2;
            double minTemp = currentTemp - 2;

            Display(averageTemp, maxTemp, minTemp);
        }

        private void Display(double average, double max, double min)
        {
            OnStatisticsUpdated?.Invoke(average, max, min);
        }
    }
}
