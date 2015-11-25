using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Tools
{
    // class to connect with any rest api (only post request implemented)
    public static class API
    {
        static string Prefix = "";
        public static string Version = "";

        public static async Task<Object> SampleRequest()
        {
            var RequestId = GetRequestId();
            string RequestUri = Prefix + "/" + Version + "method name";

            string JsonRequest = "{";
            JsonRequest += "\"var1\":\"" + new object() + "\",";
            JsonRequest += "\"var2\":\"" + new object() + "\"";
            JsonRequest += "}";

            Debug.WriteLine(RequestId + ": Started request: " + RequestUri + "\nParams: " + JsonRequest);

            if (App.IsInternetAvailable)
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage wcfResponse = await httpClient.PostAsync(RequestUri, new StringContent(JsonRequest, Encoding.UTF8, "application/json"));
                var response = await wcfResponse.Content.ReadAsStringAsync();                
                Debug.WriteLine(RequestId + ": Response gotten");
                Debug.WriteLine(response);
                object APIresponse;
                try
                {
                    APIresponse = JsonConvert.DeserializeObject<object>(response);
                }
                catch (Exception)
                {
                    throw new NotImplementedException("Error while Deserialize json");
                }
                Debug.WriteLine(RequestId + ": Response deserialized");

                return APIresponse;
            }
            else
            {
                Debug.WriteLine(RequestId + ": Response geting failed");
                throw new NotImplementedException("brak internetu");
            }
        }

        private static int GetRequestId()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 10000);
        }
    }
}
