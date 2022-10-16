using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVCUI.ViewComponents
{
    public class MoviesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(List<Movie> movies)
        {
            return View(movies);
        }
    }
}
