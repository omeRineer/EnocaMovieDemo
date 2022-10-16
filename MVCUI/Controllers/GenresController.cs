using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class GenresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
