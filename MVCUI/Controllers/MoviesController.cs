using Business.Abstract;
using System.Linq;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Entities.Dto;

namespace MVCUI.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IDirectorService _directorService;
        private readonly IGenreService _genreService;

        public MoviesController(IMovieService movieService,
                                IDirectorService directorService,
                                IGenreService genreService)
        {
            _movieService = movieService;
            _directorService = directorService;
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _movieService.GetAll();
            return View(result.Data);
        }

        [HttpPost("/filter")]
        public IActionResult GetByFilter([FromForm] MovieFilterDto filter)
        {
            var result = _movieService.GetByFilter(filter);
            return View(result.Data);
        }

        [HttpGet("/create")]
        public IActionResult CreatePage()
        {
            ViewBag.Genres = GetGenres();
            ViewBag.Directors = GetDirectors();
            return View();
        }

        [HttpGet("/get/{movieId}")]
        public IActionResult GetById(int movieId)
        {
            ViewBag.Genres = GetGenres();
            ViewBag.Directors = GetDirectors();
            var result = _movieService.GetById(movieId);
            return View(result.Data);
        }

        [HttpPost("/add")]
        public IActionResult Add(Movie movie)
        {
            var result=_movieService.Add(movie);
            if(!result.Success) return View(result);
            return RedirectToAction("Index");
        }

        [HttpGet("/delete/{movieId}")]
        public IActionResult Delete(int movieId)
        {
            var result = _movieService.Delete(movieId);
            if (!result.Success) return View(result);
            return RedirectToAction("Index");
        }

        [HttpPost("/update")]
        public IActionResult Update(Movie movie)
        {
            var result = _movieService.Update(movie);
            if (!result.Success) return View(result);
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetGenres()
        {
            var genres = (from x in _genreService.GetAll().Data
                          select new SelectListItem
                          {
                              Value = x.Id.ToString(),
                              Text = x.Name
                          }).ToList();
            return genres;
        }

        private List<SelectListItem> GetDirectors()
        {
            var directors = (from x in _directorService.GetAll().Data
                             select new SelectListItem
                             {
                                 Value = x.Id.ToString(),
                                 Text = $"{x.FirstName} {x.LastName}"
                             }).ToList();
            return directors;
        }
    }
}
