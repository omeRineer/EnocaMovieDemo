using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.Controllers
{
    public class SaloonsController : Controller
    {
        private readonly ISaloonService _saloonService;

        public SaloonsController(ISaloonService saloonService)
        {
            _saloonService = saloonService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
