using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Data.Entities
{

    public class Order
    {

        public int Id { get; set; }

       public string UserName { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int SeatNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required]
        public int Quantity { get; set; }

    }
}
