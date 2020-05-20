using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Engine : Model
    {
        [Required]
        [MaxLength(64)]
        public string Type { get; set; }

        [Required]
        [MaxLength(64)]
        public string Cylinders { get; set; }

        [Required]
        [MaxLength(64)]
        public string CoolingSystem { get; set; }

        [Required]
        [Range(45, 2400, ErrorMessage = "Capacity must be between 45cc and 2400cc.")]
        public int Capacity { get; set; }

        [Required]
        [Range(5, 320, ErrorMessage = "Horsepower must be between 5hp and 320hp.")]
        public double Horsepower { get; set; }
    }
}
