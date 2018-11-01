using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VIACinema.Data;
using VIACinema.Data.Entities;
using VIACinema.Pages.Orders;

namespace VIA_Cinema.Pages.Orders
{
    public class CreateModel : MoviePageModel
    {
        private readonly VIACinema.Data.MovieContext _context;
        private int SeatRows = 10;
        private int SeatColumns = 20;

        public CreateModel(VIACinema.Data.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateMoviesDropdownList(_context);
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        public Dictionary<string, List<(int displayNum, int id)>> GetAvailableSeats()
        {
            var availSeats = new Dictionary<string, List<(int displayNum, int id)>>();
            var takenSeats = _context.Orders.Select(s => s.SeatNumber).ToHashSet();
            for (int i = 0; i < SeatRows * SeatColumns; i++)
            {
                if (!takenSeats.Contains(i))
                {
                    var rowNum = i / SeatColumns;
                    char c = 'A';
                    c += (char)rowNum;
                    string rowName = c.ToString();
                    availSeats.TryAdd(rowName, new List<(int displayNum, int id)>());
                    availSeats[rowName].Add((i % SeatColumns + 1, i));
                }
            }
            return availSeats;

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyOrder = new Order();

            if (await TryUpdateModelAsync<Order>(
                 emptyOrder,
                 "order",   // Prefix for form value.
                 o => o.Id, o => o.UserName, o => o.MovieId, o => o.SeatNumber, o => o.OrderDate, o => o.Quantity))
            {
                emptyOrder.UserName = User.Identity.Name;
                _context.Orders.Add(emptyOrder);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Profile");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateMoviesDropdownList(_context, emptyOrder.Id);
            return Page();
        }
    }
}