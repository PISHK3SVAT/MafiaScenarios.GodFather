using System.Diagnostics;

using BusinessLogic;

using Endpoint.MVC.Models;

using Microsoft.AspNetCore.Mvc;

using Repository;

namespace Endpoint.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowPlayers()
        {
            var players = new PlayerRepos().Family1().Select(p => new ShowPlayerVM
            {
                Name = p.Name,
            });
            return View(players);
        }

        [HttpGet]
        public IActionResult ShowPlayersWithRoles()
        {
            var players = new Game().Players.Select(p => new ShowPlayerWithRoleVM
            {
                PlayerName = p.Name,
                RoleTitle = p.Role!.Title,
            });
            return View(players);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}