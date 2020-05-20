using DataStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccess.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        private readonly MotoContext _context;

        public BrandRepository(MotoContext context)
        {
            _context = context;
        }

        public void CreateOrUpdate(Brand entity)
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

            _context.Brands.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Brand brand = GetByID(id);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                _context.SaveChanges();
            }
        }

        public List<Brand> GetAll()
        {
            return _context.Brands.ToList();
        }

        public Brand GetByID(int id)
        {
            return _context.Brands.Find(id);
        }

    }
}