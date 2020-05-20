using DataStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccess.Repositories
{
    public class MotorcycleRepository : IRepository<Motorcycle>
    {
        private readonly MotoContext _context;

        public MotorcycleRepository(MotoContext context)
        {
            _context = context;
        }

        public void CreateOrUpdate(Motorcycle entity)
        {
            if (entity.ID == 0)
            {
                entity.CreatedAt = DateTime.Now;
            }
            else
            {
                entity.CreatedAt = GetByID(entity.ID).CreatedAt;

                Motorcycle row = GetByID(entity.ID);
                if (row.Category != entity.Category)
                    row.Category = entity.Category;
                if (row.Brand != entity.Brand)
                    row.Brand = entity.Brand;
                if (row.Engine != entity.Engine)
                    row.Engine = entity.Engine;
            }

            entity.UpdatedAt = DateTime.Now;

            _context.Motorcycles.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Motorcycle motorcycle = GetByID(id);
            if (motorcycle != null)
            {
                _context.Motorcycles.Remove(motorcycle);
                _context.SaveChanges();
            }
        }

        public List<Motorcycle> SearchByString(string query)
        {
            return _context.Motorcycles.Where(motorcycle => motorcycle.Name.Contains(query) || motorcycle.Category.Title.Contains(query) || motorcycle.Brand.Name.Contains(query) || motorcycle.Engine.Type.Contains(query)).ToList();
        }

        public List<Motorcycle> GetAll()
        {
            return _context.Motorcycles.ToList();
        }

        public Motorcycle GetByID(int id)
        {
            return _context.Motorcycles.Find(id);
        }
    }
}