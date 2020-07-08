using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Library.Interfaces.Factories;
using Library.Interfaces.Services.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portal.Models;

namespace Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHermesHandlerFactory _hermes;

        public HomeController(
            ILogger<HomeController> logger,
            IHermesHandlerFactory hermes)
        {
            _logger = logger;
            _hermes = hermes;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            using var handler = _hermes.Create();
            var todoRequestService = handler.Service<ITodoRequestService>();
            var response = await todoRequestService.GetList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
