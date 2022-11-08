using Microsoft.AspNetCore.Mvc;
using Models;
using MovieHander.DAL;
using MovieLibrary.MovieDALDBContext;

namespace MovieHander.Controllers
{
    public class MovieController : Controller
    {
        private IMovieDALData _movieDALData;

        public MovieController(IMovieDALData movieDALData)
        {
            _movieDALData = movieDALData;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult ShowMovieList()
        {
            var movie = _movieDALData.ShowMovieList();
            return View(movie);
        }



        [HttpGet]
         public IActionResult AddMovieItem()
        {
            return View();
        }

        [HttpPost]   
        public IActionResult AddMovieItem(MovieItem movie)
        {
            _movieDALData.AddMovie(movie);
            return RedirectToAction("ShowMovieList");
        }

        [HttpGet]
        public IActionResult EditMovieItem(int movieId)
        {
           // var  item = .ShowMovieList().Where(x => x.MovieId == movieId).SingleOrDefault();
            var item = _movieDALData.GetMovieById(movieId);
            return View(item);
        }

        [HttpPost]
        public IActionResult EditMovieItem(MovieItem movie)
        {
            _movieDALData.EditMovie(movie);
            return RedirectToAction("ShowMovieList");
        }

        public IActionResult DeleteMovieById(int MovieId)
        {
            _movieDALData.DeleteMovie(MovieId);
            return RedirectToAction("ShowMovieList");
        }


    }
}
