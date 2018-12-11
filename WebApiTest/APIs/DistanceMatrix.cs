using System.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace TrackingWebApi.APIs
{
    public class DistanceMatrix : IDistanceMatrix
    {
        private readonly string apiKey = "key";
        private readonly string url = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=";
        private readonly HttpClient client = new HttpClient();

        public async Task<string> CalculateDistanceAsync(string origins, string destinations)
        {
            var responseString = await client.GetStringAsync(url + origins + "&destinations=" + destinations + "&key=" + apiKey);
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
