using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfomanceTestingTools
{
    public class SearchEngineResultHeader
    {
        public List<SearchRequestHeaderValue> HeaderValues;

        private List<SearchRequestHeaderValue> ConfigureKeys()
        {
            return new List<SearchRequestHeaderValue>()
            {
                //new SearchRequestHeaderValue()
                //{
                //    Key = "FCT",
                //    Name = "firstConfigureTime",
                //    Value = 0
                //},
                //new SearchRequestHeaderValue()
                //{
                //    Key = "SFET",
                //    Name = "Static Filters Request",
                //    Value = 0
                //},
                //new SearchRequestHeaderValue()
                //{
                //    Key = "AOT",
                //    Name = "aggregationsObtainigTime",
                //    Value = 0
                //},
                //new SearchRequestHeaderValue()
                //{
                //    Key = "GCR",
                //    Name = "getCachedResponse",
                //    Value = 0
                //},
                new SearchRequestHeaderValue()
                {
                    Key = "MERT",
                    Name = "Main Engine Request",
                    Value = 0
                },
                //new SearchRequestHeaderValue()
                //{
                //    Key = "SERT",
                //    Name = "Total Search Engine Request",
                //    Value = 0
                //},
                new SearchRequestHeaderValue()
                {
                    Key = "GRT",
                    Name = "Goods Request ",
                    Value = 0
                },
                new SearchRequestHeaderValue()
                {
                    Key = "TT",
                    Name = "Total",
                    Value = 0
                }
            };
        }

        public SearchEngineResultHeader()
        {
            HeaderValues = ConfigureKeys();
        }

        public SearchEngineResultHeader(String header)
        {
            #region ::configure keys::
            HeaderValues = ConfigureKeys();
            #endregion
            var chunks = header.Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < chunks.Count(); i += 2)
            {
                var key = chunks[i];
                var val = chunks[i + 1];

                var headerVal = HeaderValues.FirstOrDefault(v => v.Key == key);
                if (headerVal != null)
                {
                    headerVal.Value = int.Parse(val);
                }

            }
        }

        public override string ToString()
        {
            return String.Join(" ", HeaderValues);
        }


    }

    public class SearchRequestHeaderValue
    {
        public String Key { get; set; }

        public String Name { get; set; }

        public Int32 Value { get; set; }

        public override string ToString()
        {
            return $"{Key}:{Value}";
        }
    }
}
