using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfomanceTestingToolsWF
{
    public class TestOptions
    {
        [JsonProperty("requestUrl")]
        public String RequestUri { get; set; }
        [JsonProperty("headerName")]
        public String HeaderName { get; set; }
        [JsonProperty("iterations")]
        public int Iterations { get; set; } 
        public bool ClearSearchCache { get; set; }
        [JsonProperty("interval")]
        public int Interval { get; set; }
        public int GraphWidth { get; set; }
        //public List<UriParameter> Parameters { get; set; }
    }

    public class UriParameter
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public override string ToString()
        {
            return $"{Key}={Value}";
        }
    }

}
