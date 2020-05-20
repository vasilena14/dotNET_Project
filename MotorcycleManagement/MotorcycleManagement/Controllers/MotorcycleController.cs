using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repositories;
using DataStructure;
using MotorcycleManagement.Models.ViewModels;

namespace MotorcycleManagement.Controllers
{
    [Authorize]
    public class MotorcycleController : Controller
    {
        private readonly UnitOfWork _uow;

        public MotorcycleController()
        {
            _uow = new UnitOfWork();
        }

        // GET: Motorcycle
        public ActionResult Index(string queryString)
        {
            List<Motorcycle> motorcycles;
            if (queryString != null && queryString != "")
            {
                motorcycles = _uow.MotorcycleRepository.SearchByString(queryString);
            }
            else
            {
                motorcycles = _uow.MotorcycleRepository.GetAll();
            }
            List<MotorcycleViewModel> motorcycleViewModels = MotorcycleViewModel.ToList(motorcycles);
            return View(motorcycleViewModels);
        }

        // GET: Motorcycle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorcycle motorcycle = _uow.MotorcycleRepository.GetByID((int)id);
            if (motorcycle == null)
            {
                return HttpNotFound();
            }
            MotorcycleViewModel motorcycleViewModel = new MotorcycleViewModel(motorcycle);
            return View(motorcycleViewModel);
        }

        // GET: Motorcycle/Create
        public ActionResult Create()
        {
            MakeBrandsViewBag();
            MakeCategoriesViewBag();
            MakeEnginesViewBag();

            return View();
        }

        private void MakeBrandsViewBag(BrandViewModel brandViewModel = null)
        {
            List<Brand> brand = _uow.BrandRepository.GetAll();
            List<BrandViewModel> brandViewModels = BrandViewModel.ToList(brand);
            if (brandViewModel != null)
            {
                ViewBag.Brands = new SelectList(brandViewModels, "ID", "Name", brandViewModel.ID);
            }
            else
            {
                ViewBag.Brands = new SelectList(brandViewModels, "ID", "Name");
            }
        }

        private void MakeCategoriesViewBag(CategoryViewModel categoryViewModel = null)
        {
            List<Category> category = _uow.CategoryRepository.GetAll();
            List<CategoryViewModel> categoryViewModels = CategoryViewModel.ToList(category);
            if (categoryViewModel != null)
            {
                ViewBag.Categories = new SelectList(categoryViewModels, "ID", "Title", categoryViewModel.ID);
            }
            else
            {
                ViewBag.Categories = new SelectList(categoryViewModels, "ID", "Title");
            }
        }

        private void MakeEnginesViewBag(EngineViewModel engineViewModel = null)
        {
            List<Engine> engine = _uow.EngineRepository.GetAll();
            List<EngineViewModel> engineViewModels = EngineViewModel.ToList(engine);
            if (engineViewModel != null)
            {
                ViewBag.Engines = new SelectList(engineViewModels, "ID", "Info", engineViewModel.ID);
            }
            else
            {
                ViewBag.Engines = new SelectList(engineViewModels, "ID", "Info");
            }
        }

        // POST: Motorcycle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Year,SeatHeight,Weight,BrandID,CategoryID,EngineID,CreatedAt,UpdatedAt")] MotorcycleViewModel motorcycleViewModel)
        {
            if (ModelState.IsValid)
            {
                TransformToDatabaseModelAndSave(motorcycleViewModel);
                return RedirectToAction("Index");
            }

            return View(motorcycleViewModel);
        }

        private void TransformToDatabaseModelAndSave(MotorcycleViewModel motorcycleViewModel)
        {
            Category category = _uow.CategoryRepository.GetByID(motorcycleViewModel.CategoryID);
            Brand brand = _uow.BrandRepository.GetByID(motorcycleViewModel.BrandID);
            Engine engine = _uow.EngineRepository.GetByID(motorcycleViewModel.EngineID);

            Motorcycle motorcycle = new Motorcycle()
            {
                ID = motorcycleViewModel.ID,
                Name = motorcycleViewModel.Name,
                Year = motorcycleViewModel.Year,
                SeatHeight = motorcycleViewModel.SeatHeight,
                Weight = motorcycleViewModel.Weight,
                Category = category,
                Brand = brand,
                Engine = engine,
                CreatedAt = motorcycleViewModel.CreatedAt,
                UpdatedAt = motorcycleViewModel.UpdatedAt
            };

            _uow.MotorcycleRepository.CreateOrUpdate(motorcycle);
        }

        // GET: Motorcycle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorcycle motorcycle = _uow.MotorcycleRepository.GetByID((int)id);
            if (motorcycle == null)
            {
                return HttpNotFound();
            }
            MotorcycleViewModel motorcycleViewModel = new MotorcycleViewModel(motorcycle);
            MakeBrandsViewBag(motorcycleViewModel.Brand);
            MakeCategoriesViewBag(motorcycleViewModel.Category);
            MakeEnginesViewBag(motorcycleViewModel.Engine);
            return View(motorcycleViewModel);
        }

        // POST: Motorcycle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Year,SeatHeight,Weight,BrandID,CategoryID,EngineID,CreatedAt,UpdatedAt")] MotorcycleViewModel motorcycleViewModel)
        {
            if (ModelState.IsValid)
            {
                TransformToDatabaseModelAndSave(motorcycleViewModel);
                return RedirectToAction("Index");
            }

            return View(motorcycleViewModel);
        }

        // GET: Motorcycle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Motorcycle motorcycle = _uow.MotorcycleRepository.GetByID((int)id);
            if (motorcycle == null)
            {
                return HttpNotFound();
            }
            MotorcycleViewModel motorcycleViewModel = new MotorcycleViewModel(motorcycle);
            return View(motorcycleViewModel);
        }

        // POST: Motorcycle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.MotorcycleRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
