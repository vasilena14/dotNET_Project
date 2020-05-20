using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Motorcycle : Model
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public double SeatHeight { get; set; }

        [Required]
        public double Weight { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        public virtual Engine Engine { get; set; }

    }
}
