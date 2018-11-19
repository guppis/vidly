using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using vidly1.Models;

namespace vidly1.ViewModels
{
  public class MoviesFormViewModel
  {
    public IEnumerable<Genre> Genres { get; set; }
    public int? Id { get; set; }

    [Required] [StringLength(255)] public string Name { get; set; }

    [Required] public byte? GenreId { get; set; }

    [Required]
    [Display(Name = "Release date")]
  public DateTime? ReleaseDate { get; set; }

    [Required]
    [Display(Name = "Number in stock")]
    [Range(1, 20)]
    public byte? NumberAvailable { get; set; }

    public string Title
    {
      get
      {
       return Id != 0 ? "Edit Movie" : "New Movie";
      }
    }

    public MoviesFormViewModel()
    {
      Id = 0;
    }

    public MoviesFormViewModel(Movie movie)
    {
      Id = movie.Id;
      Name = movie.Name;
      ReleaseDate = movie.ReleaseDate;
      NumberAvailable = movie.NumberAvailable;
      GenreId = movie.GenreId;
    }
  }
}