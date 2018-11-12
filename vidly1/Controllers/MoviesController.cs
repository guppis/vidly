using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly1.Models;
using vidly1.ViewModels;

namespace vidly1.Controllers
{
    public class MoviesController : Controller
    {
    
      public ActionResult Index()
      {
        var movies = new List<Movie>
        {
          new Movie() {Id = 1, Name = "Shrek"},
          new Movie() {Id = 2, Name = "Shrek2"},
          new Movie() {Id = 3, Name = "Shrek3"},
        };
        var viewModel = new MoviesDetailsViewModel
        {
          Movies = movies
        };
        return View(viewModel);
      }
    }
}