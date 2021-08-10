using System;

namespace JDege.EFQ.Web
{
    // TODO: Remove this
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}

// TODO: Make sure we have tests for all cases

// TODO: add explanations to the Swagger page