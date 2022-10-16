using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class DirectorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
