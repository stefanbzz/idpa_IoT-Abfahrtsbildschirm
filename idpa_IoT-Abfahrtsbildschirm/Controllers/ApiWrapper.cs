/*
 * Requests a connection to the API
 * 
 * Author: Stefan Thomsen
 * Date: 07.05.2023
 * Version: 1.0
 * 
 */
using idpa_IoT_Abfahrtsbildschirm.Interfaces;
using idpa_IoT_Abfahrtsbildschirm.Models;
using Newtonsoft.Json.Linq;

namespace idpa_IoT_Abfahrtsbildschirm.Controllers
{
    public class ApiWrapper : IApiWrapper
    {
        private readonly string baseUrl = "https://timetable.search.ch/api/stationboard.json?";

        /// <summary>
        /// Initiate a connection with the API based on the parameters stop and limit.
        /// </summary>
        /// <param name="stop"></param>
        /// <param name="limit"></param>
        /// <returns>IEnumerable connection</returns>
        public async Task<IEnumerable<Connection>> GetConnections(string stop, int limit)
        {
            // Build the API URL with the specified parameters
            var apiUrl = $"{baseUrl}stop={stop}&show_tracks=1&show_delays=1&show_trackchanges=1";
            if (limit > 0) apiUrl += $"&limit={limit}";


            // Call the API and deserialize the response
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var jsonParsed = JObject.Parse(jsonResponse);
            var jsonResult = jsonParsed["connections"];
            if (jsonResult != null)
            {
                var connections = jsonResult.ToObject<IEnumerable<Connection>>();
                return connections;
            }
            return null;
        }
    }
}
