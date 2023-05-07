/*
 * Create View page
 * 
 * Author: Stefan Thomsen
 * Date: 07.05.2023
 * Version: 1.0
 * 
 */
using Microsoft.AspNetCore.Mvc;

namespace idpa_IoT_Abfahrtsbildschirm.Controllers
{
    public class ConnectionsController : Controller
    {
        private readonly ApiWrapper apiWrapper;

        /// <summary>
        /// Create an instance of the APIWrapper.
        /// </summary>
        /// <param name="apiWrapper"></param>
        public ConnectionsController(ApiWrapper apiWrapper)
        {
            this.apiWrapper = apiWrapper;
        }

        /// <summary>
        /// Load the default view.
        /// </summary>
        /// <returns>a ViewResult</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Load and send the user inputted stop and limit to the method GetConnections
        /// </summary>
        /// <param name="stop"></param>
        /// <param name="limit"></param>
        /// <returns>a Partial View containing the departure board</returns>
        public async Task<IActionResult> GetConnections(string stop, int limit)
        {
            var connections = await apiWrapper.GetConnections(stop, limit);

            ViewBag.Stop =  stop;
            ViewBag.Limit = limit;

            return PartialView("_Connections", connections);
        }
    }
}