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
    public class departamentoesController : Controller
    {
        private bd_supermercadoEntities2 db = new bd_supermercadoEntities2();

        // GET: departamentoes
        public ActionResult Index()
        {
            var departamento = db.departamento.Include(d => d.pais);
            return View(departamento.ToList());
        }

        // GET: departamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamento departamento = db.departamento.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: departamentoes/Create
        public ActionResult Create()
        {
            ViewBag.Pais = new SelectList(db.pais, "ID_PAIS", "NOMBRE_PAIS");
            return View();
        }

        // POST: departamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_DEPARTAMENTO,NOMBRE_DEPARTAMENTO,ID_PAIS_DEPARTAMENTO")] departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.departamento.Add(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PAIS_DEPARTAMENTO = new SelectList(db.pais, "ID_PAIS", "NOMBRE_PAIS", departamento.ID_PAIS_DEPARTAMENTO);
            return View(departamento);
        }

        // GET: departamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamento departamento = db.departamento.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PAIS_DEPARTAMENTO = new SelectList(db.pais, "ID_PAIS", "NOMBRE_PAIS", departamento.ID_PAIS_DEPARTAMENTO);
            return View(departamento);
        }

        // POST: departamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_DEPARTAMENTO,NOMBRE_DEPARTAMENTO,ID_PAIS_DEPARTAMENTO")] departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PAIS_DEPARTAMENTO = new SelectList(db.pais, "ID_PAIS", "NOMBRE_PAIS", departamento.ID_PAIS_DEPARTAMENTO);
            return View(departamento);
        }

        // GET: departamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            departamento departamento = db.departamento.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: departamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            departamento departamento = db.departamento.Find(id);
            db.departamento.Remove(departamento);
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
