using DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotorcycleManagement.Models.ViewModels
{
    public class MotorcycleViewModel : ViewModel
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

        public int BrandID { get; set; }
        public virtual BrandViewModel Brand { get; set; }

        public int CategoryID { get; set; }
        public virtual CategoryViewModel Category { get; set; }

        public int EngineID { get; set; }
        public virtual EngineViewModel Engine { get; set; }

        public MotorcycleViewModel() : base() { }

        public MotorcycleViewModel(Motorcycle motorcycle) : base(motorcycle)
        {
            Name = motorcycle.Name;
            Year = motorcycle.Year;
            SeatHeight = motorcycle.SeatHeight;
            Weight = motorcycle.Weight;
            Brand = new BrandViewModel(motorcycle.Brand);
            BrandID = Brand.ID;
            Category = new CategoryViewModel(motorcycle.Category);
            CategoryID = Category.ID;
            Engine = new EngineViewModel(motorcycle.Engine);
            EngineID = Engine.ID;
        }

        public static List<MotorcycleViewModel> ToList(List<Motorcycle> motorcycles)
        {
            List<MotorcycleViewModel> motorcycleViewModels = new List<MotorcycleViewModel>();
            foreach (Motorcycle motorcycle in motorcycles)
            {
                MotorcycleViewModel motorcycleViewModel = new MotorcycleViewModel(motorcycle);
                motorcycleViewModels.Add(motorcycleViewModel);
            }
            return motorcycleViewModels;
        }
    }
}