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
    public class cargo_laboralController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: cargo_laboral
        public ActionResult Index()
        {
            return View(db.cargo_laboral.ToList());
        }

        // GET: cargo_laboral/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cargo_laboral cargo_laboral = db.cargo_laboral.Find(id);
            if (cargo_laboral == null)
            {
                return HttpNotFound();
            }
            return View(cargo_laboral);
        }

        // GET: cargo_laboral/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cargo_laboral/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CARGO_LABORAL,CARGO_LABORAL1,DESCRIPCION_CARGO_LABORAL,SALARIO_MENSUAL_CARGO_LABORAL")] cargo_laboral cargo_laboral)
        {
            if (ModelState.IsValid)
            {
                db.cargo_laboral.Add(cargo_laboral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo_laboral);
        }

        // GET: cargo_laboral/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cargo_laboral cargo_laboral = db.cargo_laboral.Find(id);
            if (cargo_laboral == null)
            {
                return HttpNotFound();
            }
            return View(cargo_laboral);
        }

        // POST: cargo_laboral/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CARGO_LABORAL,CARGO_LABORAL1,DESCRIPCION_CARGO_LABORAL,SALARIO_MENSUAL_CARGO_LABORAL")] cargo_laboral cargo_laboral)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo_laboral).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo_laboral);
        }

        // GET: cargo_laboral/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cargo_laboral cargo_laboral = db.cargo_laboral.Find(id);
            if (cargo_laboral == null)
            {
                return HttpNotFound();
            }
            return View(cargo_laboral);
        }

        // POST: cargo_laboral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cargo_laboral cargo_laboral = db.cargo_laboral.Find(id);
            db.cargo_laboral.Remove(cargo_laboral);
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
