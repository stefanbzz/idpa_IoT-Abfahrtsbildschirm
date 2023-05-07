/*
 * Connection Class according to the API
 * 
 * Author: Stefan Thomsen
 * Date: 07.05.2023
 * Version: 1.0
 * 
 */
namespace idpa_IoT_Abfahrtsbildschirm.Models
{
    public class Connection
    {
            public DateTime Time { get; set; }
            public string Type { get; set; }
            public string Line { get; set; }
            public string Color { get; set; }
            public string TypeName { get; set; }
            public Terminal Terminal { get; set; }
            public string Track { get; set; }
            public string Dep_Delay { get; set; }
            public int Interval { get; set; }
    }
}
