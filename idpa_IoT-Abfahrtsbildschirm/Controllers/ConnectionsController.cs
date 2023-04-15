using idpa_IoT_Abfahrtsbildschirm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace idpa_IoT_Abfahrtsbildschirm.Controllers
{
    public class ConnectionsController : Controller
    {
        private readonly ILogger<ConnectionsController> _logger;

        public ConnectionsController(ILogger<ConnectionsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetConnections(string stop, int limit = 0, int interval = 5)
        {
            var connections = await GetConnections(stop, limit);

            return View("_Connections", connections);
        }
    }
}