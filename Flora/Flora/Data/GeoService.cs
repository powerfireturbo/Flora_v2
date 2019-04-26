using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Essentials;

namespace Flora.Data
{
    public class GeoService : IGeoService
    {
        static HttpClient http;
        static string url;

        public GeoService(string apiUrl)
        {
            http = new HttpClient();
            url = apiUrl;
        }

        public Task<List<string>> GetPlantNamesByState(string state)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("fields");
                writer.WriteStartArray();
                writer.WriteValue("scientificname");
                writer.WriteEnd();

                writer.WritePropertyName("limit");
                writer.WriteValue(5000);

                writer.WritePropertyName("rq");
                writer.WriteStartObject();
                writer.WritePropertyName("kingdom");
                writer.WriteValue("plantae");

                writer.WritePropertyName("stateprovince");
                writer.WriteValue(state);

                writer.WriteEndObject();
                writer.WriteEndObject();
            }
            return SubmitQuery(sw.ToString());
        }

        public Task<List<string>> GetPlantNamesByCounty(string state, string county)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("fields");
                writer.WriteStartArray();
                writer.WriteValue("scientificname");
                writer.WriteEnd();

                writer.WritePropertyName("limit");
                writer.WriteValue(5000);

                writer.WritePropertyName("rq");
                writer.WriteStartObject();
                writer.WritePropertyName("kingdom");
                writer.WriteValue("plantae");

                writer.WritePropertyName("stateprovince");
                writer.WriteValue(state);

                writer.WritePropertyName("county");
                writer.WriteValue(county);

                writer.WriteEndObject();
                writer.WriteEndObject();
            }
            return SubmitQuery(sw.ToString());

        }

        public async Task<List<string>> GetPlantNamesWithinRadius(int radius)
        {
            Location location = await Geolocation.GetLastKnownLocationAsync();
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("fields");
                writer.WriteStartArray();
                writer.WriteValue("scientificname");
                writer.WriteEnd();

                writer.WritePropertyName("limit");
                writer.WriteValue(5000);

                writer.WritePropertyName("rq");
                writer.WriteStartObject();
                writer.WritePropertyName("kingdom");
                writer.WriteValue("plantae");

                writer.WritePropertyName("geopoint");
                writer.WriteStartObject();
                writer.WritePropertyName("type");
                writer.WriteValue("geo_distance");
                writer.WritePropertyName("distance");
                writer.WriteValue(radius.ToString() + "km");
                writer.WritePropertyName("lat");
                writer.WriteValue(location.Latitude);
                writer.WritePropertyName("lon");
                writer.WriteValue(location.Longitude);
                writer.WriteEndObject();
                writer.WriteEndObject();
                writer.WriteEndObject();
            }
            return await SubmitQuery(sw.ToString());
        }

        private async Task<List<string>> SubmitQuery(string request)
        {
            var content = new StringContent(request, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await http.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return await ParseResponse(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }

        private Task<List<string>> ParseResponse(string json)
        {
            return Task<List<string>>.Run(() =>
            {
                JObject jObject = JObject.Parse(json);
                return (from item in jObject["items"] select (string)item["indexTerms"]["scientificname"]).Distinct().ToList();
            });
        }
    }
}
