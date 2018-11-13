using System;
using System.Collections.Generic;
using System.Data.Entity;
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

  }
}