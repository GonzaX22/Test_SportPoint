using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SportPoint.Helpers
{
    public static class HttpClientFactory {

        public static HttpClient Create(string baseAddress) => new HttpClient {
            BaseAddress = new Uri(baseAddress),
            Timeout = TimeSpan.FromSeconds(5),
        };
    }
}
