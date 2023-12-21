using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class SpikesController : Controller
    {
        private SPIKEEntities db = new SPIKEEntities();

        // GET: Spikes
        public ActionResult Index()
        {
            return View(db.tblSpikes.ToList());
        }

        // GET: Spikes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSpike tblSpike = db.tblSpikes.Find(id);
            if (tblSpike == null)
            {
                return HttpNotFound();
            }
            return View(tblSpike);
        }

        // GET: Spikes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spikes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age")] tblSpike tblSpike)
        {
            if (ModelState.IsValid)
            {
                db.tblSpikes.Add(tblSpike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSpike);
        }

        // GET: Spikes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSpike tblSpike = db.tblSpikes.Find(id);
            if (tblSpike == null)
            {
                return HttpNotFound();
            }
            return View(tblSpike);
        }

        // POST: Spikes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age")] tblSpike tblSpike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSpike).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSpike);
        }

        // GET: Spikes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSpike tblSpike = db.tblSpikes.Find(id);
            if (tblSpike == null)
            {
                return HttpNotFound();
            }
            return View(tblSpike);
        }

        // POST: Spikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSpike tblSpike = db.tblSpikes.Find(id);
            db.tblSpikes.Remove(tblSpike);
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
