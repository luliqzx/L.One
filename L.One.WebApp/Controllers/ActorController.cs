using L.One.Domain.Common;
using L.One.Domain.Entity;
using L.One.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L.One.WebApp.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository ActorRepository;
        private readonly IUnitOfWork uow;

        public ActorController(IUnitOfWork _UnitOfWork, IActorRepository _ActorRepository)
        {
            ActorRepository = _ActorRepository;
            uow = _UnitOfWork;
        }

        // GET: Actor
        public ActionResult Index()
        {
            var lstActor = ActorRepository.GetAll().AsEnumerable();
            return View(lstActor);
        }

        // GET: Actor/Details/5
        public ActionResult Details(string id)
        {
            var model = ActorRepository.Get(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        [HttpPost]
        public ActionResult Create(Actor collection)
        {
            try
            {
                // TODO: Add insert logic here
                var model = new Actor();
                model.Description = collection.Description;
                model.Active = collection.Active;
                model.Id = collection.Description;

                this.uow.BeginTransaction();
                this.ActorRepository.Save(model);
                this.uow.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(string id)
        {
            var model = ActorRepository.Get(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: Actor/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Actor collection)
        {
            try
            {
                // TODO: Add update logic here

                var model = ActorRepository.Get(x => x.Id == id).FirstOrDefault();
                model.Description = collection.Description;
                model.Active = collection.Active;

                this.uow.BeginTransaction();
                this.ActorRepository.Update(model);
                this.uow.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Actor/Delete/5
        public ActionResult Delete(string id)
        {
            var model = ActorRepository.Get(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: Actor/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Actor collection)
        {
            try
            {
                // TODO: Add delete logic here
                var model = ActorRepository.Get(x => x.Id == id).FirstOrDefault();
                this.uow.BeginTransaction();
                this.ActorRepository.Delete(model);
                this.uow.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
