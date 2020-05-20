using DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotorcycleManagement.Models.ViewModels
{
    public class CategoryViewModel : ViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        public virtual ICollection<MotorcycleViewModel> Motorcycles { get; set; }

        public CategoryViewModel() : base() { }

        public CategoryViewModel(Category category) : base(category)
        {
            Title = category.Title;
        }

        public static List<CategoryViewModel> ToList(List<Category> categories)
        {
            List<CategoryViewModel> categoryViewModels = new List<CategoryViewModel>();
            foreach (Category category in categories)
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel(category);
                categoryViewModels.Add(categoryViewModel);
            }
            return categoryViewModels;
        }
    }
}