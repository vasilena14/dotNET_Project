using DataStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly MotoContext _context;

        public CategoryRepository(MotoContext context)
        {
            _context = context;
        }

        public void CreateOrUpdate(Category entity)
        {
            if (entity.ID == 0)
            {
                entity.CreatedAt = DateTime.Now;
            }
            else
            {
                entity.CreatedAt = GetByID(entity.ID).CreatedAt;
            }
            entity.UpdatedAt = DateTime.Now;

            _context.Categories.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = GetByID(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetByID(int id)
        {
            return _context.Categories.Find(id);
        }
    }
}