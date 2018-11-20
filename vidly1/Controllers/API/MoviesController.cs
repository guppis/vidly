using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using vidly1.DTOs;
using vidly1.Models;

namespace vidly1.Controllers.API
{
  public class MoviesController : ApiController
  {
    private ApplicationDbContext _context;

    public MoviesController()
    {
      _context = new ApplicationDbContext();
    }


    //  GET /api/movies
    public IEnumerable<MovieDTO> GetMovies()
    {
      return _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDTO>);
    }

    // GET /api/movies/1
    public IHttpActionResult GetMovie(int id)
    {
      var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
      if (movie == null) return NotFound();

      return Ok(Mapper.Map<Movie, MovieDTO>(movie));
    }

    // CREATE /api/movies
    [HttpPost]
    public IHttpActionResult CreateMovie(MovieDTO movieDTO)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);

      _context.Movies.Add(movie);
      _context.SaveChanges();
      movieDTO.Id = movie.Id;

      return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
    }

    // UPDATE /api/movies/1
    [HttpPut]
    public IHttpActionResult UpdateMovie(int id, MovieDTO movieDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();
      var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

      if (movieInDb == null) return NotFound();
      Mapper.Map(movieDto, movieInDb);
      _context.SaveChanges();
      return Ok();
    }

    // DELETE /api/movies/1
    [HttpDelete]
    public IHttpActionResult DeleteMovie(int id, Movie movie)
    {
      var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

      if (!ModelState.IsValid)
        return BadRequest();
      

      _context.Movies.Remove(movieInDb);
      _context.SaveChanges();
      return Ok();
    }
  }
}
