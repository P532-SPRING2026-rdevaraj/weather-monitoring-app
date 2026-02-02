
/* using WeatherMonitoring.UI.Displays;

namespace WeatherMonitoring.UI.Models
{
    public class WeatherData
    {
        private CurrentConditionsDisplay currentConditionsDisplay;
        private StatisticsDisplay statisticsDisplay;
        private ForecastDisplay forecastDisplay;

        public double Temperature { get; private set; }
        public double Humidity { get; private set; }
        public double Pressure { get; private set; }

        public WeatherData(
            CurrentConditionsDisplay currentConditionsDisplay,
            StatisticsDisplay statisticsDisplay,
            ForecastDisplay forecastDisplay)
        {
            this.currentConditionsDisplay = currentConditionsDisplay;
            this.statisticsDisplay = statisticsDisplay;
            this.forecastDisplay = forecastDisplay;
        }

        public void SetMeasurements(double temperature, double humidity, double pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;

            UpdateDisplays();
        }

        private void UpdateDisplays()
        {
            currentConditionsDisplay.Update(Temperature, Humidity, Pressure);
            statisticsDisplay.Update(Temperature, Humidity, Pressure);
            forecastDisplay.Update(Temperature, Humidity, Pressure);
        }
    }
}


*/

using System.Collections.Generic;
using WeatherMonitoring.UI.Displays;

namespace WeatherMonitoring.UI.Models
{
    public class WeatherData
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }

        private List<IDisplayElement> displays;

        public WeatherData()
        {
            displays = new List<IDisplayElement>();
        }

        public void RegisterDisplay(IDisplayElement display)
        {
            displays.Add(display);
        }

        public void RemoveDisplay(IDisplayElement display)
        {
            displays.Remove(display);
        }

        public void MeasurementsChanged()
        {
            foreach (var display in displays)
            {
                display.Update();
            }
        }

        public double GetTemperature()
        {
            return Temperature;
        }


        public double GetHumidity()
        {
            return Humidity;
        }

        public double GetPressure()
        {
            return Pressure;
        }
          
        public void SetMeasurements(double temperature, double humidity, double pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
            MeasurementsChanged();
        }
    }
}
