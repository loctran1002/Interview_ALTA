using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    class weather
    {
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    class main
    {
        public float temp { get; set; }
        public float humidity { get; set; }
    }

    class APIData
    {
        //public coord coord { get; set; }
        //public sys sys { get; set; }
        public List<weather> weather { get; set; }
        public main main { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
    internal class APIWeatherModel
    {
        public int cnt { get; set; }
        public List<APIData> list { get; set; }
    }
}
