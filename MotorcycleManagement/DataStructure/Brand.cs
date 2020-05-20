using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Brand : Model
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(64)]
        public string Country { get; set; }

        [Required]
        public int Founded { get; set; }
    }
}
