using Avalonia.Controls;
using Avalonia.Interactivity;
using WeatherMonitoring.UI.Models;
using WeatherMonitoring.UI.Displays;
using System;

namespace WeatherMonitoring.UI
{
    public partial class MainWindow : Window
    {
        private WeatherData weatherData;
        private CurrentConditionsDisplay currentConditionsDisplay;
        private StatisticsDisplay statisticsDisplay;
        private ForecastDisplay forecastDisplay;
        private StatisticsWindow statisticsWindow;
        private ForecastWindow forecastWindow;

        public MainWindow()
        {
            InitializeComponent();

            weatherData = new WeatherData();

            currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
            statisticsDisplay = new StatisticsDisplay(weatherData);
            forecastDisplay = new ForecastDisplay(weatherData);
        }

        private void UpdateWeather_Click(object? sender, RoutedEventArgs e)
        {
            var random = new Random();

            double temperature = random.Next(-10, 40);
            double humidity = random.Next(20, 100);
            double pressure = random.Next(980, 1050);

            weatherData.SetMeasurements(temperature, humidity, pressure);

            
            UpdateDisplay();
        }

        private void Statistics_Click(object? sender, RoutedEventArgs e)
        {
            var statisticsWindow = new StatisticsWindow(weatherData);
            statisticsWindow.Show();
        }

        private void Forecast_Click(object? sender, RoutedEventArgs e)
        {
            var forecastWindow = new ForecastWindow(weatherData);
            forecastWindow.Show();
        }



        private void UpdateDisplay()
        {
            TemperatureText.Text = $"Temperature: {weatherData.GetTemperature()} °C";
            HumidityText.Text = $"Humidity: {weatherData.GetHumidity()} %";
            PressureText.Text = $"Pressure: {weatherData.GetPressure()} hPa";
        }
    }
}
