using idpa_IoT_Abfahrtsbildschirm.Models;

namespace idpa_IoT_Abfahrtsbildschirm.App_Code
{
    public class ConnectionHelper
    {
        public static int CountConnections(IEnumerable<Connection> connections, int limit)
        {

            return RemoveConnections(connections, limit).Count();
        }

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

        public static IEnumerable<Connection> RemoveConnections(IEnumerable<Connection> connections, int limit) {

            return connections.Take(limit);
        }

        public static string GetConnectionNotice(Connection connection)
        {
            var hinweis = "";
            if (connection.Track != null && connection.Track.Contains('!'))
            {
                hinweis += $"Gleisänderung {connection.Track.Remove(connection.Track.Length - 1)}";
            }
            if (connection.Dep_Delay != "+0" && connection.Dep_Delay != null)
            {
                hinweis += $" {connection.Dep_Delay}'";
            }
            return hinweis;
        }
    }
}
