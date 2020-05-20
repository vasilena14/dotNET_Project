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
    public class BrandController : Controller
    {
        private readonly UnitOfWork _uow;

        public BrandController()
        {
            _uow = new UnitOfWork();
        }

        // GET: Brand
        public ActionResult Index()
        {
            List<Brand> brands = _uow.BrandRepository.GetAll();
            List<BrandViewModel> brandViewModels = BrandViewModel.ToList(brands);
            return View(brandViewModels);
        }

        // GET: Brand/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = _uow.BrandRepository.GetByID((int)id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            BrandViewModel brandViewModel = new BrandViewModel(brand);
            return View(brandViewModel);
        }


        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Country,Founded,CreatedAt,UpdatedAt")] BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                Brand brand = TransformToDatabaseModel(brandViewModel);
                _uow.BrandRepository.CreateOrUpdate(brand);
                return RedirectToAction("Index");
            }

            return View(brandViewModel);
        }

        // GET: Brand/Edit/5

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = _uow.BrandRepository.GetByID((int)id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            BrandViewModel brandViewModel = new BrandViewModel(brand);
            return View(brandViewModel);
        }

        // POST: Brand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Country,Founded,CreatedAt,UpdatedAt")] BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                Brand brand = TransformToDatabaseModel(brandViewModel);
                _uow.BrandRepository.CreateOrUpdate(brand);
                return RedirectToAction("Index");
            }
            return View(brandViewModel);
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = _uow.BrandRepository.GetByID((int)id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            BrandViewModel brandViewModel = new BrandViewModel(brand);
            return View(brandViewModel);
        }

        // POST: Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.BrandRepository.Delete(id);
            return RedirectToAction("Index");
        }

        private Brand TransformToDatabaseModel(BrandViewModel brandViewModel)
        {
            return new Brand()
            {
                ID = brandViewModel.ID,
                Name = brandViewModel.Name,
                Country = brandViewModel.Country,
                Founded = brandViewModel.Founded,
                CreatedAt = brandViewModel.CreatedAt,
                UpdatedAt = brandViewModel.UpdatedAt
            };
        }
    }
}
