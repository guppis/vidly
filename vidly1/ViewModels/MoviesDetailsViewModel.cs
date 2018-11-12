using System.Collections.Generic;
using vidly1.Models;

namespace vidly1.ViewModels
{
  public class MoviesDetailsViewModel
  {
    public Movie Movie { get; set; }
    public List<Movie> Movies { get; set; }
  }
}