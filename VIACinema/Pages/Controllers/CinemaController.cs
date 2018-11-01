using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VIACinema.Data.Entities;
using VIACinema.Data;

namespace VIA_Cinema.Pages.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CinemaController : Controller
    {
        private MovieContext _context;

        public CinemaController(MovieContext context)
        {
            _context = context;
        }

        [HttpGet("Movies")]
        public IEnumerable<Movie> GetMovies()
        {
            if (_context.Movies.Count() == 0)
                return null;

            return _context.Movies;
        }

        [HttpGet("Orders")]
        public IEnumerable<Order> GetOrders()
        {
            if (_context.Orders.Count() == 0)
                return null;

            return _context.Orders;
        }

        [HttpGet("Orders/{id}")]
        public Order GetOrderById(int id)
        {
            return _context.Orders.Where(m => m.Id == id).SingleOrDefault();
        }

        [HttpGet("Movies/{id}")]
        public Movie GetMovieById(int id)
        {
            return _context.Movies.Where(m => m.MovieId == id).SingleOrDefault();
        }
    }
}