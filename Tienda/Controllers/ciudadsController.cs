using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;

namespace Tienda.Controllers
{
    public class ciudadsController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: ciudads
        public ActionResult Index()
        {
            var ciudad = db.ciudad.Include(c => c.departamento);
            return View(ciudad.ToList());
        }

        // GET: ciudads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // GET: ciudads/Create
        public ActionResult Create()
        {
            ViewBag.ID_DEPARTAMENTO_CIUDAD = new SelectList(db.departamento, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO");
            return View();
        }

        // POST: ciudads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CIUDAD,NOMBRE_CIUDAD,ID_DEPARTAMENTO_CIUDAD")] ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.ciudad.Add(ciudad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_DEPARTAMENTO_CIUDAD = new SelectList(db.departamento, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO", ciudad.ID_DEPARTAMENTO_CIUDAD);
            return View(ciudad);
        }

        // GET: ciudads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DEPARTAMENTO_CIUDAD = new SelectList(db.departamento, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO", ciudad.ID_DEPARTAMENTO_CIUDAD);
            return View(ciudad);
        }

        // POST: ciudads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CIUDAD,NOMBRE_CIUDAD,ID_DEPARTAMENTO_CIUDAD")] ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_DEPARTAMENTO_CIUDAD = new SelectList(db.departamento, "ID_DEPARTAMENTO", "NOMBRE_DEPARTAMENTO", ciudad.ID_DEPARTAMENTO_CIUDAD);
            return View(ciudad);
        }

        // GET: ciudads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ciudad ciudad = db.ciudad.Find(id);
            if (ciudad == null)
            {
                return HttpNotFound();
            }
            return View(ciudad);
        }

        // POST: ciudads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ciudad ciudad = db.ciudad.Find(id);
            db.ciudad.Remove(ciudad);
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
