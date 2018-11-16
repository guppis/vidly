  using System;
using System.Collections.Generic;
using System.Data.Entity;
  using System.Data.Entity.Validation;
  using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly1.Models;
using vidly1.ViewModels;

namespace vidly1.Controllers
{
  public class MoviesController : Controller
  {
    private ApplicationDbContext _context;

    public MoviesController()
    {
      _context = new ApplicationDbContext();
    }

    protected override void Dispose(bool disposing)
    {
      _context.Dispose();
    }

    public ActionResult New()
    {
      var genres = _context.Genres.ToList();
      var viewModel = new MoviesFormViewModel
      {
        Genres = genres
      };
      return View("MovieForm",viewModel);
    }

    public ViewResult Index()
    {
      var movies = _context.Movies.Include(m => m.Genre).ToList();

      return View(movies);
    }

    [Route("movies/details/{id:regex(\\d)}")]
    public ActionResult Details(int id)
    {
      var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.GenreId == id);
      if (movie == null) return HttpNotFound();
      return View(movie);
    }

    public ActionResult Edit(int id)
    {
      var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
      if (movie == null) return HttpNotFound();
      var viewModel = new MoviesFormViewModel()
      {
        Genres = _context.Genres.ToList(),
        Movie = movie
      };
      return View("MovieForm",viewModel);
    }

    [HttpPost]
    public ActionResult Save(Movie movie)
    {
      if (movie.Id == 0) _context.Movies.Add(movie);
      else
      {
        var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
        movieInDb.Name = movie.Name;
        movieInDb.Genre = movie.Genre;
        movieInDb.ReleaseDate = movie.ReleaseDate;
        movieInDb.NumberAvailable = movie.NumberAvailable;

        try
        {
          _context.SaveChanges();
        }
        catch (DbEntityValidationException e)

        {
          Console.WriteLine(e);
        }
      }
        return RedirectToAction("Index", "Movies");
    }
  }
}