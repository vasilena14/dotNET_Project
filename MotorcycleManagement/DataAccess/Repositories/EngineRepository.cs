using DataStructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataAccess.Repositories
{
    public class EngineRepository : IRepository<Engine>
    {
        private readonly MotoContext _context;

        public EngineRepository(MotoContext context)
        {
            _context = context;
        }

        public void CreateOrUpdate(Engine entity)
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

            _context.Engines.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Engine engine = GetByID(id);
            if (engine != null)
            {
                _context.Engines.Remove(engine);
                _context.SaveChanges();
            }
        }

        public List<Engine> GetAll()
        {
            return _context.Engines.ToList();
        }

        public Engine GetByID(int id)
        {
            return _context.Engines.Find(id);
        }

    }
}