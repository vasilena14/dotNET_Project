using DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotorcycleManagement.Models.ViewModels
{
    public class EngineViewModel : ViewModel
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

        public virtual ICollection<MotorcycleViewModel> Motorcycles { get; set; }

        public string Info
        {
            get
            {
                return Capacity + "cc, " + CoolingSystem + ", " + Cylinders + " cylinder, " + Type;
            }
        }

        public EngineViewModel() : base() { }

        public EngineViewModel(Engine engine) : base(engine)
        {
            Type = engine.Type;
            Cylinders = engine.Cylinders;
            CoolingSystem = engine.CoolingSystem;
            Capacity = engine.Capacity;
            Horsepower = engine.Horsepower;
        }

        public static List<EngineViewModel> ToList(List<Engine> engines)
        {
            List<EngineViewModel> engineViewModels = new List<EngineViewModel>();
            foreach (Engine engine in engines)
            {
                EngineViewModel engineViewModel = new EngineViewModel(engine);
                engineViewModels.Add(engineViewModel);
            }
            return engineViewModels;
        }
    }
}