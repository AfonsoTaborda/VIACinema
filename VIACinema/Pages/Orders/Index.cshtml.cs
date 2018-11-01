using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VIACinema.Data;
using VIACinema.Data.Entities;

namespace VIA_Cinema.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly VIACinema.Data.MovieContext _context;

        public IndexModel(VIACinema.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }
        
        public async Task OnGetAsync()
        {
            Order = await _context.Orders.ToListAsync();
        }
    }
}
