namespace Weather
{
    class Data
    {
        public int cityId { get; set; }
        public string cityName { get; set; }
        public string weatherMain { get; set; }
        public string weatherDescription { get; set; }
        public string weatherIcon { get; set; }
        public float mainTemp { get; set; }
        public float mainHumidity { get; set; }
    }
    internal class DataModel
    {
        public List<Data> data { get; set; }
        public string message { get; set; } = "Current weather information of cities";
        public int statusCode { get; set; }
    }
}
