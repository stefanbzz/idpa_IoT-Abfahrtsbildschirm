/*
 * Contains methods for the View component.
 * 
 * Author: Stefan Thomsen
 * Date: 07.05.2023
 * Version: 1.0
 * 
 */
using idpa_IoT_Abfahrtsbildschirm.Models;

namespace idpa_IoT_Abfahrtsbildschirm.App_Code
{
    public class ConnectionHelper
    {

        /// <summary>
        /// Remove excess train results that are added when the departure time is the same.
        /// </summary>
        /// <param name="connections"></param>
        /// <param name="limit"></param>
        /// <returns>IEnumerable Connection</returns>
        public static IEnumerable<Connection> RemoveConnections(IEnumerable<Connection> connections, int limit)
        {
            return connections.Take(limit);
        }

        /// <summary>
        /// Count the number of connections on the screen. This is used to resize the departures table.
        /// </summary>
        /// <param name="connections"></param>
        /// <param name="limit"></param>
        /// <returns>The number of results</returns>
        public static int CountConnections(IEnumerable<Connection> connections, int limit)
        {

            return RemoveConnections(connections, limit).Count();
        }

        /// <summary>
        /// Return the corresponding transport icon based on its API property
        /// </summary>
        /// <param name="connectionType"></param>
        /// <returns>The directory for the icon as a string</returns>
        public static string GetConnectionImage(string connectionType)
        {
            switch (connectionType)
            {
                case "night_bus":
                case "bus":
                    return "img/Bus_r.svg";
                case "express_train":
                case "night_strain":
                case "strain":
                    return "img/Zug.svg";
                case "tram":
                    return "img/Tram.svg";
                case "ship":
                    return "img/Schiff.svg";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Get train info if the train is delayed or has a track change
        /// </summary>
        /// <param name="connection"></param>
        /// <returns>a string with the necessary infromation</returns>
        public static string GetConnectionNotice(Connection connection)
        {
            var hinweis = "";
            // Check if the train has a track change and add the notice to the string
            // Additionally it has to check if the track exists, otherwise there will be an error, because e.g. most buses don't have a track.
            if (connection.Track != null && connection.Track.Contains('!'))
            {
                hinweis += $"Gleisänderung {connection.Track.Remove(connection.Track.Length - 1)}";
            }

            // Check if there is a departure delay and add the notice to the string
            if (connection.Dep_Delay != "+0" && connection.Dep_Delay != null)
            {
                if(connection.Dep_Delay == "+X")
                {
                    hinweis += "unbestimmte Verspätung";
                 
                } 
                else
                {
                    hinweis += $" {connection.Dep_Delay}'";
                }
            }
            return hinweis;
        }
    }
}
