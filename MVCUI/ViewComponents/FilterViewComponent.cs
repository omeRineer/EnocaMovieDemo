using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVCUI.ViewComponents
{
    public class FilterViewComponent : ViewComponent
    {
        private readonly IDirectorService _directorService;
        private readonly IGenreService _genreService;

        public FilterViewComponent(IDirectorService directorService,
                                   IGenreService genreService)
        {
            _directorService = directorService;
            _genreService = genreService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Genres = _genreService.GetAll().Data;
            ViewBag.Directors=_directorService.GetAll().Data;
            return View();
        }
    }
}
