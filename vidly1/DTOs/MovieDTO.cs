using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using vidly1.Models;

namespace vidly1.DTOs
{
  public class MovieDTO
  {
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    public Genre Genre { get; set; }

    [Required]
    public byte GenreId { get; set; }

    public DateTime DateAdded { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    [Range(1, 20)]
    public byte NumberAvailable { get; set; }
  }
}