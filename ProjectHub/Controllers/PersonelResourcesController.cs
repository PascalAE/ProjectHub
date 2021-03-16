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
    public class PersonelResourcesController : Controller
    {
        private ProjectHubDBContext db = new ProjectHubDBContext();

        // GET: PersonelResources
        public ActionResult Index()
        {
            return View(db.PersonelResources.ToList());
        }

        // GET: PersonelResources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelResources personelResources = db.PersonelResources.Find(id);
            if (personelResources == null)
            {
                return HttpNotFound();
            }
            return View(personelResources);
        }

        // GET: PersonelResources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonelResources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ResourceFunction,BudgetTime,ActualTime,Abweichungen,ProjectActivitesID")] PersonelResources personelResources)
        {
            if (ModelState.IsValid)
            {
                db.PersonelResources.Add(personelResources);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personelResources);
        }

        // GET: PersonelResources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelResources personelResources = db.PersonelResources.Find(id);
            if (personelResources == null)
            {
                return HttpNotFound();
            }
            return View(personelResources);
        }

        // POST: PersonelResources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ResourceFunction,BudgetTime,ActualTime,Abweichungen,ProjectActivitesID")] PersonelResources personelResources)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelResources).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personelResources);
        }

        // GET: PersonelResources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelResources personelResources = db.PersonelResources.Find(id);
            if (personelResources == null)
            {
                return HttpNotFound();
            }
            return View(personelResources);
        }

        // POST: PersonelResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelResources personelResources = db.PersonelResources.Find(id);
            db.PersonelResources.Remove(personelResources);
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
