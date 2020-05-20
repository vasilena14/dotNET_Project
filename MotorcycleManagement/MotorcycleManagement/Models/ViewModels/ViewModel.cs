using DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotorcycleManagement.Models.ViewModels
{
    public class ViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ViewModel() { }

        public ViewModel(Model model)
        {
            ID = model.ID;
            CreatedAt = model.CreatedAt;
            UpdatedAt = model.UpdatedAt;
        }
    }
}