using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork
    {
        private MotorcycleRepository _motorcycleRepository;
        private BrandRepository _brandRepository;
        private CategoryRepository _categoryRepository;
        private EngineRepository _engineRepository;

        private readonly MotoContext _context;

        public BrandRepository BrandRepository
        {
            get
            {
                if (_brandRepository == null)
                {
                    _brandRepository = new BrandRepository(_context);
                }

                return _brandRepository;
            }
        }

        public MotorcycleRepository MotorcycleRepository
        {
            get
            {
                if (_motorcycleRepository == null)
                {
                    _motorcycleRepository = new MotorcycleRepository(_context);
                }

                return _motorcycleRepository;
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }

                return _categoryRepository;
            }
        }

        public EngineRepository EngineRepository
        {
            get
            {
                if (_engineRepository == null)
                {
                    _engineRepository = new EngineRepository(_context);
                }

                return _engineRepository;
            }
        }
        public UnitOfWork()
        {
            _context = new MotoContext();
        }
    }
}
