using WeatherMonitoring.UI.Models;

namespace WeatherMonitoring.UI.Displays
{
    public class CurrentConditionsDisplay : IDisplayElement
    {
        private WeatherData weatherData;
        private double temperature;
        private double humidity;

        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterDisplay(this);
        }

        public void Update()
        {
            temperature = weatherData.GetTemperature();
            humidity = weatherData.GetHumidity();

            Display();
        }

        private void Display()
        {
            System.Console.WriteLine(
                $"Current conditions: {temperature}°C and {humidity}% humidity"
            );
        }
    }
}
