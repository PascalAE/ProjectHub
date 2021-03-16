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
    public class MilestonesController : Controller
    {
        private ProjectHubDBContext db = new ProjectHubDBContext();

        // GET: Milestones
        public ActionResult Index()
        {
            var milestones = db.Milestones.Include(m => m.ProjectPhase);
            return View(milestones.ToList());
        }

        // GET: Milestones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Milestones milestones = db.Milestones.Find(id);
            if (milestones == null)
            {
                return HttpNotFound();
            }
            return View(milestones);
        }

        // GET: Milestones/Create
        public ActionResult Create()
        {
            ViewBag.ProjectPhaseId = new SelectList(db.ProjectPhases, "ID", "Name");
            return View();
        }

        // POST: Milestones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Date,ProjectPhaseId")] Milestones milestones)
        {
            if (ModelState.IsValid)
            {
                db.Milestones.Add(milestones);
                db.SaveChanges();
                return RedirectToAction("Details/" + milestones.ProjectPhaseId, "ProjectPhases");
            }

            ViewBag.ProjectPhaseId = new SelectList(db.ProjectPhases, "ID", "Name", milestones.ProjectPhaseId);
            return View(milestones);
        }

        // GET: Milestones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Milestones milestones = db.Milestones.Find(id);
            if (milestones == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectPhaseId = new SelectList(db.ProjectPhases, "ID", "Name", milestones.ProjectPhaseId);
            return View(milestones);
        }

        // POST: Milestones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Date,ProjectPhaseId")] Milestones milestones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(milestones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + milestones.ProjectPhaseId, "ProjectPhases");
            }
            ViewBag.ProjectPhaseId = new SelectList(db.ProjectPhases, "ID", "Name", milestones.ProjectPhaseId);
            return View(milestones);
        }

        // GET: Milestones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Milestones milestones = db.Milestones.Find(id);
            if (milestones == null)
            {
                return HttpNotFound();
            }
            return View(milestones);
        }

        // POST: Milestones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Milestones milestones = db.Milestones.Find(id);
            db.Milestones.Remove(milestones);
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
