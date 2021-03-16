using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectHub.Context;
using ProjectHub.Models;

namespace ProjectHub.Controllers
{
    public class ExternalCostsController : Controller
    {
        private ProjectHubDBContext db = new ProjectHubDBContext();

        // GET: ExternalCosts
        public ActionResult Index()
        {
            var externalCosts = db.ExternalCosts.Include(e => e.ProjectActivities);
            return View(externalCosts.ToList());
        }

        // GET: ExternalCosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExternalCost externalCost = db.ExternalCosts.Find(id);
            if (externalCost == null)
            {
                return HttpNotFound();
            }
            return View(externalCost);
        }

        // GET: ExternalCosts/Create
        public ActionResult Create()
        {
            ViewBag.ProjectActivitiesID = new SelectList(db.ProjectActivities, "ID", "Name");
            return View();
        }

        // POST: ExternalCosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CostType,BudgetCost,ActualCost,Abweichungen,ProjectActivitiesID")] ExternalCost externalCost)
        {
            if (ModelState.IsValid)
            {
                db.ExternalCosts.Add(externalCost);
                db.SaveChanges();
                return RedirectToAction("Details/" + externalCost.ProjectActivitiesID, "ProjectActivities");
            }

            ViewBag.ProjectActivitiesID = new SelectList(db.ProjectActivities, "ID", "Name", externalCost.ProjectActivitiesID);
            return View(externalCost);
        }

        // GET: ExternalCosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExternalCost externalCost = db.ExternalCosts.Find(id);
            if (externalCost == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectActivitiesID = new SelectList(db.ProjectActivities, "ID", "Name", externalCost.ProjectActivitiesID);
            return View(externalCost);
        }

        // POST: ExternalCosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CostType,BudgetCost,ActualCost,Abweichungen,ProjectActivitiesID")] ExternalCost externalCost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(externalCost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + externalCost.ProjectActivitiesID, "ProjectActivities");

            }
            ViewBag.ProjectActivitiesID = new SelectList(db.ProjectActivities, "ID", "Name", externalCost.ProjectActivitiesID);
            return View(externalCost);
        }

        // GET: ExternalCosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExternalCost externalCost = db.ExternalCosts.Find(id);
            if (externalCost == null)
            {
                return HttpNotFound();
            }
            return View(externalCost);
        }

        // POST: ExternalCosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExternalCost externalCost = db.ExternalCosts.Find(id);
            db.ExternalCosts.Remove(externalCost);
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
