using BusinessLogic;

using Endpoint.MVC.Models.Game;

using Microsoft.AspNetCore.Mvc;

namespace Endpoint.MVC.Controllers
{
    public class GameController : Controller
    {
        private GameService GameService;

        public GameController(GameService gameService)
        {
            GameService = gameService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AssignRoles()
        {
            GameService.RandomizeSetRoleToPlayer();
            return RedirectToAction(nameof(PlayerRoles));
        }

        [HttpGet]
        public IActionResult PlayerRoles()
        {
            var vm = GameService.Players.Select(p => new PlayerRoleViewModel
            {
                Name = p.Name,
                RoleTitle = p.Role!.Title,
                PicUrl = p.Role!.PicPath!,
                Describtion = p.Role!.Describtion!
            }).ToList();
            return View(vm);
        }
    }
}
