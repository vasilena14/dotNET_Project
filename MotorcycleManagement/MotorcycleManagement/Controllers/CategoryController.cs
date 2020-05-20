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
    public class CategoryController : Controller
    {
        private readonly UnitOfWork _uow;

        public CategoryController()
        {
            _uow = new UnitOfWork();
        }

        // GET: Category
        public ActionResult Index()
        {
            List<Category> categories = _uow.CategoryRepository.GetAll();
            List<CategoryViewModel> categoryViewModels = CategoryViewModel.ToList(categories);
            return View(categoryViewModels);
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _uow.CategoryRepository.GetByID((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            CategoryViewModel categoryViewModel = new CategoryViewModel(category);
            return View(categoryViewModel);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title")] CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = TransformToDatabaseModel(categoryViewModel);
                _uow.CategoryRepository.CreateOrUpdate(category);
                return RedirectToAction("Index");
            }

            return View(categoryViewModel);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _uow.CategoryRepository.GetByID((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            CategoryViewModel categoryViewModel = new CategoryViewModel(category);
            return View(categoryViewModel);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = TransformToDatabaseModel(categoryViewModel);
                _uow.CategoryRepository.CreateOrUpdate(category);
                return RedirectToAction("Index");
            }
            return View(categoryViewModel);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _uow.CategoryRepository.GetByID((int)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            CategoryViewModel categoryViewModel = new CategoryViewModel(category);
            return View(categoryViewModel);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.CategoryRepository.Delete(id);
            return RedirectToAction("Index");
        }

        private Category TransformToDatabaseModel(CategoryViewModel categoryViewModel)
        {
            return new Category()
            {
                ID = categoryViewModel.ID,
                Title = categoryViewModel.Title,
                CreatedAt = categoryViewModel.CreatedAt,
                UpdatedAt = categoryViewModel.UpdatedAt
            };
        }
    }
}
