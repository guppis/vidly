using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using vidly1.Models;

namespace vidly1.ViewModels
{
  public class MoviesFormViewModel
  {
    public IEnumerable<Genre> Genres { get; set; }
    public Movie Movie { get; set; }
  }
}