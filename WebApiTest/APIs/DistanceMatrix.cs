using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiTest.APIs
{
    public class DistanceMatrix
    {
        private readonly string apiKey = "key";
        private readonly string url = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=";
        private static readonly HttpClient client = new HttpClient();

        public string Origins { get; private set; }
        public string Destinations { get; private set; }

        public DistanceMatrix(string origins, string destinations)
        {
            Origins = origins;
            Destinations = destinations;
        }

        public async Task<string> CalculateDistanceAsync()
        {
            var responseString = await client.GetStringAsync(url + Origins + "&destinations=" + Destinations + "&key=" + apiKey);
            JsonValue json = JsonValue.Parse(responseString);

            string status = json["status"];
            double distance = 0;

            if (status == "OK")
            {
                var x = json["rows"][0]["elements"][0];
                distance = x["distance"]["value"];
                distance = distance / 1000;
            }

            return distance.ToString();
        }
    }
}
