using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using vidly1.Models;

namespace vidly1.ViewModels
{
  public class MoviesDetailsViewModel
  {
    public IEnumerable<Genre> Genres { get; set; }
  }
}