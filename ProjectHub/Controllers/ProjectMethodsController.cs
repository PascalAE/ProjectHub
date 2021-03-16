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
    public class ProjectMethodsController : Controller
    {
        private ProjectHubDBContext db = new ProjectHubDBContext();

        // GET: ProjectMethods
        public ActionResult Index()
        {
            return View(db.ProjectMethods.ToList());
        }

        // GET: ProjectMethods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectMethod projectMethod = db.ProjectMethods.Find(id);
            if (projectMethod == null)
            {
                return HttpNotFound();
            }
            return View(projectMethod);
        }

        // GET: ProjectMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Method")] ProjectMethod projectMethod)
        {
            if (ModelState.IsValid)
            {
                db.ProjectMethods.Add(projectMethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectMethod);
        }

        // GET: ProjectMethods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectMethod projectMethod = db.ProjectMethods.Find(id);
            if (projectMethod == null)
            {
                return HttpNotFound();
            }
            return View(projectMethod);
        }

        // POST: ProjectMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Method")] ProjectMethod projectMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectMethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectMethod);
        }

        // GET: ProjectMethods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectMethod projectMethod = db.ProjectMethods.Find(id);
            if (projectMethod == null)
            {
                return HttpNotFound();
            }
            return View(projectMethod);
        }

        // POST: ProjectMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectMethod projectMethod = db.ProjectMethods.Find(id);
            db.ProjectMethods.Remove(projectMethod);
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
