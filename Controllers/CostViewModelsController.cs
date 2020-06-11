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
    public class CostViewModelsController : Controller
    {
        private SpaceEmpire4XDb db = new SpaceEmpire4XDb();

        // GET: CostViewModels
        public ActionResult Index()
        {
            return View(db.Cost.ToList());
        }

        // GET: CostViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostViewModel costViewModel = db.Cost.Find(id);
            if (costViewModel == null)
            {
                return HttpNotFound();
            }
            return View(costViewModel);
        }

        // GET: CostViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CostViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CostId,Cost")] CostViewModel costViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Cost.Add(costViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(costViewModel);
        }

        // GET: CostViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostViewModel costViewModel = db.Cost.Find(id);
            if (costViewModel == null)
            {
                return HttpNotFound();
            }
            return View(costViewModel);
        }

        // POST: CostViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CostId,Cost")] CostViewModel costViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(costViewModel);
        }

        // GET: CostViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostViewModel costViewModel = db.Cost.Find(id);
            if (costViewModel == null)
            {
                return HttpNotFound();
            }
            return View(costViewModel);
        }

        // POST: CostViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CostViewModel costViewModel = db.Cost.Find(id);
            db.Cost.Remove(costViewModel);
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
