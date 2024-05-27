using Microsoft.AspNetCore.Mvc;
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

        public void OnGet(string sortBy = null, bool sortAsc = true)
        {
            List<WeatherItem> weatherItems = new List<WeatherItem>()
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

            if (sortBy == null)
            {
                WeatherItems = weatherItems;
                return;
            }

            WeatherItems = sortBy.ToLower() switch
            {
                "city" => sortAsc ? weatherItems.OrderBy(w => w.City).ToList() : weatherItems.OrderByDescending(w => w.City).ToList(),
                "temperature" => sortAsc ? weatherItems.OrderBy(w => w.Temperature).ToList() : weatherItems.OrderByDescending(w => w.Temperature).ToList(),
                "humidity" => sortAsc ? weatherItems.OrderBy(w => w.Humidity).ToList() : weatherItems.OrderByDescending(w => w.Humidity).ToList(),
                "airspeed" => sortAsc ? weatherItems.OrderBy(w => w.AirSpeed).ToList() : weatherItems.OrderByDescending(w => w.AirSpeed).ToList(),
                _ => weatherItems
            };
        }

        public class WeatherItem
        {
            public string City { get; set; }
            public double Temperature { get; set; }
            public int Humidity { get; set; }
            public int AirSpeed { get; set; }
        }
    }
}
