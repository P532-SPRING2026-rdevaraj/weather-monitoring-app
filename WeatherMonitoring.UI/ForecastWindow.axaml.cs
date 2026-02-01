using Avalonia.Controls;
using WeatherMonitoring.UI.Models;
using WeatherMonitoring.UI.Displays;

namespace WeatherMonitoring.UI
{
    public partial class ForecastWindow : Window
    {
        private ForecastDisplay forecastDisplay;

        public ForecastWindow(WeatherData weatherData)
        {
            InitializeComponent();

            forecastDisplay = new ForecastDisplay(weatherData);
            forecastDisplay.OnDisplayUpdated = UpdateUI;

            forecastDisplay.Update();
        }


        private void UpdateUI(string text)
        {
            ForecastText.Text = text;
        }
    }
}
