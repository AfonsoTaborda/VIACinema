using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VIACinema.Data;

namespace VIACinema.Pages.Orders
{
    public class MoviePageModel:PageModel
    {
        public SelectList MovieNameSL { get; set; }

        public void PopulateMoviesDropdownList(MovieContext _context,
            object selectedMovie = null)
        {
            var moviesQuery = from m in _context.Movies
                              orderby m.Name
                              select m;

            MovieNameSL = new SelectList(moviesQuery.AsNoTracking(),
                "MovieId", "Name", selectedMovie);
        }
    }
}
