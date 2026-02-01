using WeatherMonitoring.UI.Models;

namespace WeatherMonitoring.UI.Displays
{
    public class ForecastDisplay : IDisplayElement
    {
        private WeatherData weatherData;
        private double currentPressure = 1013;
        private double lastPressure;
        public System.Action<string>? OnDisplayUpdated;

        public ForecastDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            lastPressure = weatherData.GetPressure();
            weatherData.RegisterDisplay(this);
        }

        public void Update()
        {
            lastPressure = currentPressure;
            currentPressure = weatherData.GetPressure();
            Display();
        }

        private void Display()
        {
            string forecast;

            if (currentPressure > lastPressure)
                forecast = "Improving weather on the way!";
            else if (currentPressure == lastPressure)
                forecast = "More of the same.";
            else
                forecast = "Watch out for cooler, rainy weather.";

            OnDisplayUpdated?.Invoke($"Forecast: {forecast}");
        }

    }
}
