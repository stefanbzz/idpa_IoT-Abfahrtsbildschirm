using idpa_IoT_Abfahrtsbildschirm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace idpa_IoT_Abfahrtsbildschirm.Controllers
{
    public class ConnectionsController : Controller
    {
        private readonly ApiWrapper apiWrapper;

        public ConnectionsController(ApiWrapper apiWrapper)
        {
            this.apiWrapper = apiWrapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetConnections(string stop, int limit = 0, int interval = 5)
        {
            var connections = await apiWrapper.GetConnections(stop, limit);

            ViewBag.Stop =  stop;

            return PartialView("_Connections", connections);
        }
    }
}