using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace RkApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<WeatherItem> WeatherItems { get; set; }
        public List<WeatherItem> FilteredWeatherItems { get; set; }
        public SearchParameters SearchParams { get; set; }

        public void OnGet(SearchParameters searchParams)
        {
            WeatherItems = new List<WeatherItem>()
            {
                new WeatherItem {
                    City = "New York",
                    Temperature = 20.5,
                    Humidity = 60,
                    AirSpeed = 5
                },
                new WeatherItem {
                    City = "Los Angeles",
                    Temperature = 25.3,
                    Humidity = 50,
                    AirSpeed = 3
                },
                new WeatherItem {
                    City = "Chicago",
                    Temperature = 15.0,
                    Humidity = 55,
                    AirSpeed = 7
                },
                new WeatherItem {
                    City = "Houston",
                    Temperature = 30.1,
                    Humidity = 70,
                    AirSpeed = 6
                },
                new WeatherItem {
                    City = "Phoenix",
                    Temperature = 35.2,
                    Humidity = 40,
                    AirSpeed = 2
                },
                new WeatherItem {
                    City = "Philadelphia",
                    Temperature = 22.4,
                    Humidity = 65,
                    AirSpeed = 4
                },
                new WeatherItem {
                    City = "San Antonio",
                    Temperature = 28.3,
                    Humidity = 60,
                    AirSpeed = 5
                },
                new WeatherItem {
                    City = "San Diego",
                    Temperature = 24.5,
                    Humidity = 55,
                    AirSpeed = 3
                },
                new WeatherItem {
                    City = "Dallas",
                    Temperature = 29.0,
                    Humidity = 60,
                    AirSpeed = 6
                },
                new WeatherItem {
                    City = "San Jose",
                    Temperature = 26.5,
                    Humidity = 50,
                    AirSpeed = 4
                },
                new WeatherItem {
                    City = "Austin",
                    Temperature = 27.3,
                    Humidity = 65,
                    AirSpeed = 5
                },
                new WeatherItem {
                    City = "Jacksonville",
                    Temperature = 28.0,
                    Humidity = 70,
                    AirSpeed = 4
                },
                new WeatherItem {
                    City = "Fort Worth",
                    Temperature = 29.2,
                    Humidity = 60,
                    AirSpeed = 5
                },
                new WeatherItem {
                    City = "Columbus",
                    Temperature = 21.0,
                    Humidity = 55,
                    AirSpeed = 4
                },
                new WeatherItem {
                    City = "Charlotte",
                    Temperature = 23.4,
                    Humidity = 60,
                    AirSpeed = 4
                }
            };

            SearchParams = searchParams ?? new SearchParameters();
            FilteredWeatherItems = ApplyFilter(WeatherItems, SearchParams);
        }

        private List<WeatherItem> ApplyFilter(List<WeatherItem> items, SearchParameters searchParams)
        {
            if (searchParams == null || string.IsNullOrEmpty(searchParams.FilterProperty) || string.IsNullOrEmpty(searchParams.Keyword))
            {
                return items;
            }

            var keyword = searchParams.Keyword.ToLower();
            switch (searchParams.FilterProperty)
            {
                case "City":
                    return items.Where(w => w.City.ToLower().Contains(keyword)).ToList();
                case "Temperature":
                    return items.Where(w => w.Temperature.ToString().Contains(keyword)).ToList();
                case "Humidity":
                    return items.Where(w => w.Humidity.ToString().Contains(keyword)).ToList();
                case "AirSpeed":
                    return items.Where(w => w.AirSpeed.ToString().Contains(keyword)).ToList();
                default:
                    return items;
            }
        }

        public class WeatherItem
        {
            public string City { get; set; }
            public double Temperature { get; set; }
            public int Humidity { get; set; }
            public int AirSpeed { get; set; }
        }

        public class SearchParameters
        {
            public string FilterProperty { get; set; }
            public string Keyword { get; set; }
        }
    }
}