using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpaceEmpire4XGameTracker.Data;
using SpaceEmpire4XTracker.Models;

namespace SpaceEmpire4XTracker.Controllers
{
    public class TechnologyLevelViewModelsController : Controller
    {
        private SpaceEmpire4XDb db = new SpaceEmpire4XDb();

        // GET: TechnologyLevelViewModels
        public ActionResult Index()
        {
            return View(db.TechnologyLevel.ToList());
        }

        // GET: TechnologyLevelViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyLevelViewModel technologyLevelViewModel = db.TechnologyLevel.Find(id);
            if (technologyLevelViewModel == null)
            {
                return HttpNotFound();
            }
            return View(technologyLevelViewModel);
        }

        // GET: TechnologyLevelViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnologyLevelViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LevelId,LevelNumber")] TechnologyLevelViewModel technologyLevelViewModel)
        {
            if (ModelState.IsValid)
            {
                db.TechnologyLevel.Add(technologyLevelViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technologyLevelViewModel);
        }

        // GET: TechnologyLevelViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyLevelViewModel technologyLevelViewModel = db.TechnologyLevel.Find(id);
            if (technologyLevelViewModel == null)
            {
                return HttpNotFound();
            }
            return View(technologyLevelViewModel);
        }

        // POST: TechnologyLevelViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LevelId,LevelNumber")] TechnologyLevelViewModel technologyLevelViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technologyLevelViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technologyLevelViewModel);
        }

        // GET: TechnologyLevelViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyLevelViewModel technologyLevelViewModel = db.TechnologyLevel.Find(id);
            if (technologyLevelViewModel == null)
            {
                return HttpNotFound();
            }
            return View(technologyLevelViewModel);
        }

        // POST: TechnologyLevelViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnologyLevelViewModel technologyLevelViewModel = db.TechnologyLevel.Find(id);
            db.TechnologyLevel.Remove(technologyLevelViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
