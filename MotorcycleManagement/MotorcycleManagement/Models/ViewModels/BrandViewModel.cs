using DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotorcycleManagement.Models.ViewModels
{
    public class BrandViewModel : ViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(64)]
        public string Country { get; set; }

        [Required]
        public int Founded { get; set; }

        public virtual ICollection<MotorcycleViewModel> Motorcycles { get; set; }

        public BrandViewModel() : base() { }

        public BrandViewModel(Brand brand) : base(brand)
        {
            Name = brand.Name;
            Country = brand.Country;
            Founded = brand.Founded;
        }

        public static List<BrandViewModel> ToList(List<Brand> brands)
        {
            List<BrandViewModel> brandViewModels = new List<BrandViewModel>();
            foreach (Brand brand in brands)
            {
                BrandViewModel brandViewModel = new BrandViewModel(brand);
                brandViewModels.Add(brandViewModel);
            }
            return brandViewModels;
        }
    }
}