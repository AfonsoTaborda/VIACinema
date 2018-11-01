using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VIACinema.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace VIACinema.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly VIACinema.Data.MovieContext _context;

        public ProfileModel(VIACinema.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get; set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders.Include(o => o.Movie).AsNoTracking().ToListAsync();
        }
    }
}