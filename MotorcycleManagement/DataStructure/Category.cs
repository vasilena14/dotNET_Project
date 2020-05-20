using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Category : Model
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
    }
}
