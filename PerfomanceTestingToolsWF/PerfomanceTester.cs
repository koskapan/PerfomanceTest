using PerfomanceTestingToolsWF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerfomanceTestingTools
{
    public class PerfomanceTester
    {

        private string headerName;
        
        public SearchEngineResultHeader Test(TestOptions options)
        {
            headerName = options.HeaderName;

            using (var client = new HttpClient())
            {
                //var response = client.GetAsync(BuildUri(options)).Result;

                if (options.ClearSearchCache)
                {
                    client.DefaultRequestHeaders.Add("Pragma", "no-cache");
                }

                var response = client.GetAsync(options.RequestUri).Result;

                var header = response.Headers.GetValues(headerName);


                return new SearchEngineResultHeader(header.First());
            }

        }

        //private String BuildUri(TestOptions options)
        //{
        //    var builder = new StringBuilder();
        //    builder.Append(options.RequestUri+ "?");
        //    foreach (var parameter in options.Parameters)
        //    {
        //        builder.Append($"{parameter.Key}={parameter.Value}&");
        //    }
        //    return builder.ToString().TrimEnd('&');
        //}

    }
}
