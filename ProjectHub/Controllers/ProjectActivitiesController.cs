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
    public class ProjectActivitiesController : Controller
    {
        private ProjectHubDBContext db = new ProjectHubDBContext();

        // GET: ProjectActivities
        public ActionResult Index()
        {
            var projectActivities = db.ProjectActivities.Include(p => p.ProjectPhase);
            return View(projectActivities.ToList());
        }

        // GET: ProjectActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectActivities projectActivities = db.ProjectActivities.Find(id);
            if (projectActivities == null)
            {
                return HttpNotFound();
            }
            return View(projectActivities);
        }

        // GET: ProjectActivities/Create
        public ActionResult Create()
        {
            ViewBag.ProjectPhaseID = new SelectList(db.ProjectPhases, "ID", "Name");
            return View();
        }

        // POST: ProjectActivities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,StartDate,EndDate,ActualStartDate,ActualEndDate,Progress,DocumentsLink,ProjectPhaseID")] ProjectActivities projectActivities)
        {
            if (ModelState.IsValid)
            {
                db.ProjectActivities.Add(projectActivities);
                db.SaveChanges();
                return RedirectToAction("Details/" + projectActivities.ProjectPhaseID, "ProjectPhases");
            }

            ViewBag.ProjectPhaseID = new SelectList(db.ProjectPhases, "ID", "Name", projectActivities.ProjectPhaseID);
            return View(projectActivities);
        }

        // GET: ProjectActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectActivities projectActivities = db.ProjectActivities.Find(id);
            if (projectActivities == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectPhaseID = new SelectList(db.ProjectPhases, "ID", "Name", projectActivities.ProjectPhaseID);
            return View(projectActivities);
        }

        // POST: ProjectActivities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,StartDate,EndDate,ActualStartDate,ActualEndDate,Progress,DocumentsLink,ProjectPhaseID")] ProjectActivities projectActivities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectActivities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details/" + projectActivities.ProjectPhaseID, "ProjectPhases");
            }
            ViewBag.ProjectPhaseID = new SelectList(db.ProjectPhases, "ID", "Name", projectActivities.ProjectPhaseID);
            return View(projectActivities);
        }

        // GET: ProjectActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectActivities projectActivities = db.ProjectActivities.Find(id);
            if (projectActivities == null)
            {
                return HttpNotFound();
            }
            return View(projectActivities);
        }

        // POST: ProjectActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectActivities projectActivities = db.ProjectActivities.Find(id);
            db.ProjectActivities.Remove(projectActivities);
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
