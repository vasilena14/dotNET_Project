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
    public class EngineController : Controller
    {
        private readonly UnitOfWork _uow;

        public EngineController()
        {
            _uow = new UnitOfWork();
        }

        // GET: Engine
        public ActionResult Index()
        {
            List<Engine> engines = _uow.EngineRepository.GetAll();
            List<EngineViewModel> engineViewModels = EngineViewModel.ToList(engines);
            return View(engineViewModels);
        }

        // GET: Engine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engine engine = _uow.EngineRepository.GetByID((int)id);
            if (engine == null)
            {
                return HttpNotFound();
            }
            EngineViewModel engineViewModel = new EngineViewModel(engine);
            return View(engineViewModel);
        }

        // GET: Engine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Type,Cylinders,CoolingSystem,Capacity,Horsepower,CreatedAt,UpdatedAt")] EngineViewModel engineViewModel)
        {
            if (ModelState.IsValid)
            {
                Engine engine = TransformToDatabaseModel(engineViewModel);
                _uow.EngineRepository.CreateOrUpdate(engine);
                return RedirectToAction("Index");
            }

            return View(engineViewModel);
        }

        // GET: Engine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engine engine = _uow.EngineRepository.GetByID((int)id);
            if (engine == null)
            {
                return HttpNotFound();
            }
            EngineViewModel engineViewModel = new EngineViewModel(engine);
            return View(engineViewModel);
        }

        // POST: Engine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Type,Cylinders,CoolingSystem,Capacity,Horsepower,CreatedAt,UpdatedAt")] EngineViewModel engineViewModel)
        {
            if (ModelState.IsValid)
            {
                Engine engine = TransformToDatabaseModel(engineViewModel);
                _uow.EngineRepository.CreateOrUpdate(engine);
                return RedirectToAction("Index");
            }
            return View(engineViewModel);
        }

        // GET: Engine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engine engine = _uow.EngineRepository.GetByID((int)id);
            if (engine == null)
            {
                return HttpNotFound();
            }
            EngineViewModel engineViewModel = new EngineViewModel(engine);
            return View(engineViewModel);
        }

        // POST: Engine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.EngineRepository.Delete(id);
            return RedirectToAction("Index");
        }

        private Engine TransformToDatabaseModel(EngineViewModel engineViewModel)
        {
            return new Engine()
            {
                ID = engineViewModel.ID,
                Type = engineViewModel.Type,
                Cylinders = engineViewModel.Cylinders,
                CoolingSystem = engineViewModel.CoolingSystem,
                Capacity = engineViewModel.Capacity,
                Horsepower = engineViewModel.Horsepower,
                CreatedAt = engineViewModel.CreatedAt,
                UpdatedAt = engineViewModel.UpdatedAt
            };
        }
    }
}
