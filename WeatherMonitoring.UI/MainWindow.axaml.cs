using Avalonia.Controls;
using WeatherMonitoring.UI.Models;
using System;

namespace WeatherMonitoring.UI
{
    public partial class MainWindow : Window
    {
        private WeatherData _weather;

        public MainWindow()
        {
            InitializeComponent();
            _weather = new WeatherData();
            UpdateDisplay();
        }

        private void UpdateWeather_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var random = new Random();

            _weather.Temperature = random.Next(-10, 40);
            _weather.Humidity = random.Next(20, 100);
            _weather.Pressure = random.Next(980, 1050);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            TemperatureText.Text = $"Temperature: {_weather.Temperature} °C";
            HumidityText.Text = $"Humidity: {_weather.Humidity} %";
            PressureText.Text = $"Pressure: {_weather.Pressure} hPa";
        }
    }
}
