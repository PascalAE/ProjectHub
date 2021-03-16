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
    public class PhasesController : Controller
    {
        private ProjectHubDBContext db = new ProjectHubDBContext();

        // GET: Phases
        public ActionResult Index()
        {
            var phases = db.Phases.Include(p => p.ProjectMethod);
            return View(phases.ToList());
        }

        // GET: Phases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phase phase = db.Phases.Find(id);
            if (phase == null)
            {
                return HttpNotFound();
            }
            return View(phase);
        }

        // GET: Phases/Create
        public ActionResult Create()
        {
            ViewBag.ProjectMethodID = new SelectList(db.ProjectMethods, "ID", "Method");
            return View();
        }

        // POST: Phases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ProjectMethodID")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                db.Phases.Add(phase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectMethodID = new SelectList(db.ProjectMethods, "ID", "Method", phase.ProjectMethodID);
            return View(phase);
        }

        // GET: Phases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phase phase = db.Phases.Find(id);
            if (phase == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectMethodID = new SelectList(db.ProjectMethods, "ID", "Method", phase.ProjectMethodID);
            return View(phase);
        }

        // POST: Phases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ProjectMethodID")] Phase phase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectMethodID = new SelectList(db.ProjectMethods, "ID", "Method", phase.ProjectMethodID);
            return View(phase);
        }

        // GET: Phases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phase phase = db.Phases.Find(id);
            if (phase == null)
            {
                return HttpNotFound();
            }
            return View(phase);
        }

        // POST: Phases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phase phase = db.Phases.Find(id);
            db.Phases.Remove(phase);
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
