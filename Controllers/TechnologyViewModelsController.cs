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
    public class TechnologyViewModelsController : Controller
    {
        private SpaceEmpire4XDb db = new SpaceEmpire4XDb();

        // GET: TechnologyViewModels
        public ActionResult Index()
        {

            //if (!ModelState.IsValid)
            //{
            //    return View(db.Hole.ToList());
            //}
            var technology = db.Technology.Include(t => t.TechnologyLevel.LevelNumber)
            .Include(c => c.Cost.Cost).ToList();

            return View(technology);
        }

        // GET: TechnologyViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyViewModel technologyViewModel = db.Technology.Find(id);
            if (technologyViewModel == null)
            {
                return HttpNotFound();
            }
            return View(technologyViewModel);
        }

        // GET: TechnologyViewModels/Create
        public ActionResult Create()
        {

            //Get database values
            var dbTechnologyLevel = db.TechnologyLevel.ToList();
            var dbCost = db.Cost.ToList();

            //Make selectlist, which is IEnumerable<SelectListItem>
            var LevelDropdownList = new SelectList(db.TechnologyLevel.Select(item => new SelectListItem()
            {
                Text = item.LevelNumber.ToString(),
                Value = item.LevelNumber.ToString()
            }).ToList(), "Value", "Text");

            var CostDropdownList = new SelectList(db.Cost.Select(item => new SelectListItem()
            {
                Text = item.Cost.ToString(),
                Value = item.Cost.ToString()
            }).ToList(), "Value", "Text");

            // Assign the Selectlist to the View Model  
            var ViewTech = new TechnologyViewModel()
            {
                //TechnologyLevel = dbTechnologyLevel.FirstOrDefault(),
                //Cost = dbCost.FirstOrDefault(),
                // The Dropdownlist values
                TechLevelDropDownList = LevelDropdownList,
                CostDropDownList = CostDropdownList,

            };
            return View(ViewTech);
        }

        // POST: TechnologyViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TechId,TechnologyName,Level_Id,Cost_Id")] TechnologyViewModel technologyViewModel)
        {
            //Get database values
            var dbTechnologyLevel = db.TechnologyLevel.ToList();
            var dbCost = db.Cost.ToList();

            //Make selectlist, which is IEnumerable<SelectListItem>
            var LevelDropdownList = new SelectList(db.TechnologyLevel.Select(item => new SelectListItem()
            {
                Text = item.LevelNumber.ToString(),
                Value = item.LevelNumber.ToString()
            }).ToList(), "Value", "Text");

            var CostDropdownList = new SelectList(db.Cost.Select(item => new SelectListItem()
            {
                Text = item.Cost.ToString(),
                Value = item.Cost.ToString()
            }).ToList(), "Value", "Text");

            if (ModelState.IsValid)
            {
                db.Technology.Add(technologyViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technologyViewModel);
        }

        // GET: TechnologyViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyViewModel technologyViewModel = db.Technology.Find(id);
            if (technologyViewModel == null)
            {
                return HttpNotFound();
            }
            return View(technologyViewModel);
        }

        // POST: TechnologyViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TechId,TechnologyName")] TechnologyViewModel technologyViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technologyViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technologyViewModel);
        }

        // GET: TechnologyViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnologyViewModel technologyViewModel = db.Technology.Find(id);
            if (technologyViewModel == null)
            {
                return HttpNotFound();
            }
            return View(technologyViewModel);
        }

        // POST: TechnologyViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnologyViewModel technologyViewModel = db.Technology.Find(id);
            db.Technology.Remove(technologyViewModel);
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
