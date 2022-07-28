
using System.Net;
using System.Text.Json;

namespace Weather
{
    class Program
    {
        public async Task<string> GetDataAsync(Uri url)
        {
            var client = new HttpClient();
            var jsonString = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            var apiData = JsonSerializer.Deserialize<APIWeatherModel>(jsonString);

            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
            var weatherData = new DataModel()
            {
                data = new List<Data>(),
                statusCode = (int)httpRes.StatusCode
            };
            foreach (var item in apiData.list)
            {
                var data = new Data()
                {
                    cityId = item.id,
                    cityName = item.name,
                    weatherMain = item.weather[0].main,
                    weatherDescription = item.weather[0].description,
                    weatherIcon = "http://openweathermap.org/img/wn/" + item.weather[0].icon + "@2x.png",
                    mainTemp = item.main.temp,
                    mainHumidity = item.main.humidity
                };
                weatherData.data.Add(data);
            }
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(weatherData, options);
        }
        static void Main(string[] args)
        {
            var url = new Uri("http://api.openweathermap.org/data/2.5/group?id=1580578,1581129,1581297,1581188,1587923&units=metric&appid=91b7466cc755db1a94caf6d86a9c788a");
            var data = new Program().GetDataAsync(url).Result;
            Console.WriteLine(data);
        }
    }
}