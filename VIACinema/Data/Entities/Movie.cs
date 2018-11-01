using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VIACinema.Data.Entities 
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string ImageURL { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Category { get; set; }

        public string MovieLength { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Description { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public int Rating { get; set; }

        [StringLength(30)]
        public string DirectorName { get; set; }
    }
}
