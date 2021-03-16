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
    public class ProjectPhasesController : Controller
    {
        private ProjectHubDBContext db = new ProjectHubDBContext();

        // GET: ProjectPhases
        public ActionResult Index()
        {
            return View(db.ProjectPhases.ToList());
        }

        // GET: ProjectPhases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPhase projectPhase = db.ProjectPhases.Find(id);
            if (projectPhase == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = projectPhase.Project.ID;
            return View(projectPhase);
        }

        // GET: ProjectPhases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectPhases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,StartDate,EndDate,ActualStartDate,ActualEndDate,ReviewDate,ActualReviewDate,Status,Progress,ReleaseDate,Visum")] ProjectPhase projectPhase)
        {
            if (ModelState.IsValid)
            {
                db.ProjectPhases.Add(projectPhase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectPhase);
        }

        // GET: ProjectPhases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPhase projectPhase = db.ProjectPhases.Find(id);
            if (projectPhase == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = projectPhase.Project.ID;
            return View(projectPhase);
        }

        // POST: ProjectPhases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,StartDate,EndDate,ActualStartDate,ActualEndDate,ReviewDate,ActualReviewDate,Status,Progress,ReleaseDate,Visum,ProjectID")] ProjectPhase projectPhase)
        {

            if (ModelState.IsValid)
            {
                db.Entry(projectPhase).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details/" + projectPhase.ProjectID, "Projects");
            }
            
            return View();
        }

        // GET: ProjectPhases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectPhase projectPhase = db.ProjectPhases.Find(id);
            if (projectPhase == null)
            {
                return HttpNotFound();
            }
            return View(projectPhase);
        }

        // POST: ProjectPhases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectPhase projectPhase = db.ProjectPhases.Find(id);
            db.ProjectPhases.Remove(projectPhase);
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
