using BusinessLogic;

using Endpoint.MVC.Models.Player;

using Microsoft.AspNetCore.Mvc;

namespace Endpoint.MVC.Controllers
{
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            var vm = PlayerService.Players.Select(p => new ShowPlayerViewModel
            {
                Name = p.Name,
                Role=new ShowPlayerRoleViewModel
                {
                    Title=p.Role?.Title??string.Empty,
                    PicPath=p.Role?.PicPath??string.Empty,
                    Describtion=p.Role?.Describtion ?? string.Empty,
                    Side= p.Role.Side,
                    SideRole = p.Role.SideRole
                }
            }).ToList();
            vm = new List<ShowPlayerViewModel>
            {
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
                new ShowPlayerViewModel{Name="محمدجواد"},
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(List<string> Names) 
        {
            if (Names.Any(n=>n is null))
            {
                ModelState.AddModelError(string.Empty, "اسامی هر 11 نفر را وارد کنید");
                return View();
            }
            if (Names.Distinct().ToList().Count() != 11)
            {                
                ModelState.AddModelError(string.Empty, "اسامی تکراری مجاز نیستند");
                return View();
            }
            var inputDtos = Names.Select(n => new InputPlayerDto { Name = n }).ToList();
            PlayerService.InputPlayers(inputDtos);
            return View();
        }
    }
}
